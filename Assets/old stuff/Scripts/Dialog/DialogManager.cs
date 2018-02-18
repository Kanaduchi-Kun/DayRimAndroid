using UnityEngine;
using System.Collections;

public class DialogManager : MonoBehaviour {

	public int progerss;

	//public ArrayList LuiseTrees;

	public DialogTree LuiseTree1;

	//public ArrayList MoehreTrees;
	public DialogTree MoehreTree2;

	//public ArrayList PopaTrees;
	public DialogTree PopaTree2;
	public DialogTree PopaTree4;

	//public ArrayList SyrxTrees;
	public DialogTree SyrxTree3;
	public DialogTree SyrxTree4;
	public DialogTree SyrxTree5;

	//Matze
	//public ArrayList TardosTree;
	public DialogTree TardosTree1;
	public DialogTree TardosTree2;

	public DialogPanel panel;

	public Hashtable LuiseTrees;
	public Hashtable MoehreTrees;
	public Hashtable PopaTrees;
	public Hashtable SyrxTrees;
	public Hashtable MeroTrees;
	//Matze
	public Hashtable TardosTrees;

	// Use this for initialization
	void Start () {
	
		progerss = 0;

		LuiseTrees = new Hashtable ();
		MoehreTrees = new Hashtable ();
		PopaTrees = new Hashtable ();
		SyrxTrees = new Hashtable ();
		MeroTrees = new Hashtable ();
		//Matze
		TardosTrees = new Hashtable ();

		LuiseTree1 = new DialogTree ("Luise", "Nur zu! Komm näher und bade in meiner Weisheit! Ich habe meine Augen und Ohern die ganze Zeit offen!");
		LuiseTree1.addAnswer ("Es ist echt praktisch, dass sich hier jemand mit Geisterzeug auskennt!");
		LuiseTree1.addAnswer ("Wegen der Gang...");
		LuiseTree1.addAnswer ("Ist es schon öfter vorgekommen, dass Leute ihren Körper verlassen?");

		DialogTree Luise1_1 = new DialogTree ("Luise", "Meine Rede! endlich werden meine unglaublichen Fähigkeiten mal gewürdigt!");
		Luise1_1.addSubtree (LuiseTree1);

		DialogTree Luise1_2 = new DialogTree("Luise", "Die werden uns nicht einfach so glauben, wir müssen ihnen Beweise liefern, denk dran!");
		DialogTree Luise1_21 = new DialogTree("Luise", "Weil sie keine Unmenschen sind, werden sie uns aber bestimmt unter die Arme greifen, um den Übersetzer bauen zu können.");
		Luise1_2.addSubtree (Luise1_21);
		DialogTree Luise1_22 = new DialogTree("Luise", "Oder ehr den Lautsprecher? Immerhin können die anderen deinen Geisterfreund überhaupt nicht hören.");
		Luise1_21.addSubtree (Luise1_22);

		Luise1_22.addAnswer ("Popa");
		Luise1_22.addAnswer ("Syrx");
		Luise1_22.addAnswer ("Möhre");
		Luise1_22.addAnswer ("Feli");
		Luise1_22.addAnswer ("Felix");

		DialogTree Luise1_22_1 = new DialogTree ("Luise", "Ich bin mir sicher, dass Popa ein paar Teile beim Schrottsammeln gefunden hat, die wir gebrauchen können");
		DialogTree Luise1_22_11 = new DialogTree ("Luise", "Frag sie mal danach, sie ist bestimmt drinnen im Wohnwagen");
		Luise1_22_1.addSubtree (Luise1_22_11);

		DialogTree Luise1_22_2 = new DialogTree ("Luise","Weiß leider nicht wo er steckt, vielleicht schaust Du mal drinnen nach? Wenn wir die richtigen Teile zusammen haben, dann kann er mit meiner Anleitung das Gerät zusammenbauen.");

		DialogTree Luise1_22_3 = new DialogTree ("Luise","Du kennst ja Möhre! Die ist schon die ganze Zeit an ihrem Computer, die hat heute den Wohnwagen noch nicht einmal verlassen, tss!");
		DialogTree Luise1_22_31 = new DialogTree ("Luise","Vermutlich ist sie auch kaum ansprechbar... Leider werden wir nicht um ihre Hilfe drumherum kommen.");
		DialogTree Luise1_22_32 = new DialogTree ("Luise","Sie muss das Gerät programmieren, sonst wird es nicht richtig funktionieren. Zum Glück lässt Möhre sich mit den richtigen Worten ganz leicht bequatschen, was?");
		Luise1_22_3.addSubtree (Luise1_22_31);
		Luise1_22_31.addSubtree (Luise1_22_32);


		DialogTree Luise1_22_4 = new DialogTree ("Luise","Wir haben uns echt Gedanken um dich gemacht! Du bist auf eine deiner Touren gegangen und einfach nicht zurückgekommen! Dass ausgerechnet Du erwischt worden bist...");
		DialogTree Luise1_22_41 = new DialogTree ("Luise","Aber etwas gutes hat die Sache ja, so eine Geisterhafte Erfahrung kann auch nicht jeder machen! Du hast zwar deinen eigenen Körper nicht mehr, aber das ist nur ein kleiner Makel!");
		Luise1_22_4.addSubtree (Luise1_22_41);

		DialogTree Luise1_22_5 = new DialogTree ("Luise","Ach! Über mich gibt es nicht so viel zu erzählen! Wir haben jetzt auch keine Zeit für ein Pläuschchen! Über mich können wir noch quatschen, wenn dein Geisterfreund auch kann.");
	

		Luise1_22.addSubtree (Luise1_22_1);
		Luise1_22.addSubtree (Luise1_22_2);
		Luise1_22.addSubtree (Luise1_22_3);
		Luise1_22.addSubtree (Luise1_22_4);
		Luise1_22.addSubtree (Luise1_22_5);

		DialogTree Luise1_3 = new DialogTree ("Luise","Keine Ahnung! Hier auf dem Schrottplatz gibt es auch niemanden, den ich danach fragen könnte.");
		DialogTree Luise1_31 = new DialogTree ("Luise","Aber es ist total faszinierend, nicht wahr?! Endlich mal übernatürlicher Nervenkitzel!");
		Luise1_3.addSubtree (Luise1_31);

		Luise1_31.addSubtree (LuiseTree1);


		LuiseTree1.addSubtree (Luise1_1);
		LuiseTree1.addSubtree (Luise1_2);
		LuiseTree1.addSubtree (Luise1_3);


		// Möhres Tree

		MoehreTree2 = new DialogTree ("Möhre", "Ich weiß zwar nicht wer du bist, aber fass dich kurz, ich bin beschäftigt!");
		MoehreTree2.addAnswer ("Hast du nicht einmal Zeit für ein Gespräch mit einem Freund?");
		MoehreTree2.addAnswer ("Ich brauch deine Hilfe!");
		MoehreTree2.addAnswer ("Weißt du nicht wer ich bin?");

		DialogTree MoehreTree2_1 = new DialogTree ("Möhre", "Nicht, wenn es nicht um etwas Wichtiges geht. Für Smalltalk hab ich wirklich keine Zeit.");
		MoehreTree2.addSubtree (MoehreTree2_1);
		MoehreTree2_1.addSubtree (MoehreTree2);


		DialogTree MoehreTree2_2 = new DialogTree ("Möhre", "Ich hab nicht wirklich Zeit dir bei irgendeiner Kleinigkeit zu helfen.");
		MoehreTree2.addSubtree (MoehreTree2_2);
		MoehreTree2_2.addAnswer ("Es ist keine Kleinigkeit!");
		MoehreTree2_2.addAnswer ("Du bist die Einzige, die mir helfen kann!");
		MoehreTree2_2.addAnswer ("Seit wann bist du so eklig zu anderen?");

		DialogTree MoehreTree2_21 = new DialogTree ("Möhre", "Das was ich mache ist auch keine Kleinigkeit.");
		MoehreTree2_2.addSubtree (MoehreTree2_21);
		MoehreTree2_21.addSubtree (MoehreTree2);

		DialogTree MoehreTree2_22 = new DialogTree ("Möhre", "Achja? Ich weiß nicht... das hier ist echt wichtig...");
		MoehreTree2_2.addSubtree (MoehreTree2_22);
		MoehreTree2_22.addAnswer("Komm schon! Ich weiß, dass du nichts lieber tun würdest!");
		MoehreTree2_22.addAnswer("Ausreden!");
		MoehreTree2_22.addAnswer("Bitte, ich weiß echt nicht, wen ich sonst fragen könnte!");
		MoehreTree2_22.addAnswer("Das hier ist auch wichtig! Es geht wirklich um eine Menge!");

		DialogTree MoehreTree2_22_1 = new DialogTree ("Möhre", "Achja? Da kennst du mich aber schlecht.");
		MoehreTree2_22_1.addSubtree ( MoehreTree2_22);

		DialogTree MoehreTree2_22_2 = new DialogTree ("Möhre", "Wenn du mir so kommst, können wir das hier gleich vergessen");
		MoehreTree2_22_2.addSubtree ( MoehreTree2_22);

		DialogTree MoehreTree2_22_3 = new DialogTree ("Möhre", "...worum geht es denn?");
		MoehreTree2_22_3.addAnswer ("Du musst etwas programmieren, das Syrx zusammengebaut hat! ");
		MoehreTree2_22_3.addAnswer ("Luise kennt die Einzelheiten, aber es wäre super hilfreich, wenn du mir unter die Arme greifen könntest!");
		MoehreTree2_22_3.addAnswer ("Warum nicht gleich so?");

		DialogTree MoehreTree2_22_31 = new DialogTree ("Möhre", "Ach, muss ich das?");
		MoehreTree2_22_31.addSubtree ( MoehreTree2_22_3);

		//finaler punkt
		DialogTree MoehreTree2_22_32 = new DialogTree ("Möhre", "Luise steckt da auch mit drin? ...fein. Ich werd mit ihr reden. Stör mich aber bitte nicht mehr unnötig bei der Arbeit.");

		DialogTree MoehreTree2_22_33 = new DialogTree ("Möhre", "Lassen wir das doch lieber.");
		MoehreTree2_22_31.addSubtree ( MoehreTree2_22_3);

		MoehreTree2_22_3.addSubtree (MoehreTree2_22_31);
		MoehreTree2_22_3.addSubtree (MoehreTree2_22_32);
		MoehreTree2_22_3.addSubtree (MoehreTree2_22_33);


		DialogTree MoehreTree2_22_4 = new DialogTree ("Möhre", "Hm... jetzt ist wirklich ein schlechter Zeitpunkt.");
		MoehreTree2_22_4.addSubtree ( MoehreTree2_22);

		MoehreTree2_22.addSubtree (MoehreTree2_22_1);
		MoehreTree2_22.addSubtree (MoehreTree2_22_2);
		MoehreTree2_22.addSubtree (MoehreTree2_22_3);
		MoehreTree2_22.addSubtree (MoehreTree2_22_4);

		DialogTree MoehreTree2_23 = new DialogTree ("Möhre", "Wow, dafür dass du etwas von mir willst, bist du echt frech.");
		MoehreTree2_2.addSubtree (MoehreTree2_23);
		MoehreTree2_23.addSubtree (MoehreTree2);


		DialogTree MoehreTree2_3 = new DialogTree ("Möhre", "Jemand, der andere Leute gerne beim Arbeiten unterbricht?");
		MoehreTree2.addSubtree (MoehreTree2_3);
		MoehreTree2_3.addSubtree (MoehreTree2);

		// POPAS DIALOGE
		PopaTree2 = new DialogTree ("Popa", "Hey, neues Gesicht! Ich bin Popa. Keine Ahnung wer du bist, aber du siehst in Ordnung aus! Also, was führt dich in meine bescheidene Hütte?");
		PopaTree2.addAnswer ("Kannst du mir etwas von deinem Schrott abgeben?");
		PopaTree2.addAnswer ("Popa, ich bin's, Feli!");
		PopaTree2.addAnswer ("Glaubst du an Geister?");

		DialogTree PopaTree2_1 = new DialogTree ("Popa", "Ich weiß nicht...! Dafür kenn ich dich eigentlich noch nicht gut genug, aber wie wäre es mit einem Tauschgeschäft?");
		DialogTree PopaTree2_11 = new DialogTree ("Popa", "Wenn du mir eine Pfirsichtomate bringst, dann geb ich dir was von meinen Schätzen ab! Deal? Deal! Perfekt. Husch, husch, bevor ich noch verhungere!");
		PopaTree2_1.addSubtree(PopaTree2_11);

		DialogTree PopaTree2_2 = new DialogTree ("Popa", "Hälst du mich für blöd? Bin ich nämlich nicht! Feli sieht ganz anders aus als du und sie riecht auch ganz anders! So leicht kannst du mich nicht reinlegen!");
		DialogTree PopaTree2_21 = new DialogTree ("Popa", "Wir können nur dann Freunde sein, wenn du nicht versuchst mir so einen Bären aufzubinden. Und wenn du es versuchst sei dabei nicht so offensichtlich!");
		PopaTree2_2.addSubtree(PopaTree2_21);
		PopaTree2_21.addSubtree(PopaTree2);

		DialogTree PopaTree2_3 = new DialogTree ("Popa", "Versuchst du mir Angst einzujagen? Vergiss es! Aber red bloß nicht weiter...! Ich kann ich gar nicht hören, lalalala!");
		PopaTree2_3.addSubtree(PopaTree2);

		PopaTree2.addSubtree (PopaTree2_1);
		PopaTree2.addSubtree (PopaTree2_2);
		PopaTree2.addSubtree (PopaTree2_3);

		PopaTree4 = new DialogTree ("Popa", "Hey, du! Die Pfirsichtomate hat etwas komisch geschmeckt, aber wenigstens grummelt mein Magen nicht mehr!");
		PopaTree4.addAnswer ("Kannst du mir mit dem Schrott weiterhelfen?");
		PopaTree4.addAnswer ("Popa, ich bin's, Feli!");
		PopaTree4.addAnswer ("Glaubst du an Geister?");

		DialogTree PopaTree4_1 = new DialogTree ("Popa", "Ne! Ich sammel nur Schrott. Solange du nicht noch mehr von meinen Schätzen haben willst, kann ich dir nicht weiterhelfen! Aber Syrx kann das bestimmt!");
		DialogTree PopaTree4_11 = new DialogTree ("Popa", "Bei seinem Tüftlerkopf weiß er schon was zu tun ist. Ich glaub er ist oben auf dem Dach. Er sah ziemlich gestresst aus für seine Verhältnisse.");
		PopaTree4_1.addSubtree (PopaTree4_11);


		DialogTree PopaTree4_2 = new DialogTree ("Popa", "Fängst du schon wieder damit an?");
		PopaTree4_2.addSubtree (PopaTree4);

		DialogTree PopaTree4_3 = new DialogTree ("Popa", "Versuchst du mir Angst einzujagen? Vergiss es! Aber red bloß nicht weiter...! Ich kann ich gar nicht hören, lalalala!");
		PopaTree4_2.addSubtree (PopaTree4);

		PopaTree4.addSubtree (PopaTree4_1);
		PopaTree4.addSubtree (PopaTree4_2);
		PopaTree4.addSubtree (PopaTree4_3);

		//SYRX Dialoge


		SyrxTree3 = new DialogTree ("Syrx","...");
		SyrxTree3.addAnswer ("Was machst du hier oben?");
		SyrxTree3.addAnswer ("Ich bin's! Feli! Sag bloß, du erkennst mich nicht?");
		SyrxTree3.addAnswer ("Ich brauche deine Hilfe! Du musst mir was zusammenbauen!");
		SyrxTree3.addAnswer ("Erzähl mir mehr über dich!");
		SyrxTree3.addAnswer ("Du bist nicht sonderlich gesprächig, was?");

		DialogTree SyrxTree3_1 = new DialogTree ("Syrx","Ich halte Ausschau. Ich habe etwas verloren, aber ich kann mich nicht erinnern wo ich es das letzte Mal gesehen habe. Es muss aber in der Nähe gewesen sein... ");
		DialogTree SyrxTree3_11 = new DialogTree ("Feli","Was hast du verloren?");
		DialogTree SyrxTree3_12 = new DialogTree ("Syrx","Meinen Hasen.");
		SyrxTree3_1.addSubtree (SyrxTree3_11);
		SyrxTree3_11.addSubtree (SyrxTree3_12);

		DialogTree SyrxTree3_2 = new DialogTree ("Syrx","...nein.");
		SyrxTree3_2.addSubtree (SyrxTree3);

		DialogTree SyrxTree3_3 = new DialogTree ("Syrx","Wenn ich meinen Hasen wiederhabe, helfe ich dir solange du mir Teile bringst.");

		DialogTree SyrxTree3_4 = new DialogTree ("Syrx","Ich will einem Fremden nichts über mich erzählen...");
		SyrxTree3_4.addSubtree (SyrxTree3);

		DialogTree SyrxTree3_5 = new DialogTree ("Syrx","...");
		SyrxTree3_5.addSubtree (SyrxTree3);

		SyrxTree3.addSubtree (SyrxTree3_1);
		SyrxTree3.addSubtree (SyrxTree3_2);
		SyrxTree3.addSubtree (SyrxTree3_3);
		SyrxTree3.addSubtree (SyrxTree3_4);
		SyrxTree3.addSubtree (SyrxTree3_5);

		SyrxTree4 = new DialogTree ("Syrx","...");
		SyrxTree4.addAnswer ("Ich hab dir deinen Hasen gebracht, jetzt musst du mir auch helfen!");
		SyrxTree4.addAnswer ("Ich bin's! Feli! Sag bloß, du erkennst mich nicht?");
		SyrxTree4.addAnswer ("Erzähl mir mehr über dich!");
		SyrxTree4.addAnswer ("Du bist nicht sonderlich gesprächig, was?");

		DialogTree SyrxTree4_1 = new DialogTree ("Syrx","Dann bring mir Teile, aus denen ich etwas bauen kann.");

		DialogTree SyrxTree4_2 = new DialogTree ("Syrx","...nein.");
		SyrxTree4_2.addSubtree (SyrxTree4);

		DialogTree SyrxTree4_3 = new DialogTree ("Syrx","Ich will einem Fremden nichts über mich erzählen...");
		SyrxTree4_3.addSubtree (SyrxTree4);

		DialogTree SyrxTree4_4 = new DialogTree ("Syrx","...");
		SyrxTree4_4.addSubtree (SyrxTree4);

		SyrxTree4.addSubtree (SyrxTree4_1);
		SyrxTree4.addSubtree (SyrxTree4_2);
		SyrxTree4.addSubtree (SyrxTree4_3);
		SyrxTree4.addSubtree (SyrxTree4_4);


		SyrxTree5 = new DialogTree ("Syrx","...");
		SyrxTree5.addAnswer ("Es funktioniert nicht!");
		SyrxTree5.addAnswer ("Du bist nicht sonderlich gesprächig, was?");


		DialogTree SyrxTree5_1 = new DialogTree ("Syrx","Es ist auch noch nicht programmiert. Das ist nicht meine Spezialität.");


		DialogTree SyrxTree5_2 = new DialogTree ("Syrx","...");
		SyrxTree5_2.addSubtree (SyrxTree5);


		SyrxTree5.addSubtree (SyrxTree5_1);
		SyrxTree5.addSubtree (SyrxTree5_2);

		//Matze

	
		//Tardos Dialoge (temp)

		TardosTree1 = new DialogTree ("Tardos","Ich kenn' dich nicht. Wer bist du?");
		TardosTree1.addAnswer ("Miau!");
		TardosTree1.addAnswer ("Miau.");
		TardosTree1.addAnswer ("Miaumiaumiau?");
		TardosTree1.addAnswer ("Na gut, dann geh ich eben...");

		DialogTree TardosTree1_1 = new DialogTree ("Tardos","Ich bin zwar eine Katze, aber ich kann sprechen.");
		TardosTree1_1.addSubtree (TardosTree1);

		DialogTree TardosTree1_2 = new DialogTree ("Tardos","Ich spreche Menschensprache...");
		TardosTree1_2.addSubtree (TardosTree1);

		DialogTree TardosTree1_3 = new DialogTree ("Tardos","...was willst du von mir?");
		TardosTree1_3.addSubtree (TardosTree1);

		DialogTree TardosTree1_4 = new DialogTree ("Tardos","Miau!");

		TardosTree1.addSubtree (TardosTree1_1);
		TardosTree1.addSubtree (TardosTree1_2);
		TardosTree1.addSubtree (TardosTree1_3);
		TardosTree1.addSubtree (TardosTree1_4);



		LuiseTrees.Add (1, LuiseTree1);
		LuiseTrees.Add (2, LuiseTree1);
		LuiseTrees.Add (3, LuiseTree1);
		LuiseTrees.Add (4, LuiseTree1);
		LuiseTrees.Add (5, LuiseTree1);
		LuiseTrees.Add (6, LuiseTree1);

		MoehreTrees.Add (1, MoehreTree2);
		MoehreTrees.Add (2, MoehreTree2);
		MoehreTrees.Add (3, MoehreTree2);
		MoehreTrees.Add (4, MoehreTree2);
		MoehreTrees.Add (5, MoehreTree2);
		MoehreTrees.Add (6, MoehreTree2);

		PopaTrees.Add (1, PopaTree2);
		PopaTrees.Add (2, PopaTree2);
		PopaTrees.Add (3, PopaTree2);
		PopaTrees.Add (4, PopaTree4);
		PopaTrees.Add (5, PopaTree4);
		PopaTrees.Add (6, PopaTree4);

		SyrxTrees.Add (1, SyrxTree3);
		SyrxTrees.Add (2, SyrxTree3);
		SyrxTrees.Add (3, SyrxTree3);
		SyrxTrees.Add (4, SyrxTree4);
		SyrxTrees.Add (5, SyrxTree5);
		SyrxTrees.Add (6, SyrxTree5);

		//Matze
		TardosTrees.Add (1, TardosTree1);
		TardosTrees.Add (2, TardosTree1);
		TardosTrees.Add (3, TardosTree1);
		TardosTrees.Add (4, TardosTree1);
		TardosTrees.Add (5, TardosTree1);
		TardosTrees.Add (6, TardosTree1);

		// TESTZWECKE!
		//panel.setRoot (getTree("Syrx",6));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public DialogTree getTree(string person, int progr)
	{

		Debug.Log (progr);

		DialogTree tmp = new DialogTree("","");

		switch (person)
		{
		case("Luise"):
			tmp = (DialogTree)LuiseTrees [progr];
				break;

		case("Möhre"):
			tmp = (DialogTree)MoehreTrees [progr];
			break;

		case("Popa"):
			tmp = (DialogTree)PopaTrees [progr];
			break;

		case("Syrx"):
			tmp = (DialogTree)SyrxTrees [progr];
			break;

		case("Mero"):
			tmp = (DialogTree)MeroTrees [progr];
			break;

			//Matze
		case("Tardos") :
			tmp = (DialogTree)TardosTrees [progr];
			break;

			default:
				break;
		}

		return tmp;
	}

	public void setDialog(DialogTree tree)
	{
		panel.setRoot (tree);
		panel.setTextFinished (false);
	}

	public void activatePanel()
	{
		panel.showCanvas (true);
	}
}
