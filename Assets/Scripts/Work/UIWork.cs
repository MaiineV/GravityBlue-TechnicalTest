using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWork : MonoBehaviour
{
    [SerializeField] private Image _loadingImage;
    
    private void Awake()
    {
        EventManager.Subscribe(EventName.UpdateWorkUI, UpdateWorkUI);
    }

    private void UpdateWorkUI(params object[] parameters)
    {
        _loadingImage.fillAmount = (float)parameters[0];
    }
}
