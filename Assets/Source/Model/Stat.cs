namespace Bonehead.Model
{
    public abstract class Stat
    {
        public virtual Config.ItemStats ItemStat { get; protected set; }
        public int Value { get; private set; }

        public Stat(int value)
        {
            Value = value;
        }
    }

    public class AttackStat : Stat
    {
        public override Config.ItemStats ItemStat => Config.ItemStats.Attack;

        public AttackStat(int value) : base(value) { }
    }

    public class DefenseStat : Stat
    {
        public override Config.ItemStats ItemStat => Config.ItemStats.Defense;

        public DefenseStat(int value) : base(value) { }
    }

    public class HealthStat : Stat
    {
        public override Config.ItemStats ItemStat => Config.ItemStats.Health;

        public HealthStat(int value) : base(value) { }
    }
}
