using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    private Model _model;

    public Action OnUpdate = delegate {  };
    
    public Controller(SO_Inputs soSoInputs, Model model)
    {
        _model = model;

        foreach (var inputPair in soSoInputs.inputs)
        {
            OnUpdate += () =>
            {
                if (Input.GetKeyDown(inputPair.Key))
                {
                    EventManager.Trigger(inputPair.Value);
                }
            };
        }
    }
}
