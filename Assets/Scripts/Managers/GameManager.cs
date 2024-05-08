using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public UpdateManager UpdateManager { private set; get; }
    [HideInInspector] public UIManager UIManager { private set; get; }
    [HideInInspector] public EconomyManager EconomyManager { private set; get; }
    [HideInInspector] public UIStore Store { private set; get; }
    [HideInInspector] public Model model { private set; get; }

    private bool gamePaused = false;

    [SerializeField] private GameObject _randomMerchant;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        UpdateManager = GetComponent<UpdateManager>();
        UIManager = GetComponentInChildren<UIManager>();
        EconomyManager = GetComponentInChildren<EconomyManager>();
        Store = UIManager.GetStore();
        model = FindObjectOfType<Model>();
    }

    private void Update()
    {
        if (gamePaused) return;
        
        UpdateManager.OnUpdate();
    }

    private void LateUpdate()
    {
        if (gamePaused) return;
        
        UpdateManager.OnLateUpdate();
    }

    public void RollRandomMerchant()
    {
        var percent = Random.Range(0, 100);

        _randomMerchant.SetActive(percent < 30);
    }
}
