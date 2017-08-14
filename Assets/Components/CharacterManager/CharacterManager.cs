using UnityEngine;
using System.Collections;
using Transfer.Data;
namespace Transfer.System {
    public class CharacterManager : MonoBehaviour {
        public static CharacterManager instance;
        private CharacterInitializer charInit;
        private CharacterBlacklist blacklist;
        void Awake() {
            if (instance == null) {
                instance = this;
            }
            else if (instance != this) {
                Destroy(gameObject);
            }
            if (charInit == null) {
                charInit = new CharacterInitializer();
            }

            DontDestroyOnLoad(gameObject);
            blacklist = GameObject.FindObjectOfType<CharacterBlacklist>();
            InitializeCharacters();
        }

        void InitializeCharacters() {
            blacklist.InitializeNameBlacklist();
            charInit.PopulateCharacterDatabase(true);

        }
        void LogCharacters() {

            Debug.Log(CharacterDatabase.GetCharacterID("A") + " " + CharacterDatabase.GetCharacterName("A"));
            Debug.Log(CharacterDatabase.GetCharacterID("B") + " " + CharacterDatabase.GetCharacterName("B"));
            Debug.Log(CharacterDatabase.GetCharacterID("C") + " " + CharacterDatabase.GetCharacterName("C"));
            Debug.Log(CharacterDatabase.GetCharacterID("D") + " " + CharacterDatabase.GetCharacterName("D"));
            Debug.Log(CharacterDatabase.GetCharacterID("E") + " " + CharacterDatabase.GetCharacterName("E"));
            Debug.Log(CharacterDatabase.GetCharacterID("F") + " " + CharacterDatabase.GetCharacterName("F"));
            Debug.Log(CharacterDatabase.GetCharacterID("G") + " " + CharacterDatabase.GetCharacterName("G"));
            Debug.Log(CharacterDatabase.GetCharacterID("H") + " " + CharacterDatabase.GetCharacterName("H"));
            Debug.Log(CharacterDatabase.GetCharacterID("I") + " " + CharacterDatabase.GetCharacterName("I"));
            Debug.Log(CharacterDatabase.GetCharacterID("0") + " " + CharacterDatabase.GetCharacterName("0"));

        }
        public string GetPlayerID() {
            return CharacterDatabase.GetPlayerID().Trim();
        }
		public string GetCharacterNameByID(string id){
			return CharacterDatabase.GetCharacterName (id);
		}

		public string GetCharacterPronounByID(string id, string tense){
			Transfer.Data.Case _case = new Case();
			if (tense == "subject") {
				_case = Case.subjective;
			} else if (tense == "object") {
				_case = Case.objective;
			} else if (tense == "possess") {
				_case = Case.possessive;
			}
			return CharacterDatabase.GetPronoun (id, _case);
		}
    }

}