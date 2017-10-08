using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.UI;




public class DialogTest : MonoBehaviour {
	/*
	public DialogTree root = new DialogTree("Duck", "Hallo! Wie gehts dir?");
	public DialogTree root2 = new DialogTree("Duck", "Mononononononoooolog");

	public DialogTree broot = new DialogTree("Hexerich", "Willkommen im Dialogsystem, weiter mit Enter!");

	public DialogPanel panel;

*/
	public Button person1;
	public Button person2;
	public Button person3;
	public Button person4;

	public DialogPanel panel;
	public DialogManager manager;

	public int progress = 3;

	// Use this for initialization
	void Start () {

		person1.onClick.AddListener ( () => {pushButton("Syrx");});
		person2.onClick.AddListener ( () => {pushButton("Möhre");});
		person3.onClick.AddListener ( () => {pushButton("Popa");});
		person4.onClick.AddListener ( () => {pushButton("Luise");});
		/*

		root.addAnswer ("gut!");
		root.addAnswer ("nicht so..");

		DialogTree answer1 = new DialogTree ("Hexerich", "Das freut mich");
		DialogTree answer2 = new DialogTree ("Hexerich", "Oh, gute Besserung! Aber warum? :(");
		root.addSubtree (answer1);
		root.addSubtree (answer2);

		DialogTree thirdLayer = new DialogTree("Hexerich", "OK, Ciao!");

		answer2.addAnswer ("Zu viele blöde fragen!");
		answer2.addAnswer ("Ausversehen Käse gegessen..");
		answer2.addAnswer ("Mein Freund wollte nur schnell Kippen holen gehen..");

		DialogTree subAnswer1 = new DialogTree("Hexerich", "Kenn ich!!");
		DialogTree subAnswer2 = new DialogTree("Hexerich", "Kenn ich!!");
		DialogTree subAnswer3 = new DialogTree("Duck", "Kenn ich!!");


		answer2.addSubtree (subAnswer1);
		answer2.addSubtree (subAnswer2);
		answer2.addSubtree (subAnswer3);

		answer1.addSubtree (thirdLayer);

		broot.addSubtree (root);

		root2.addSubtree(new DialogTree("Schmarribärt", "JAJAJAJAJAJAJA!"));

		DialogTree root3 = new DialogTree("Felix", "Hallo! Mein Name ist Felix! Sehr erfreut :)");
		DialogTree feli = new DialogTree("Feli", "Hallo! Mein Name ist Felix! Sehr erfreut :)");
		DialogTree popa = new DialogTree("Popa", "Hallo! Mein Name ist Felix! Sehr erfreut :)");
		DialogTree mero = new DialogTree("Mero", "Hallo! Mein Name ist Felix! Sehr erfreut :)");
		DialogTree syrx = new DialogTree("Syrx", "Hallo! Mein Name ist Felix! Sehr erfreut :)");

		root3.addSubtree (feli);
		feli.addSubtree (popa);
		popa.addSubtree (mero);
		mero.addSubtree (syrx);




		DialogViewer Player = new DialogViewer (root3, panel);
		Player.play ();
		*/

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pushButton(string name)
	{
		manager.setDialog (manager.getTree (name, progress));
		//panel.updatePanel ();
		manager.activatePanel ();

	}

/*	public DialogTree createTreeOutOfXML()
	{


	}
	*/
}
