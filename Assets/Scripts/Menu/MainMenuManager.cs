using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour 
{
    public void Start()
    {
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.MENU;
        SceneNameManager.lastScene = SceneNameManager.mainMenu;
        GameSafe.LoadOptions();
    }

    public void newGame()
    {
		SceneManager.LoadScene(SceneNameManager.junkyardFirst); //indoor
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INGAME;
    }

    public void loadGame()
    {
       // GameSafe.Load();
        SceneManager.LoadScene(SceneNameManager.junkyardFirst);
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INGAME;
    }

    public void enterOptionsMenu()
    {
        SceneManager.LoadScene(SceneNameManager.optionsMenu);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
