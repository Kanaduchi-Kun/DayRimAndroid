using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCombinations : MonoBehaviour {

    //Sound
    private SoundManager soundManager;

    //Test zum schließen des Inventars für SceneItemKombi
    private Animation inventar;
    public GameObject Inventar_Panel;
    public GameObject Invenape;
    public GameObject watchMode;

    private Button watchButton;
    public static Item FixedItem;
    private Item TestItem;
    private GameObject slot;

    public GameObject SceneItemButton;

    //zum interagieren mit der szene, bezug zu detecttouches
    public static bool isItemSceneCombiActive = false;
    public static bool isWatchModeActive = false;
    public static Item selectedItem;

    //ItemSprites
    public Image test;
   // public ItemManager manager;
    public static bool isRemoved = false;
    public bool load;

    //private CanvasNavigator navi;

    // Use this for initialization
    void Start () 
    {
        inventar = Inventar_Panel.GetComponent<Animation>();
        soundManager = Inventar_Panel.GetComponent<SoundManager>();

       // manager = TouchInputManager.getManager();
        //navi = new CanvasNavigator();

       // if(load)
         //   manager.LoadInventar();
    }
	
	// Update is called once per frame
	void Update () {

        if (isRemoved)
        {
            if (FixedItem != null)
            {
                FixedItem.transform.parent.GetComponent<Button>().GetComponent<Image>().color = Color.white;
                FixedItem = null;
                
            }
            isRemoved = false;
        }

        if (isWatchModeActive)
        {
            if (FixedItem != null)
            {
                getItemInformation(FixedItem);
            }
        }

   }

    /*public void SaveGame()
    {
        //SPIEL SPEICHERN
        GameSafe.Safe();
    }*/


    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void watchItemInfo(Button watchB)
    {
        watchButton = watchB;

        if (!isWatchModeActive)
        {
            isWatchModeActive = true;
            watchButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            isWatchModeActive = false;
            watchButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void getItemInformation(Item i)
    {
        watchMode.SetActive(true);
        //GameObject.Find("ItemImage").GetComponent<Image>().sprite = ItemSlot.transform.GetChild(0).GetComponentInChildren<Item>().getSprite();
        GameObject.Find("ItemImage").GetComponent<Image>().sprite = i.getSprite();
        //GameObject.Find("ItemInfoText").GetComponent<Text>().text = ItemSlot.transform.GetChild(0).GetComponentInChildren<Item>().getBeschreibung();
        GameObject.Find("ItemInfoText").GetComponent<Text>().text = i.getBeschreibung();
    }

    public void closeItemInfo()
    {
        //   FixedItem.transform.parent.GetComponent<Button>().GetComponent<Image>().color = Color.white;
        //   FixedItem = null;
        // Debug.Log("MIAU");
        //watchButton.GetComponent<Image>().color = Color.white;
        //isWatchModeActive = false;
        if(FixedItem != null)
        {
            FixedItem.transform.parent.GetComponent<Button>().GetComponent<Image>().color = Color.white;
            FixedItem = null;
        }
        
        watchMode.SetActive(false);
    }
        

    public void CombineItem(GameObject ItemSlot)
    {
        slot = ItemSlot;

        if (isWatchModeActive)
        {
            if (slot != null)
            {
                getItemInformation(slot.transform.GetChild(0).GetComponent<Item>());
            }
        }

        else { //nicht info bekommen zu item
            if (ItemSlot.transform.childCount != 0)
            {
                if (FixedItem == null)
                {

                    ItemSlot.GetComponent<Button>().GetComponent<Image>().color = Color.gray;
                    FixedItem = ItemSlot.transform.GetChild(0).GetComponent<Item>();

                    // GameObject.Find("TestText").GetComponent<Text>().text = ItemSlot.transform.GetChild(0).GetComponent<Item>().ToString();
                    //FixedItem = ItemSlot.transform.parent.GetChild(0).GetChild(0).GetComponent<GameObject>().gameObject;
                }

                else
                {
                    if (ItemSlot.transform.childCount != 0)
                    {

                        if (FixedItem == ItemSlot.transform.GetChild(0).GetComponent<Item>())
                        {
                            ItemSlot.GetComponent<Button>().GetComponent<Image>().color = Color.white;

                            FixedItem = null;

                            if (TestItem != null)
                            {
                                //TestItem.GetComponent<Button>().GetComponent<Image>().color = Color.white;
                                TestItem = null;
                            }

                            if (test.sprite != null)
                            {
                                test.sprite = null;
                                //GameObject.Find("SceneItem").active = false;
                            }
                        }
                        else
                        {
                            TestItem = ItemSlot.transform.GetChild(0).GetComponent<Item>();

                           /* if(ItemManager == null)
                            {
                                Debug.Log("LULU");
                            }*/

                            ItemManager.possibleItemCombinations(FixedItem, TestItem);
                        }
                    }
                }
            }
        }
    }

    public void SceneCombinations()
    {
        if(FixedItem != null)
        {
            ItemManager.SceneItem = FixedItem;
            Sprite chosenItem = FixedItem.getSprite();

            FixedItem.transform.parent.GetComponent<Button>().GetComponent<Image>().color = Color.white;
            FixedItem = null;

            inventar.Play("Inventar_OUT");
            Invenape.SetActive(true);
            ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.ITEMCOMBI;

            CanvasNavigator.inventar_isActive = false; //muss drin bleiben, da Kamera und Affe sonst nicht mehr reagieren

            selectedItem = FixedItem;
            isItemSceneCombiActive = true;

            //GameObject.Find("TestText").GetComponent<Text>().text = selectedItem.name.ToString();

            SceneItemButton.SetActive(true);

            //Item aus Inventar löschen
            ItemManager.navi.deleteAllItems();
            
            
            GameObject.Find("SceneItemImage").GetComponent<Image>().sprite = chosenItem;
            GameObject.Find("SceneItemImage").transform.localScale = new Vector3(2.5f, 2.5f, 0f);
            //GameObject.Find("ItemImage").GetComponent<SpriteRenderer>().sprite = gummipflanze; 

           
        }
    }

    public void SceneItem()
    {
        GameObject.Find("SceneItem").SetActive(false);

        isItemSceneCombiActive = false;
        //FixedItem = null;
        //slot.GetComponent<Button>().GetComponent<Image>().color = Color.white;

        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INGAME;
    }

    public void closeInventar()
    {
        inventar.Play("Inventar_OUT");
        Invenape.SetActive(true);
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INGAME;
        CanvasNavigator.inventar_isActive = false;

        if (FixedItem != null)
        {
            FixedItem.transform.parent.GetComponent<Button>().GetComponent<Image>().color = Color.white;
            FixedItem = null;
        }
        //slot.GetComponent<Button>().GetComponent<Image>().color = Color.white;
       // CanvasNavigator navi = Item;
        ItemManager.navi.deleteAllItems();
    }

    public void playSound(int sound)
    {
        //.playSound(sound);
    }

    public void openMenu()
    {
        SceneManager.LoadScene(SceneNameManager.mainMenu);
    }
}
