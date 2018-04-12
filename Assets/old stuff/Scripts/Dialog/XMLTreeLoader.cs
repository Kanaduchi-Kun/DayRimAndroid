using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLTreeLoader : MonoBehaviour {

    DialogTree rootDialogNode;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Dialog please!"))
        {
            DialogPanel.s_instance.setRoot(rootDialogNode);


            DialogPanel.s_instance.setTextFinished(false);
            DialogPanel.s_instance.showCanvas(true);
        }
    }

        // Use this for initialization
        void Start() {

        

        XmlDocument xmlTree = new XmlDocument();
        xmlTree.Load(Application.dataPath + "/Dialoge/test.xml");

        //XmlNodeList node = xmlTree.GetElementsByTagName("dialogtree");
        XmlNodeList nodeList = xmlTree.GetElementsByTagName("dialogtree");
        XmlNode rootNodeXML = nodeList[0];

        /*foreach (XmlNode node in rootNodeXML)
        {
            Debug.Log(node.LocalName);
        }*/



        rootDialogNode = new DialogTree(rootNodeXML.ChildNodes[0].InnerText, rootNodeXML.ChildNodes[1].InnerText);

        Traverse(rootNodeXML, rootDialogNode);
        rootDialogNode = rootDialogNode.getSubTree(0);

        //Debug.Log(rootDialogNode.subTrees.Count + "is the name!");

        //Debug.Log(rootNode.ChildNodes);

        //XmlNode node = xmlTree.LastChild;
        //Debug.Log(node.ChildNodes.Count);

        //foreach (XmlNode dialogNode in node)
        //{

        //}




        //foreach(XMLNo)

    }
	
    void Traverse(XmlNode n, DialogTree fatherNode)
    {
        // Ein neues Dialog Tree Objekt wird erstellt und bekommt den ersten und zweiten inner tag des akuellen dialogtree xml knotens mit
        DialogTree tmp = new DialogTree(n.ChildNodes[0].InnerText, n.ChildNodes[1].InnerText);
        fatherNode.addSubtree(tmp);

        //Debug.Log(n.ChildNodes[0].InnerText + "    " + n.ChildNodes[1].InnerText);
        //XmlNodeList nodelist;

        foreach(XmlNode children in n)
        {
            if(children.LocalName.Equals("dialogtree"))
            {
                Traverse(children, tmp);
                //Debug.Log("Traversiert!");
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}


