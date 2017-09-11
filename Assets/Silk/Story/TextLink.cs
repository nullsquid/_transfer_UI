using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class TextLink  {

    private string curNodeName;
    private string linkedNodeName;
    private string linkText;



    public string CurNodeName
    {
        get
        {
            return curNodeName;
        }
        set
        {
            curNodeName = value;
        }
    }

    public string LinkedNodeName
    {
        get
        {
            return linkedNodeName;
        }
        set
        {
            linkedNodeName = value;
        }
    }

    public string LinkText
    {
        get
        {
            return linkText;
        }
        set
        {
            linkText = value;
        }
    }
}
