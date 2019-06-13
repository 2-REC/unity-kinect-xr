/*

- code between
    - "//// FULL BODY - BEGIN" and "//// FULL BODY - MID"
        => If want to render full body with bones
    - "//// FULL BODY - MID" and "//// FULL BODY - END"
        => If want to render only head (faster)

*/

using UnityEngine;
using System.Collections.Generic;
using Kinect = Windows.Kinect;

public class BodyView : MonoBehaviour {

////
public Transform head;
////

    public Material BoneMaterial;
    public GameObject BodySourceManager;

    private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
    private KinectInputManager _BodyManager;

//// FULL BODY - BEGIN
//TODO: should move to a separate class, and moved to the "Kinect/Scripts" directory
    private Dictionary<Kinect.JointType, Kinect.JointType> _BoneMap = new Dictionary<Kinect.JointType, Kinect.JointType>() {
        { Kinect.JointType.FootLeft, Kinect.JointType.AnkleLeft },
        { Kinect.JointType.AnkleLeft, Kinect.JointType.KneeLeft },
        { Kinect.JointType.KneeLeft, Kinect.JointType.HipLeft },
        { Kinect.JointType.HipLeft, Kinect.JointType.SpineBase },

        { Kinect.JointType.FootRight, Kinect.JointType.AnkleRight },
        { Kinect.JointType.AnkleRight, Kinect.JointType.KneeRight },
        { Kinect.JointType.KneeRight, Kinect.JointType.HipRight },
        { Kinect.JointType.HipRight, Kinect.JointType.SpineBase },

        { Kinect.JointType.HandTipLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.ThumbLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.HandLeft, Kinect.JointType.WristLeft },
        { Kinect.JointType.WristLeft, Kinect.JointType.ElbowLeft },
        { Kinect.JointType.ElbowLeft, Kinect.JointType.ShoulderLeft },
        { Kinect.JointType.ShoulderLeft, Kinect.JointType.SpineShoulder },

        { Kinect.JointType.HandTipRight, Kinect.JointType.HandRight },
        { Kinect.JointType.ThumbRight, Kinect.JointType.HandRight },
        { Kinect.JointType.HandRight, Kinect.JointType.WristRight },
        { Kinect.JointType.WristRight, Kinect.JointType.ElbowRight },
        { Kinect.JointType.ElbowRight, Kinect.JointType.ShoulderRight },
        { Kinect.JointType.ShoulderRight, Kinect.JointType.SpineShoulder },

        { Kinect.JointType.SpineBase, Kinect.JointType.SpineMid },
        { Kinect.JointType.SpineMid, Kinect.JointType.SpineShoulder },
        { Kinect.JointType.SpineShoulder, Kinect.JointType.Neck },
        { Kinect.JointType.Neck, Kinect.JointType.Head },
    };
//// FULL BODY - MID


    void Update () {
//TODO: should be done in "Start" (?)
        if (BodySourceManager == null) {
            return;
        }

//TODO: should be done in "Start" (?)
        _BodyManager = BodySourceManager.GetComponent<KinectInputManager>();
        if (_BodyManager == null) {
            return;
        }

        Kinect.Body[] data = _BodyManager.GetBodyData();
        if (data == null) {
            return;
        }

        List<ulong> trackedIds = new List<ulong>();
        foreach(var body in data) {
            if (body == null) {
                continue;
            }

            if(body.IsTracked) {
                trackedIds.Add (body.TrackingId);
            }
        }

        List<ulong> knownIds = new List<ulong>(_Bodies.Keys);

        // First delete untracked bodies
        foreach(ulong trackingId in knownIds) {
            if(!trackedIds.Contains(trackingId)) {
//TODO!
head.parent = null;
                Destroy(_Bodies[trackingId]);
                _Bodies.Remove(trackingId);
            }
        }

        foreach(var body in data) {
            if (body == null) {
                continue;
            }

            if(body.IsTracked) {
                if(!_Bodies.ContainsKey(body.TrackingId)) {
                    _Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                }

                RefreshBodyObject(body, _Bodies[body.TrackingId]);
            }
        }
    }

//// FULL BODY - BEGIN
    private GameObject CreateBodyObject(ulong id) {
        GameObject body = new GameObject("Body_" + id);
        body.transform.SetParent(gameObject.transform.parent, false);

        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++) {
//            GameObject jointObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject jointObj = new GameObject();
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            sphere.transform.parent = jointObj.transform;

            LineRenderer lr = jointObj.AddComponent<LineRenderer>();
            lr.positionCount = 2;
            lr.material = BoneMaterial;
            lr.startWidth = 0.05f;
            lr.endWidth = 0.05f;

            jointObj.name = jt.ToString();
            jointObj.transform.parent = body.transform;
////
if (jt == Kinect.JointType.Head) {
    print("HEAD");
    head.localPosition = Vector3.zero;
    head.SetParent(jointObj.transform);
}
////
        }

        return body;
    }
//// FULL BODY - MID
/*
    private GameObject CreateBodyObject(ulong id) {
        GameObject body = new GameObject("Body_" + id);
        body.transform.SetParent(gameObject.transform.parent, false);

        GameObject head = new GameObject();
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(0.15f, 0.25f, 0.2f);
        cube.transform.parent = head.transform;

        LineRenderer lr = head.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.material = BoneMaterial;
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;

        head.name = Kinect.JointType.Head.ToString();
        head.transform.parent = body.transform;

        return body;
    }
*/
//// FULL BODY - END

//// FULL BODY - BEGIN
    private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject) {
        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++) {
            Kinect.Joint sourceJoint = body.Joints[jt];
            Kinect.Joint? targetJoint = null;

            if(_BoneMap.ContainsKey(jt)) {
                targetJoint = body.Joints[_BoneMap[jt]];
            }

//TODO: find more optimised way for this!
            Transform jointObj = bodyObject.transform.Find(jt.ToString());
            jointObj.localPosition = GetVector3FromJoint(sourceJoint);

            LineRenderer lr = jointObj.GetComponent<LineRenderer>();
            if(targetJoint.HasValue) {
                lr.SetPosition(0, jointObj.position);
//TODO: find solution for local/world coordinates problem!
//=> THIS IS HORRIBLE!
//                lr.SetPosition(1, GetVector3FromJoint(targetJoint.Value));
Transform targetObj = bodyObject.transform.Find(_BoneMap[jt].ToString());
targetObj.localPosition = GetVector3FromJoint(targetJoint.Value);
lr.SetPosition(1, targetObj.position);
                lr.startColor = GetColorForState(sourceJoint.TrackingState);
                lr.endColor = GetColorForState(targetJoint.Value.TrackingState);
            }
            else {
                lr.enabled = false;
            }
        }
    }
//// FULL BODY - MID
/*
    private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject) {
        Kinect.Joint headJoint = body.Joints[Kinect.JointType.Head];

        Transform headTransform = bodyObject.transform.Find(Kinect.JointType.Head.ToString());
        headTransform.localPosition = GetVector3FromJoint(headJoint);

        LineRenderer lr = headTransform.GetComponent<LineRenderer>();
        lr.SetPosition(0, headTransform.position);
        lr.SetPosition(1, headTransform.position + new Vector3(.0f, -1.0f, .0f));
        Color color = GetColorForState(headJoint.TrackingState);
        lr.startColor = color;
        lr.endColor = color;
    }
*/
//// FULL BODY - END

    private static Color GetColorForState(Kinect.TrackingState state) {
        switch (state) {
            case Kinect.TrackingState.Tracked:
                return Color.green;
            case Kinect.TrackingState.Inferred:
                return Color.red;
            default:
                return Color.black;
        }
    }

    private static Vector3 GetVector3FromJoint(Kinect.Joint joint) {
        return new Vector3(joint.Position.X, joint.Position.Y, -joint.Position.Z);
    }

}
