public class RandomizerWithSpeedIncrease : AbstractRandomizerDecorator
{
    private float _additionalSpeed;

    public float Increase { get; set; }

    public RandomizerWithSpeedIncrease(Randomizer randomizer) : base(randomizer) { }

    public override float Speed
    {
        get
        {
            float speed = base.Speed;
            _additionalSpeed += Increase;
            return speed + _additionalSpeed; ;
        }
    }

    public override void Reset()
    {
        _additionalSpeed = 0;
    }
}