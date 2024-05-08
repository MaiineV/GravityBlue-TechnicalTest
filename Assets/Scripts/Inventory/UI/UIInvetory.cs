using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInvetory : MonoBehaviour
{
    private readonly UIItem[] _uiInventory = new UIItem[20];

    [SerializeField] private UIPopUp _itemPopUp;
    [SerializeField] private Inventory _inventory;

    [SerializeField] private bool _isShopUI;
    [SerializeField] private bool _isPlayerInventory;

    private int _actualIndex;

    private void OnEnable()
    {
        _itemPopUp.gameObject.SetActive(false);
    }

    public void AddUIItem(int index, UIItem item)
    {
        _uiInventory[index] = item;
    }

    public void SetPopUp(int index)
    {
        _actualIndex = index;
        
        var selectedItem = _inventory.GetItem(index);
        _itemPopUp.gameObject.SetActive(true);
        _itemPopUp.SetInfo(selectedItem.itemName, _isPlayerInventory ? selectedItem.sellCost : selectedItem.buyCost);
        
        var button = _itemPopUp.GetButton();
        if (_isShopUI)
        {
           button.gameObject.SetActive(true);
           
           button.onClick.RemoveAllListeners();

           if (_isPlayerInventory)
           {
               button.onClick.AddListener(SellItem);
           }
           else
           {
               button.onClick.AddListener(BuyItem);
           }
        }
        else
        {
            button.gameObject.SetActive(false);
        }
    }

    public void ClosePopUp()
    {
        _itemPopUp.gameObject.SetActive(false);
    }

    public void ChangeUIImage(int index, Sprite item = null)
    {
        _uiInventory[index].ChangeImage(item);
    }

    private void SellItem()
    {
        _inventory.RemoveItem(_actualIndex);
    }

    private void BuyItem()
    {
        
    }
    
    public void SetStoreOwner(Inventory newOwner)
    {
        _inventory = newOwner;
    }

    public void CopyInfoFromInventory()
    {
        for (var i = 0; i < 20; i++)
        {
            _uiInventory[i].ChangeImage(_inventory[i] ? _inventory[i].inventoryImage : null);
        }
    }
}