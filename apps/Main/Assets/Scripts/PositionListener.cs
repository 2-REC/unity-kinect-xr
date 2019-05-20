using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class PositionListener : MonoBehaviour {

    public Transform position;
    public MessageSender messageManager;

public Text text;

/*
    void Start() {
        
    }
*/

    void Update() {
        if (position.hasChanged) {
//print("sending message: " + position.position.ToString());
text.text = position.position.x + "\n" + position.position.y + "\n" + position.position.z;


var msg = new JSONClass();
msg["position"]["x"] = ((int)(position.position.x * 100)).ToString();
msg["position"]["y"] = ((int)(position.position.y * 100)).ToString();
msg["position"]["z"] = ((int)(position.position.z * 100)).ToString();

//            messageManager.SendMove(position.position.ToString());
            messageManager.SendMove(msg.ToString());
            position.hasChanged = false;
        }
    }

}
