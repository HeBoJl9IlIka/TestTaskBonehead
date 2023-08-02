using System;

namespace Bonehead.Model
{
    public class Cell
    {
        public Item Item { get; private set; }
        public Config.TypeItem TypeItem { get; private set; }

        public bool IsEmpty => Item == null;

        public event Action<Item> Changed;

        public Cell(Config.TypeItem typeItem)
        {
            TypeItem = typeItem;
        }

        public void AddItem(Item item)
        {
            if (item.TypeItem != TypeItem)
                throw new ArgumentException(nameof(item));

            Item = item;
            Changed?.Invoke(Item);
        }

        public int GetStatValue(Stat itemStat)
        {
            return Item.GetStatValue(itemStat);
        }
    }
}
