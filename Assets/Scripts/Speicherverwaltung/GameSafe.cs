using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class GameSafe //: MonoBehaviour 
{
    public static ArrayList CurrentItems;
    public static GameSafe gameSafe;

    /*void Awake () {
	
        if(gameSafe == null)
        {
            DontDestroyOnLoad(gameObject);
            gameSafe = this;
        }
        else if (gameSafe != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/

    public static void Safe()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
        GameData gameData = new GameData();
        gameData.characterPositionX = ActiveCharacter.activeCharacter.transform.position.x;
        gameData.characterPositionY = ActiveCharacter.activeCharacter.transform.position.y;
        gameData.characterPositionZ = ActiveCharacter.activeCharacter.transform.position.z;
        gameData.currentCharacterName = ActiveCharacter.activeCharacter.name;
        gameData.storyProgress = ProgressManager.STORYPROGRESS;
        gameData.currentScene = SceneNameManager.lastIngameScene;
        gameData.items = new ArrayList(ItemManager.inventarSafe);
        bf.Serialize(file, gameData);
        file.Close();
    }

    public static void SafeOptions()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
        GameData gameData = new GameData();
        Debug.Log("S: " + BackgroundMusicContinuation.soundMuted);
        gameData.soundMuted = BackgroundMusicContinuation.soundMuted;
        bf.Serialize(file, gameData);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            GameData gameData = (GameData)bf.Deserialize(file);

            if (gameData.currentCharacterName != null)
            {
                ActiveCharacter.activeCharacterName = gameData.currentCharacterName;
                ActiveCharacter.setCharacters();
                ActiveCharacter.activeCharacter.transform.position = new Vector3(gameData.characterPositionX, gameData.characterPositionY, gameData.characterPositionZ);
            }

            if(gameData.items != null)
                ItemManager.inventarSafe = new ArrayList(gameData.items);
            
            if(gameData.currentScene != null)
                 SceneNameManager.lastIngameScene = gameData.currentScene;

            if(gameData.storyProgress != null)
                ProgressManager.STORYPROGRESS = gameData.storyProgress;

            if(gameData.soundMuted != null)
                BackgroundMusicContinuation.soundMuted = gameData.soundMuted;

            file.Close();
        }
    }

    public static void LoadOptions()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            GameData gameData = (GameData)bf.Deserialize(file);
            BackgroundMusicContinuation.soundMuted = gameData.soundMuted;

            //Debug.Log(BackgroundMusicContinuation.soundMuted);

            if (BackgroundMusicContinuation.soundMuted)
                BackgroundMusicContinuation.soundVolume = 0.0f;
            else
                BackgroundMusicContinuation.soundVolume = 1.0f;

            file.Close();
        }
    }
}
[Serializable]
class GameData{
    public string currentScene;
    public string currentCharacterName;
    public ProgressManager.ProgressStates storyProgress;
    public float characterPositionX;
    public float characterPositionY;
    public float characterPositionZ;
    public ArrayList items;
    public bool soundMuted;
}
