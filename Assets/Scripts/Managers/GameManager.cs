using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UpdateManager updateManager;

    private bool gamePaused = false;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        updateManager = GetComponent<UpdateManager>();
    }

    private void Update()
    {
        if (gamePaused) return;
        
        updateManager.OnUpdate();
    }
}
