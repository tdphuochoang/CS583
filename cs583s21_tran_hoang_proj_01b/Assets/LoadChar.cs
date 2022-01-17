using System.Collections;
using UnityEngine;
using System.IO;


public class LoadChar : CharacterVar
{
    
    public void LoadCharJSON()
    {
        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
        PlayerData loadedPlayerdata = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(json);

    }

}
