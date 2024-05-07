using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Model : MonoBehaviour
{
    private readonly Dictionary<ControllerName, Controller> _possibleControllers = new();
    private Controller _activeController;

    private Rigidbody2D _rb;
    private Vector3 _actualDir = Vector3.zero;

    private readonly HashSet<Collider2D> _interactableOnRange = new();
    
    private void Awake()
    {
        GameManager.Instance.updateManager.AddUpdate(OnUpdate);

        _rb = GetComponent<Rigidbody2D>();
        
        #region Controller Init

        var controllers = Resources.LoadAll<SO_Inputs>("Inputs");

        foreach (var controller in controllers)
        {
            if (_possibleControllers.ContainsKey(controller.ControllerName)) continue;
            
            _possibleControllers.Add(controller.ControllerName, new Controller(controller));
        }

        _activeController = _possibleControllers[ControllerName.InGame];

        #endregion
        
        EventManager.Subscribe(EventName.UpdateHAxis, UpdateHAxis);
        EventManager.Subscribe(EventName.UpdateVAxis, UpdateVAxis);
        EventManager.Subscribe(EventName.Interact, Interact);
    }

    private void OnUpdate()
    {
        _activeController.OnUpdate();

       _rb.velocity = _actualDir;
    }

    private void UpdateVAxis(params object[] parameters)
    {
        _actualDir.y = (float)parameters[0];
    }

    private void UpdateHAxis(params object[] parameters)
    {
        _actualDir.x = (float)parameters[0];
    }

    private void Interact(params object[] parameters)
    {
        if (!_interactableOnRange.Any()) return;

        var closest = _interactableOnRange.OrderBy(x =>
            Vector2.Distance(x.transform.position, transform.position)).First();

        closest.gameObject.GetComponent<IInteractable>()?.Interact(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != 6) return;
        
        if(_interactableOnRange.Contains(other)) return;

        _interactableOnRange.Add(other);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != 6) return;
        
        if(!_interactableOnRange.Contains(other)) return;

        _interactableOnRange.Remove(other);
    }
}
