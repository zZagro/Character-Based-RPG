using UnityEngine;

public class PlayerAttackingState : PlayerGroundedState
{
    public PlayerAttackingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.ReusableData.MovementSpeedModifier = 0f;

        base.Enter();

        ResetVelocity();

        //StartAnimation(stateMachine.Player.AnimationData.AttackingParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        //StopAnimation(stateMachine.Player.AnimationData.AttackingParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            return;
        }

        OnMove();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!IsMovingHorizontally())
            return;

        ResetVelocity();
    }
}
