using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public Action OnUpdate { get; private set; } = delegate { };
    public Action OnLateUpdate { get; private set; } = delegate { };

    #region Update
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
    #endregion

    #region Late Update
    public void AddLateUpdate(Action newUpdate)
    {
        OnLateUpdate += newUpdate;
    }

    public void RemoveLateUpdate(Action newUpdate)
    {
        OnLateUpdate -= newUpdate;
    }

    public void ResetLateUpdate()
    {
        OnLateUpdate = delegate {  };
    }
    #endregion
}
