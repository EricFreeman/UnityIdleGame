using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MoneyDirector : MonoBehaviour
    {
        public float MoneyPerSecond = 1;
        public float CurrentMoney = 0;

        public Text MoneyText;

        void Update()
        {
            CurrentMoney += MoneyPerSecond;
            MoneyText.text = CurrentMoney.ToString("C");
        }
    }
}