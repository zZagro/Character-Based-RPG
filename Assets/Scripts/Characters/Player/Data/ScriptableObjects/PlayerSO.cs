using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Custom/Player/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundedData GroundedData { get; private set; }
}
