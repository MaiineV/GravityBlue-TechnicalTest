using System;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
    private Model _model;

    [SerializeField] private Inventory _inventory;
    [SerializeField] private SO_Item[] _startingItems;


    private void Awake()
    {
        _inventory.SetOwnerState(false);
        foreach (var item in _startingItems)
        {
            _inventory.AddItem(item);
        }
    }

    public void Interact(Model model)
    {
        _model = model;
        GameManager.Instance.UIManager.SetStoreOwner(_inventory);
        EventManager.Trigger(EventName.TurnOnUI, Screens.Store);
    }
}
