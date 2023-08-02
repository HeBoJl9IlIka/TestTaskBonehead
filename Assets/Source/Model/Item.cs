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

        public int GetStatValue(Stat target)
        {
            Stat stat = _stats.FirstOrDefault(stat => stat.ItemStat == target.ItemStat);

            if (stat == null)
                throw new ArgumentNullException(nameof(target));

            return stat.Value;
        }
    }
}
