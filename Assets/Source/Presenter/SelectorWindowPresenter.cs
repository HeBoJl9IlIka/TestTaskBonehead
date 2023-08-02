using AYellowpaper.SerializedCollections;
using Bonehead.Model;
using UnityEngine;
using UnityEngine.UI;

public class SelectorWindowPresenter : MonoBehaviour
{
    private const string NameKey = "Item Stat";
    private const string NameValue = "Image";

    [SerializeField] private Sprite _arrowUp;
    [SerializeField] private Sprite _arrowDown;
    [SerializeField] private Image _currentItemIcon;
    [SerializeField] private Image _newItemIcon;
    [SerializeField] private StatValuePresenter[] _statsValuesNewItem;
    [SerializeField] private StatValuePresenter[] _statsValuesCurrentItem;

    [SerializedDictionary(NameKey, NameValue)]
    [SerializeField] private SerializedDictionary<Config.ItemStats, Image> _images;

    private ItemsIconsPresenter _itemsIconsPresenter;

    public void Init(ItemsIconsPresenter itemsIconsPresenter)
    {
        _itemsIconsPresenter = itemsIconsPresenter;
    }

    public void Show(Item newItem)
    {
        _newItemIcon.sprite = _itemsIconsPresenter.GetIcon(newItem.TypeItem);

        foreach (var stat in _statsValuesNewItem)
            stat.SetValue(newItem.GetStatValue(stat.ItemStat));
    }

    public void Show(Item newItem, Item currentItem)
    {
        _currentItemIcon.sprite = _itemsIconsPresenter.GetIcon(currentItem.TypeItem);
        _newItemIcon.sprite = _itemsIconsPresenter.GetIcon(newItem.TypeItem);

        foreach (var stat in _statsValuesCurrentItem)
            stat.SetValue(currentItem.GetStatValue(stat.ItemStat));

        foreach (var stat in _statsValuesNewItem)
            stat.SetValue(newItem.GetStatValue(stat.ItemStat));

        SetArrows(newItem, currentItem);
    }

    private void SetArrows(Item newItem, Item currentItem)
    {
        foreach (var stat in _statsValuesNewItem)
        {
            if (newItem.GetStatValue(stat.ItemStat) == currentItem.GetStatValue(stat.ItemStat))
            {
                if (_images.TryGetValue(stat.ItemStat, out Image image))
                    image.color = Color.clear;
            }
            else
            {
                if (newItem.GetStatValue(stat.ItemStat) > currentItem.GetStatValue(stat.ItemStat))
                {
                    if (_images.TryGetValue(stat.ItemStat, out Image image))
                    {
                        image.sprite = _arrowUp;
                        image.color = Color.white;
                    }
                }
                else
                {
                    if (_images.TryGetValue(stat.ItemStat, out Image image))
                    {
                        image.sprite = _arrowDown;
                        image.color = Color.white;
                    }
                }
            }
        }
    }
}
