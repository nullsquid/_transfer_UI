using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Silk {
    public class Importer : MonoBehaviour
    {
        public bool useFullText;
        public TextAsset[] rawTweeFiles;
        // Use this for initialization
        void OnEnable()
        {
            if (useFullText == true) {
                rawTweeFiles = Resources.LoadAll<TextAsset>("Text/FullText");
            }
            else {
                rawTweeFiles = Resources.LoadAll<TextAsset>("Text/Test");
            }
            
        }
    }
}
