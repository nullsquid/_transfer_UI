﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class PromptTag : SilkTagBase {
    public PromptTag(string name) {
        TagName = name;
        type = TagType.SEQUENCED;

    }

}
