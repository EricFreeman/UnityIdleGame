namespace Assets.Scripts.Interfaces
{
    public interface IItem
    {
        string Name { get; set; }
        float Price { get; set; }
        float PriceIncrease { get; set; }
        float MoneyPerSecond { get; set; }
    }
}