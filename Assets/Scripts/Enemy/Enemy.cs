using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _searchhRadius = 2f;
    [SerializeField] float _touchRadius = .1f;
    [SerializeField] float _movementSpeed;
    [SerializeField] LayerMask _playerMask;

    SpriteRenderer _spriteRenderer;

    public float SearchRadius => _searchhRadius;
    public LayerMask PlayerMask => _playerMask;

    public float MovementSpeed => _movementSpeed;
    public Rigidbody2D _rigidbody2D { get; private set; }

    EnemyStateMachine _stateMachine;
    public EnemyStateIdle IdleState { get; private set; }
    public EnemyStateFlee FleeState { get; private set; }
    public EnemyStateCaptured CapturedState { get; private set; }

    GameObject _player;

    void Awake()
    {
        _stateMachine = new EnemyStateMachine();
        IdleState = new EnemyStateIdle(this, _stateMachine);
        FleeState = new EnemyStateFlee(this, _stateMachine);
        CapturedState = new EnemyStateCaptured(this, _stateMachine);


    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _stateMachine.Initialize(IdleState);
    }

    void Update()
    {
        _stateMachine.CurrentState.LogicUpdate();
    }
    void FixedUpdate()
    {
        _stateMachine.CurrentState.PhysicsUpdate();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position, SearchRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position, _touchRadius);
    }

    public bool CheckIfPlayerNearby()
    {
        Collider2D other = Physics2D.OverlapCircle(gameObject.transform.position, SearchRadius, PlayerMask);
        if (other != null) _player = other.gameObject;
        else _player = null;
        return _player != null;
    }

    public void Flee()
    {
        if (_player == null) return;
        Vector2 direction = (transform.position - _player.transform.position).normalized;
        _rigidbody2D.velocity = direction * _movementSpeed;
    }

    public void WalkRandomly()
    {
        Vector2 direction = UnityEngine.Random.insideUnitCircle.normalized;
        _rigidbody2D.velocity = direction * _movementSpeed;
    }

    public bool CheckIfTouchedByPlayer()
    {
        return Physics2D.OverlapCircle(gameObject.transform.position, _touchRadius, PlayerMask);
    }

    public void Capture()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _spriteRenderer.color = Color.blue;
    }
}
