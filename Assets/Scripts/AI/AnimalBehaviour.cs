using UnityEngine;

namespace AI
{
    public abstract class AnimalBehaviour : MonoBehaviour
    {
        public float maxSpeed;
        public float accSpeed;
        public float rotSpeed;
        public float walkingRadius;
        public Animator animator;

        private float m_Speed;
        public Vector3 destination;
        public Vector3 startingPosition;
        private static readonly int Walk = Animator.StringToHash("walk"); 
        private static readonly int Run = Animator.StringToHash("run");

        private void Awake()
        {
            startingPosition = transform.position;

            // var debugObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // debugObj.transform.position = startingPosition + (Vector3.right * -walkingRadius) + (Vector3.forward * -walkingRadius);
            // debugObj.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            // debugObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // debugObj.transform.position = startingPosition + (Vector3.right * walkingRadius) + (Vector3.forward * -walkingRadius);
            // debugObj.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            // debugObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // debugObj.transform.position = startingPosition + (Vector3.right * -walkingRadius) + (Vector3.forward * walkingRadius);
            // debugObj.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            // debugObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // debugObj.transform.position = startingPosition + (Vector3.right * walkingRadius) + (Vector3.forward * walkingRadius);
            // debugObj.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
        }
        private void Start()
        {
            SetNextPosition();
        }
        private void Update()
        {
            UpdateBehaviour();
        }

        public abstract void UpdateBehaviour();

        protected bool IsWalking()
        {
            return animator.GetBool(Walk);
        }
        protected bool IsRunning()
        {
            return animator.GetBool(Run);
        }
        protected bool IsOnLocation()
        {
            //Debug.Log(Vector3.Distance(transform.position, m_Destination));
            return Vector3.Distance(transform.position, destination) <= 0.05f;
        }

        protected void SetNextPosition()
        {
            destination = GetRandomPosition();
        }
        protected void MoveForward()
        {
            transform.position += transform.forward * m_Speed;
        }
        protected void MoveForward(float baseSpeed)
        {
            transform.position += transform.forward * ((m_Speed / 2) + baseSpeed);
        }
        protected void Rotate()
        {
            // Rotate towards destination
            var dir = destination - transform.position;
            var to = Quaternion.LookRotation(dir, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, to, Time.deltaTime * rotSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, to, rotSpeed);
        }
        protected void IncrementSpeed()
        {
            // Is running
            if (IsRunning())
            {
                var mSpeed = maxSpeed * 2f;
                if (m_Speed >= mSpeed)
                {
                    m_Speed = mSpeed;
                }
                else
                    m_Speed += accSpeed;
            }
            // Is walking
            else
            {
                if (m_Speed >= maxSpeed)
                {
                    m_Speed = maxSpeed;
                }
                else
                    m_Speed += accSpeed;
            }
        }
        protected void DecrementSpeed()
        {
            if (m_Speed <= 0)
            {
                m_Speed = 0;
            }
            else
                m_Speed -= accSpeed * 3;
        }
        
        private Vector3 GetRandomPosition()
        {
            Vector3 pos;
            do
            {
                var x = Random.Range(-walkingRadius, walkingRadius);
                var z = Random.Range(-walkingRadius, walkingRadius);
                pos = startingPosition + (Vector3.right * x) + (Vector3.forward * z);

            } while (Vector3.Distance(pos, transform.position) < walkingRadius / 2.5f);
            
            return pos;
        }
    }
}
