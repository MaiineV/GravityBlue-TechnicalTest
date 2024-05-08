using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Stack<GameObject> _screenStack = new();

    [SerializedDictionary("Screen Name", "Screen Game Object")]
    public SerializedDictionary<Screens, GameObject> possibleScreens;

    [Header("Store Variables")]
    [SerializeField]
    private UIStore _uiStore;

    [Header("Gold Variable")] private TMP_Text _goldAmount;

    private void Awake()
    {
        foreach (var screen in possibleScreens)
        {
            screen.Value.SetActive(false);
        }

        possibleScreens[Screens.Hud].SetActive(true);
        _screenStack.Push(possibleScreens[Screens.Hud]);

        EventManager.Subscribe(EventName.TurnOnUI, TurnOnScreen);
        EventManager.Subscribe(EventName.TurnOnInventory, TurnOnInventory);
        EventManager.Subscribe(EventName.TurnOnPause, TurnOnPause);
        EventManager.Subscribe(EventName.TurnOffUI, TurnOffLastScreen);
    }

    #region Screens Zone

    private void TurnOnScreen(params object[] parameters)
    {
        var targetScreen = (Screens)parameters[0];

        if (_screenStack.Contains(possibleScreens[targetScreen])) return;

        possibleScreens[targetScreen].SetActive(true);
        _screenStack.Push(possibleScreens[targetScreen]);
    }

    private void TurnOffLastScreen(params object[] parameters)
    {
        if (_screenStack.Count <= 1) return;

        _screenStack.Peek().SetActive(false);
        _screenStack.Pop();

        if (_screenStack.Count <= 1)
        {
            EventManager.Trigger(EventName.ReturnGameMode);
        }
    }

    private void TurnOnInventory(params object[] parameters)
    {
        if (_screenStack.Contains(possibleScreens[Screens.Inventory])) return;

        possibleScreens[Screens.Inventory].SetActive(true);
        _screenStack.Push(possibleScreens[Screens.Inventory]);
    }

    private void TurnOnPause(params object[] parameters)
    {
        if (_screenStack.Contains(possibleScreens[Screens.Pause])) return;

        possibleScreens[Screens.Pause].SetActive(true);
        _screenStack.Push(possibleScreens[Screens.Pause]);
    }

    #endregion

    public void SetStoreOwner(Inventory inventory)
    {
        _uiStore.SetStoreOwner(inventory);
    }

    public void SetGold(int gold)
    {
        _goldAmount.text = gold.ToString();
    }
}
