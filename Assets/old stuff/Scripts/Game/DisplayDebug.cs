using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDebug : MonoBehaviour {


    // Dummy ersatz für Debug.log, dass eine nachricht auf dem Display ausgibt. =)
    public static DisplayDebug instance;

    public string displayText;

    void  OnGUI()
    {
        GUI.Label(new Rect(400, 10, 100, 20), displayText);
    }
    // Use this for initialization
    void Awake () {

        displayText = "bla";
	}
	
	// Update is called once per frame
	void Update () {

        //displayText = Time.deltaTime + "";

	}

    public void Log(string text)
    { displayText = text;

    }
}
