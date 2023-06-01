using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gameplay Data", menuName = "Data/MetaData/GameplayData")]
public class GameplayDataSO : ScriptableObject
{
    // save data in session and when close game , write data to a seperate json file. when game open again -> read json file and load data
    [Header("Meta Data")]
    [SerializeField] private FinanceDataSO financeData = null;

    public FinanceDataSO FinanceData { get => financeData; set => financeData = value; }
}
