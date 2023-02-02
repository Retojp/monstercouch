using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy _enemy;
    protected EnemyStateMachine _stateMachine;
    bool _touchedByPlayer;
    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        Debug.Log("Entered State: " + this.GetType().Name);
        DoChecks();
    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {
        if (_touchedByPlayer)
        {
            _stateMachine.ChangeState(_enemy.CapturedState);
        }
    }
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {
        _touchedByPlayer = _enemy.CheckIfTouchedByPlayer();
    }
}
