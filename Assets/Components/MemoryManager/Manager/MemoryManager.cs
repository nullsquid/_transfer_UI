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

	Dictionary<string,MemoryData> allMemoriesForRun = new Dictionary<string, MemoryData> ();
	List <MemoryData> unlockedMemories = new List<MemoryData>();
    private void Start() {
		string player = CharacterDatabase.GetPlayerID ();
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
		switch (player) {
		case "A":
			allMemoriesForRun = AMemDat;
			break;
		case "B":
			allMemoriesForRun = BMemDat;
			break;
		case "C":
			allMemoriesForRun = CMemDat;
			break;
		case "D":
			allMemoriesForRun = DMemDat;
			break;
		case "E":
			allMemoriesForRun = EMemDat;
			break;
		case "F":
			allMemoriesForRun = FMemDat;
			break;
		case "G":
			allMemoriesForRun = GMemDat;
			break;
		case "H":
			allMemoriesForRun = HMemDat;
			break;
		case "I":
			allMemoriesForRun = IMemDat;
			break;
		case "0":
			allMemoriesForRun = ZMemDat;
			break;
		}



    }

	public void UnlockMemory(string level){
		unlockedMemories.Add (allMemoriesForRun [level]);
		InvokeUnlockSequence ();

	}

	public void ReturnMemory(string level){

		if (allMemoriesForRun [level].type == "text") {
			InvokeTextMemory(allMemoriesForRun[level].contents);
		} else if (allMemoriesForRun [level].type == "video") {
			InvokeVideoMemory(allMemoriesForRun[level].contents);
		} else if (allMemoriesForRun [level].type == "audio") {
			InvokeAudioMemory (allMemoriesForRun [level].contents);
		}
	}

	void InvokeAudioMemory(string fileName){

	}

	void InvokeVideoMemory(string fileName){

	}

	void InvokeTextMemory(string text){

	}
	void InvokeUnlockSequence(){

	}

}
