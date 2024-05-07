using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private int _maxXIndex;
    [SerializeField] private int _maxYIndex;
    private bool _hasItem;

    private int _actualX, _actualY;

    private void Awake()
    {
        var index = transform.GetSiblingIndex();

        while (_maxXIndex * _actualY + _actualX != index)
        {
            _actualX++;

            if (_actualX < _maxXIndex) continue;
            
            _actualX = 0;
            _actualY++;
                
            if(_actualY > _maxYIndex) break;
        }
    }

    public void ChangeImage(Sprite newImage = null)
    {
        var color = _itemImage.color;
        
        if (newImage == null)
        {
            color.a = 0;
            _hasItem = false;
        }
        else
        {
            color.a = 1;
            _itemImage.sprite = newImage;
            _hasItem = true;
        }
        
        _itemImage.color = color;
    }

    public void OnPressButton()
    {
        if (!_hasItem) return;
        
        
    }

    public void UseItem()
    {
        
    }
}
