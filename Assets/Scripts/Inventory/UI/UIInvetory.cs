using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIInvetory : MonoBehaviour
{
    private readonly UIItem[,] _uiInventory = new UIItem[5, 4];

    [SerializeField] private UIPopUp _itemPopUp;
    [SerializeField] private Inventory _inventory;

    [SerializeField] private bool _isShopUI;
    [SerializeField] private bool _isPlayerInventory;

    private int _actualXIndex, _actualYIndex;

    private void OnEnable()
    {
        _itemPopUp.gameObject.SetActive(false);
    }

    public void AddUIItem(int xIndex, int yIndex, UIItem item)
    {
        _uiInventory[xIndex, yIndex] = item;
    }

    public void SetPopUp(int xIndex, int yIndex)
    {
        _actualXIndex = xIndex;
        _actualYIndex = yIndex;
        
        var selectedItem = _inventory.GetItem(xIndex, yIndex);
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

    public void ChangeUIImage(int xIndex, int yIndex, Sprite item = null)
    {
        _uiInventory[xIndex, yIndex].ChangeImage(item);
    }

    private void SellItem()
    {
        _inventory.RemoveItem(_actualXIndex, _actualYIndex);
    }

    private void BuyItem()
    {
        
    }
}