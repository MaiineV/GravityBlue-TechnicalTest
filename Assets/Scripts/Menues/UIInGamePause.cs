using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInGamePause : MonoBehaviour
{
    public void ReturnGame()
    {
        EventManager.Trigger(EventName.TurnOffUI);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
