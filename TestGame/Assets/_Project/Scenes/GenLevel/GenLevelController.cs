using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using SS.View;
using TMPro;

public class GenLevelController : Controller
{
    public const string GENLEVEL_SCENE_NAME = "GenLevel";
    [SerializeField] private Button btnGen, btnBack;
    [SerializeField] private TMP_InputField inpId, inpName, inpDescription;
    LevelData levelData;
    string levelName;
    //Dictionary<string,LevelData> levelList;

    public override string SceneName()
    {
        return GENLEVEL_SCENE_NAME;
    }

    private void Start()
    {
        //levelList = new Dictionary<string, LevelData>();
        btnGen.onClick.AddListener(() =>
        {
            levelData = new LevelData();
            levelData.id = int.Parse(inpId.text);
            levelData.name = inpName.text;
            levelData.description = inpDescription.text;
            //levelList.Add("level", levelData);
            SaveLevelData(levelData);
        });
        btnBack.onClick.AddListener(()=> Manager.Load(HomeController.HOME_SCENE_NAME));
    }

    public void SaveLevelData(LevelData levelData)
    {
        levelName = levelData.name;
        string jsonText = JsonUtility.ToJson(levelData, true);
        Debug.Log(jsonText);
        string path = Path.Combine(Application.dataPath, $"Resources/DataTest/{levelName}.json");
        //Debug.Log(path);
        File.WriteAllText(path, jsonText);
    }

    // public static string GetFilePath(int storyId, int orderInStory)
    // {
    //     return Path.Combine(Application.dataPath, $"Resources/{GetResPath(storyId, orderInStory)}" + ".json");
    // }

    // public static string GetResPath(int storyId, int orderInStory)
    // {
    //     return ($"LevelData/{GetPicDataFileName(storyId, orderInStory)}");
    // }

    // public static string GetPicDataFileName(int storyId, int orderInStory)
    // {
    //     return $"{storyId}_{orderInStory}_Data";
    // }
}