using UnityEngine;
using System.Collections;

public class ItemMenuTest : MonoBehaviour {

	//public ItemManager manager;

	// Use this for initialization
	void Start () {
	
		//manager = new ItemManager ();

        ItemManager.addItem(new Item("Gummiball", "Supersaftiger Gummiball", 11, null));
        ItemManager.addItem(new Item("Dose", "Rote Sprühdose", 12, null));
        ItemManager.addItem(new Item("Plastikpflanze", "Ein Plastikflaschen-Konstrukt. Irgendwie schön!", 12, null));

		Debug.Log ("Vor dem Kombinieren");
		foreach (Item i in ItemManager.inventar) {
			Debug.Log (i.getName());
		}

		Debug.Log ("Nach Kombinationsversuch Ball mit Ball");
        ItemManager.possibleItemCombinations(ItemManager.getItem(0), ItemManager.getItem(0));
		foreach (Item i in ItemManager.inventar) {
			Debug.Log (i.getName());
		}

        // Weg 1
        /*
		Debug.Log ("Nach Kombinationsversuch Ball mit Dose");
		manager.kombinieren (manager.getItem(0), manager.getItem(1));
		foreach (Item i in manager.inventar) {
			Debug.Log (i.getName());
		}
		manager.kombinieren (manager.getItem (1), manager.getItem (2));
		foreach (Item i in manager.inventar) {
			Debug.Log (i.getName());
		}
		*/

        //Weg 2
        ItemManager.possibleItemCombinations(ItemManager.getItem(0), ItemManager.getItem(2));
		foreach (Item i in ItemManager.inventar) {
			Debug.Log (i.getName());
		}
        ItemManager.possibleItemCombinations(ItemManager.getItem (0), ItemManager.getItem (1));
		foreach (Item i in ItemManager.inventar) {
			Debug.Log (i.getName());
		}

			

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
