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

    [Header("Data")]
    [SerializeField] private List<CharacterDataSO> characterProfiles = new List<CharacterDataSO>();
    public List<CharacterDataSO> CharacterProfiles { get => characterProfiles; set => characterProfiles = value; }
}
