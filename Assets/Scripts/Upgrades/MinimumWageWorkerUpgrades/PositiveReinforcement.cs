using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;

namespace Assets.Scripts.Upgrades.MinimumWageWorkerUpgrades
{
    public class PositiveReinforcement : IUpgrade
    {
        public string Name { get { return "Positive Reinforcement"; } }
        public float Price { get { return 50; } }
        public float UpgradeAmount { get { return 1; } }
        public UpgradeType UpgradeType { get; set; }
        
        public IItem Item { get { return new MinimumWageWorker(); } }
        public int? UnlockCount { get { return 0; } }
    }
}
