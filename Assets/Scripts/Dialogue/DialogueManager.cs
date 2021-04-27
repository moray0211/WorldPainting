using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public GameObject DialoguePanel;
    public Sprite narration_box;
    public Sprite magenta_box;
    public Sprite cyan_box;
    public Sprite yellow_box;
    public Sprite black_box;
    public Sprite none_box;

    public GameObject choicePanel1;
    public GameObject choicePanel2;
    public GameObject choicePanel3;
    public Text dialgoueText;
    public Image standigCGImage;
    public float typingSpeed;
    public AudioSource typingSound;

    struct Types //Dialogue.cs의 Sentences클래스와 동일한 구성
    {
        public Dialogue.Type type;
        public Dialogue.ChoiceType choiceType;
        public Sprite standingCG;
        public AudioClip audioClip;
    }

    Queue<KeyValuePair<string, Types>> sentences;

    public bool inConversation = false;
    bool isChoice = false;
    bool wait = false;
    bool inTyping = false;

    //몇번째 선택지를 선택했는가
    bool selectChoiceAnswer1 = false;
    bool selectChoiceAnswer2 = false;
    bool selectChoiceAnswer3 = false;

    string currentText;
    IEnumerator corutine;

    Button[] buttons;
    ItemPickup[] itemPickups;

    void Start()
    {
        dialogueCanvas.SetActive(false);
        choicePanel1.SetActive(false);
        choicePanel2.SetActive(false);
        choicePanel3.SetActive(false);
        sentences = new Queue<KeyValuePair<string, Types>>();

        if (GameObject.Find("ItemsParent") != null)
        { buttons = GameObject.Find("ItemsParent").GetComponentsInChildren<Button>(); }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && inConversation && !isChoice)
        {
            if (inTyping)
            {
                typingSound.Stop();
                StopCoroutine(corutine);
                dialgoueText.text = currentText;
                inTyping = false;
                return;
            }
            DisplayNextSentence();
        }

        //대화중일시 인벤토리 사용 불능
        if(buttons != null)
        {
            if (inConversation || isChoice)
            {
                itemPickups = GameObject.FindObjectsOfType<ItemPickup>();
                for (int i = 0; i < buttons.Length; i++) buttons[i].enabled = false;
                for (int i = 0; i < itemPickups.Length; i++) itemPickups[i].enabled = false;
            }
        }
        

    }

    Switch onSwitchAfterDlg;
    //대화 시작시 호출
    public void StartDialogue (Dialogue dialogue, Switch onSwitchAfterDlg)
    {
        //이미 대화를 하고 있는 경우가 아니라면
        if (!inConversation)
        {
            //대사가 끝난 뒤 on될 스위치 설정
            if (onSwitchAfterDlg != null) this.onSwitchAfterDlg = onSwitchAfterDlg;
            //대사 시작 전 초기화
            sentences.Clear();

            //대사 전부 등록
            for (int i = 0; i < dialogue.character.Length; i++)
            {
                for (int j = 0; j < dialogue.character[i].sentences.Length; j++)
                {
                    Types tmp;
                    tmp.type = dialogue.character[i].type;
                    tmp.choiceType = dialogue.character[i].choiceType;
                    tmp.standingCG = dialogue.character[i].standingCG;
                    tmp.audioClip = dialogue.character[i].audioClip;

                    sentences.Enqueue(new KeyValuePair<string, Types>
                        (dialogue.character[i].sentences[j], tmp));
                }
            }

            //대사 시작
            inConversation = true;

        }

    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            EndConversation();
            return;
        }

        //타이핑중이 아니라면
        if (!inTyping)
        {
            //대화 정보 수집
            string sentence = sentences.Peek().Key; //다음 대화 꺼내오기

            Dialogue.ChoiceType choiceType = sentences.Peek().Value.choiceType;
            Dialogue.Type type = sentences.Peek().Value.type;
            AudioClip audioClip = sentences.Peek().Value.audioClip;

            //캐릭터별 대화창 설정
            if (type == Dialogue.Type.narration) DialoguePanel.GetComponent<Image>().sprite = narration_box;
            if (type == Dialogue.Type.magenta) DialoguePanel.GetComponent<Image>().sprite = magenta_box;
            if (type == Dialogue.Type.cyan) DialoguePanel.GetComponent<Image>().sprite = cyan_box;
            if (type == Dialogue.Type.yellow) DialoguePanel.GetComponent<Image>().sprite = yellow_box;
            if (type == Dialogue.Type.black) DialoguePanel.GetComponent<Image>().sprite = black_box;
            if (type == Dialogue.Type.etc) DialoguePanel.GetComponent<Image>().sprite = none_box;


            Sprite standingCG = sentences.Peek().Value.standingCG;

            if(standingCG != null)
            {
                standigCGImage.sprite = standingCG;
            }
            else
            {
                standigCGImage.sprite = null;
            }

            sentences.Dequeue();

            #region ifChoice
            if (type == Dialogue.Type.choice) //선택지일 경우
            {
                isChoice = true;
                Queue<string> choices = new Queue<string>();
                choices.Enqueue(sentence);

                //선택지 텍스트 설정
                choicePanel1.SetActive(true);
                choicePanel1.GetComponentInChildren<Text>().text = choices.Dequeue();

                //2,3번째 선택지 확인
                while (true)
                {
                    if (sentences.Count <= 0 || (sentences.Peek().Value.type != Dialogue.Type.choice)) break;
                    else choices.Enqueue(sentences.Dequeue().Key);
                }
                if (choices.Count <= 2){
                    choicePanel2.SetActive(true);
                    choicePanel2.GetComponentInChildren<Text>().text = choices.Dequeue();

                    if (choices.Count == 1)
                    {
                        choicePanel3.SetActive(true);
                        choicePanel3.GetComponentInChildren<Text>().text = choices.Dequeue();
                    }
                }
                
                return;

            }
            #endregion
            #region ifChoiceAnswer
            else if (choiceType != Dialogue.ChoiceType.DEFAULT_NONE) //선택지에 대한 답이라면
            {
                if (selectChoiceAnswer1) //선택1
                {
                    if (choiceType != Dialogue.ChoiceType.choiceAnswer1)
                    {
                        while (sentences.Peek().Value.choiceType != Dialogue.ChoiceType.DEFAULT_NONE)
                        {
                            if(sentences.Count == 1)
                            {
                                EndConversation();
                                return;
                            }
                            type = sentences.Peek().Value.type;
                            sentences.Dequeue();
                            if (sentences.Count == 0) break;
                        }
                        selectChoiceAnswer1 = false;
                        if (sentences.Count != 0) {
                            type = sentences.Peek().Value.type;
                            sentence = sentences.Dequeue().Key;
                        }
                        
                        

                    }
                    
                }
                else if (selectChoiceAnswer2) //선택2
                {
                    if(choiceType == Dialogue.ChoiceType.DEFAULT_NONE)
                    {
                        selectChoiceAnswer2 = false;
                    }
                    else if(choiceType == Dialogue.ChoiceType.choiceAnswer1)
                    {
                        while (sentences.Peek().Value.choiceType != Dialogue.ChoiceType.choiceAnswer2)
                        {
                            type = sentences.Peek().Value.type;
                            sentences.Dequeue();
                            if (sentences.Count == 0) break;
                        }
                        if (sentences.Count != 0) {
                            type = sentences.Peek().Value.type;
                            sentence = sentences.Dequeue().Key;
                             }
                    }
                    else if (choiceType == Dialogue.ChoiceType.choiceAnswer3)
                    {
                        while (sentences.Peek().Value.choiceType != Dialogue.ChoiceType.DEFAULT_NONE)
                        {
                            if(sentences.Count == 1)
                            {
                                EndConversation();
                                return;
                            }
                            type = sentences.Peek().Value.type;
                            sentences.Dequeue();
                            if (sentences.Count == 0) break;
                        }
                        selectChoiceAnswer2 = false;
                        if (sentences.Count != 0)
                        {
                            type = sentences.Peek().Value.type;
                            sentence = sentences.Dequeue().Key;
                        }
                    }

                }else if (selectChoiceAnswer3) //선택3
                {
                    if(choiceType == Dialogue.ChoiceType.DEFAULT_NONE)
                    {
                        selectChoiceAnswer3 = false;
                    }
                    else if (choiceType != Dialogue.ChoiceType.choiceAnswer3)
                    {
                        while (sentences.Peek().Value.choiceType != Dialogue.ChoiceType.choiceAnswer3)
                        {
                            sentences.Dequeue();
                        }
                        sentence = sentences.Dequeue().Key;

                    }

                }else
                {
                    while (sentences.Peek().Value.choiceType == Dialogue.ChoiceType.DEFAULT_NONE)
                    {
                        sentences.Dequeue();
                    }
                    sentence = sentences.Dequeue().Key;
                }
            }

            #endregion

            //일반 대화일 경우
            //대화 진행

            //SE 재생
            if(audioClip != null) GameObject.Find("SEManager").GetComponent<SEManager>().playAudioClip(audioClip);
            //대화창 설정
            if (type == Dialogue.Type.narration) DialoguePanel.GetComponent<Image>().sprite = narration_box;
            if (type == Dialogue.Type.magenta) DialoguePanel.GetComponent<Image>().sprite = magenta_box;
            if (type == Dialogue.Type.cyan) DialoguePanel.GetComponent<Image>().sprite = cyan_box;
            if (type == Dialogue.Type.yellow) DialoguePanel.GetComponent<Image>().sprite = yellow_box;
            if (type == Dialogue.Type.black) DialoguePanel.GetComponent<Image>().sprite = black_box;
            if (type == Dialogue.Type.etc) DialoguePanel.GetComponent<Image>().sprite = none_box;
            dialgoueText.text = "";
            currentText = sentence;
            corutine = Type(sentence);
            StartCoroutine(corutine);
            
        }
        
    }
    
    public void EndConversation()
    {
        Debug.Log("End conversation");
        if(sentences.Count != 0) sentences.Dequeue();
        dialogueCanvas.SetActive(false); //대화창 퇴장
        inConversation = false;
        wait = true;

        //인벤토리 활성화
        if(buttons != null)
        {
            for (int i = 0; i < buttons.Length; i++) buttons[i].enabled = true;
            for (int i = 0; i < itemPickups.Length; i++) itemPickups[i].enabled = true;
        }
        //대사 종료후 스위치 on
        if(onSwitchAfterDlg != null)
        {
            onSwitchAfterDlg.setSwitchActive(true);
        }

    }

    //타이핑 효과
    IEnumerator Type(string sentence)
    {
        inTyping = true;
        typingSound.Play();
        foreach(char letter in sentence.ToCharArray())
        {
            dialgoueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        inTyping = false;
        typingSound.Stop();
    }
    
    //wait값의 참거짓을 반환하는 함수
    public bool getWait()
    {
        return wait;
    }

    public void setWaitFalse()
    {
        wait = false;
    }

    public void setSelectChoiceAnswer1()
    {
        selectChoiceAnswer1 = true;
        selectChoiceAnswer2 = false;
        selectChoiceAnswer3 = false;
        choicePanel1.SetActive(false);
        choicePanel2.SetActive(false);
        choicePanel3.SetActive(false);
        isChoice = false;
        DisplayNextSentence();
    }

    public void setSelectChoiceAnswer2()
    {
        selectChoiceAnswer1 = false;
        selectChoiceAnswer2 = true;
        selectChoiceAnswer3 = false;
        choicePanel1.SetActive(false);
        choicePanel2.SetActive(false);
        choicePanel3.SetActive(false);
        isChoice = false;
        DisplayNextSentence();
    }

    public void setSelectChoiceAnswer3()
    {
        selectChoiceAnswer1 = false;
        selectChoiceAnswer2 = false;
        selectChoiceAnswer3 = true;
        choicePanel1.SetActive(false);
        choicePanel2.SetActive(false);
        choicePanel3.SetActive(false);
        isChoice = false;
        DisplayNextSentence();
    }
}
