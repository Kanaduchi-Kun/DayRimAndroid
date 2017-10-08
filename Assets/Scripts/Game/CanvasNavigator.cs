using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasNavigator : MonoBehaviour {

    public static bool inventar_isActive = false;
    public static bool isKranActive = false;
    public GameObject kranAuto;
    public GameObject kranAutoRechts;
    public GameObject kranAutoLinks;
    public GameObject sceneWechselButton;
    public GameObject HaseInFalle;
    public GameObject Köder;
    public GameObject Tardos;

    //Kran Verschiebung
    public GameObject Kran_Teil_1;
    public GameObject Kran_Teil_2;
    public GameObject Kran_Teil_3;
    public GameObject Kran_Teil_4;
    public GameObject Kran_Teil_5;


    private Animation inventar;
    public GameObject Inventar_Panel;
    public GameObject Invenape;

    public GameObject SceneItemButton;
    private string slot;

    void Start () 
    {

        inventar = Inventar_Panel.GetComponent<Animation>();
        SceneItemButton.SetActive(false);

        if (SceneManager.GetActiveScene().name == "Junkyard_Scene_01")
        {

            if (isKranActive == true)
            {
                Kran_Teil_1.transform.eulerAngles = new Vector3(0, 0, -47.4418f);
                Kran_Teil_1.transform.position = new Vector3(-6.24f, 5.3f, 0);

                Kran_Teil_3.transform.position = new Vector3(-10.92f, 1.15f, 0);
                Kran_Teil_4.transform.position = new Vector3(-12.19f, -1.92f, 0);
                Kran_Teil_5.transform.position = new Vector3(-9.8f, -1.82f, 0);

                sceneWechselButton.SetActive(true);

                kranAuto.SetActive(false);
                kranAutoLinks.SetActive(true);
                kranAutoRechts.SetActive(true);
            }

            if (ItemManager.falleGestellt == true)
            {
                if (SceneNameManager.szeneGewechselt == true)
                {
                    Köder.SetActive(false);

                    if (ItemManager.isHaseInFalle == false)
                    {
                        // Debug.Log("KA");
                        
                        //ItemManager.falleGestellt = false;
                        HaseInFalle.SetActive(true);
                        Tardos.SetActive(true);
                    }
                }
            }

            foreach (string s in ItemManager.Screen_01)
            {
                if (s != null)
                {
                    GameObject item = GameObject.Find(s);
                    if (item != null)
                    {
                        item.SetActive(false);
                    }
                }
            }
        }


            if (SceneManager.GetActiveScene().name == "Junkyard_Scene_02")
            {
                foreach (string s in ItemManager.Screen_02)
                {
                if (s != null)
                {
                    GameObject item = GameObject.Find(s);
                    if (item != null)
                    {
                        item.SetActive(false);
                    }
                }
                }
            }

            if (SceneManager.GetActiveScene().name == "Junkyard_Indoor_Scene_03")
            {
            foreach (string s in ItemManager.Screen_03)
            {
                if (s != null)
                {
                    GameObject item = GameObject.Find(s);
                    if (item != null)
                    {
                        item.SetActive(false);
                    }
                }
            }
            }
     }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Junkyard_Scene_01")
        {
            if (ItemManager.falleGestellt == true)
            {
                if (SceneNameManager.szeneGewechselt == false)
                {
                    Köder.active = true;
                }
            }
        }
       
    }
    
    public void OpenDialog()
    {
      
        if (!inventar_isActive)
        {
            inventar.Play("Inventar_IN");
            inventar_isActive = true;
            ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INVENTORY;
            
            Invenape.SetActive(false);

            setAllItems();
        }
    }

    //NEU__________________________________________________
    public void deleteAllItems()
    {
        foreach (Item i in ItemManager.getInventar())
        {
            Destroy(GameObject.Find(i.getName()));
        }
    }

    public void setAllItems()
    {
        //________________________ITEMS ANORDNEN_____________________________________________
        //GameSafe.Load();

       // manager.LoadInventar();
       GameObject itemSlots = GameObject.Find("ItemSlots").GetComponent<GameObject>();

        for (int i = 0; i < ItemManager.getAnzahlItems(); i++)
        {
            int o = i + 1;

            if (o < 10)
            {
                slot = "Slot_0" + o;
            }
            else
            {
                slot = "Slot_" + o;
            }

            GameObject obj = new GameObject(ItemManager.getItem(i).getName());
            obj.AddComponent<Image>().sprite = ItemManager.getItem(i).getSprite();
            obj.AddComponent<Item>();
            obj.GetComponent<Item>().name = ItemManager.getItem(i).getName();
            obj.GetComponent<Item>().beschreibung = ItemManager.getItem(i).getBeschreibung();
            obj.GetComponent<Item>().verwendungsCode = ItemManager.getItem(i).getCode();
            obj.GetComponent<Item>().aussehen = ItemManager.getItem(i).getSprite();
            obj.transform.parent = GameObject.Find(slot).transform;
            obj.transform.position = obj.transform.parent.position;
            //sprite größen gleich machen -> anpassen!!
            obj.transform.localScale = new Vector3(0.85f, 0.85f, 0);
        }
    }

    public void ExitDialog()
    {
        GameObject.Find("Dialog_Panel").SetActive(false);
    }
    
}
