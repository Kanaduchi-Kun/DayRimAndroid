using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ItemManager 
{
    //item in szene löschen
    public static ArrayList Screen_01 = new ArrayList(); //außen1
    public static ArrayList Screen_02 = new ArrayList(); //außen2
    public static ArrayList Screen_03 = new ArrayList(); //innen

    public static ArrayList inventar = new ArrayList();
    public static ArrayList inventarSafe;
    public static Item SceneItem;

    public static CanvasNavigator navi = GameObject.Find("Canvas").GetComponent<CanvasNavigator>();
    private static ItemCombinations combiVar = new ItemCombinations();

    private static bool isSyrxUberzeugt = false;
    public static bool isHaseInFalle = false;
    public static bool tardosZufrieden = false;
    public static bool falleGestellt = false;
    



    public static void addItem(Item i)
	{
		inventar.Add (i);
        //___________________________________________
        // inventarSafe.Add(i.name);
        //GameSafe.Safe();

        switch (i.getName())
        {
            case "GummiBall":
                Screen_01.Add("GummiBall");
                break;
            case "Gummipflanze":
                Screen_01.Add("Gummipflanze");
                break;
            case "OrigamiHase":
                Screen_01.Add("HaseInFalle");
                break;
            case "Schere":
                Screen_03.Add("Schere");
                break;
            case "ChibiMoehre":
                Screen_03.Add("ChibiMoehre");
                break;
            case "BärenMauseFalle":
                Screen_03.Add("BärenMauseFalle");
                break;
            case "Spruehdose":
                Screen_02.Add("Spruehdose");
                break;
            case "Fischgraete":
                Screen_02.Add("Fischgraete");
                break;
        }
    }

	public static void deleteItem (Item i)
	{
		inventar.Remove (i);
        inventarSafe.Remove(i.name);
	}

	public static Item getItem(int i)
	{
		return (Item) inventar[i];
	}

    public static int getAnzahlItems()
    {
        int i = 0;

        foreach (Item o  in inventar)
        {
            i++;
        }

        return i;
    }


    public static ArrayList getInventar()
    {
        ArrayList itemList = inventar;
        return (ArrayList) itemList;
    }


    public static void possibleItemCombinations(Item i1, Item i2)
	{
        //test einer objektkombi
        // z.b. abfrage der namen
        
        //POPA RÄTSEL
        // Roter Ball = Gummiball + Dose
        if (i1.getName () == "GummiBall" && i2.getName () == "Spruehdose" || i1.getName () == "Spruehdose" && i2.getName () == "GummiBall")
        {
            navi.deleteAllItems();
            searchItemAndRemove("GummiBall");
            Sprite s = Resources.Load<Sprite>("RoterBall");
            Item newItem = new Item("RoterBall", "Oh weh, oh je... ! Das sieht aber schon ziemlich lecker aus. Aber irgendwas fehlt noch...hmm", 1, s);
            inventar.Add (newItem);
            navi.setAllItems();
            combiVar.playSound(0);
        }

        //Gummiball mit Grün = Gummiball + Grünzeug
        else if (i1.getName() == "GummiBall" && i2.getName() == "Grünstück" || i1.getName() == "Grünstück" && i2.getName() == "GummiBall")
        {
            navi.deleteAllItems();
            searchItemAndRemove("Grünstück");
            searchItemAndRemove("GummiBall");
            Sprite s = Resources.Load<Sprite>("GummiballMitGrün");
            inventar.Add(new Item("GummiballMitGrün", "Das könnte was werden. Was genau... hm. Vielleicht eine Art Frucht. Aber da fehlt noch was. Früchte sind doch nicht blau.", 2, s));
            navi.setAllItems();
            combiVar.playSound(0);
        }

        //Pfirsischtomate = GummiballMitGrün + Sprühdose
        else if (i1.getName() == "GummiballMitGrün" && i2.getName() == "Spruehdose" || i1.getName() == "Spruehdose" && i2.getName() == "GummiballMitGrün")
        {
            navi.deleteAllItems();
            searchItemAndRemove("GummiballMitGrün");
            Sprite s = Resources.Load<Sprite>("Pfirsischtomate");
            inventar.Add(new Item("Pfirsischtomate", "Saftig lackierte Gummiball - Pfirsichtomate  wie sie im Buche steht! Genau das richtige für diesen kleinen verfressenen Chaot...", 3, s));
            navi.setAllItems();
            combiVar.playSound(0);
        }

        // Pfirsichtomate = RoterBall + Grünstück
        else if (i1.getName() == "RoterBall" && i2.getName() == "Grünstück" || i1.getName() == "Grünstück" && i2.getName() == "RoterBall")
        {
            navi.deleteAllItems();
            searchItemAndRemove("Grünstück");
            searchItemAndRemove("RoterBall");
            Sprite s = Resources.Load<Sprite>("Pfirsischtomate");
            Item newItem = new Item("Pfirsischtomate", "Das ist mal eine saftig lackierte Gummiball-Pfirsichtomate wie sie im Buche steht! Genau das richtige für diesen kleinen verfressenen Chaot...", 4, s);
            inventar.Add(newItem);
            navi.setAllItems();
            combiVar.playSound(0);
        }


        // Grünstück = Gummipflanze + Schere
        else if (i1.getName() == "Schere" && i2.getName() == "Gummipflanze" || i1.getName() == "Gummipflanze" && i2.getName() == "Schere")
        {
            navi.deleteAllItems();
            searchItemAndRemove("Gummipflanze");
            Sprite s = Resources.Load<Sprite>("Grünstück");
            inventar.Add(new Item("Grünstück", "Ein grünes Stück Plastik. Damit hätte ich nicht gerechnet. Es war doch ein Teil des Kaktus.", 5, s));
            navi.setAllItems();
            combiVar.playSound(0);
        }


        //SYRX RÄTSEL

        else if (i1.getName() == "BärenMauseFalle" && i2.getName() == "ChibiMoehre" || i1.getName() == "ChibiMoehre" && i2.getName() == "BärenMauseFalle")
        {
            navi.deleteAllItems();
            searchItemAndRemove("ChibiMoehre");
            searchItemAndRemove("BärenMauseFalle");
            Sprite s = Resources.Load<Sprite>("Köder");
            inventar.Add(new Item("Köder", "Ein perfekter Köder für Schrott und Papiertiere.", 8, s));
            navi.setAllItems();
            combiVar.playSound(0);
        }
        else
            combiVar.playSound(1);
    }
	

    public static void SceneItemCombinations(GameObject RandomSceneObject)
    {
      //  Debug.Log(RandomSceneObject.name);
        
        //Pfirsischtomate Popa geben und gegen Schrott eintauschen
        if (SceneItem.getName() == "Pfirsischtomate" && RandomSceneObject.name == "Popa")
        {
            
            navi.deleteAllItems();
            searchItemAndRemove("Pfirsischtomate");
            Sprite s = Resources.Load<Sprite>("Schrotthaufen");
            inventar.Add(new Item("Schrotthaufen", "Ein riesiger Haufen Schrott. Was soll ich denn damit? Wo hat die das Zeug eigentlich immer her? Ist das eine Muschel? HÄÄ!?!?", 6, s));
            combiVar.SceneItem(); //Scene KombiModus Löschen
            ProgressManager.STORYPROGRESS = ProgressManager.ProgressStates.GOTJUNK;
            //navi.setAllItems();
        }

        else if (SceneItem.getName() == "Schrotthaufen" && RandomSceneObject.name == "Syrx")
        {
            if (isSyrxUberzeugt) {
                navi.deleteAllItems();
                searchItemAndRemove("Schrotthaufen");
                Sprite s = Resources.Load<Sprite>("Muschel-Phone");
                inventar.Add(new Item("Muschel-Phone", "Ok, ein Mussle-Phone... Sowas hab ich auch noch nie gehört. Jetzt müssen wir es nur noch zum Leben erwecken. Da fehlt noch ein Chip oder sowas.", 7, s));
                combiVar.SceneItem(); //Scene KombiModus Löschen
                ProgressManager.STORYPROGRESS = ProgressManager.ProgressStates.GOTBUILD;
                //navi.setAllItems();
            }
        }

        else if (SceneItem.getName() == "OrigamiHase" && RandomSceneObject.name == "Syrx")
        {
            //ACHTUNG // MIT YASMIN EINBAUEN
            Debug.Log("Du hast Syrx überzeugt dir zu helfen. Ab diesem Moment kann der Spieler sich von Syrx das Muschel-Phone aus Popas Schrott zusammen bauen.");
            isSyrxUberzeugt = true;

            navi.deleteAllItems();
            searchItemAndRemove("OrigamiHase");
            //Sprite s = Resources.Load<Sprite>("Muschel-Phone");
            //inventar.Add(new Item("Muschel-Phone", "Ok, ein Mussle-Phone... Sowas hab ich auch noch nie gehört. Aber gut, hoffen wir, dass es funktioniert! GOGO Felix! YOLO!", 7, s));
            combiVar.SceneItem(); //Scene KombiModus Löschen

            //navi.setAllItems();
        }


        //Falle aufstellen
        else if (SceneItem.getName() == "Köder" && RandomSceneObject.name == "Wohnmobil_oben")
        {
            navi.deleteAllItems();
            searchItemAndRemove("Köder");
            //SZENENWECHSEL//isHaseInFalle = true;
            falleGestellt = true;
            //navi.HaseInFalle.active = true;
            //delete altes Tardos sprite. neues einfügen mit fisch. im Maul
            //bool setzen, dass man Hase aus falle nehmen kann //bool noch erzeugen1!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
            combiVar.SceneItem(); //Scene KombiModus Löschen

            //navi.setAllItems();
        }

        else if (SceneItem.getName() == "Fischgraete" && RandomSceneObject.name == "Tardos")
        {
            navi.deleteAllItems();
            searchItemAndRemove("Fischgraete");
            tardosZufrieden = true;
            //delete altes Tardos sprite. neues einfügen mit fisch. im Maul
            //bool setzen, dass man Hase aus falle nehmen kann //bool noch erzeugen1!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
            combiVar.SceneItem(); //Scene KombiModus Löschen

            //navi.setAllItems();
        }

        else if (SceneItem.getName() == "Muschel-Phone" && RandomSceneObject.name == "Möhre")
        {
            navi.deleteAllItems();
            searchItemAndRemove("Muschel-Phone");
            Sprite s = Resources.Load<Sprite>("Muschel-Phone-Ready");
            inventar.Add(new Item("Muschel-Phone-Ready", "GOGO Felix! Probier's aus! YOLO!!!.", 8, s));

            Debug.Log("ENDLICH IST ES FUNkTIONSFÄHIG1!");

            //evtl neues Sprite mit aktiviertem Muschel-Phone
            combiVar.SceneItem(); //Scene KombiModus Löschen
           
            //Items doppelt
            // navi.setAllItems();
        }

        else if (SceneItem.getName() == "Spruehdose" && RandomSceneObject.name == "Karton_Luise")
        {
            navi.deleteAllItems();
            SceneManager.LoadScene(SceneNameManager.drawScene);
            /*searchItemAndRemove("Muschel-Phone");
            Sprite s = Resources.Load<Sprite>("Muschel-Phone-Ready");
            inventar.Add(new Item("Muschel-Phone-Ready", "GOGO Felix! Probier's aus! YOLO!!!.", 8, s));

            Debug.Log("ENDLICH IST ES FUNkTIONSFÄHIG1!");

            //evtl neues Sprite mit aktiviertem Muschel-Phone
            combiVar.SceneItem(); //Scene KombiModus Löschen

            //Items doppelt
            // navi.setAllItems();*/
        }
    }

    private static void searchItemAndRemove(string item)
    {
        for (int i = 0; i < getAnzahlItems(); i++)
        {
            if (getItem(i).getName() == item)
            {
                getInventar().RemoveAt(i);
                ItemCombinations.isRemoved = true;
                //inventarSafe.RemoveAt(i);
            }
        }  

        //__________________________________________________________

    }

   /* public void LoadInventar()
    {
        GameSafe.Load();
        
    }*/
}
