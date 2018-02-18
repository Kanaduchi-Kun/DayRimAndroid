using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Dialog_Navigation : MonoBehaviour {

    

    // Use this for initialization
    void Start () {	}
	
	// Update is called once per frame
	void Update () { }

    public void BackToGame()
    {
        SceneManager.LoadScene("Junkyard_Scene_01");
        //als Parameter String eingeben der zur Ausgangsszene zurückführt
    }
}
