using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 2f;
    Rigidbody2D _rigidbody2D;
    PlayerInput _playerInput;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = _playerInput.Direction * _movementSpeed;
    }
}
