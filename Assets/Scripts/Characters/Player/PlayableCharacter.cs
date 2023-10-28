using CombatSystem;
using UnityEngine;

public class PlayableCharacterDataHolder : MonoBehaviour
{
    [field: Header("Playable Character Data")]
    [field: SerializeField] public PlayableCharacterSO PlayableCharacter { get; private set; }

    public CharacterStats CharacterStats { get; private set; }

    public int CurrentCharacterLevel { get; private set; }

    public Animator Animator { get; private set; }
    public Armory Armory { get; private set; }

    private Player player;

    private void Awake()
    {
        player = transform.parent.parent.GetComponent<Player>();
        Animator = GetComponent<Animator>();
        Armory = GetComponent<Armory>();

        PlayableCharacter.LoadData();

        SetStats();
    }

    private void SetStats()
    {
        CharacterStats = PlayableCharacter.PlayableCharacterStats;
    }
}
