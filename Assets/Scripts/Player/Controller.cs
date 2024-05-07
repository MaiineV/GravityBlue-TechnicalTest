using System;
using UnityEngine;

public class Controller
{
    public Action OnUpdate = delegate {  };
    
    public Controller(SO_Inputs soSoInputs)
    {
        foreach (var inputPair in soSoInputs.inputs)
        {
            var inputName = inputPair.Key.ToString();
            switch (inputPair.Value.InputType)
            {
                case InputType.ButtonDown:
                    OnUpdate += () =>
                    {
                        if (Input.GetButtonDown(inputName))
                        {
                            EventManager.Trigger(inputPair.Value.EventName);
                        }
                    };
                    break;
                case InputType.ButtonUp:
                    OnUpdate += () =>
                    {
                        if (Input.GetButtonUp(inputName))
                        {
                            EventManager.Trigger(inputPair.Value.EventName);
                        }
                    };
                    break;
                case InputType.ButtonHold:
                    OnUpdate += () =>
                    {
                        if (Input.GetButton(inputName))
                        {
                            EventManager.Trigger(inputPair.Value.EventName);
                        }
                    };
                    break;
                case InputType.Axie:
                    OnUpdate += () =>
                    {
                        var axis = Input.GetAxisRaw(inputName);
                        EventManager.Trigger(inputPair.Value.EventName, axis);
                    };
                    break;
            }
        }
    }
}
