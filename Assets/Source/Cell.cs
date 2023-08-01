using System;

namespace Bonehead.Model
{
    public class Cell
    {
        public Config.TypeItem TypeItem { get; private set; }
        public Item Item { get; private set; }

        public bool IsEmpty => Item == null;

        public event Action<Item> Changed;

        public Cell(Config.TypeItem typeItem, Item item)
        {
            TypeItem = typeItem;
            Item = item;
        }

        public void AddItem(Item item)
        {
            if (item.TypeItem != TypeItem)
                throw new ArgumentException(nameof(item.TypeItem));

            Item = item;
            Changed?.Invoke(Item);
        }

        public int GetStats(Config.ItemStats itemStats)
        {
            switch (itemStats)
            {
                case Config.ItemStats.Attack:
                    return Item.AttackStats;
                case Config.ItemStats.Defense:
                    return Item.DefenseStats;
                case Config.ItemStats.Health:
                    return Item.HealthStats;
            }

            return 0;
        }
    }
}
