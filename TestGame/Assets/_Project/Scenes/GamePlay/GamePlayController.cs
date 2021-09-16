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
    [SerializeField] TMP_InputField inpLevel;
    string levelName;
    LevelData levelData;

    public override string SceneName()
    {
        return GAMEPLAY_SCENE_NAME;
    }
    void Awake()
    {
        if(PlayerPrefs.GetString(Const.LEVELNAME) == null || PlayerPrefs.GetString(Const.LEVELNAME) == "" )
        {
            levelName = "level1";
        }
        else
        {
            levelName = PlayerPrefs.GetString(Const.LEVELNAME);
        }
    }

    private void Start()
    {
        levelData = new LevelData();
        string path = Path.Combine(Application.dataPath, $"Resources/DataTest/{levelName}.json");
        string json = File.ReadAllText(path);
        levelData = JsonUtility.FromJson<LevelData>(json);
        txtLevel.text = "Level "+levelData.id;
        PlayerPrefs.SetString(Const.LEVELNAME,levelName);
        btnBack.onClick.AddListener(() => Manager.Add(PopupConfirmController.POPUPCONFIRM_SCENE_NAME));
        btnWin.onClick.AddListener(() =>DebugGameLevel());
    }

    public void DebugGameLevel()
    {
        levelName = inpLevel.text;
        string path = Path.Combine(Application.dataPath, $"Resources/DataTest");
        
        DirectoryInfo d = new DirectoryInfo(path);
        foreach (var file in d.GetFiles("*.json"))
        {
            if(levelName+".json" == file.Name)
            {
                LoadLevelData();
            }
        }
    }

    public void LoadLevelData()
    {
        string path = Path.Combine(Application.dataPath, $"Resources/DataTest/{levelName}.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            levelData = JsonUtility.FromJson<LevelData>(json);
            txtLevel.text = "Level "+levelData.id;
            Debug.Log("ID: "+levelData.id);
            Debug.Log("name: "+levelData.name);
            Debug.Log("description: "+levelData.description);  
            PlayerPrefs.SetString(Const.LEVELNAME,levelName);
        }
        else
        {
            Debug.Log("File not found");
        }
    }
}