using UnityEngine;
using System.Collections;

public class SwitchCharacterController : MonoBehaviour
{
    public GameObject felixGameObject;
    public GameObject feliGameObject;

    private PlayerCharacterController felix;
    private PlayerCharacterController feli;

    void Start()
    {
        felix = felixGameObject.GetComponent<PlayerCharacterController>();
        feli = feliGameObject.GetComponent<PlayerCharacterController>();

        ActiveCharacter.setCharacters();
        setActiveCharacter();
    }

    public void switchActiveCharacter()
    {
        felix.activeCharacter = !felix.activeCharacter;
        feli.activeCharacter = !feli.activeCharacter;

        setActiveCharacter();

        ActiveCharacter.reachedGoal = false;
    }

    private void setActiveCharacter()
    {
        if (feli.activeCharacter)
        {
            ActiveCharacter.switchCharacterPosition();

            felix.activeCharacter = false;

            ActiveCharacter.inactiveCharacter.transform.parent = null;

            ActiveCharacter.activeCharacter = feliGameObject;
            ActiveCharacter.inactiveCharacter = felixGameObject;

            ActiveCharacter.inactiveCharacter.transform.parent = ActiveCharacter.activeCharacter.transform;

            felixGameObject.tag = "NPC";
            feliGameObject.tag = "ActiveCharacter";
        }
        else if (felix.activeCharacter)
        {
            ActiveCharacter.switchCharacterPosition();

            feli.activeCharacter = false;

            ActiveCharacter.inactiveCharacter.transform.parent = null;

            ActiveCharacter.activeCharacter = felixGameObject;
            ActiveCharacter.inactiveCharacter = feliGameObject;

            ActiveCharacter.inactiveCharacter.transform.parent = ActiveCharacter.activeCharacter.transform;

            feliGameObject.tag = "NPC";
            felixGameObject.tag = "ActiveCharacter";
        }
    }
}

