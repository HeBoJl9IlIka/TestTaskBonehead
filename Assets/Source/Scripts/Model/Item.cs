using System.Linq;
using System;

namespace Bonehead.Model
{
    public class Item
    {
        private readonly Stat[] _stats;

        public Config.TypeItem TypeItem { get; private set; }

        public Item(Config.TypeItem typeItem, Stat[] stats)
        {
            TypeItem = typeItem;
            _stats = stats;
        }

        public int GetStatValue(Config.ItemStats targetStat)
        {
            Stat stat = _stats.FirstOrDefault(stat => stat.ItemStat == targetStat);

            if (stat == null)
                throw new ArgumentNullException(nameof(targetStat));

            return stat.Value;
        }

        public int GetAllStatsValue()
        {
            int amount = 0;

            foreach (Stat stat in _stats)
                amount += stat.Value;

            return amount;
        }
    }
}
