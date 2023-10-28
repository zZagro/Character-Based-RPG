using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO PlayerData { get; private set; }

    [field: Header("Collisions")]
    [field: SerializeField] public PlayerCapsuleColliderUtility ColliderUtility { get; private set; }
    [field: SerializeField] public PlayerLayerData LayerData { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    [field: Header("Playable Characters")]
    [field: SerializeField] public PlayableCharacterDataHolder CurrentCharacter { get; private set; }
    [field: SerializeField] public List<GameObject> CurrentCharacterPartyList { get; private set; }
    [field: SerializeField] public Transform CharacterParentTransform { get; private set; }

    public Rigidbody Rigidbody { get; set; }
    public Animator Animator { get; set; }

    public Transform MainCameraTransform { get; private set; }

    public PlayerInput Input { get; private set; }

    private PlayerMovementStateMachine movementStateMachine { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Input = GetComponent<PlayerInput>();

        ColliderUtility.Initialize(gameObject);
        ColliderUtility.CalculateCapsuleColliderDimensions();

        AnimationData.Initialize();

        MainCameraTransform = Camera.main.transform;

        InitializePlayableCharacterList();
        CurrentCharacter = CurrentCharacterPartyList[0].GetComponent<PlayableCharacterDataHolder>();

        Animator = CurrentCharacter.Animator;

        movementStateMachine = new PlayerMovementStateMachine(this);
    }

    private void OnValidate()
    {
        ColliderUtility.Initialize(gameObject);
        ColliderUtility.CalculateCapsuleColliderDimensions();
    }

    private void Start()
    {
        movementStateMachine.ChangeState(movementStateMachine.IdlingState);
    }

    private void OnTriggerEnter(Collider other)
    {
        movementStateMachine.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        movementStateMachine.OnTriggerExit(other);
    }

    private void Update()
    {
        movementStateMachine.HandleInput();
        movementStateMachine.Update();
    }

    private void FixedUpdate()
    {
        movementStateMachine.PhysicsUpdate();
    }

    public void OnMovementStateAnimationEnterEvent()
    {
        movementStateMachine.OnAnimationEnterEvent();
    }

    public void OnMovementStateAnimationExitEvent()
    {
        movementStateMachine.OnAnimationExitEvent();
    }

    public void OnMovementStateAnimationTransitionEvent()
    {
        movementStateMachine.OnAnimationTransitionEvent();
    }

    private void InitializePlayableCharacterList()
    {
        CurrentCharacterPartyList = new List<GameObject>();

        foreach (Transform child in CharacterParentTransform)
        {
            CurrentCharacterPartyList.Add(child.gameObject);
        }
    }
}
