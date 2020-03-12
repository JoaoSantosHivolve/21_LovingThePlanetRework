namespace AI
{
    public class GarranoMovementBehaviour : AnimalBehaviour
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
