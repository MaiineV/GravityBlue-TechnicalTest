using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image _itemImage;

    private bool _hasItem;

    private int _index;

    [SerializeField] private UIInvetory _uiInvetory;

    private void Awake()
    {
        _index = transform.GetSiblingIndex();
        _uiInvetory.AddUIItem(_index, this);
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
            _uiInvetory.SetPopUp(_index);
    }
}