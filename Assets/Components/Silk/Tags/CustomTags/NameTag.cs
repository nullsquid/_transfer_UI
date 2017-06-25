using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class NameTag : SilkTagBase {

    public NameTag(string tagName, string[] args) {
        DefineArguments(args);
        _tagName = tagName;

    }

    public override void SilkTagDefinition() {
        

    }

    public void ReplaceTagWithName() {

    }
    
}
