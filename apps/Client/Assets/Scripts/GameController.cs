using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Avatar avatar;

    public Text textYaw;
    public Text textPitch;
    public Text textRoll;


    void Update() {
        if (transform.hasChanged) {
            Vector3 angles = transform.eulerAngles;
            textYaw.text = angles.y.ToString();
            textPitch.text = angles.x.ToString();
            textRoll.text = angles.z.ToString();

            SetOrientation(transform.rotation);
            transform.hasChanged = false;
        }
    }

    private void SetOrientation(Quaternion orientation) {
        avatar.SetHeadOrientation(orientation);
    }

}
