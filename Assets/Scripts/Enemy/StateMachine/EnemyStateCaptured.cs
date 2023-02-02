using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateCaptured : EnemyState
{
    public EnemyStateCaptured(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
    }


    public override void Enter()
    {
        base.Enter();
        _enemy.Capture();
    }
}

