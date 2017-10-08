using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PrototypDialog : MonoBehaviour
{
    public Text dialogText;
    public GameObject contButton;

    public GameObject BA;
    public GameObject BB;
    public GameObject BC;
    public GameObject BD;
    public GameObject backButton;

    public Text ButtonA;
    public Text ButtonB;
    public Text ButtonC;
    public Text ButtonD;

    public string[] dialogTexts;
    public string[] dialogOptionsA;
    public string[] dialogOptionsB;
    public string[] dialogOptionsC;

    private int i = 1;
    private int j = 0;
    private bool a, b, c;

    void Start()
    {
        BA.SetActive(false);
        BB.SetActive(false);
        BC.SetActive(false);
        BD.SetActive(false);

        dialogText.text = dialogTexts[0];
        contButton.SetActive(true);
    }

    public void showNext()
    {
        contButton.SetActive(false);
        Debug.Log(i);

        if (a)
            i = 1;
        if (b)
            i = 2;
        if (c)
            i = 3;

        switch (i)
        {
            case 1:
                showDialogOptionsA();
                break;
            case 2:
                showDialogOptionsB();
                break;
            case 3:
                showDialogOptionsC();
                break;
        }
    }


    public void showDialogOptionsA()
    {
        contButton.SetActive(false);
        dialogText.text = "";
        a = true;
        b = false;
        c = false;

        BA.SetActive(true);
        BB.SetActive(true);
        BC.SetActive(true);
        BD.SetActive(false);

        ButtonA.text = dialogOptionsA[0];
        ButtonB.text = dialogOptionsA[1];
        ButtonC.text = dialogOptionsA[2];
    }

    private void showDialogOptionsB()
    {
        b = true;
        a = false;
        c = false;
        dialogText.text = "";
        backButton.SetActive(true);

        BA.SetActive(true);
        BB.SetActive(true);
        BC.SetActive(true);
        BD.SetActive(true);

        ButtonA.text = dialogOptionsB[0];
        ButtonB.text = dialogOptionsB[1];
        ButtonC.text = dialogOptionsB[2];
        ButtonD.text = dialogOptionsB[3];
    }

    private void showDialogOptionsC()
    {
        backButton.SetActive(true);

        c = true;
        a = false;
        b = false;

        dialogText.text = "";

        BA.SetActive(true);
        BB.SetActive(false);
        BC.SetActive(false);
        BD.SetActive(false);

        ButtonA.text = dialogOptionsC[0];
    }

    public void iPlusPlus()
    {
        showNext();
    }

    public void showDialog()
    {
        backButton.SetActive(false);
        BA.SetActive(false);
        BB.SetActive(false);
        BC.SetActive(false);
        BD.SetActive(false);

        contButton.SetActive(true);
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        string tmp = EventSystem.current.currentSelectedGameObject.name;

        Debug.Log(c);

        if (tmp == "ButtonA")
        {
            if (a)
            {
                j = 1;
                b = true;
            }
            else if (b)
            {
                j = 4;
            }
            else if (c)
            {
                j = 8;
            }
        }
        else if (tmp == "ButtonB")
        {
            if (a)
            {
                j = 2;
                c = true;
            }
            else if (b)
            {
                j = 5;
            }
        }
        else if (tmp == "ButtonC")
        {
            if (a)
            {
                j = 3;
            }
            else if (b)
            {
                j = 6;
            }
        }
        else if (tmp == "ButtonD")
        {
            if (b)
            {
                j = 7;
            }
        }

        dialogText.text = dialogTexts[j];
    }
}

  