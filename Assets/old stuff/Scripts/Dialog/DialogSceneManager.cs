using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DialogSceneManager : MonoBehaviour 
{
    public void enterDialogScene()
    {
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.DIALOG;
        Debug.Log(ActiveGameMode.GAMEMODE);
        SceneManager.LoadScene("DialogScene");
    }

    public void leaveDialogScene()
    {
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INGAME;
        Debug.Log(ActiveGameMode.GAMEMODE);
        SceneManager.LoadScene(SceneNameManager.lastIngameScene);
    }
}
