using Bonehead.Model;
using UnityEngine;

public class PresentersFactory : MonoBehaviour
{
    [SerializeField] private ItemSelectorPresenter _itemSelectorTemplate;
    [SerializeField] private ItemsIconsPresenter _itemsIconsTemplate;

    public ItemsIconsPresenter CreateItemsIcons()
    {
        ItemsIconsPresenter itemsIcons = Instantiate(_itemsIconsTemplate);

        return itemsIcons;
    }

    public ItemSelectorPresenter CreateItemSelector(LevelRoot levelRoot, ItemSelector model, ItemsIconsPresenter itemsIconsPresenter)
    {
        ItemSelectorPresenter itemSelector = Instantiate(_itemSelectorTemplate);
        itemSelector.Init(levelRoot, model, itemsIconsPresenter);

        return itemSelector;
    }
}
