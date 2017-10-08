using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KranScript : MonoBehaviour 
{
    private Animator animator;
    public GameObject kran;
    //Animator animator;

    public Text infoText;
    public Button bigButton, losButton, stopButton, pauseButton, miauButton;

    private SoundManager bigButtonSound, losButtonSound, stopButtonSound, pauseButtonSound, miauButtonSound;

    private int buttonClicked;

	// Use this for initialization
	void Start () 
    {
        setSoundManager();
        buttonClicked = -1;
        animator = kran.GetComponent<Animator>();
        infoText.text = "Der Große Knopf da ist wichtig! Was sollen wir drauf schreiben?";
	}

    public void bigButtonClick()
    {
        switch (buttonClicked)
        {
            case 0:
                moveCar();
                infoText.text = "Oh Junge, Felix! Ich glaub etwas ist passiert! Lass uns schnell nachsehen!";
                bigButtonSound.playSound();
                break;
            case 1:
                infoText.text = "Komisch... dass sich nichts tut, wenn man STOP auf einen Button schreibt... Was anderes vielleicht?";
                setButtons(true);
                stopButtonSound.playSound();
                break;
            case 2:
                infoText.text = "...ist was passiert? Ich glaube es ist nichts passiert... Lass es uns noch mal versuchen!";
                setButtons(true);
                pauseButtonSound.playSound();
                break;
            case 3:
                infoText.text = "Ich bin mir auch gar nicht so sicher, was miau überhaupt heißen soll... sowas weiß höchstens Tardos. Richtig war es aber nicht...";
                setButtons(true);
                miauButtonSound.playSound();
                break;
            default: 
                break;
        }
    }

    public void losButtonClick()
    {
        setButtons(false);
        buttonClicked = 0;
        infoText.text = "Und jetzt auf den großen roten Knopf!";
    }

    public void stopButtonClick()
    {
        setButtons(false);
        buttonClicked = 1;
        infoText.text = "Und jetzt auf den großen roten Knopf!";
    }

    public void pauseButtonClick()
    {
        setButtons(false);
        buttonClicked = 2;
        infoText.text = "Und jetzt auf den großen roten Knopf!";
    }

    public void miauButtonClick()
    {
        setButtons(false);
        buttonClicked = 3;
        infoText.text = "Und jetzt auf den großen roten Knopf!";
    }

    private void moveCar()
    {
        animator.enabled = true;
        CanvasNavigator.isKranActive = true;
    }

    private void setButtons(bool status)
    {
        losButton.gameObject.SetActive(status);
        stopButton.gameObject.SetActive(status);
        pauseButton.gameObject.SetActive(status);
        miauButton.gameObject.SetActive(status);
    }
    
    public void Back()
    {
        SceneManager.LoadScene("Junkyard_Scene_01");
    }

    private void setSoundManager()
    {
        bigButtonSound = bigButton.GetComponent<SoundManager>();
        losButtonSound = losButton.GetComponent<SoundManager>();
        pauseButtonSound = pauseButton.GetComponent<SoundManager>();
        miauButtonSound = miauButton.GetComponent<SoundManager>();
        stopButtonSound = stopButton.GetComponent<SoundManager>();
    }
}
