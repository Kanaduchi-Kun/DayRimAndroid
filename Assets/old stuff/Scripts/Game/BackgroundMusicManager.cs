using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    private AudioSource[] backgroundMusic;
    private string currentScene;

    public bool inMenu;

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        backgroundMusic = new AudioSource[2];
        backgroundMusic = this.GetComponents<AudioSource>();

        setGameMode();

        if (ActiveGameMode.GAMEMODE == ActiveGameMode.GameModes.MENU)
            stopGame();
        else
            stopMenu();

          if (backgroundMusic[0].volume != BackgroundMusicContinuation.soundVolume || backgroundMusic[1].volume != BackgroundMusicContinuation.soundVolume)
          {
              backgroundMusic[0].volume = BackgroundMusicContinuation.soundVolume/2;
              backgroundMusic[1].volume = BackgroundMusicContinuation.soundVolume/2;
          }

        playMusic();

        if (BackgroundMusicContinuation.keepPlayingGameMusic || BackgroundMusicContinuation.keepPlayingMenuMusic)
        {
            DontDestroyOnLoad(this.gameObject);
            BackgroundMusicContinuation.keepPlayingGameMusic = false;
            BackgroundMusicContinuation.keepPlayingMenuMusic = false;
        }

    }

    void Update()
    {
        if (backgroundMusic[0].volume != BackgroundMusicContinuation.soundVolume || backgroundMusic[1].volume != BackgroundMusicContinuation.soundVolume)
        {
            backgroundMusic[0].volume = BackgroundMusicContinuation.soundVolume/2;
            backgroundMusic[1].volume = BackgroundMusicContinuation.soundVolume/2;
        }

        if ((ActiveGameMode.GAMEMODE == ActiveGameMode.GameModes.INGAME || ActiveGameMode.GAMEMODE == ActiveGameMode.GameModes.INVENTORY) && backgroundMusic[1].isPlaying)
            backgroundMusic[1].volume = 0.0f;

        if (ActiveGameMode.GAMEMODE == ActiveGameMode.GameModes.MENU && backgroundMusic[0].isPlaying)
            backgroundMusic[0].volume = 0.0f;
    }

    private void setGameMode()
    {
        if (currentScene == "MainMenu" || currentScene == "OptionsMenu")
            ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.MENU;
        else
            ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INGAME;
    }

    private void stopMenu()
    {
        BackgroundMusicContinuation.keepPlayingMenuMusic = false;
        BackgroundMusicContinuation.menuMusicStarted = false;

        BackgroundMusicContinuation.keepPlayingGameMusic = true;
    }

    private void stopGame()
    {
        BackgroundMusicContinuation.keepPlayingGameMusic = false;
        BackgroundMusicContinuation.gameMusicStarted = false;

        BackgroundMusicContinuation.keepPlayingMenuMusic = true;
    }

    private void playMusic()
    {
        if (BackgroundMusicContinuation.keepPlayingGameMusic && !BackgroundMusicContinuation.gameMusicStarted)
        {
            backgroundMusic[1].Stop();
            BackgroundMusicContinuation.gameMusicStarted = true;
            backgroundMusic[0].loop = true;

            if(!backgroundMusic[0].isPlaying)
                backgroundMusic[0].Play();
        }
        else if (BackgroundMusicContinuation.keepPlayingMenuMusic && !BackgroundMusicContinuation.menuMusicStarted)
        {
            backgroundMusic[0].Stop();
            BackgroundMusicContinuation.menuMusicStarted = true;
            backgroundMusic[1].loop = true;

            if(!backgroundMusic[1].isPlaying)
                backgroundMusic[1].Play();
        }
    }
}