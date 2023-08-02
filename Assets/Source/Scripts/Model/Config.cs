namespace Bonehead.Model
{
    public static class Config
    {
        public enum TypeItem
        {
            Weapon,
            Shield,
            Helmet
        }

        public enum ItemStats
        {
            Attack,
            Defense,
            Health
        }

        public const int MinStat = 1;
        public const int MaxStat = 15;
        public const int MaxAmountCreatedItems = 2;
        public const int MaxCountMoney = 45;
        public const float MinRandomMoneyPosition = -10f;
        public const float MaxRandomMoneyPosition = 10f;
        public const float MinRandomMoneyDuration = -0.2f;
        public const float MaxRandomMoneyDuration = 0.2f;
        public const string TriggerAnimationAttack = "attack";
    }
}
