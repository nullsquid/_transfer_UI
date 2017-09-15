using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Transfer.Data;

namespace Transfer.System {
    public class CharacterInitializer {

        private CharacterBlacklist blacklist;
        private string playerID;
        private List<string> characterIDs = new List<string>();
        private List<string> shortCharacterIDs = new List<string>();

        private List<string> firstCharacterIDs = new List<string>();
        private List<string> secondCharacterIDs = new List<string>();
        private List<string> playedCharacterIDs = new List<string>();
        //name generation collections
        private string[] nameBits = { "A", "B", "C", "D", "E", "F",
            "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q",
            "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private List<string> vowels = new List<string>();
        private List<string> consonants = new List<string>();
        private List<string> names = new List<string>();

        void AddCharacterIdentifiers() {
            characterIDs.Add("A");
            characterIDs.Add("B");
            characterIDs.Add("C");
            characterIDs.Add("D");
            characterIDs.Add("E");
            characterIDs.Add("F");
            characterIDs.Add("G");
            characterIDs.Add("H");
            characterIDs.Add("I");
            characterIDs.Add("0");
            /////
            /// 
            ///
            shortCharacterIDs.Add("A");
            shortCharacterIDs.Add("E");
            shortCharacterIDs.Add("I");
            shortCharacterIDs.Add("0");
            /////
            ///
            //first half characters
            /*
            firstCharacterIDs.Add("A");
            firstCharacterIDs.Add("E");
            firstCharacterIDs.Add("I");
            firstCharacterIDs.Add("0");
            //second half characters
            secondCharacterIDs.Add("B");
            secondCharacterIDs.Add("C");
            secondCharacterIDs.Add("D");
            secondCharacterIDs.Add("F");
            secondCharacterIDs.Add("G");
            secondCharacterIDs.Add("H");
            */
            //try this?
            /*
            PlayerPrefs.SetString("A", "false");
            PlayerPrefs.SetString("E", "false");
            PlayerPrefs.SetString("I", "false");
            PlayerPrefs.SetString("0", "false");
            ///////
            PlayerPrefs.SetString("B", "false");
            PlayerPrefs.SetString("C", "false");
            PlayerPrefs.SetString("D", "false");
            PlayerPrefs.SetString("F", "false");
            PlayerPrefs.SetString("G", "false");
            PlayerPrefs.SetString("H", "false");
            */

        }

        void Update() {
            //remove after testing
            if (UnityEngine.Input.GetKeyDown(KeyCode.Tab)) {
                PlayerPrefs.DeleteAll();
                Debug.LogWarning("All data deleted");
            }
        }

        string GeneratePlayerID(bool useShortCharacters) {
            firstCharacterIDs.Clear();
            secondCharacterIDs.Clear();
            if (useShortCharacters) {

                playerID = shortCharacterIDs[Random.Range(0, shortCharacterIDs.Count)];
            }
            
            else{
                if (PlayerPrefs.HasKey("AllBeginningsPlayed")){
                    if (bool.Parse(PlayerPrefs.GetString("AllBeginningsPlayed")) == false) {

                        //for testing/////////
                        /*
                        PlayerPrefs.SetString("A", "true");
                        PlayerPrefs.SetString("E", "true");
                        PlayerPrefs.SetString("I", "true");
                        PlayerPrefs.SetString("0", "true");
                        */
                        //////////////////////
                        #region Find and Add IDs
                        if (PlayerPrefs.HasKey("A")) {
                            if (bool.Parse(PlayerPrefs.GetString("A")) == false) {
                                firstCharacterIDs.Add("A");
                            }
                        }
                        else {
                            PlayerPrefs.SetString("A", "false");
                            if (!firstCharacterIDs.Contains("A")) {
                                firstCharacterIDs.Add("A");
                            }
                        }
                        if (PlayerPrefs.HasKey("B")) {
                            if (bool.Parse(PlayerPrefs.GetString("B")) == false) {
                                secondCharacterIDs.Add("B");
                            }
                        }
                        else {
                            PlayerPrefs.SetString("B", "false");
                            if (!secondCharacterIDs.Contains("B")) {
                                secondCharacterIDs.Add("B");
                            }
                        }
                        if (PlayerPrefs.HasKey("C")){
                            if (bool.Parse(PlayerPrefs.GetString("C")) == false) {
                                secondCharacterIDs.Add("C");
                            }
                        }
                        else {
                            PlayerPrefs.SetString("C", "false");
                            if (!secondCharacterIDs.Contains("C")) {
                                secondCharacterIDs.Add("C");
                            }
                        }
                        if (PlayerPrefs.HasKey("D")) {
                            if (bool.Parse(PlayerPrefs.GetString("D")) == false) {
                                secondCharacterIDs.Add("D");
                            }
                        }
                        else {
                            PlayerPrefs.SetString("D", "false");
                            if (!secondCharacterIDs.Contains("D")) {
                                secondCharacterIDs.Add("D");
                            }

                        }
                        if (PlayerPrefs.HasKey("E")) {
                            if (bool.Parse(PlayerPrefs.GetString("E")) == false) {
                                firstCharacterIDs.Add("E");
                            }
                        }
                        else {
                            PlayerPrefs.SetString("E", "false");
                            if (!firstCharacterIDs.Contains("E")) {
                                firstCharacterIDs.Add("E");
                            }
                        }
                        if (PlayerPrefs.HasKey("F")) {
                            if (bool.Parse(PlayerPrefs.GetString("F")) == false) {
                                secondCharacterIDs.Add("F");
                            }
                        }
                        else {
                            PlayerPrefs.SetString("F", "false");
                            if (!secondCharacterIDs.Contains("F")) {
                                secondCharacterIDs.Add("F");
                            }
                        }
                        if (PlayerPrefs.HasKey("G")) {
                            if (bool.Parse(PlayerPrefs.GetString("G")) == false) {
                                secondCharacterIDs.Add("G");
                            }
                        }
                        else {
                            PlayerPrefs.SetString("G", "false");
                            if (!secondCharacterIDs.Contains("G")) {
                                secondCharacterIDs.Add("G");
                            }
                        }
                        if (PlayerPrefs.HasKey("H")) {
                            if (bool.Parse(PlayerPrefs.GetString("H")) == false) {
                                secondCharacterIDs.Add("H");
                            }
                        }
                        else {
                            PlayerPrefs.SetString("H", "false");
                            if (!secondCharacterIDs.Contains("H")) {
                                secondCharacterIDs.Add("H");
                            }
                        }
                        if (PlayerPrefs.HasKey("I")) {
                            if (bool.Parse(PlayerPrefs.GetString("I")) == false) {
                                firstCharacterIDs.Add("I");
                            }
                        }
                        else {
                            PlayerPrefs.SetString("I", "false");
                            if (!firstCharacterIDs.Contains("I")) {
                                firstCharacterIDs.Add("I");
                            }
                        }
                        if (PlayerPrefs.HasKey("0")) {
                            if (bool.Parse(PlayerPrefs.GetString("0")) == false) {
                                firstCharacterIDs.Add("0");
                            }
                        }
                        else {
                            PlayerPrefs.SetString("0", "false");
                            if (!firstCharacterIDs.Contains("0")) {
                                firstCharacterIDs.Add("0");
                            }
                        }
                        #endregion
                        #region Check Section and Generate Player
                        if (PlayerPrefs.HasKey("FirstSectionComplete") && PlayerPrefs.HasKey("SecondSectionComplete")) {
                            if(bool.Parse(PlayerPrefs.GetString("FirstSectionComplete")) == false) {
                                if (firstCharacterIDs.Count > 0) {
                                    string testID = firstCharacterIDs[Random.Range(0, firstCharacterIDs.Count)];
                                    playerID = testID;
                                }
                                else {
                                    PlayerPrefs.SetString("FirstSectionComplete", "true");
                                    return GeneratePlayerID(false);
                                }
                            }
                            else if(bool.Parse(PlayerPrefs.GetString("FirstSectionComplete")) == true && bool.Parse(PlayerPrefs.GetString("SecondSectionComplete")) == false) {
                                if(secondCharacterIDs.Count > 0) {
                                    string testID = secondCharacterIDs[Random.Range(0, secondCharacterIDs.Count)];
                                    playerID = testID;
                                }
                                else {
                                    PlayerPrefs.SetString("SecondSectionComplete", "true");
                                    return GeneratePlayerID(false);
                                }
                            }
                            else if(bool.Parse(PlayerPrefs.GetString("FirstSectionComplete")) == true && bool.Parse(PlayerPrefs.GetString("SecondSectionComplete")) == false) {
                                PlayerPrefs.SetString("AllBeginningsPlayed", "true");
                                return GeneratePlayerID(false);
                            }
                        }
                        else {
                            PlayerPrefs.SetString("FirstSectionComplete", "false");
                            PlayerPrefs.SetString("SecondSectionComplete", "false");
                            return GeneratePlayerID(false);
                        }
                        
                        #endregion



                    }
                    else {
						playerID = characterIDs [Random.Range (0, characterIDs.Count)];
                    }

                }
                else{
                    PlayerPrefs.SetString("AllBeginningsPlayed", "false");
					return GeneratePlayerID (false);
                }
            }
            return playerID;
            

        }
        //make independent loops for both PC and NPC object lists
        //might not need to return anything?
        void GeneratePlayerCharacter(string playerID, string playerName, Gender playerGender) {

            Transfer.Data.PlayerCharacter newPlayer = new Transfer.Data.PlayerCharacter(playerID, playerName, playerGender);
            CharacterDatabase.AddCharacter(newPlayer);
            for (int i = 0; i < characterIDs.Count; i++) {
                if (characterIDs[i] == playerID) {
                    characterIDs.Remove(characterIDs[i]);
                }
            }


        }

        void GenerateCharacters(Gender charGender) {
            Data.NonPlayerCharacter newCharacter;
            for (int i = 0; i < characterIDs.Count; i++) {
                newCharacter = new Data.NonPlayerCharacter(characterIDs[i], GenerateName(), charGender);
                CharacterDatabase.AddCharacter(newCharacter);
            }
        }



        Data.Gender SetRandomCharacterGender() {
            Gender gender = (Gender)Random.Range(0, 3);
            return gender;
        }



        public void PopulateCharacterDatabase(bool useShortCharacters) {

            CharacterDatabase.CharacterDictionary.Clear();
            AddCharacterIdentifiers();
            playerID = GeneratePlayerID(useShortCharacters);
            GeneratePlayerCharacter(playerID, GenerateName(), SetRandomCharacterGender());
            GenerateCharacters(SetRandomCharacterGender());
            //for testing
            for (int i = 0; i < firstCharacterIDs.Count; i++) {
                Debug.Log(firstCharacterIDs[i]);
            }

            /*
			for(int i = 0; i < characterIDs.Count; i++)
            {
				string newID = characterIDs[Random.Range(0, characterIDs.Count)];
				Debug.Log ("new id is " + newID);
                Data.Character newCharacter;
                if (newID == playerID)
                {
					newCharacter = GeneratePlayerCharacter(playerID, "MEMM", SetRandomCharacterGender());
                    CharacterDatabase.AddCharacter(newCharacter);
                                        return newCharacter;
                }
                else
                {
                    //newCharacter = GenerateCharacter(characterIDs[i], "MEMM", SetRandomCharacterGender());
                    //CharacterDatabase.AddCharacter(newCharacter);
                    //return GenerateCharacter(characterIDs[i], "name " + characterIDs[i], Gender.Masculine);
                }

            }
            return null;
            */
        }

        ////////////////////////////////

        
        string GenerateName() {
            blacklist = GameObject.FindObjectOfType<CharacterBlacklist>();
            for (int i = 0; i < nameBits.Length; i++) {
                if (nameBits[i] == "A" || nameBits[i] == "E" || nameBits[i] == "I" || nameBits[i] == "O" || nameBits[i] == "U") {
                    vowels.Add(nameBits[i]);
                }
                else {
                    consonants.Add(nameBits[i]);
                }
            }
            
            string newName;
            string testName;
            testName = consonants[Random.Range(0, consonants.Count)] + vowels[Random.Range(0, vowels.Count)] + consonants[Random.Range(0, consonants.Count)] + consonants[Random.Range(0, consonants.Count)].ToUpper();
            if (names.Contains("MEMM")) {
                Debug.Log("It's MEMM!");
            }
            if (names.Contains(testName)) {
                Debug.LogError("retry");
                return GenerateName();

            }
            else if (blacklist.nameBlacklist.Contains(testName)) {
                Debug.LogError("cannot contain " + testName);
                return GenerateName();
            }
            else {
                newName = testName;
                names.Add(newName);
                return newName;
            }
            
            return null;
        }



    }
}
