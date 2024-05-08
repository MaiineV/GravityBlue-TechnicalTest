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
        var item = _inventory.GetItem(_actualIndex);
        _inventory.RemoveItem(_actualIndex);
        
        GameManager.Instance.EconomyManager.AddGold(item.sellCost);
        
        GameManager.Instance.Store.PassItem(item, false);
        
        _itemPopUp.gameObject.SetActive(false);
        //TODO: Set Feedback sell
    }

    private void BuyItem()
    {
        var item = _inventory.GetItem(_actualIndex);
        
        //TODO: Set Feedback buy
        
        if (GameManager.Instance.EconomyManager.HasEnoughGold(item.buyCost))
        {
            _inventory.RemoveItem(_actualIndex);
        
            GameManager.Instance.EconomyManager.SubtractGold(item.sellCost);
        
            GameManager.Instance.Store.PassItem(item, true);
        }
        else
        {
            Debug.Log("No money");
        }
        
        _itemPopUp.gameObject.SetActive(false);
    }
    
    public void SetStoreOwner(Inventory newOwner)
    {
        _inventory = newOwner;
    }

    public Inventory GetInventory() => _inventory;

    public void CopyInfoFromInventory()
    {
        if (_uiInventory.Length<=0) return;
        
        for (var i = 0; i < 20; i++)
        {
            _uiInventory[i].ChangeImage(_inventory[i] ? _inventory[i].inventoryImage : null);
        }
    }
}