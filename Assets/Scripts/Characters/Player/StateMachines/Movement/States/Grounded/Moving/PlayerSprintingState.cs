using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprintingState : PlayerMovingState
{
    private PlayerSprintData sprintData;

    public PlayerSprintingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        sprintData = movementData.SprintData;
    }

    public override void Enter()
    {
        stateMachine.ReusableData.MovementSpeedModifier = sprintData.SpeedModifier;

        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.SprintParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.SprintParameterHash);
    }

    public override void Update()
    {
        base.Update();

        StopSprinting();
    }

    private void StopSprinting()
    {
        if (stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.IdlingState);

            return;
        }
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.HardStoppingState);

        base.OnMovementCanceled(context);
    }

    protected override void OnSprintToggleStarted(InputAction.CallbackContext context)
    {
        base.OnSprintToggleStarted(context);

        stateMachine.ChangeState(stateMachine.RunningState);
    }
}
