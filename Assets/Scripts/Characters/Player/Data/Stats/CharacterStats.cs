using System;
using UnityEngine;

[Serializable]
public class CharacterStats
{
    [field: SerializeField] public Stat Health { get; private set; }
    [field: SerializeField] public Stat Defense { get; private set; }
    [field: SerializeField] public Stat CriticalHitChance { get; private set; }
    [field: SerializeField] public Stat CriticalHitDamage { get; private set; }
    [field: SerializeField] public Stat Luck { get; private set; }
    [field: SerializeField] public Stat Attack { get; private set; }
    [field: SerializeField] public Stat AttackSpeed { get; private set; }
}
