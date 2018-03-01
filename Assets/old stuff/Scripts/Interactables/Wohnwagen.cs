using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wohnwagen : MonoBehaviour, ILookAt, ITalkTo, IPickUp {

    public void Look()
    {
        TouchInput.instance.debugtext.text = "Hmm.. Der Wohnwagen sieht 2D aus..";
    }

    public void PickUp()
    {
        TouchInput.instance.debugtext.text = "NOTE: Wohnwagen mal fix in die Tasche gesteckt";
    }

    public void TalkTo()
    {
        TouchInput.instance.debugtext.text = "hi I bimz da wohnwagen";
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
