using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    private void Awake()
    {
        if(instance == null) { instance = this; DontDestroyOnLoad(gameObject); }
        else                 { Destroy(gameObject); }
    }

    [Header("Meta Data")]
    [SerializeField] private GameplayDataSO gameplayDataSO = null;
    public GameplayDataSO GameplayData { get => gameplayDataSO; set => gameplayDataSO = value; }
}
