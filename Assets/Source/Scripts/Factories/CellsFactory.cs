using AYellowpaper.SerializedCollections;
using Bonehead.Model;
using System.Collections.Generic;
using UnityEngine;

public class CellsFactory : MonoBehaviour
{
    private const string NameKey = "Type Item";
    private const string NameValue = "Cell Presenter";

    [SerializedDictionary(NameKey, NameValue)]
    [SerializeField] private SerializedDictionary<Config.TypeItem, CellPresenter> _cells;

    public Cell[] CreateCells(ItemsIconsPresenter itemsIconsPresenter)
    {
        List<Cell> cells = new List<Cell>();

        foreach (var cellPresenter in _cells)
        {
            Cell cellModel = new Cell(cellPresenter.Key);
            cellPresenter.Value.Init(cellModel, itemsIconsPresenter);
            cells.Add(cellModel);
        }

        return cells.ToArray();
    }
}
