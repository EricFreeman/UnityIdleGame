using Assets.Scripts.Enums;

namespace Assets.Scripts.Interfaces
{
    public interface IUpgrade
    {
        string Name { get; }
        IItem Item { get; }
        float Price { get; }
        float UpgradeAmount { get; }
        UpgradeType UpgradeType { get; }

        int? UnlockCount { get; }
    }
}