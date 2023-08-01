using System;
using System.Linq;

namespace Bonehead.Model
{
    public class Inventory
    {
        private Cell[] _cells;

        public event Action AddedItem;

        public bool HasItem(Config.TypeItem typeItem)
        {
            Cell cell = _cells.FirstOrDefault(cell => cell.TypeItem == typeItem);

            return cell.IsEmpty == false;
        }

        public void AddItem(Item item)
        {
            Cell cell = _cells.FirstOrDefault(cell => cell.TypeItem == item.TypeItem);
            cell.AddItem(item);
            AddedItem?.Invoke();
        }

        public int GetItemsStats(Config.ItemStats itemStats)
        {
            int amount = 0;

            foreach (var cell in _cells)
            {
                if (cell.IsEmpty == false)
                    amount += cell.GetStats(itemStats);
            }

            return amount;
        }
    }
}
