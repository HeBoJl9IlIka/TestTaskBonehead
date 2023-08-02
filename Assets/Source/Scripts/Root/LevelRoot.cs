using Bonehead.Model;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CellsFactory))]
[RequireComponent(typeof(PresentersFactory))]
[RequireComponent(typeof(MoneyFactory))]
public class LevelRoot : MonoBehaviour
{
    [SerializeField] private Button _activationButton;
    [SerializeField] private PlayerStatsPresenter _playerStatsPresenter;
    [SerializeField] private WalletPresenter _walletPresenter;

    private CellsFactory _cellsFactory;
    private ItemsFactory _itemsFactory;
    private PresentersFactory _presentersFactory;
    private MoneyFactory _moneyFactory;
    private Inventory _inventory;
    private ItemSelector _itemSelector;
    private Wallet _wallet;
    private ItemsIconsPresenter _itemsIconsPresenter;
    private ItemSelectorPresenter _itemSelectorPresenter;

    private MoneyPresenter[] Moneys => _moneyFactory.Moneys;

    private void Awake()
    {
        _cellsFactory = GetComponent<CellsFactory>();
        _presentersFactory = GetComponent<PresentersFactory>();
        _moneyFactory = GetComponent<MoneyFactory>();

        _itemsIconsPresenter = _presentersFactory.CreateItemsIcons();

        _itemsFactory = new ItemsFactory();
        _inventory = new Inventory(_cellsFactory.CreateCells(_itemsIconsPresenter));
        _itemSelector = new ItemSelector(_inventory);
        _wallet = new Wallet();

        _walletPresenter.Init(_wallet);
        _itemSelectorPresenter = _presentersFactory.CreateItemSelector(this, _itemSelector, _itemsIconsPresenter);
    }

    private void OnEnable()
    {
        _activationButton.onClick.AddListener(OnClickActivationButton);
        _inventory.AddedItem += OnAddedItem;
    }

    private void OnDisable()
    {
        _activationButton.onClick.RemoveListener(OnClickActivationButton);
        _inventory.AddedItem -= OnAddedItem;
    }

    public void AddItem(Item item)
    {
        _inventory.AddItem(item);
    }

    public void AddItem(Item newItem, Item currentItem)
    {
        _inventory.AddItem(newItem);
        _itemSelector.ShowSelection(currentItem);
    }

    public void DropItem(Item item)
    {
        int sumStatsValue = item.GetAllStatsValue();

        _wallet.AddMoney(sumStatsValue);
        ShowMoneys(sumStatsValue);
    }

    private void OnClickActivationButton()
    {
        Item item = _itemsFactory.CreateItem();
        _itemSelector.ShowSelection(item);
    }

    private void OnAddedItem()
    {
        Array array = Enum.GetValues(typeof(Config.ItemStats));

        for (int i = 0; i < array.Length; i++)
            _playerStatsPresenter.ShowStats((Config.ItemStats)i, _inventory.GetItemsStats((Config.ItemStats)i));
    }

    private void ShowMoneys(int count)
    {
        for (int i = 0; i < count; i++)
        {
            MoneyPresenter money = Moneys.FirstOrDefault(money => money.gameObject.activeSelf == false);

            if (money != null)
                money.gameObject.SetActive(true);
        }
    }
}
