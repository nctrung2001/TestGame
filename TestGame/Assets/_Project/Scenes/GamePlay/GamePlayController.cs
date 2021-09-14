using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SS.View;

public class GamePlayController : Controller
{
    public const string GAMEPLAY_SCENE_NAME = "GamePlay";
    [SerializeField] private Button btnBack, btnWin;
    [SerializeField] private Text txtLevel;
    public int level = 1;

    public override string SceneName()
    {
        return GAMEPLAY_SCENE_NAME;
    }

    private void Start()
    {
        btnBack.onClick.AddListener(() => Manager.Add(PopupConfirmController.POPUPCONFIRM_SCENE_NAME));
        btnWin.onClick.AddListener(() =>
        {
            level ++;
        });
    }

    private void Update()
    {
        txtLevel.text = "Level: " + level;
    }
}