using Bonehead.Model;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CellPresenter : MonoBehaviour
{
    private Cell _model;
    private ItemsIconsPresenter _itemsIconsPresenter;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _model.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _model.Changed -= OnChanged;
    }

    public void Init(Cell model, ItemsIconsPresenter itemsIconsPresenter)
    {
        _model = model;
        _itemsIconsPresenter = itemsIconsPresenter;
        enabled = true;
    }

    private void OnChanged(Item item)
    {
        _image.sprite = _itemsIconsPresenter.GetIcon(item.TypeItem);
    }
}
