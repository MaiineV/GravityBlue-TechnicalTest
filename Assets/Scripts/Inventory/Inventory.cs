using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private SO_Item[,] _inventory = new SO_Item[5, 4];
    [SerializeField] private UIInvetory _uiInvetory;

    [SerializeField] private SO_Item testItem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddItem(testItem);
        }
    }

    public void AddItem(SO_Item item)
    {
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                if (_inventory[j, i] != null) continue;

                _inventory[j, i] = item;
                _uiInvetory.ChangeUIImage(j, i, item.inventoryImage);
                return;
            }
        }
    }

    public void RemoveItem(int xIndex, int yIndex)
    {
        if (xIndex >= 5) return;
        if (yIndex >= 4) return;

        _inventory[xIndex, yIndex] = null;

        _uiInvetory.ChangeUIImage(xIndex, yIndex);
    }

    public bool HasEmptyCells()
    {
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                if (_inventory[j, i] != null) continue;

                return true;
            }
        }

        return false;
    }

    public SO_Item GetItem(int xIndex, int yIndex)
    {
        return _inventory[xIndex, yIndex];
    }
}