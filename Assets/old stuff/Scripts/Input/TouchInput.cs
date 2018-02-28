using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class TouchInput : MonoBehaviour
{

    public static TouchInput instance;


    public GameObject interactionPrefab;
    //public GameObject canvas;

    public Text debugtext;

    bool tooFarMoved;

    Vector3 pos;

    float initial_x;
    float initial_y;

    float actual_x;
    float actual_y;

    public float tolerance = 30.0f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        pos = new Vector3(0.0f, 0.0f, 0.0f);

        instance = this;

        initial_x = 0.0f;
        initial_y = 0.0f;

        actual_x = 0.0f;
        actual_y = 0.0f;

        tooFarMoved = false;
    }



    // Use this for initialization
    void Start()
    {

        
        var clickStream = Observable.EveryUpdate()
              .Where(_ => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);

        clickStream.Subscribe(xs => {
                                      pos = Input.GetTouch(0).position;
                                      initial_x = Input.GetTouch(0).position.x;
                                      initial_y = Input.GetTouch(0).position.y;
        });


        // DOPPELKLICK
        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
            .Where(xs => xs.Count >= 2)
            .Subscribe(xs => //textfeld.text = ("DoubleClick Detected at X:" + initial_x + " Y:" + initial_y)
             {
                
                 NavMeshMovement.instance.Move(pos);
             }
            );


        //Einfachklick!!!
        var OneClickStream = Observable.EveryUpdate()
             .Where(_ => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended);
             
       // OneClickStream.Subscribe(xs => pos = Input.GetTouch(0).position);
             //.Where(_ => Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Ended));

        OneClickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
            .Where(xs => xs.Count == 1)
            .Subscribe(xs => { //textfeld.text = ("Simple Click Detected at" + initial_x + " Y:" + initial_y);

                
                //pos = Input.GetTouch(0).position;

                 Ray ray = Camera.main.ScreenPointToRay(pos);
                 RaycastHit hit;

                 if (Physics.Raycast(ray, out hit))
                 {

                    ILookAt tmp = hit.collider.GetComponent<ILookAt>();


                    if (tmp != null )
                    {
                        debugtext.text = hit.collider.name + " LOOK AT ERKANNT! ";
                    }
                    else
                    {
                        debugtext.text = hit.collider.name +  " LOOK AT NICHT ERKANNT! ";
                    }
                  


                     if (hit.collider.name == "felixdummy")
                     {
                        setInteractionPanel(pos, true);
                     }
                    else
                    {
                        setInteractionPanel(pos, false);
                    }




                 }

                
                tooFarMoved = false; }
            );



        // Auf der stelle gedrückt halten
        var clickHoldStream = Observable.EveryUpdate()
              // .Where(_ => Input.GetTouch(0).phase == TouchPhase.Began);
              .Where(_ => Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved) && !tooFarMoved);

       


        clickHoldStream.Buffer(clickHoldStream.Throttle(TimeSpan.FromMilliseconds(250)))
        .Where(xs => xs.Count >= 22)
        .Subscribe(xs => {
            //textfeld.text = "TOUCH-HOLD! at X:" + actual_x + " Y:" + actual_y;
            tooFarMoved = false;
        });
        //.Subscribe(xs => textfeld.text = "TOUCH-HOLD! and moved from X:" + initial_x + " Y:" + initial_y + "to NEW-X:" + Input.GetTouch(0).position.x + "NEW-Y:" + Input.GetTouch(0).position.y);

        //.Subscribe(xs => { initial_x = Input.GetTouch(0).position.x;
        //                   initial_y = Input.GetTouch(0).position.y;   });

        //clickHoldStream.Buffer(clickHoldStream.Throttle(TimeSpan.FromMilliseconds(300)))




        // Stream der beim Ende eines Touch auslöst
        var EndOfTouchStream = Observable.EveryUpdate()
              // .Where(_ => Input.GetTouch(0).phase == TouchPhase.Began);
              .Where(_ => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
              .Subscribe(xs =>
                         {
                             actual_x = Input.GetTouch(0).position.x;
                             actual_y = Input.GetTouch(0).position.y;
                         });


        // Stream der beim Bewegen eines Touch auslöst
        var MoveOfTouchStream = Observable.EveryUpdate()
              // .Where(_ => Input.GetTouch(0).phase == TouchPhase.Began);
              .Where(_ => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
              .Subscribe(xs =>
              {
                 if((initial_x - tolerance > Input.GetTouch(0).position.x) || (initial_x + tolerance < Input.GetTouch(0).position.x))
                  {
                      tooFarMoved = true;
                  }
                 else if ((initial_y - tolerance > Input.GetTouch(0).position.y) || (initial_y + tolerance < Input.GetTouch(0).position.y))
                  { tooFarMoved = true; }
                  else
                  {
                      tooFarMoved = false;
                  }
              });

    }

    // Update is called once per frame
    void Update()
    {



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

    void setInteractionPanel(Vector3 touchPos, bool visible)
    {
        interactionPrefab.transform.position = touchPos;
        interactionPrefab.SetActive(visible);

    }
}

