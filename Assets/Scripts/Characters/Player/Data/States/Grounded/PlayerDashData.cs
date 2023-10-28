using System;
using UnityEngine;

[Serializable]
public class PlayerDashData
{
    [field: SerializeField] [field: Range(1f, 5f)] public float SpeedModifier { get; private set; } = 3f;
    [field: SerializeField] public PlayerRotationData RotationData { get; private set; }
    [field: SerializeField] [field: Range(0f, 5f)] public float DashCooldownTime { get; private set; } = 0.5f;
}