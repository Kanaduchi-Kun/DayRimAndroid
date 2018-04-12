using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataController : MonoBehaviour {




    public static DataController instance;


    int currentScene;

    public float playerx;
    public float playerz;

    public GameObject player;

    ArrayList items;

    public Junkyard junkprogress;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        items = new ArrayList();
    }


    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Save"))
        {
            DataController.instance.Save();
        }

        if (GUI.Button(new Rect(10, 140, 100, 30), "Load"))
        {
            DataController.instance.Load();
            player.transform.position = new Vector3(playerx, player.transform.position.y, playerz);
            player.GetComponent<NavMeshMovement>().navMeshAgent.isStopped = true;
            
        }

        if (GUI.Button(new Rect(10, 200, 100, 30), "AddItem"))
        {
            items.Add(new Item2("Item " + items.Count, "", 0, ""));
        }

        if (GUI.Button(new Rect(10, 240, 100, 30), "ShowItems"))
        {
            TouchInput.instance.debugtext.text = "item Anzahl: " + items.Count;
        }

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerGameData data = new PlayerGameData(player.transform.position.x, player.transform.position.z, items);

        bf.Serialize(file, data);
        file.Close();

    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerGameData data = (PlayerGameData)bf.Deserialize(file);
            file.Close();


            playerx = data.getPlayerX();
            playerz = data.getPlayerZ();
            items = data.getItemList();

        }
    }
}


[Serializable]
public class PlayerGameData
{
    //player coordinates
    private float playerx;
    private float playerz;

    //Liste der Items
    private ArrayList itemList;

    public PlayerGameData(float px, float pz, ArrayList items)
    {
        playerx = px;
        playerz = pz;

        itemList = items;
    }

    public float getPlayerX()
    {
        return playerx;
    }

    public float getPlayerZ()
    {
        return playerz;
    }

    public ArrayList getItemList()
    {
        return itemList;
    }

}

[Serializable]
class Inventar
{
    private List<Item2> items;
    
    public Inventar()
    {
        items = new List<Item2>();
    }

    public void addItem(Item2 i)
    {
        items.Add(i);
    }

    public List<Item2> getAllItems()
    {
        return items;
    }
}


[Serializable]
public class Junkyard
{
    // Szenenprogress wird hier geflagt und später bei einem load wird die szene den bools angepasst
    private bool CamperisHere;


    public bool isCamperHere()
    {
        return CamperisHere;
    }

    public void setCamperEvent(bool camper)
    {
        CamperisHere = camper;
    }

}

