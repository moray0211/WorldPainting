using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewDialogue", menuName = "Custom/Dialogue")]
[System.Serializable]
public class Dialogue : ScriptableObject
{
    public string D_id;

    public enum Type
    {
        narration,
        magenta,
        cyan,
        yellow,
        black,
        etc,
        choice,
    }

    public enum ChoiceType
    {
        DEFAULT_NONE,
        choiceAnswer1,
        choiceAnswer2,
        choiceAnswer3
    }

    public enum EmotionType
    {
        idle,
        sad,
        littleSad,
        angry,
        embrassed,
        littleEmbrassed,
        smile
    };

    [System.Serializable]
    public class ChoiceOption
    {
        public string optionstr; //선택지 고를 때 버튼에 나올 내용
        public Sentences[] optionsentences; //선택지 고른 후 나올 내용
    }

    //[CreateAssetMenu(fileName = "NewSentences", menuName = "Custom/Sentences")]

    [System.Serializable]
    public class Sentences
    {
        public Type type; //어떤 인물의 대사인지Or선택지인지
        public EmotionType emotionType; //어떤 표정인지
        public ChoiceType choiceType; //선택지 1,2,3 (기본은 선택지 아님)
        public List<ChoiceOption> choices; //선택지에 따라 출력될 내용
        public Sprite standingCG; //스탠딩 CG
        public AudioClip audioClip; //실행될 SE
        [TextArea(2, 10)]
        public string[] sentences;
    }

    public Sentences[] character;

}
