using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class TouchInput : MonoBehaviour {

    public static TouchInput instance;

    public Text textfeld;


    // Use this for initialization
    void Start()
    {

        
        /*  
        // DOPPELKLICK
        var clickStream = Observable.EveryUpdate()
              // .Where(_ => Input.GetTouch(0).phase == TouchPhase.Began);
              .Where(_ => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);

        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
            .Where(xs => xs.Count >= 2)
            .Subscribe(xs => textfeld.text = ("DoubleClick Detected! Count:" + xs.Count));
        //clickStream.TimeInterval(TimeSpan.FromMilliseconds(300))
        */

        // Auf der stelle gedrückt halten
        var clickHoldStream = Observable.EveryUpdate()
              // .Where(_ => Input.GetTouch(0).phase == TouchPhase.Began);
              .Where(_ => Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved));

        clickHoldStream.Buffer(clickHoldStream.Throttle(TimeSpan.FromMilliseconds(10)))
            .Subscribe(xs => textfeld.text = xs.Count + "");






    }

    // Update is called once per frame
    void Update () {

       

        /*

        int fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                fingerCount++;

        }
        if (fingerCount > 0)
            textfeld.text = "User has " + fingerCount + " finger(s) touching the screen";

    */
    }
}

