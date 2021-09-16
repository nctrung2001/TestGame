using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using SS.View;
using TMPro;

public class GenLevelController : Controller
{
    public const string GENLEVEL_SCENE_NAME = "GenLevel";
    [SerializeField] private Button btnGen;
    [SerializeField] private TMP_InputField inpId, inpName, inpDescription;
    LevelData levelData;

    public override string SceneName()
    {
        return GENLEVEL_SCENE_NAME;
    }

    private void Start()
    {
        btnGen.onClick.AddListener(() =>
        {
            levelData = new LevelData();
            levelData.id = int.Parse(inpId.text);
            levelData.name = inpName.text;
            levelData.description = inpDescription.text;
        });
    }

    public void SaveLevelData()
    {
#if UNITY_EDITOR
        string jsonText = JsonUtility.ToJson(this, true);
        //string path = GetFilePath();
        //File.WriteAllText(path, jsonText);
#else
        Debug.LogError("Can't save json data on mobile");
#endif
    }

    public static string GetFilePath(int storyId, int orderInStory)
    {
        return Path.Combine(Application.dataPath, $"Resources/{GetResPath(storyId, orderInStory)}" + ".json");
    }

    public static string GetResPath(int storyId, int orderInStory)
    {
        return ($"LevelData/{GetPicDataFileName(storyId, orderInStory)}");
    }

    public static string GetPicDataFileName(int storyId, int orderInStory)
    {
        return $"{storyId}_{orderInStory}_Data";
    }
}