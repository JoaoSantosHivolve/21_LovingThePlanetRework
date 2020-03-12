using UnityEngine;

namespace Anim
{
    public abstract class AnimalAnimationBehaviour : MonoBehaviour
    {
        [SerializeField]
        protected Animator animator;

        private void Start()
        {
            ChangeAnimation();
        }

        public abstract void ChangeAnimation();

        protected void SetAnimatorBool(int dir, bool value)
        {
            animator.SetBool(dir, value);
        }
    }
}
