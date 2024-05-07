using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public Action OnUpdate { get; private set; } = delegate { };

    public void AddUpdate(Action newUpdate)
    {
        OnUpdate += newUpdate;
    }

    public void RemoveUpdate(Action newUpdate)
    {
        OnUpdate -= newUpdate;
    }

    public void ResetUpdate()
    {
        OnUpdate = delegate {  };
    }
}
