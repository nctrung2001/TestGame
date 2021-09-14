using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SS.View;

public class MainController : Controller
{
    public const string MAIN_SCENE_NAME = "Main";
    public Slider slider;

    public override string SceneName()
    {
        return MAIN_SCENE_NAME;
    }

    private void Update()
    {
        if (slider.value < 100) slider.value += 0.5f;
        else slider.value += 0f;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        Manager.Load(HomeController.HOME_SCENE_NAME);
    }
}