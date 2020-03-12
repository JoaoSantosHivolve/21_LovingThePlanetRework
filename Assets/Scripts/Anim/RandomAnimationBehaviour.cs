using UnityEngine;
using Random = UnityEngine.Random;

namespace Anim
{
    public class RandomAnimationBehaviour : AnimalAnimationBehaviour
    {
        private AnimationClip[] m_Clips;

        public float timer;
        public float target;
        private const float MAX_WAIT_TIME = 4;
        private const float MIN_WAIT_TIME = 1;

        private void Start()
        {
            m_Clips = animator.runtimeAnimatorController.animationClips;
        }
        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= target)
            {
                timer = 0;
                ChangeAnimation();
            }
        }

        public override void ChangeAnimation()
        {
            // Play random animation
            var index = Random.Range(0, m_Clips.Length);
            animator.CrossFade(m_Clips[index].name, 0.25f);

            // Set animation time
            target = Random.Range(MIN_WAIT_TIME, MAX_WAIT_TIME);
        }
    }
}