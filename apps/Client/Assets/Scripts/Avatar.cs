using UnityEngine;

public class Avatar : MonoBehaviour {

    [SerializeField]
    Transform head;


    public void SetPosition(Vector3 position) {
        transform.position = position;
    }

    public void SetOrientation(float orientation) {
        transform.rotation = Quaternion.Euler(Vector3.up * orientation);
    }

// TODO: consider initial orientation (init * orientation)
    public void SetHeadOrientation(Quaternion orientation) {
        head.rotation = orientation;
    }

}
