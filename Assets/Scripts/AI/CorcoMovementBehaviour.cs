namespace AI
{
    public class CorcoMovementBehaviour : AnimalBehaviour
    {
        public override void UpdateBehaviour()
        {
            MoveForward();

            if (IsWalking())
            {
                Rotate();
                IncrementSpeed();
            }
            else
            {
                DecrementSpeed();
            }

            if (IsOnLocation())
                SetNextPosition();
        }
    }
}
