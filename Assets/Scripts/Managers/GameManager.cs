using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public UpdateManager updateManager { private set; get; }
    [HideInInspector] public Model model { private set; get; }

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
        model = FindObjectOfType<Model>();
    }

    private void Update()
    {
        if (gamePaused) return;
        
        updateManager.OnUpdate();
    }

    private void LateUpdate()
    {
        if (gamePaused) return;
        
        updateManager.OnLateUpdate();
    }
}
