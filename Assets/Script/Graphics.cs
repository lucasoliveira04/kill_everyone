using UnityEngine;

namespace Script
{
    public class Graphics : MonoBehaviour
    {
        private Animator animator;

        private bool _isWalking;
        private bool isIdle;   

        public bool IsWalking
        {
            get => _isWalking;
            set
            {
                _isWalking = value;
                animator.SetBool("IsWalking", value);
            }
        }
        
        public bool IsIdle
        {
            get => isIdle;
            set
            {
                isIdle = value;
                animator.SetBool("isIdle", value);
            }
        }
        
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        
    }
}