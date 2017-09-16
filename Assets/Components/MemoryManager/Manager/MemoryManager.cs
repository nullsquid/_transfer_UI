using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Transfer.Data;
public class MemoryManager : MonoBehaviour {

    public static MemoryManager instance;
    void Awake() {

        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public List<MemoryData> AMemories = new List<MemoryData>();
    public List<MemoryData> BMemories = new List<MemoryData>();
    public List<MemoryData> CMemories = new List<MemoryData>();
    public List<MemoryData> DMemories = new List<MemoryData>();
    public List<MemoryData> EMemories = new List<MemoryData>();
    public List<MemoryData> FMemories = new List<MemoryData>();
    public List<MemoryData> GMemories = new List<MemoryData>();
    public List<MemoryData> HMemories = new List<MemoryData>();
    public List<MemoryData> IMemories = new List<MemoryData>();
    public List<MemoryData> ZMemories = new List<MemoryData>();


	Dictionary<string,MemoryData> AMemDat = new Dictionary<string, MemoryData>();
	Dictionary<string,MemoryData> BMemDat = new Dictionary<string, MemoryData>();
	Dictionary<string,MemoryData> CMemDat = new Dictionary<string, MemoryData>();
	Dictionary<string,MemoryData> DMemDat = new Dictionary<string, MemoryData>();
	Dictionary<string,MemoryData> EMemDat = new Dictionary<string, MemoryData>();
	Dictionary<string,MemoryData> FMemDat = new Dictionary<string, MemoryData>();
	Dictionary<string,MemoryData> GMemDat = new Dictionary<string, MemoryData>();
	Dictionary<string,MemoryData> HMemDat = new Dictionary<string, MemoryData>();
	Dictionary<string,MemoryData> IMemDat = new Dictionary<string, MemoryData>();
	Dictionary<string,MemoryData> ZMemDat = new Dictionary<string, MemoryData>();

    private void Start() {
		for (int i = 0; i < 9; i++) {
			AMemDat.Add (AMemories [i].level, AMemories [i]);
			BMemDat.Add (BMemories [i].level, BMemories [i]);
			CMemDat.Add (CMemories [i].level, CMemories [i]);
			DMemDat.Add (DMemories [i].level, DMemories [i]);
			EMemDat.Add (EMemories [i].level, EMemories [i]);
			FMemDat.Add (FMemories [i].level, FMemories [i]);
			GMemDat.Add (GMemories [i].level, GMemories [i]);
			HMemDat.Add (HMemories [i].level, HMemories [i]);
			IMemDat.Add (IMemories [i].level, IMemories [i]);
			ZMemDat.Add (ZMemories [i].level, ZMemories [i]);
		}

    }

	public void ReturnMemory(string level){
		string player = CharacterDatabase.GetPlayerID ();
		Dictionary<string, MemoryData> memData = new Dictionary<string, MemoryData> ();
		switch (player) {
		case "A":
			memData = AMemDat;
			break;
		case "B":
			memData = BMemDat;
			break;
		case "C":
			memData = CMemDat;
			break;
		case "D":
			memData = DMemDat;
			break;
		case "E":
			memData = EMemDat;
			break;
		case "F":
			memData = FMemDat;
			break;
		case "G":
			memData = GMemDat;
			break;
		case "H":
			memData = HMemDat;
			break;
		case "I":
			memData = IMemDat;
			break;
		case "0":
			memData = ZMemDat;
			break;
		}

		if (memData [level].type == "text") {
			InvokeTextMemory(memData[level].contents);
		} else if (memData [level].type == "video") {
			InvokeVideoMemory(memData[level].contents);
		} else if (memData [level].type == "audio") {
			InvokeAudioMemory (memData [level].contents);
		}
	}

	void InvokeAudioMemory(string fileName){

	}

	void InvokeVideoMemory(string fileName){

	}

	void InvokeTextMemory(string text){

	}

}
