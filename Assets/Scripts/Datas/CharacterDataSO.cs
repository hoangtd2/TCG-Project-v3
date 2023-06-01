using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Empty Character Profile", menuName = "Data/Profile/Character")]
public class CharacterDataSO : ScriptableObject
{
    [Header("Infos")]
    [SerializeField] private new string name = "PlaceHolder";
    [SerializeField] private string description = "PlaceHolder";
    [SerializeField] private Sprite sprite = null;
    public string Name { get => name; }
    public string Description { get => description; }
    public Sprite Sprite { get => sprite; }

    [Header("Pre-Gameplay Stats")]
    [SerializeField] private int maxHealth = 60;
    [SerializeField] private int startingCoin = 100;

    [Header("Gameplay Stats")]
    private int curMaxHealth = 0;
    private int curHealth = 0;
    private int curCoin = 0;
    public int CurMaxHealth { get => curMaxHealth; set => curMaxHealth = value; }
    public int CurHealth { get => curHealth; set => curHealth = value; }
    public int CurCoin { get => curCoin; set => curCoin = value; }

    public void Initialize()
    {
        curMaxHealth = maxHealth;
        curHealth = maxHealth;
        curCoin = startingCoin;
    }
}
