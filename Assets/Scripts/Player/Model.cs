using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    private Dictionary<ControllerName, Controller> _possibleControllers;
    private Controller _activeController;
    
    private void Awake()
    {
        var controllers = Resources.LoadAll<SO_Inputs>("Inputs");

        foreach (var controller in controllers)
        {
            if (_possibleControllers.ContainsKey(controller.ControllerName)) continue;
            
            _possibleControllers.Add(controller.ControllerName, new Controller(controller, this));
        }

        _activeController = _possibleControllers[ControllerName.InGame];
    }

    void Update()
    {
        _activeController.OnUpdate();
    }
}
