using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemCost;

    [SerializeField] private Button _actionButton;

    public void SetInfo(string itemName, int itemCost)
    {
        _itemName.text = itemName;
        _itemCost.text = itemCost.ToString();
    }

    public Button GetButton()
    {
        return _actionButton;
    }
}