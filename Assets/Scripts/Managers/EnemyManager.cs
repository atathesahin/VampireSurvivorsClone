using UnityEngine;
using static CharacterDirection;
public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyStats stats;
        [SerializeField] private PlayerController target;
        [SerializeField] private Animator animator;


        [SerializeField] private float attackRange;
 
        private enum AnimationState
        {
            Walk,
            Run,
            Attack1
        }

        private AnimationState _animationState;
        private Directions _currentDirection = Directions.S;
        private Vector3 _direction;
   

        protected virtual void Update()
        {
            if (target == null) return;
            
            _direction = (target.transform.position - transform.position).normalized;
            _currentDirection = CharacterDirection.GetDirection(_direction, _currentDirection);
            
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance <= attackRange)
            {
                AttackToPlayer();
            }
            else if(distance > attackRange)
            {
                MoveToTarget(); 
                PlayAnimation(AnimationState.Walk,_currentDirection);
            }
            
        }

        private void AttackToPlayer()
        {
            PlayAnimation(AnimationState.Attack1,_currentDirection);
        }

        private void MoveToTarget()
        {
            transform.position += _direction * (stats.MoveSpeed * Time.deltaTime);
            
        }

        private void PlayAnimation(AnimationState state, Directions direction)
        {
          
            string animName = state.ToString() + "_" + direction.ToString();
            animator.Play(animName);
        }
        

      
    }


