using UnityEngine;
using System.Collections;

public class TippenAnimation : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();

        //animator.Play();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void playTippen()
    {
       // animator.Play("", int i);
    }
}
