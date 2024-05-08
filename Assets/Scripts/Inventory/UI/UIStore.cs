using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStore : MonoBehaviour
{
    [Header("Store Variables")] [SerializeField]
    private UIInvetory _playerUI, _storeUI;

    private void OnEnable()
    {
        _playerUI.CopyInfoFromInventory();
        _storeUI.CopyInfoFromInventory();
    }

    public void SetStoreOwner(Inventory inventory)
    {
        _storeUI.SetStoreOwner(inventory);
    }

    public void PassItem(SO_Item newItem, bool storeToPlayer)
    {
        if (storeToPlayer)
            _playerUI.GetInventory().AddItem(newItem);
        else
            _storeUI.GetInventory().AddItem(newItem);
        
    }
}
