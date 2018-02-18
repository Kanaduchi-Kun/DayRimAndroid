using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour
{
    public GameObject[] Nodes;
    private GameObject character;
    public int crossPoint;

    public float speed;
    public bool isPatroling;
    public bool isPatrolingQueue;
    public bool hasCrossPoint;

    private int currentNode;
    private int nextNode;
    private int lastNode;
    private int destNode;
    private float thisDistance;

    private Vector3 destination;
    private GameObject[] tmpPath;

    private bool onPath;
    private bool adding;
    private bool foundClosestNode;
    private bool moving;

    void Start()
    {
        speed = ActiveCharacter.speed;

        if (character == null)
            character = ActiveCharacter.activeCharacter;

        if (isPatroling && isPatrolingQueue) // Falls beide Patroullienarten ausgewählt werden, Pfadpatroullie als Standart nehmen
        {
            isPatrolingQueue = false;
        }
    }

    void Update()
    {
        if (currentNode == destNode)
            ActiveCharacter.reachedGoal = true;

        if (isPatroling) // Pfadpatroullie
            patrolPath();
        else if (isPatrolingQueue) // Kreispatroullie
            patrolQueue();

        if (moving != ActiveCharacter.isMoving)
            ActiveCharacter.isMoving = moving;
    }

    private void findClosestNodeIndex(Vector3 position)
    {
        float distance = Vector3.Distance(Nodes[0].transform.position, position);

        for (int i = 0; i < Nodes.Length; ++i)
        {
            Vector3 nodePosition = Nodes[i].transform.position;
            float nodeDistance = Vector3.Distance(nodePosition, position);

            if (nodeDistance <= distance)
            {
                distance = nodeDistance;
                thisDistance = distance;
                destNode = i;
            }
        }

        foundClosestNode = true;
    }

    public GameObject findClosestNode(Vector3 position)
    {
        GameObject node = Nodes[0];
        float distance = Vector3.Distance(Nodes[0].transform.position, position);

        for (int i = 1; i < Nodes.Length; ++i) // nächsten Knotenpunkt über geringsten Abstand ermitteln
        {
            Vector3 nodePosition = Nodes[i].transform.position;
            float nodeDistance = Vector3.Distance(nodePosition, position);

            if (nodeDistance < distance)
            {
                distance = nodeDistance;
                thisDistance = distance;
                node = Nodes[i];
            }
            else
                continue;
        }

        return node;
    }

    public void leavePath() // diesen Pfad verlassen
    {
        onPath = false;
        currentNode = 0;
    }

    public void enterPath() // diesen Pfad betreten
    {
        onPath = true;
    }

    public void setCurrentNode(GameObject node) // aktuellen Knotenpunkt setzen
    {
        for (int i = 0; i < Nodes.Length; ++i)
        {
            if (Nodes[i] == node)
            {
                currentNode = i;
                break;
            }
        }
    }

    public void setDestination(Vector3 newDest) // Ziel setzen
    {
        destination = newDest;
    }

    public Vector3 getDestination()
    {
        return destination;
    }

    public void walkPath() // Pfad ablaufen
    {
        if (!moving)
            moving = true;

        getPath(destination); // pfad berechnen und richtung bestimmen
        checkDirection();

        if (adding)
        {
            nextNode = currentNode + 1; // "vorwärts/rechts" laufen

            if (!ActiveCharacter.facingRight)
                ActiveCharacter.facingRight = true;

            if (ActiveCharacter.activeCharacter.transform.position.x < ActiveCharacter.inactiveCharacter.transform.position.x)
                ActiveCharacter.switchCharacterPosition(); // RECHTS LAUFEN
        }
        else
        {
            nextNode = currentNode - 1; // "rückwärts/links" laufen

            if (ActiveCharacter.facingRight)
                ActiveCharacter.facingRight = false;

            if (ActiveCharacter.activeCharacter.transform.position.x > ActiveCharacter.inactiveCharacter.transform.position.x) // LINKS LAUFEN
                ActiveCharacter.switchCharacterPosition();
        }

        if (nextNode < 0)
            nextNode = 0;

        if (currentNode == destNode) // wenn Ziel erreicht, Bewegung beenden
        {
            foundClosestNode = false;
            moving = false;
            ActiveCharacter.reachedGoal = true;
        }
        else
        {
            if (character == null)
                character = ActiveCharacter.activeCharacter;

            character.transform.position = Vector3.MoveTowards(character.transform.position, Nodes[nextNode].transform.position, speed * Time.deltaTime);

            if (character.transform.position == Nodes[nextNode].transform.position) // wenn nächsten Knoten erreicht, aktueller Knoten = nächster Knoten
                currentNode = nextNode;

            ActiveCharacter.reachedGoal = false;
        }
    }

    private void checkDirection()
    {
        if (destNode > currentNode)
            adding = true;
        else if (destNode < currentNode)
            adding = false;
    }

    private void getPath(Vector3 destPosition) // Pfad berechnen
    {
        if (!foundClosestNode)
            findClosestNodeIndex(destPosition);

        if (destNode > currentNode)
        {
            adding = true;
            tmpPath = new GameObject[destNode - currentNode + 1]; // pfad anlegen

            int j = 0;
            for (int i = currentNode; i <= destNode; ++i) //  benötigte punkte in neuen pfad einfügen
            {
                tmpPath[j] = Nodes[i];
                ++j;
            }
        }
        else if (destNode < currentNode)
        {
            adding = false;
            tmpPath = new GameObject[currentNode - destNode + 1];
            int j = 0;

            for (int i = currentNode; i >= destNode; --i) //  benötigte punkte in neuen pfad einfügen
            {
                tmpPath[j] = Nodes[i];
                ++j;
            }
        }
    }

    public void patrolQueue() // kreis ablaufen
    {
        nextNode = (currentNode + 1) % (Nodes.Length);

        character.transform.position = Vector3.MoveTowards(character.transform.position, Nodes[nextNode].transform.position, speed * Time.deltaTime);

        if (character.transform.position == Nodes[nextNode].transform.position)
            currentNode = nextNode;
    }

    public void patrolPath() // pfad hin und her laufen
    {
        if (currentNode != Nodes.Length - 1)
            nextNode = (currentNode + 1);
        else
            lastNode = Nodes.Length - 1;

        if (lastNode != -1)
        {
            if (lastNode < currentNode)
                nextNode = (currentNode + 1);
            else
            {
                if (currentNode != 0)
                    nextNode = (currentNode - 1);
                else
                    nextNode = (currentNode + 1);
            }
        }

        character.transform.position = Vector3.MoveTowards(character.transform.position, Nodes[nextNode].transform.position, speed * Time.deltaTime);

        if (character.transform.position == Nodes[nextNode].transform.position)
        {
            lastNode = currentNode;
            currentNode = nextNode;
        }
    }

    public bool isMoving()
    {
        return moving;
    }

    public void setMoving(bool isNowMoving)
    {
        moving = isNowMoving;
    }

    public float getPathDistance()
    {
        return thisDistance;
    }

    public bool atCrossPoint()
    {
        bool atCrossPoint = false;

        if (currentNode == crossPoint)
            atCrossPoint = true;

        return atCrossPoint;
    }

    public bool reachedGoal()
    {
        bool reachedGoal = !moving;
        return reachedGoal;
    }

    public void setCharacter(GameObject newCharacter)
    {
        character = newCharacter;
    }

    public void setPathCharacter(GameObject newCharacter)
    {
        character = newCharacter;
    }
}