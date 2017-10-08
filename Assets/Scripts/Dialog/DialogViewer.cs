using UnityEngine;
using System.Collections;
using UnityEngine.UI;



//geht alle Texte schritt für schritt durch!
public class DialogViewer{

	private DialogTree r;
	private DialogTree selectedTree;
	private bool isQuestion;

	public DialogPanel panel;

	private int maxDisplayCharacters = 50;

	//Spielt den tree von oben bis unten ab
	// Zündet das Gespräch
	public void play()
	{
		//bool weiter = true;
		
	    //canvas.GetComponentsInChildren<Text>().

		// so lange noch etwas gesagt werden kann
		//do {

			
		panel.setRoot (selectedTree);
			//panel.showText(selectedTree);


			// Aktuellen Text gut zerstückeln!

			// Aktueller Name + Text in das Canvas füllen

			// Falls Frage, Buttons einblenden und diese Mit antworttexten befüllen

			// Eingabe abfangen

			//So lange noch ein Nachfolgeelement kommt
			//if(selectedTree.hasNext () == false)
			//{weiter = false;}
			//else
			//{
				
			//		selectNextMonolog (0);
			//}


		//} while(weiter);

		// buttons im canvas wieder ausblenden
	}

	//konstruktor
	public DialogViewer(DialogTree root, DialogPanel p)
	{
		r = root;
		selectedTree = root;
		if (selectedTree.getAnswerTrees ().Count > 0)
		{
			isQuestion = true;
		}
		else
		{
			isQuestion = false;
		}
			
		panel = p;
	}


	public string getActualText()
	{
		return selectedTree.getMonologText ();
	}

	// Anzahl der Antworten
	public int answerCount()
	{
		return selectedTree.getAnswerTrees ().Count;
	}

	public void selectNextMonolog(int i)
	{
		selectedTree = selectedTree.getSubTree (i);
		if(selectedTree.getAnswerTrees ().Count > 0)
		{
			isQuestion = true;
		}
		else
		{
			isQuestion = false;
		}
	}

}
