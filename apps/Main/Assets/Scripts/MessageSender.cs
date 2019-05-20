using UnityEngine;

public class MessageSender : MonoBehaviour {

    public SpacebrewEvents spacebrewClientEvents;
    public string pubNameMove;


    public void SendMove(string message) {
        spacebrewClientEvents.SendString(pubNameMove, message);
    }

}
