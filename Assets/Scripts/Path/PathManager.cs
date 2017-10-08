using UnityEngine;
using System.Collections;

public class PathManager : MonoBehaviour
{
    private GameObject character;
    public GameObject[] Paths;

    private Path[] PathScripts;
    private Path[] CrossScripts;
    private Path currentPath;
    private Vector3 dest;

    private int currentPathIndex;
    private int crossPath;
    private int closestPath;
    private int goalPath;

    public bool finished;

    private Vector3 tmpDestination;

    // Use this for initialization
    void Start()
    {
        setPathScripts();
        setCrossPaths();

        if (character == null)
            character = ActiveCharacter.activeCharacter;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPath.isMoving()) // wenn Charakter in Bewegung ist, Pfad ablaufen
            walkPathTo(dest);
    }

    public void walkPathTo(Vector3 destination)
    {
        dest = destination;
        decideClosestPath(destination);

        if (currentPathIndex == closestPath)
            walkNormalPathTo(destination);
        else
            goToCrossPoint();
    }

    public void changeCharacterPositionToNode(Vector3 position)
    {
        if (currentPath == null)
            setPathScripts();

        decideClosestPath(position);
        setCurrentPath(closestPath);
        GameObject closestNode = currentPath.findClosestNode(position);

        if (character == null) // Im Wohnwagen war der Character aus irgendeinem Grund null???
            character = ActiveCharacter.activeCharacter;

      
        //character.transform.position = closestNode.transform.position;
        currentPath.setCurrentNode(closestNode);
    }

    private void setPathScripts()
    {
        PathScripts = new Path[Paths.Length];

        for (int i = 0; i < Paths.Length; ++i)
        {
            PathScripts[i] = Paths[i].GetComponent<Path>();
            if (PathScripts[i].hasCrossPoint)
                crossPath++;
        }
    }

    private void setCurrentPath(int i)
    {
        if (CrossScripts != null && CrossScripts.Length > 1)
        {
            currentPathIndex = i;
            currentPath = CrossScripts[currentPathIndex];
        }
    }

    private void setCrossPaths()
    {
        CrossScripts = new Path[crossPath];
        int j = 0;
        for (int i = 0; i < Paths.Length; ++i)
        {
            if (PathScripts[i].hasCrossPoint)
            {
                CrossScripts[j] = PathScripts[i];
                j++;
            }
        }
    }

    private bool crossedPaths()
    {
        if (CrossScripts.Length > 0)
            return true;
        else
            return false;
    }

    private void walkNormalPathTo(Vector3 destination)
    {
        currentPath.setMoving(true);

        if (destination != currentPath.getDestination())
            currentPath.setDestination(destination);

        currentPath.walkPath();
    }

    private void decideClosestPath(Vector3 destination)
    {
        if (CrossScripts != null && CrossScripts.Length > 1)
        {
            GameObject closestNode = CrossScripts[0].findClosestNode(destination);
            float tmpDistance = CrossScripts[0].getPathDistance();
            closestPath = 0;
            float distance;

            for (int i = 0; i < CrossScripts.Length; ++i)
            {
                closestNode = CrossScripts[i].findClosestNode(destination);
                distance = CrossScripts[i].getPathDistance();

                if (distance <= tmpDistance)
                {
                    tmpDistance = distance;
                    closestPath = i;
                    goalPath = i;
                }
            }
        }
        else
            currentPath = PathScripts[0];
    }

    private void goToCrossPoint()
    {
        currentPath.setMoving(true);

        if (currentPath.atCrossPoint())
        {
            currentPath.leavePath();
            CrossScripts[goalPath].enterPath();
            setCurrentPath(goalPath);
            finished = true;
        }
        else
        {
            currentPath.setDestination(tmpDestination);
            finished = false;
        }

        currentPath.walkPath();
    }

    public void setCharacter(GameObject newCharacter)
    {
        character = newCharacter;

        if (PathScripts != null)
        {
            for (int i = 0; i < Paths.Length; ++i)
            {
                PathScripts[i].setCharacter(newCharacter);
            }
        }
    }

    public GameObject getCharacter()
    {
        return character;
    }

    public void checkCharacter()
    {
        if (character != ActiveCharacter.activeCharacter)
            character = ActiveCharacter.activeCharacter;
    }
}
