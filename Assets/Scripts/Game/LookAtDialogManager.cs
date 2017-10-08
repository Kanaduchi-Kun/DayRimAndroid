using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LookAtDialogManager : MonoBehaviour
{
    public string felixDialog;
    public string feliDialog;

	public void showDialogText(Text text)
	{
		if(ActiveCharacter.activeCharacter.name == "Feli")
			text.text = feliDialog;
		else if(ActiveCharacter.activeCharacter.name == "Felix")
			text.text = felixDialog;
		else // Manchmal Character null???
			text.text = feliDialog; // Default
	}

 /*   public string getLookAtDialog()
    {
        string lookAtDialog = "";

        if (ActiveCharacter.activeCharacter.name == "Felix")
            lookAtDialog = felix;
        else
            lookAtDialog = feli;

        return lookAtDialog;
    }*/
}