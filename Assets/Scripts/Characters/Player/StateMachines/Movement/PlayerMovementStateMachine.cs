public class PlayerMovementStateMachine : StateMachine
{
    public Player Player { get; }
    public PlayerStateReusableData ReusableData { get; }

    public PlayerIdlingState IdlingState { get; }

    public PlayerDashingState DashingState { get; }

    public PlayerRunningState RunningState { get; }
    public PlayerSprintingState SprintingState { get; }

    public PlayerMediumStoppingState MediumStoppingState { get; }
    public PlayerHardStoppingState HardStoppingState { get; }

    public PlayerAttackingState AttackingState { get; }

    public PlayerMovementStateMachine(Player player)
    {
        Player = player;
        ReusableData = new PlayerStateReusableData();

        IdlingState = new PlayerIdlingState(this);

        DashingState = new PlayerDashingState(this);

        RunningState = new PlayerRunningState(this);
        SprintingState = new PlayerSprintingState(this);

        MediumStoppingState = new PlayerMediumStoppingState(this);
        HardStoppingState = new PlayerHardStoppingState(this);

        AttackingState = new PlayerAttackingState(this);
    }
}
