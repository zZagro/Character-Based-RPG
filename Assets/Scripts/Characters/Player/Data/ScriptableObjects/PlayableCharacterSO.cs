using UnityEngine;

[CreateAssetMenu(fileName = "PlayableCharacter", menuName = "Custom/Player/PlayableCharacter")]
public class PlayableCharacterSO : ScriptableObject
{
    [field: Header("General Information")]
    [field: SerializeField] public string CharacterName { get; private set; }
    [field: SerializeField] public string CharacterDescription { get; private set; }
    [field: SerializeField] public Rarity CharacterRarity { get; private set; }
    [field: SerializeField] public WeaponType CharacterWeaponType { get; private set; }

    [field: Header("Stats")]
    [field: SerializeField] public CharacterStats PlayableCharacterStats { get; private set; }

    [field: Header("Graphics")]
    [field: SerializeField] public GameObject CharacterPrefab { get; private set; }
    [field: SerializeField] public Sprite UISprite { get; private set; }

    public int CurrentCharacterLevel { get; private set; }
    public int CurrentMaxLevel { get; private set; }

    public void LoadData()
    {

    }
}
