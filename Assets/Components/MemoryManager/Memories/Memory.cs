using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Transfer.Data;
enum MemType{
	TEXT,
	VIDEO,
	AUDIO
}
public class Memory  {
	public string textValue;
	public string videoName;
	public string audioName;
	//
	string playerCharacterID;
	MemType mType;
	public Memory(string memType){
		switch (memType) {
		case "text":
			mType = MemType.TEXT;
			break;
		case "video":
			mType = MemType.VIDEO;
			break;
		case "audio":
			mType = MemType.AUDIO;
			break;
		}

		playerCharacterID = CharacterDatabase.GetPlayerID ();

	}

	
}
