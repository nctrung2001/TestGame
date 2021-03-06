using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleActiveObject : MonoBehaviour
{
    [SerializeField] private GameObject onObject;
    [SerializeField] private GameObject offObject;
    Toggle m_Toggle;
    bool isInit = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (!isInit)
        {
            m_Toggle = GetComponent<Toggle>();
            if (m_Toggle != null)
            {
                OnToggle(m_Toggle.isOn);
                m_Toggle.onValueChanged.AddListener(OnToggle);
            }
            isInit = true;
        }
    }

    private void Start()
    {
        m_Toggle.onValueChanged.AddListener(PlayAudio);
    }

    public void OnToggle(bool value)
    {
        onObject.SetActive(value);
        offObject.SetActive(!value);
    }

    public void SetInteractable(bool active)
    {
        Init();
        m_Toggle.interactable = active;
    }

    public void PlayAudio(bool toggle) { AudioManager.Instance.PlayButtonTapSfx(); }
}
