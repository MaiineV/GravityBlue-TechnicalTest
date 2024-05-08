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
}
