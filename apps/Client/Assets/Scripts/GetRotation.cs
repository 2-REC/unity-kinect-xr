/*
Inspired from:
https://forum.unity.com/threads/sharing-gyroscope-camera-script-ios-tested.241825/

TODO:
- have a look at
  http://plaw.info/articles/sensorfusion/
  => See if needed, & if better (avoid gyroscope drifting)
*/

using UnityEngine;

delegate void Calibrator();

public class GetRotation : MonoBehaviour {

    public float initDelay = 5.0f;

    private float initialYaw;
    private float time;
    private Calibrator calibrate;


    void Start() {
        initialYaw = .0f;
        time = .0f;
        calibrate = new Calibrator(InitCalibration);

        InitGyroscope();

        transform.rotation = Input.gyro.attitude;
        transform.Rotate(.0f, .0f, 180.0f, Space.Self); // Swap "handedness" of quaternion from gyro
        transform.Rotate(90.0f, 180.0f, .0f, Space.World); // Rotate to point camera out the back of device
        initialYaw = transform.eulerAngles.y;
        //print("Calibration angle: " + initialYaw);
    }

    void Update() {
        transform.rotation = Input.gyro.attitude;
        transform.Rotate(.0f, .0f, 180.0f, Space.Self); // Swap "handedness" of quaternion from gyro.
        transform.Rotate(90.0f, 180.0f, .0f, Space.World); // Rotate to make sense as a camera pointing out the back of your device.

        calibrate();
    }

    private void InitGyroscope() {
        if (!SystemInfo.supportsGyroscope) {
            //TODO: throw exception...
            print("ERROR: NO GYROSCOPE SUPPORT ON DEVICE!");
            Application.Quit();
        }

        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.0167f; // highest value (=60 Hz)
    }

    private void ApplyCalibration() {
        transform.Rotate(.0f, -initialYaw, .0f, Space.World);
    }

    private void InitCalibration() {
        if (time >= initDelay) {
            calibrate = new Calibrator(ApplyCalibration);
            return;
        }

        time += Time.deltaTime;
        initialYaw = transform.eulerAngles.y;
        //print("Calibration angle: " + initialYaw);

        transform.Rotate(.0f, -initialYaw, .0f, Space.World);
    }

}
