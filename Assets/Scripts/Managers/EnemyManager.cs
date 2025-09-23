using UnityEngine;
using static CharacterDirection;
public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyStats stats;
        [SerializeField] private PlayerController target;
        [SerializeField] private Animator animator;

        private enum AnimationState
        {
            Walk,
            Run,
            Attack
        }

        private AnimationState _animationState;
        private Directions _currentDirection = Directions.S;
        private Vector3 _direction;
   

        protected virtual void Update()
        {
            if (target == null) return;

            _direction = (target.transform.position - transform.position).normalized;
            transform.position += _direction * (stats.MoveSpeed * Time.deltaTime);

            _currentDirection = CharacterDirection.GetDirection(_direction, _currentDirection);

            PlayAnimation(AnimationState.Walk, _currentDirection);
        }

        private void PlayAnimation(AnimationState state, Directions direction)
        {
            string animName = state.ToString() + "_" + direction.ToString();
            animator.Play(animName);
        }
        

      
    }


