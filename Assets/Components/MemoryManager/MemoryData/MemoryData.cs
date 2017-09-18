using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryData : ScriptableObject {

    public string ID;
    public string level;
    public string type;
	public string linkedFileName;
	public string memFileName;
    public string contents;
	public bool hasBeenAccessed = false;
}
