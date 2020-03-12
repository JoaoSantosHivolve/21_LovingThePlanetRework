using UnityEngine;

namespace Anim
{
    public class WalkingAnimationBehaviour : AnimalAnimationBehaviour
    {
        public bool canRun;
        private static readonly int Walk = Animator.StringToHash("walk");
        private static readonly int Run = Animator.StringToHash("run");

        public float timer;
        public float targetTimer;
        private const float MAX_WALK_TIMER = 5f;
        private const float MIN_WALK_TIMER = 1f;
        private const float MAX_IDLE_TIMER = 5f;
        private const float MIN_IDLE_TIMER = 1f;

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= targetTimer)
            {
                timer = 0;
                ChangeAnimation();
            }
        }

        public override void ChangeAnimation()
        {
            var state = !animator.GetBool(Walk);
            SetAnimatorBool(Walk, state);
            SetAnimatorBool(Run, state && Random.value > 0.5f);

            targetTimer = state
                ? Random.Range(MIN_WALK_TIMER, MAX_WALK_TIMER)
                : Random.Range(MIN_IDLE_TIMER, MAX_IDLE_TIMER);
        }
    }
}
