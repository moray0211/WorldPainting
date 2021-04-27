using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
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

    [System.Serializable]
    public class Sentences
    {
        public Type type; //어떤 인물의 대사인지Or선택지인지
        public ChoiceType choiceType; //선택지 1,2,3 (기본은 선택지 아님)
        public Sprite standingCG; //스탠딩 CG
        public AudioClip audioClip; //실행될 SE
        [TextArea(3, 10)]
        public string[] sentences;
 
    }

    public Sentences[] character;

}
