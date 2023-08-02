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
        public const int MaxAmountCreatedItems = 3;
    }
}
