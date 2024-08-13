using System;
using MKDir.InputBind;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;
    [SerializeField] private float _speed = 5f, _gravity = -9.81f, _jumpPower = 2;
    private CharacterController _characterController;

    private float _verticalVelocity;
    private Vector3 _velocity;

    public bool IsGround => _characterController.isGrounded;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        _inputReader.OnJumpEvent += HandleJumpEvent;
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        ApplyMovement();
        Move();
    }

    private void ApplyGravity()
    {
        if (IsGround && _verticalVelocity < 0)
        {
            _verticalVelocity = -3.0f;
        }
        else
        {
            _verticalVelocity = _gravity * Time.fixedDeltaTime;
        }

        _velocity.y = _verticalVelocity;
    }

    private void HandleJumpEvent()
    {
        _verticalVelocity = _jumpPower;
    }

    private void Move()
    {
        _characterController.Move(_velocity);
    }

    private void ApplyMovement()
    {
        _velocity = _inputReader.Movement * (Time.fixedDeltaTime * _speed);
    }
}
