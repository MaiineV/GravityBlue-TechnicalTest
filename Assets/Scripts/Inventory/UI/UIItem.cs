using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private int _maxXIndex;
    [SerializeField] private int _maxYIndex;

    private bool _hasItem;

    private int _actualX, _actualY;

    [SerializeField] private UIInvetory _uiInvetory;

    private void Awake()
    {
        var index = transform.GetSiblingIndex();

        while (_maxXIndex * _actualY + _actualX != index)
        {
            _actualX++;

            if (_actualX < _maxXIndex) continue;

            _actualX = 0;
            _actualY++;

            if (_actualY > _maxYIndex) break;
        }

        _uiInvetory.AddUIItem(_actualX, _actualY, this);
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
        if (!_hasItem)
            _uiInvetory.ClosePopUp();
        else
            _uiInvetory.SetPopUp(_actualX, _actualY);
    }
}