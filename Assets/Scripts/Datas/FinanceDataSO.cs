using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FinanceType { Gold }

[Serializable] public class FinanceElement
{
    [SerializeField] private FinanceType _type;
    [SerializeField] private int _value;
    public FinanceType Type { get => _type; set => _type = value; }
    public int Value { get => _value; set => _value = value; }
}
[CreateAssetMenu(fileName = "Finance Data", menuName = "Data/MetaData/Finance")]
[Serializable] public class FinanceDataSO : ScriptableObject
{
    /// <summary>
    /// For Display Finance changes
    /// </summary>
    public Action<FinanceType, int> OnFinanceDataChange;

    // Datas
    [SerializeField] private FinanceElement gold = null;
    
    public void Initialize()
    {
        gold.Value = 100;
    }

    public FinanceElement GetFinanceFromType(in FinanceType financeType)
    {
        return financeType switch
        {
            FinanceType.Gold => gold,
            _ => null
        };
    }
    public void IncreaseFinance(FinanceType financeType, int amount)
    {
        FinanceElement financeElement = GetFinanceFromType(financeType);
        if (financeElement == null)
        {
            Debug.LogError($"FinanceType {financeType} NotFound");
            return;
        }

        financeElement.Value += amount;
        OnFinanceDataChange?.Invoke(financeType, amount);
    }
    public void DecreaseFinance(FinanceType financeType, int amount)
    {
        FinanceElement financeElement = GetFinanceFromType(financeType);
        if (financeElement == null)
        {
            Debug.LogError($"FinanceType {financeType} NotFound");
            return;
        }

        financeElement.Value -= amount;
        OnFinanceDataChange?.Invoke(financeType, amount);
    }
}
