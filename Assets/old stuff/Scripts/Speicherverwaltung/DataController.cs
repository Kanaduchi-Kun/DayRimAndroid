using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataController : MonoBehaviour {


    int currentScene;

    public float playerx;
    public float playerz;

    public GameObject player;

    ArrayList items;

    public static DataController instance;


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
class PlayerGameData
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