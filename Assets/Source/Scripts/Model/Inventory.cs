using System;
using System.Collections.Generic;
using System.Linq;

namespace Bonehead.Model
{
    public class Inventory
    {
        private readonly Cell[] _cells;

        public IReadOnlyCollection<Cell> Cells => _cells;

        public Inventory(Cell[] cells)
        {
            _cells = cells;
        }

        public event Action AddedItem;

        public bool TryGetItem(Config.TypeItem typeItem, out Item item)
        {
            Cell cell = _cells.FirstOrDefault(cell => cell.TypeItem == typeItem);

            item = cell.Item;
            return cell.IsEmpty == false;
        }

        public void AddItem(Item item)
        {
            Cell cell = _cells.FirstOrDefault(cell => cell.TypeItem == item.TypeItem);
            cell.AddItem(item);
            AddedItem?.Invoke();
        }

        public int GetItemsStats(Config.ItemStats stat)
        {
            int amount = 0;

            foreach (var cell in _cells)
            {
                if (cell.IsEmpty == false)
                    amount += cell.GetStatValue(stat);
            }

            return amount;
        }
    }
}
