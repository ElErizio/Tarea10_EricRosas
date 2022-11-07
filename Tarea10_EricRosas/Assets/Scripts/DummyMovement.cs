using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    [SerializeField] private float _walkVelocity;

    private Animator _animator;
    private CharacterController _characterController;

    private int _ahAxisX;
    private int _ahAxisY;

    private float _horizontalInput;
    private float _verticalInput;   

    private void Awake()
    {
        SetComponents();
        SetAnimatorHashes();
    }

    private void Update()
    {
        SetInput();
        SetAnimatorParameters();
        Move();
    }

    private void SetInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }
    
    private void SetComponents()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    private void SetAnimatorHashes()
    {
        _ahAxisX = Animator.StringToHash("AxisX");
        _ahAxisY = Animator.StringToHash("AxisY");  
    }

    private void SetAnimatorParameters()
    {
        _animator.SetFloat(_ahAxisX, _horizontalInput);
        _animator.SetFloat(_ahAxisY, _verticalInput);
    }

    private Vector3 InputToVector()
    {
        return new Vector3(_horizontalInput, 0f,  _verticalInput);
    }

    private void Move()
    {
        _characterController.Move(InputToVector() * _walkVelocity * Time.deltaTime);
    }


}
