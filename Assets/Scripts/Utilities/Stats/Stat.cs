using System;
using UnityEngine;

[Serializable]
public class Stat
{
    [field: SerializeField] public StatType StatType { get; private set; }
    [field: SerializeField] public int BaseValue { get; private set; }
    [field: SerializeField] public int FlatModifier { get; private set; }
    [field: SerializeField] public int PercentageModifier { get; private set; }

    public int CurrentValue { get; private set; }
    public int TotalValue { get; private set; }

    public void AddModifierValue(int valueToAdd, StatModType valueType)
    {
        switch (valueType)
        {
            case StatModType.Flat:
                {
                    FlatModifier += valueToAdd;
                    break;
                }
            case StatModType.Percentage:
                {
                    PercentageModifier += valueToAdd;
                    break;
                }
            default:
                {
                    break;
                }
        }

        CalculateTotalStatValue();
    }

    public void RemoveModifierValue(int valueToRemove, StatModType valueType)
    {
        switch (valueType)
        {
            case StatModType.Flat:
                {
                    FlatModifier -= valueToRemove;
                    break;
                }
            case StatModType.Percentage:
                {
                    PercentageModifier -= valueToRemove;
                    break;
                }
            default:
                {
                    break;
                }
        }

        CalculateTotalStatValue();
    }

    public void CalculateTotalStatValue()
    {
        int oldTotalValue = TotalValue;
        TotalValue = (BaseValue + FlatModifier) * Mathf.RoundToInt(PercentageModifier / 100 + 1);
        CurrentValue += TotalValue - oldTotalValue;
    }

    public void RemoveCurrentValue(int valueToRemove)
    {
        CurrentValue -= valueToRemove;
    }

    public void SetBaseValue(int value)
    {
        BaseValue = value;
    }

    public void SetStatType(StatType type)
    {
        StatType = type;
    }
}