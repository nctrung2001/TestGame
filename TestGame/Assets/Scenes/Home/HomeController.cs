using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SS.View;

public class HomeController : Controller
{
    public const string HOME_SCENE_NAME = "Home";
    [SerializeField] private Button btnSetting, btnPlay;

    public override string SceneName()
    {
        return HOME_SCENE_NAME;
    }

    private void Start()
    {
        btnSetting.onClick.AddListener(() => Manager.Load(SettingController.SETTING_SCENE_NAME));
        btnPlay.onClick.AddListener(() => Manager.Load(GamePlayController.GAMEPLAY_SCENE_NAME));
    }
}