using UnityEngine;
using System.Collections;

public class Luise_Animation : MonoBehaviour {

    private Animator animator;
    

    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();
        StartCoroutine(WaitSomeSeconds());
        //animator.SetBool("isTalking", true);
    }

    //Buttons von Canvas
    public void Continue()
    {
        animator.SetBool("isTalking", false);
    }

    public void Answer()
    {
        animator.SetBool("isTalking", true);
        StartCoroutine(WaitSomeSeconds());
    }

    IEnumerator WaitSomeSeconds()
    {
        yield return new WaitForSeconds(3.5f);
        animator.SetBool("isTalking", false);
    }
}
