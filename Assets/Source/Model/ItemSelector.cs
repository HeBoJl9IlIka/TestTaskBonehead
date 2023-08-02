using System;

namespace Bonehead.Model
{
    public class ItemSelector
    {
        private Inventory _inventory;
        private Item _newItem;

        public ItemSelector(Inventory inventory)
        {
            _inventory = inventory;
        }

        public event Action<Item, Item> Showed;
        public event Action<Item> Equipped;
        public event Action<Item> Dropped;

        public void ShowSelection(Item item)
        {
            _newItem = item;
            if (_inventory.TryGetItem(_newItem.TypeItem, out Item currentItem))
                Showed?.Invoke(_newItem, currentItem);
            else
                Showed?.Invoke(_newItem, null);
        }
    }
}
