using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Transfer.Data;
using Transfer.System;

public class BuddyListController : MonoBehaviour {

    public GameObject connectableName;
    public GameObject mainStoryName;


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            //PopulateBuddyList();
        }
    }

    public void StartPopulate() {
        StartCoroutine(WaitAndPopulateBuddies());
    }
    private void PopulateBuddyList() {
        ClearBuddyList();
        int numOfOthers = Random.Range(0, CharacterDatabase.GetCharacterCount());
        int numOfMainStory = Random.Range(0, numOfOthers);
        List<string> otherNames = new List<string>();
        foreach (KeyValuePair<string, Character> character in CharacterDatabase.CharacterDictionary) {
            if (character.Value.Identifier != CharacterManager.instance.GetPlayerID() && character.Value.Name != DialogueManager.instance.connectID) {
                //newName.GetComponent<Text>().text = "FU
                otherNames.Add(character.Value.Name);
            }
        }
        for (int i = 0; i < numOfOthers; i++) {
            if (i == numOfMainStory) {
                GameObject newMainName = Instantiate(mainStoryName);
                newMainName.transform.SetParent(gameObject.transform);
                newMainName.transform.localScale = (new Vector3(1, 1, 1));
                newMainName.GetComponent<Text>().text = DialogueManager.instance.connectID;
            }
            else {
                int nameIndex = Random.Range(0, otherNames.Count);
                GameObject newName = Instantiate(connectableName);
                newName.transform.SetParent(gameObject.transform);
                newName.transform.localScale = (new Vector3(1, 1, 1));

                newName.GetComponent<Text>().text = otherNames[nameIndex];
                otherNames.RemoveAt(nameIndex);
            }
        }

    }

    IEnumerator WaitAndPopulateBuddies() {
        yield return new WaitForEndOfFrame();
        PopulateBuddyList();
    }

    void ClearBuddyList() {
        foreach(Transform child in this.transform) {
            Destroy(child.gameObject);
        }
    }
}
