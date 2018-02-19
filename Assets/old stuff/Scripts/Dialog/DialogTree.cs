using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;



public class DialogTree {

	[XmlAttribute("name")]
	public string name;
	[XmlAttribute("text")]
	public string monologText;

	//[XmlArray("Answer")]
	//[XmlArrayItem("atext")]
	[XmlArray("Answer")]
	public ArrayList answers; 

	//[XmlArray("Answer")]
	//[XmlArrayItem("atext")]
	[XmlArray("Tree")]
	public ArrayList subTrees;


	public DialogTree(string n, string text)
	{
		name = n;
		monologText = text;
		answers = new ArrayList ();
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
		return (string) answers[i];
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
		answers.Add (a);
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

		if (answers.Count > 1)
			tmp = true;

		return tmp;
	}
}
	