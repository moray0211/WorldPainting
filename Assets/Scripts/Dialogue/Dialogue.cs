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
        public Type type;
        public ChoiceType choiceType;
        public Sprite standingCG;
        [TextArea(3, 10)]
        public string[] sentences;
 
    }

    public Sentences[] character;

}
