using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NavigationMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewGame()
    {
        //Application.LoadLevel("Junkyard_Scene_01");
        //GameObject.Find("TestText").GetComponent<Text>().text = "NEW GAME";
        SceneManager.LoadScene("Junkyard_Scene_01");
    }

    public void LoadGame()
    {
        //GameObject.Find("TestText").GetComponent<Text>().text = "LOAD GAME";
        SceneManager.LoadScene("Junkyard_Scene_01");
    }

    public void Options()
    {
        //GameObject.Find("TestText").GetComponent<Text>().text = "OPTIONS";
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Quit()
    {
       // GameObject.Find("TestText").GetComponent<Text>().text = "QUIT";
        Application.Quit();
    }
}
