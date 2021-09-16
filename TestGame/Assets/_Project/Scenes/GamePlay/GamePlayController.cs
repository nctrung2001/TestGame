using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SS.View;
using System.IO;
using TMPro;

public class GamePlayController : Controller
{
    public const string GAMEPLAY_SCENE_NAME = "GamePlay";
    [SerializeField] Button btnBack, btnWin;
    [SerializeField] TMP_Text txtLevel;

    public override string SceneName()
    {
        return GAMEPLAY_SCENE_NAME;
    }

    private void Start()
    {
        LevelData levelData = new LevelData();
        levelData = LoadLevelData();

        btnBack.onClick.AddListener(() => Manager.Add(PopupConfirmController.POPUPCONFIRM_SCENE_NAME));
        btnWin.onClick.AddListener(() =>
        {
        });

        Debug.Log(levelData);
    
        // Debug.Log("Level: " + levelData.id);
        // Debug.Log("name: " + levelData.name);
        // Debug.Log("description: " + levelData.description);

        //LevelData levelData = new LevelData();
        //levelData.id = 1;
        //levelData.name = "Level 1";
        //levelData.description = "Nothing here";

        //string json = JsonUtility.ToJson(levelData, true);
        //LevelData levelLoaded = JsonUtility.FromJson<LevelData>(json);
        
    }

    public static LevelData LoadLevelData()
    {
        string path = Application.persistentDataPath + "/levelData.json";
        var json = File.ReadAllText(path);
        if (File.Exists(path))
        {
            LevelData levelData = JsonUtility.FromJson<LevelData>(json);
            return levelData;
        }
        else
        {
            Debug.Log("File not found");
            return null;
        }
    }
}