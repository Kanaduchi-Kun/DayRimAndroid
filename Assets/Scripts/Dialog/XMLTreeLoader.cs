using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLTreeLoader : MonoBehaviour {

    // Use this for initialization
    void Start() {


        XmlDocument xmlTree = new XmlDocument();
        xmlTree.Load(Application.dataPath + "/Dialoge/testtree.xml");

        //XmlNodeList node = xmlTree.GetElementsByTagName("dialogtree");
        XmlNodeList node = xmlTree.GetElementsByTagName("dialogtree");

        foreach (XmlNode dialogNode in node)
        {
            Debug.Log(dialogNode.ParentNode);
        }


       

        //foreach(XMLNo)

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}


