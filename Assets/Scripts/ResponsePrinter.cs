using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Silk;
public class ResponsePrinter : MonoBehaviour {
    //attach to container of responses
    
    public GameObject responsePrefab;
    private void Start() {
         foreach(KeyValuePair<string, SilkGraph> story in Parser.Instance.mother.MotherGraph) {
            foreach(KeyValuePair<string, SilkNode> node in story.Value.Story) {
                if(node.Value.GetNodeName() == "Start") {
                    for(int i = 0; i < node.Value.silkLinks.Count; i++) {
                        GameObject newResponse = Instantiate(responsePrefab);
                        //means this script must be attached to the parent object
                        newResponse.transform.SetParent(this.gameObject.transform);
                        newResponse.transform.localScale = new Vector3(1, 1, 1);
                        newResponse.GetComponent<Response>().responseText = node.Value.silkLinks[i].LinkText;
                        
                    }
                }
            }
        }
    }

}
