using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimationRobo : MonoBehaviour {

    private Animator animator;

    // Use this for initialization
    void Start () {

        animator = this.GetComponent<Animator>();
        //StartCoroutine(WaitingForSeconds());
        //animator.Play("Robo_Animatio", 0);
        animator.SetBool("hasPaused", false);
       
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0) //  && Input.GetTouch(0).phase == TouchPhase.Began)
        {
           // GameObject.Find("Text").GetComponent<Text>().text = "kacka";
            animator.SetBool("hasPaused", true);
            //animator.Play("Robo_Animation", 0);
        }
        else
        {
            animator.SetBool("hasPaused", false);
            //GameObject.Find("Text").GetComponent<Text>().text = "törö";
            //StartCoroutine(WaitingForSeconds());

        }

    }

    IEnumerator WaitingForSeconds()
    {
        // animator.
        yield return new WaitForSeconds(5.0f);       
    }

}
