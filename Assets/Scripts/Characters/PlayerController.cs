using System;
using UnityEngine;
using static CharacterDirection;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private PlayerStats playerStats;

    private Directions _currentDirection = Directions.S;
    
    private enum MovementState
    {
        Idle,
        Walk,
        Run,
    }
    
    
    private MovementState _movementState = MovementState.Idle;
    

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        HandleMovement();
        UpdateDirectionByMouse();

    }
    
    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);

        if (direction.magnitude == 0)
        {
            _movementState = MovementState.Idle;
        }
        else
        {
            _currentDirection = CharacterDirection.GetDirection(direction,_currentDirection);

            if (Input.GetKey(KeyCode.LeftShift) && playerStats.currentStamina > 0)
            {
                _movementState = MovementState.Run;
                playerStats.currentStamina -= 2f * Time.deltaTime;

            }
            else
                _movementState = MovementState.Walk;

            float speed = (_movementState == MovementState.Run) ? playerStats.MoveSpeed * 1.5f : playerStats.MoveSpeed;
            transform.Translate(direction.normalized * (speed * Time.deltaTime));
        }

        PlayAnimation(_movementState, _currentDirection);
    }

    private void PlayAnimation(MovementState state, Directions directions)
    {
        string animName = state.ToString() + "_" + directions.ToString();
        _animator.Play(animName);
    }
    void UpdateDirectionByMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mouseWorldPos - transform.position;

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            _currentDirection = dir.x > 0 ? Directions.E : Directions.W;
        else
            _currentDirection = dir.y > 0 ? Directions.N : Directions.S;

        if (Input.GetMouseButtonDown(0))
        {
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        _animator.Play("Attack1_" + _currentDirection.ToString());
    }
   
}


