using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private SO_Item[] _inventory = new SO_Item[20];
    [SerializeField] private UIInvetory _uiInvetory;
    [SerializeField] private UIInvetory _storeInvetory;

    [SerializeField] private bool _isPlayer = true;

    [SerializedDictionary("Body Part", "Equipped Item")]
    public SerializedDictionary<BodyPart, SO_Item> equippedItems;

    private void Awake()
    {
        if (!_isPlayer) return;

        foreach (var item in equippedItems)
        {
            EventManager.Trigger(EventName.ChangeCloth, item.Key, item.Value.equippedInfo.equippedSprite);
            _uiInvetory.uiEquipment.ReplaceItem(item.Key, item.Value.inventoryImage);
        }
    }

    public void SetOwnerState(bool isPlayer)
    {
        _isPlayer = isPlayer;
    }

    public void AddItem(SO_Item item)
    {
        for (var i = 0; i < 20; i++)
        {
            if (_inventory[i] != null) continue;

            _inventory[i] = item;
            
            if (_isPlayer || _uiInvetory.isActiveAndEnabled) _uiInvetory.ChangeUIImage(i, item.inventoryImage);
            if (_isPlayer && _storeInvetory.isActiveAndEnabled) _storeInvetory.ChangeUIImage(i, item.inventoryImage);
            
            return;
        }
    }

    public void RemoveItem(int index)
    {
        if (index >= 20) return;

        _inventory[index] = null;

        _uiInvetory.ChangeUIImage(index, null);
        if (_isPlayer) _storeInvetory.ChangeUIImage(index, null);
    }

    public void EquipItem(int index)
    {
        var newItem = _inventory[index];
        var lastItem = equippedItems[newItem.equippedInfo.bodyPart];

        _inventory[index] = lastItem;
        _uiInvetory.ChangeUIImage(index, lastItem.inventoryImage);

        equippedItems[newItem.equippedInfo.bodyPart] = newItem;
        _uiInvetory.uiEquipment.ReplaceItem(newItem.equippedInfo.bodyPart, newItem.inventoryImage);
        
        EventManager.Trigger(EventName.ChangeCloth, newItem.equippedInfo.bodyPart, newItem.equippedInfo.equippedSprite);
    }

    public bool HasEmptyCells()
    {
        for (var i = 0; i < 20; i++)
        {
            if (_inventory[i] != null) continue;

            return true;
        }

        return false;
    }

    #region Collection Functions

    public SO_Item this[int index] => _inventory[index];
    
    #endregion
}