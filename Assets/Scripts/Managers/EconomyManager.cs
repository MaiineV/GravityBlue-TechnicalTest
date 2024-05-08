using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    private int _gold;
    private Inventory _playerInventory;
    private Inventory _storeInventory;
    
    //TODO: Delete later
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddGold(100);
        }
    }

    public void AddGold(int goldToAdd)
    {
        _gold += goldToAdd;
        GameManager.Instance.UIManager.SetGold(_gold);
    }

    public void SubtractGold(int goldToSubtract)
    {
        _gold -= goldToSubtract;
        GameManager.Instance.UIManager.SetGold(_gold);
    }

    public bool HasEnoughGold(int cost)
    {
        return _gold >= cost;
    }
}
