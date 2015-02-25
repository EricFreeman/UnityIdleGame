using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Upgrades
{
    class MinimumWageWorker : IItem
    {
        public string Name
        {
            get { return "Minimum Wage Worker"; }
        }

        public float MoneyPerSecond { get { return .1f; } }

        public float Price { get { return 15; } }

        public float PriceIncrease { get; set; }
    }
}