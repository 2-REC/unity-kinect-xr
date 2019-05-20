using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class MessageReceiverImpl : MessageReceiver {

//    public Text text;
    public Transform position;


    override public void Receive(SpacebrewClient.SpacebrewMessage message) {
/*
        print("RECEIVED MESSAGE");
        print("clientName: " + message.clientName);
        print("name: " + message.name);
        print("type: " + message.type);
        print("value: " + message.value);
*/
//        text.text = message.value;


        if (message.type == "string") {
            ProcessMessage(message.value);
        }
    }

    public void ProcessMessage(string message) {
        var msg = JSONNode.Parse(message);

        if (msg["position"] != null) {
//            print("new position: " + msg["position"].ToString()); // could check that has the desired form
            float x = int.Parse(msg["position"][0].Value) / 100.0f;
            float y = int.Parse(msg["position"][1].Value) / 100.0f;
            float z = int.Parse(msg["position"][2].Value) / 100.0f;

            position.position = new Vector3(x, y, z);

        }
    }

}
