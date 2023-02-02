using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFlee : EnemyState
{
    bool _isPlayerNearby;
    public EnemyStateFlee(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        _isPlayerNearby = _enemy.CheckIfPlayerNearby();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!_isPlayerNearby)
        {
            _stateMachine.ChangeState(_enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (_isPlayerNearby)
        {
            _enemy.Flee();
        }
    }
}
