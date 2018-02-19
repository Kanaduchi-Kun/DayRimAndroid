using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour 
{
    public Toggle toggle;

    public void Start()
    {
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.MENU;

        GameSafe.LoadOptions();

        if (BackgroundMusicContinuation.soundMuted)
        {
            toggle.isOn = false;
            BackgroundMusicContinuation.soundVolume = 0.0f;
        }
        else
        {
            toggle.isOn = true;
            BackgroundMusicContinuation.soundVolume = 1.0f;
        }

        //muteSoundToggle();
    }

    public void muteSoundToggle()
    {
        BackgroundMusicContinuation.soundMuted = !BackgroundMusicContinuation.soundMuted;

        if (BackgroundMusicContinuation.soundMuted)
        {
            BackgroundMusicContinuation.soundVolume = 0.0f;
            Debug.Log("OFF");
        }
        else
        {
            BackgroundMusicContinuation.soundVolume = 1.0f;
            Debug.Log("ON");
        }

       // GameSafe.SafeOptions();
    }

    public void leaveOptionsMenu()
    {
        GameSafe.SafeOptions();
        SceneManager.LoadScene(SceneNameManager.mainMenu);
    }
}
