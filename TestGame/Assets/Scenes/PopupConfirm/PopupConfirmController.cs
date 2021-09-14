using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SS.View;

public class PopupConfirmController : Controller
{
    public const string POPUPCONFIRM_SCENE_NAME = "PopupConfirm";
    [SerializeField] private Button btnYes, btnNo;

    public override string SceneName()
    {
        return POPUPCONFIRM_SCENE_NAME;
    }

    private void Start()
    {
        btnYes.onClick.AddListener(() => Manager.Load(HomeController.HOME_SCENE_NAME));
        btnNo.onClick.AddListener(() => Manager.Load(GamePlayController.GAMEPLAY_SCENE_NAME));
    }
}