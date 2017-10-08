using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchInputManager : MonoBehaviour
{
    public GameObject CharacterController;

    public GameObject LookAtButton;
    public GameObject PickUpButton;
    public GameObject TalkToButton;

    public Text infoText;

    private SwitchCharacterController switchCharacterController;
    private MoveCharacterController moveCharacterController;
    private DialogSceneManager dialogSceneManager;
    private LookAtDialogManager lookAtDialogManager;
   
    private GameObject selectedObject;
    private Vector3 target;
    private float distance = 10;
    private int interaction;

    private Ray ray;
    private RaycastHit rayHit;

    private Vector3 touchPosition;
    private Vector3 lookPosition;
    private Vector3 talkPosition;
    private Vector3 pickPosition;

    //vanessas quatsch
    private bool changeScene = false;
    public GameObject pfeil;
    public GameObject x;
    public GameObject pfeil_Kran;
    public GameObject x_Kran;
    public static ItemManager manager;
    public GameObject tipp;
    private int tippCount = 0;
    // private Animator animator;

    public GameObject Dialog_Panel;
	public DialogManager Dialog_Manager;


    void Start()
    {
        SceneNameManager.lastScene = SceneManager.GetActiveScene().name;
        SceneNameManager.lastIngameScene = SceneManager.GetActiveScene().name;
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INGAME;

        switchCharacterController = CharacterController.GetComponent<SwitchCharacterController>();
        moveCharacterController = CharacterController.GetComponent<MoveCharacterController>();

        dialogSceneManager = this.GetComponent<DialogSceneManager>();

        interaction = -1;

        SetInteraction(false, false, false);
    }

    void Update()
    {

        if (ActiveCharacter.reachedGoal)
            interact();

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                Touch touch = Input.touches[0];
                touchPosition = Input.GetTouch(0).position;

                switch (ActiveGameMode.GAMEMODE) // NOCH ZU ERWEITERN
                {
                    case ActiveGameMode.GameModes.INGAME:
                        HandleTouchIngameScene(touch);
                        break;
                    case ActiveGameMode.GameModes.ITEMCOMBI:
                        HandleTouchCombiScene(touch);
                        break;
                    default:
                        //Debug.Log("NOT INGAME GAMEMODE");
                        break;
                }
            }
        }

    }

    private void HandleTouchIngameScene(Touch touch)
    {
        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
            {
                GameObject hitObject = rayHit.transform.gameObject;
                selectedObject = hitObject;
                moveCharacterController.moveCharacterTo(hitObject.transform.position);

                SetPositionsToTouchPosition();
                SetButtonPositions();

                if (hitObject.name == "Felix")
                {
                    if (hitObject.tag != "NPC" && hitObject.tag != "ActiveCharacter")
                    {
                        if (ActiveCharacter.activeCharacter.name == "Feli")
                            hitObject.tag = "NPC";
                    }
                }

                if (hitObject.tag == "ActiveCharacter" || hitObject.tag == "NPC")
                {
                 //   Debug.Log("FELIX ODER FELI");
                    lookPosition.x -= 50;
                    lookPosition.y += 30;

                    talkPosition.x += 50;
                    talkPosition.y += 30;

                    SetButtonPositions();

                    SetInteraction(true, true, false);
                }
                else if (hitObject.tag == "PickableItem")
                {
                    lookPosition.x -= 50;
                    lookPosition.y += 30;

                    pickPosition.x += 50;
                    pickPosition.y += 30;

                    SetButtonPositions();

                    SetInteraction(true, false, true);
           

                }
                else if (hitObject.tag == "UnpickableItem")
                {
                    
                   // if (itemSingleInteraction.singleInteraction)
                    //    infoText.text = "Ich interagiere mit diesem Objekt"; // ENTSPRECHEND ETWAS TUN, BETRETEN ODER SO, KA
                   // else
                   //     infoText.text = "Mit diesem Objekt ist keine Interaktion möglich";

                    lookPosition.y += 30;

                    SetButtonPositions();

                    SetInteraction(true, false, false);
                }

                

                
                if (hitObject.name == "Door")
                {

                    pfeil.SetActive(true);
                    x.SetActive(true);

                    changeScene = true;
                }

                if (hitObject.name == "Kran_Entry")
                {

                    pfeil_Kran.SetActive(true);
                    x_Kran.SetActive(true);

                    changeScene = true;
                }

                else if (changeScene)
                {
                    if (hitObject.tag == "OpenJunkyard01")
                    {
                        SceneManager.LoadScene("Junkyard_Scene_01");
                        if (ItemManager.falleGestellt == true)
                        {
                            SceneNameManager.szeneGewechselt = true;
                        }
                        changeScene = false;
                        pfeil.SetActive(false);
                        x.SetActive(false);
                    }

                    else if (hitObject.tag == "OpenKranScene")
                    {
                        SceneManager.LoadScene("Kran_Szene");
                        if (ItemManager.falleGestellt == true)
                        {
                            SceneNameManager.szeneGewechselt = true;
                        }
                        changeScene = false;
                        pfeil.SetActive(false);
                        x.SetActive(false);
                    }

                    else if (hitObject.tag == "OpenJunkyardIndoor")
                    {
                        
                        SceneManager.LoadScene("Junkyard_Indoor_Scene_03");
                        if(ItemManager.falleGestellt == true)
                        {
                            SceneNameManager.szeneGewechselt = true;
                        }
                        changeScene = false;
                        pfeil.SetActive(false);
                        x.SetActive(false);
                    }

                    else if (hitObject.name == "x")
                    {
                        changeScene = false;
                        pfeil.SetActive(false);
                        x.SetActive(false);
                    }
                }
            }
            else
            {
                SetInteraction(false, false, false);
            }
        }
    }

    private void HandleTouchCombiScene(Touch touch)
    {
        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            //    GameObject.Find("TestText").GetComponent<Text>().text = "CHICK CHICK CHICK";

            if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
            {
                // GameObject.Find("TestText").GetComponent<Text>().text = "HIT HIT HIT";

                GameObject hitObject = rayHit.transform.gameObject;
                selectedObject = hitObject;

                //für den Fall der Sprühdose als Beispiel


                  //GameObject.Find("TestText").GetComponent<Text>().text = hitObject.name;


                    if (ItemCombinations.isItemSceneCombiActive)
                    {
                        ItemManager.SceneItemCombinations(selectedObject);
                    }
                
            }
        }
    }

    private void SetInteraction(bool stateA, bool stateB, bool stateC)
    {
        LookAtButton.SetActive(stateA);
        TalkToButton.SetActive(stateB);
        PickUpButton.SetActive(stateC);
    }

    private void SetPositionsToTouchPosition()
    {
        lookPosition = touchPosition;
        pickPosition = touchPosition;
        talkPosition = touchPosition;
    }

    private void SetButtonPositions()
    {
        LookAtButton.transform.position = lookPosition;
        PickUpButton.transform.position = pickPosition;
        TalkToButton.transform.position = talkPosition;
    }

    public void interact()
    {
        if (!ActiveCharacter.interacted)
        {
            switch (interaction)
            {
                case 0:
                    //switchCharacterController.switchActiveCharacter();
                    break;
                case 1:
                    handleLookAt();
                    break;
                case 2:
                    handlePickUp();
                    break;
                case 3:
                    handleTalkTo();
                    break;
            }
            ActiveCharacter.interacted = true;
        }
    }

    public void switchCharacterOnButton()
    {
        interaction = -1;
        ActiveCharacter.interacted = false;
        ActiveCharacter.reachedGoal = false;
        switchCharacterController.switchActiveCharacter();
    }

    public void LookAt() // Steuerung über das Element
    {
        interaction = 1;
        ActiveCharacter.interacted = false;
        ActiveCharacter.reachedGoal = false;
    }

    public void handleLookAt()
    {
        lookAtDialogManager = selectedObject.GetComponent<LookAtDialogManager>();
        SetInteraction(false, false, false);
		if(lookAtDialogManager != null)
			lookAtDialogManager.showDialogText(infoText);
        interaction = -1;
    }


    public void TalkTo() // Steuerung über das Element
    {
        interaction = 3;
        ActiveCharacter.interacted = false;
        ActiveCharacter.reachedGoal = false;
    }

    public void handleTalkTo()
    {
        SetInteraction(false, false, false);
        lookAtDialogManager = selectedObject.GetComponent<LookAtDialogManager>();

        if (selectedObject.name == ActiveCharacter.activeCharacter.name || selectedObject.name == ActiveCharacter.inactiveCharacter.name)
        {
			lookAtDialogManager.showDialogText(infoText);
            // Anschauen Dialog öffnen, da Spieler sonst mit sich selbst redet
        }
        else
        {
            Dialog_Manager.setDialog(Dialog_Manager.getTree(selectedObject.name, ProgressManager.getProgressInt()));
            Dialog_Manager.activatePanel();
            //Dialog_Panel.active = true;
        }
        interaction = -1;
    }

    public void PickUp() // Steuerung über das Element
    {
        interaction = 2;
        ActiveCharacter.interacted = false;
        ActiveCharacter.reachedGoal = false;
    }

    public void handlePickUp()
    {
        SetInteraction(false, false, false);
        lookAtDialogManager = selectedObject.GetComponent<LookAtDialogManager>();

        if (lookAtDialogManager != null)
        {
            lookAtDialogManager.showDialogText(infoText);
        }

        

        if (selectedObject.name == "HaseInFalle")
        {
            if (ItemManager.tardosZufrieden == true)
            {
                ItemManager.addItem(selectedObject.GetComponent<Item>());
                ItemManager.isHaseInFalle = true;
                ItemManager.falleGestellt = false;
                selectedObject.SetActive(false);
            }
            
        }
        else {
            //Debug.Log(selectedObject.name);
            ItemManager.addItem(selectedObject.GetComponent<Item>());
            selectedObject.SetActive(false);
        }

        interaction = -1;
    }

    public void ClearInfoText()
    {
        infoText.text = "";
    }

    public void ChangeToScene01()
    {
        SceneManager.LoadScene(SceneNameManager.junkyardFirst);
        if (ItemManager.falleGestellt == true)
        {
            SceneNameManager.szeneGewechselt = true;
        }
    }

    public void ChangeToScene02()
    {
        SceneManager.LoadScene(SceneNameManager.junkyardSecond);
        if (ItemManager.falleGestellt == true)
        {
            SceneNameManager.szeneGewechselt = true;
        }
    }
}