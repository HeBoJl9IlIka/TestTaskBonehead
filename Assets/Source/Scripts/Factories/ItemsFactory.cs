using System;
using System.Collections.Generic;

namespace Bonehead.Model
{
    public class ItemsFactory
    {
        private Config.TypeItem _lastItemType;
        private int _amountCreatedItems;
        private System.Random _random = new System.Random();
        private List<Stat> _stats = new List<Stat>();
        private Config.TypeItem _currentItemType;

        public Item CreateItem()
        {
            GenerateItemType();
            GenerateItemStat();

            if (_currentItemType == _lastItemType)
            {
                ++_amountCreatedItems;
            }
            else
            {
                _amountCreatedItems = 0;
                _lastItemType = _currentItemType;
            }

            return new Item(_currentItemType, _stats.ToArray());
        }

        public void GenerateItemType()
        {
            Array array = Enum.GetValues(typeof(Config.TypeItem));
            Config.TypeItem typeItem = (Config.TypeItem)_random.Next(array.Length);

            if (_amountCreatedItems >= Config.MaxAmountCreatedItems)
            {
                while (typeItem == _lastItemType)
                {
                    typeItem = (Config.TypeItem)_random.Next(array.Length);
                }
            }

            _currentItemType = typeItem;
        }

        public void GenerateItemStat()
        {
            _stats.Clear();

            int attackValue = _random.Next(Config.MinStat, Config.MaxStat);
            int defenseValue = _random.Next(Config.MinStat, Config.MaxStat);
            int healthValue = _random.Next(Config.MinStat, Config.MaxStat);

            _stats.Add(new AttackStat(attackValue));
            _stats.Add(new DefenseStat(defenseValue));
            _stats.Add(new HealthStat(healthValue));
        }
    }
}
