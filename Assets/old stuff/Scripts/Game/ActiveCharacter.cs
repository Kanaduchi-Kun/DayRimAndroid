using UnityEngine;
using System.Collections;

public class ActiveCharacter
{
    public static GameObject activeCharacter;
    public static GameObject inactiveCharacter;
    public static string activeCharacterName;
    public static bool facingRight = true;
    public static bool isMoving = false;
    public static float speed = 4;
    public static int iiii = 1;
    public static Vector3 inactiveCharacterPosition;
    public static bool reachedGoal;
    public static bool interacted;

    public static void switchCharacterPosition()
    {
        if (activeCharacter != null)
        {
            float tmpActivePosition = ActiveCharacter.activeCharacter.transform.position.x;

            ActiveCharacter.activeCharacter.transform.position = new Vector3(ActiveCharacter.inactiveCharacter.transform.position.x, ActiveCharacter.activeCharacter.transform.position.y, ActiveCharacter.activeCharacter.transform.position.z);
            ActiveCharacter.inactiveCharacter.transform.position = new Vector3(tmpActivePosition, ActiveCharacter.inactiveCharacter.transform.position.y, ActiveCharacter.inactiveCharacter.transform.position.z);
        }
    }

    public static void resetCharacters()
    {
        if (ActiveCharacter.activeCharacter == null)
            ActiveCharacter.activeCharacter = GameObject.Find("Feli");

        if (ActiveCharacter.activeCharacter.tag != "ActiveCharacter")
            ActiveCharacter.activeCharacter.tag = "ActiveCharacter";

        ActiveCharacter.inactiveCharacter = GameObject.Find("Felix");

        if (ActiveCharacter.inactiveCharacter.tag != "NPC")
            ActiveCharacter.inactiveCharacter.tag = "NPC";

        setCharacterPositions();
    }

    public static void setCharacters()
    {
        if (ActiveCharacter.activeCharacterName != "Feli" && ActiveCharacter.activeCharacterName != "Felix")
            ActiveCharacter.activeCharacterName = "Feli";

        ActiveCharacter.activeCharacter = GameObject.Find(ActiveCharacter.activeCharacterName);
        ActiveCharacter.activeCharacter.tag = "ActiveCharacter";

        if (ActiveCharacter.activeCharacter.name == "Feli")
            ActiveCharacter.inactiveCharacter = GameObject.Find("Felix");
        else
            ActiveCharacter.inactiveCharacter = GameObject.Find("Feli");

        ActiveCharacter.inactiveCharacter.tag = "NPC";
        setCharacterPositions();
    }

    private static void setCharacterPositions()
    {
        PlayerCharacterController activeController = ActiveCharacter.activeCharacter.GetComponent<PlayerCharacterController>();
        PlayerCharacterController inactiveController = ActiveCharacter.inactiveCharacter.GetComponent<PlayerCharacterController>();

        activeController.activeCharacter = true;
        inactiveController.activeCharacter = false;

        inactiveCharacterPosition = new Vector3(-ActiveCharacter.inactiveCharacter.transform.position.x*2, ActiveCharacter.activeCharacter.transform.position.y, ActiveCharacter.activeCharacter.transform.position.z);
        ActiveCharacter.inactiveCharacter.transform.position = inactiveCharacterPosition;
    }
}

