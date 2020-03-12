namespace AI
{
    public class MarrequinhaMovementBehaviour : AnimalBehaviour
    {
        public override void UpdateBehaviour()
        {
            MoveForward(maxSpeed / 2);
            Rotate();

            if (IsWalking())
            {
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
