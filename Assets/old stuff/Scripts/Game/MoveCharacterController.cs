using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveCharacterController : MonoBehaviour
{
    public GameObject pathManagerObject;
    private PathManager pathManager;

    public GameObject feli;
    public GameObject felix;
    public float speed;

    private bool spritesRight = true;


    void Start()
    {
        //GameSafe.Load();
        pathManager = pathManagerObject.GetComponent<PathManager>();
        pathManager.setCharacter(ActiveCharacter.activeCharacter);
        pathManager.changeCharacterPositionToNode(this.transform.position);
    }

    void Update()
    {
        setFollowingCharacter(); // Prüfen, ob Charaktere richtig gesetzt sind
        setCharacterSprites(); // Flip sprites, wenn nötig


        /*if (Input.anyKeyDown)
        {
            if (ActiveCharacter.iiii == 1)
            {
                SceneManager.LoadScene("Junkyard_Indoor_Scene_03");
                ActiveCharacter.iiii = 2;
            }
            else
            {
                SceneManager.LoadScene("Junkyard_Scene_01");
                ActiveCharacter.iiii = 1;
            }
        }*/
    }

    private void setFollowingCharacter()
    {
        if (pathManager != null)
            pathManager.checkCharacter();

        if (ActiveCharacter.inactiveCharacter == null)
           // Debug.Log("NULL");

        if (ActiveCharacter.inactiveCharacter.transform.parent == null)
            ActiveCharacter.inactiveCharacter.transform.parent = ActiveCharacter.activeCharacter.transform;
    }

    private void setCharacterSprites()
    {
        if (ActiveCharacter.isMoving)
        {
            if (ActiveCharacter.facingRight && !spritesRight || !ActiveCharacter.facingRight && spritesRight)
            {
                spritesRight = !spritesRight;
                Vector3 tmpScale = ActiveCharacter.activeCharacter.transform.localScale;
                tmpScale.x *= -1;
                ActiveCharacter.activeCharacter.transform.localScale = tmpScale;

                ActiveCharacter.switchCharacterPosition();
            }
        }
    }

    public void moveCharacterTo(Vector3 position)
    {
        pathManager.walkPathTo(position);
    }
}
