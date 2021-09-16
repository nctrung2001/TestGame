using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using SS.View;
using TMPro;

public class GenLevelController : Controller
{
    public const string GENLEVEL_SCENE_NAME = "GenLevel";
    [SerializeField] private Button btnGen;
    [SerializeField] private TMP_InputField inpId, inpName, inpDescription;
    LevelData levelData;
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
            string jsonText = JsonUtility.ToJson(levelData, true);
            SaveLevelData(jsonText);
            Debug.Log(jsonText);
        });
    }

    public void SaveLevelData(string jsonText)
    {
        string path = @"D:/Unity/Project/levelData.json";
        File.WriteAllText(path, jsonText);
        FileStream stream = new FileStream(path, FileMode.Create);
        stream.Close();
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