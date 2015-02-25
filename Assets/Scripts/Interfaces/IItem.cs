namespace Assets.Scripts.Interfaces
{
    public interface IItem
    {
        string Name { get; }
        float MoneyPerSecond { get; }
        float Price { get; }
        float PriceIncrease { get; }
    }
}