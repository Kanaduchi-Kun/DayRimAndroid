using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class CameraFollow : MonoBehaviour {

    public Transform target;


    public GameObject canvas;


    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float zOffset = -10.0f;

    public DeviceOrientation lastOrientation;

    private void Start()
    {
        lastOrientation = Input.deviceOrientation;

        var RotationPortraitStream = Observable.EveryUpdate()
             .Where(_ => Input.deviceOrientation == DeviceOrientation.Portrait && lastOrientation != DeviceOrientation.Portrait)
             .Subscribe(xs =>
             {
                 //transform.eulerAngles = new Vector3(0,0,-90.0f);
                 transform.eulerAngles = new Vector3(0, 0, 0);
                 offset.y = 3.5f;

                 TouchInput.instance.debugtext.text = "UI enthält Elemente: " + canvas.GetComponentsInChildren<Text>(true).Length + " " + canvas.GetComponentsInChildren<Text>(true)[0].gameObject.name;
                 //foreach (Text uielement in canvas.GetComponentsInChildren<Text>(true))
                 //{ uielement.transform.eulerAngles = new Vector3(0, 0, -90.0f); }

                 lastOrientation = DeviceOrientation.Portrait;
             });

        var RotationLandscapeStream = Observable.EveryUpdate()
            .Where(_ => Input.deviceOrientation == DeviceOrientation.LandscapeRight && lastOrientation != DeviceOrientation.LandscapeRight)
            .Subscribe(xs =>
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                offset.y = 2.5f;

               // foreach (Transform uielement in canvas.GetComponentsInChildren<Transform>(true))
               //{ uielement.eulerAngles = new Vector3(0, 0, 0f); }

                lastOrientation = DeviceOrientation.LandscapeRight;
            });
    }


    void FixedUpdate () {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = new Vector3(smoothPos.x, smoothPos.y, offset.z);
        // transform.position = new Vector3(smoothPos.x, smoothPos.y, zOffset);
    }
}
