using Bonehead.Model;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectorPresenter : MonoBehaviour
{
    [SerializeField] private SelectorWindowPresenter _soloWindow;
    [SerializeField] private SelectorWindowPresenter _doubleWindow;
    [SerializeField] private Button[] _buttonEquip;
    [SerializeField] private Button[] _buttonDrop;

    private ItemSelector _model;
    private LevelRoot _levelRoot;
    private Item _newItem;
    private Item _currentItem;

    private void OnEnable()
    {
        _model.Showed += OnShowed;

        foreach (var button in _buttonEquip)
            button.onClick.AddListener(OnClickEquipped);

        foreach (var button in _buttonDrop)
            button.onClick.AddListener(OnClickDropped);
    }

    private void OnDisable()
    {
        _model.Showed -= OnShowed;

        foreach (var button in _buttonEquip)
            button.onClick.RemoveListener(OnClickEquipped);

        foreach (var button in _buttonDrop)
            button.onClick.RemoveListener(OnClickDropped);
    }

    public void Init(LevelRoot levelRoot, ItemSelector model, ItemsIconsPresenter itemsIconsPresenter)
    {
        _levelRoot = levelRoot;
        _model = model;
        enabled = true;
        _soloWindow.Init(itemsIconsPresenter);
        _doubleWindow.Init(itemsIconsPresenter);
    }

    private void OnShowed(Item newItem, Item currentItem)
    {
        _newItem = newItem;
        _currentItem = currentItem;

        if (currentItem == null)
        {
            _soloWindow.gameObject.SetActive(true);
            _soloWindow.Show(_newItem);
        }
        else
        {
            _doubleWindow.gameObject.SetActive(true);
            _doubleWindow.Show(_newItem, _currentItem);
        }
    }

    private void OnClickEquipped()
    {
        if (_currentItem == null)
            _levelRoot.AddItem(_newItem);
        else
            _levelRoot.AddItem(_newItem, _currentItem);
    }

    private void OnClickDropped()
    {
        _levelRoot.DropItem(_newItem);
    }
}
