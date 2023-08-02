using Bonehead.Model;
using UnityEngine;

[RequireComponent(typeof(CellsFactory))]
public class LevelRoot : MonoBehaviour
{
    private CellsFactory _cellsFactory;
    private ItemsFactory _itemsFactory;
    private Inventory _inventory;

    private void Awake()
    {
        _cellsFactory = GetComponent<CellsFactory>();
        _itemsFactory = new ItemsFactory();
        _inventory = new Inventory(_cellsFactory.CreateCells());

       
    }

    private void Start()
    {
    }

    public void AddItem()
    {
        Item item = _itemsFactory.CreateItem();
        _inventory.AddItem(item);

    }
}
