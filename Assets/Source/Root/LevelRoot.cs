using Bonehead.Model;
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CellsFactory))]
[RequireComponent(typeof(PresentersFactory))]
public class LevelRoot : MonoBehaviour
{
    [SerializeField] private Button _activationButton;
    [SerializeField] private PlayerStatsPresenter _playerStatsPresenter;

    private CellsFactory _cellsFactory;
    private ItemsFactory _itemsFactory;
    private PresentersFactory _presentersFactory;
    private Inventory _inventory;
    private ItemSelector _itemSelector;
    private ItemsIconsPresenter _itemsIconsPresenter;
    private ItemSelectorPresenter _itemSelectorPresenter;

    private void Awake()
    {
        _cellsFactory = GetComponent<CellsFactory>();
        _presentersFactory = GetComponent<PresentersFactory>();

        _itemsIconsPresenter = _presentersFactory.CreateItemsIcons();

        _itemsFactory = new ItemsFactory();
        _inventory = new Inventory(_cellsFactory.CreateCells(_itemsIconsPresenter));
        _itemSelector = new ItemSelector(_inventory);

        _itemSelectorPresenter = _presentersFactory.CreateItemSelector(this, _itemSelector, _itemsIconsPresenter);
    }

    private void Start()
    {
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
        Debug.Log(item.GetAllStatsValue());
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
}
