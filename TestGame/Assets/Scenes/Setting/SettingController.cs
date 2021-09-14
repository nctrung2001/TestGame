using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SS.View;

public class SettingController : Controller
{
    public const string SETTING_SCENE_NAME = "Setting";
    [SerializeField] private Button btnBack;

    public override string SceneName()
    {
        return SETTING_SCENE_NAME;
    }

    private void Start()
    {
        btnBack.onClick.AddListener(() => Manager.Load(HomeController.HOME_SCENE_NAME));
    }
}