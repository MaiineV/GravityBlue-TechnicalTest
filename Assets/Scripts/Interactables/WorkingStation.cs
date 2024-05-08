using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorkingStation : MonoBehaviour, IInteractable
{
    [SerializeField] private float _workingTime;
    [SerializeField] private int _goldProduction;

    [SerializeField] private GameObject _interactIcon;
    
    public void Interact(Model model)
    {
        EventManager.Trigger(EventName.TurnOnUI, Screens.Work);
        EventManager.Trigger(EventName.UpdateWorkUI,0f);
        StartCoroutine(WaitWork());
    }

    private IEnumerator WaitWork()
    {
        var actualTime = 0f;
        
        while (actualTime < _workingTime)
        {
            actualTime += Time.deltaTime;
            EventManager.Trigger(EventName.UpdateWorkUI,actualTime/_workingTime);
            yield return null;
        }
        
        GameManager.Instance.EconomyManager.AddGold(_goldProduction);
        GameManager.Instance.RollRandomMerchant();
        EventManager.Trigger(EventName.TurnOffUI);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            _interactIcon.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            _interactIcon.SetActive(false);
        }
    }
}
