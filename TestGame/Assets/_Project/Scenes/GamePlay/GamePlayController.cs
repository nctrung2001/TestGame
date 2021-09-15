using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SS.View;
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
        btnBack.onClick.AddListener(() => Manager.Add(PopupConfirmController.POPUPCONFIRM_SCENE_NAME));
        btnWin.onClick.AddListener(() =>
        {
            
        });

        LevelData levelData = new LevelData();
        levelData.id = 1;
        levelData.name = "Level 1";
        levelData.description = "Nothing here";

        string json = JsonUtility.ToJson(levelData);
        LevelData levelLoaded = JsonUtility.FromJson<LevelData>(json);

        Debug.Log("id: "+levelData.id);
        Debug.Log("name: " + levelData.name);
        Debug.Log("description: " + levelData.description);

        Debug.Log(json);
        Debug.Log("id: " + levelLoaded.id);
        Debug.Log("name: " + levelLoaded.name);
        Debug.Log("description: " + levelLoaded.description);
    }

    private void Update()
    {
        //txtLevel.text = "Level: ";
    }
}