using Assets.Scripts.Enums;

namespace Assets.Scripts.Interfaces
{
    public interface IUpgrade
    {
        string Name { get; set; }
        IItem Item { get; set; }
        float UpgradeAmount { get; set; }
        UpgradeType UpgradeType { get; set; }
    }
}