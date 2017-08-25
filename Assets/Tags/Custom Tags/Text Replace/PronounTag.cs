﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
using Transfer.System;
public class PronounTag : SilkTagBase {

    public PronounTag(string name, List<string> args){
        //arg 0 is name
        //arg 1 is tense
        type = TagType.INLINE;
        TagName = name;
        string _appendedWord;
        if(args.Count == 3) {
            //mostly for dealing with edge cases
            switch (args[2]) {
                case ("has"):
                    if(CharacterManager.instance.GetCharacterPronounByID(args[0], args[1]) == "they") {
                        _appendedWord = "have";
                    }
                    else {
                        _appendedWord = "has";
                    }
                    break;
                default:
                    _appendedWord = "";
                    break;
            }
    
        }
        if (args[1] == "tense") {
            Value = "PRONOUN TENSE ERROR";
        }
        else {
            Value = CharacterManager.instance.GetCharacterPronounByID(args[0], args[1]);
        }
	}
}
