using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;



public class DialogTree {

	
	public string name;
	
	public string monologText;

	
	
	//public ArrayList answers; 

	
	public ArrayList subTrees;


	public DialogTree(string n, string text)
	{
		name = n;
		monologText = text;
		//answers = new ArrayList ();
		subTrees = new ArrayList ();
	}

	public string getName()
	{
		return name;
	}

	public string getMonologText()
	{
		return monologText;
	}

    
	public string getAnswerText(int i)
	{
        DialogTree sub = (DialogTree) subTrees[i];


        return sub.getMonologText();
	}
    
	public DialogTree getSubTree(int i)
	{
		return (DialogTree)subTrees [i];
	}

	public ArrayList getAnswerTrees()
	{
		return subTrees;
	}

	public void addAnswer(string a)
	{
		//answers.Add (a);
	}

	public void addSubtree(DialogTree tree)
	{
		subTrees.Add (tree);
	}

	public bool hasNext()
	{
		bool tmp = false;

		if (subTrees.Count > 0)
		{
			tmp = true;
		}

		return tmp;

	}

	public bool isQuestion()
	{
		bool tmp = false;

		if (subTrees.Count > 2)
			tmp = true;

		return tmp;
	}
}
	