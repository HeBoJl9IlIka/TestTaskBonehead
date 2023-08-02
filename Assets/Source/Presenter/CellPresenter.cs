using AYellowpaper.SerializedCollections;
using Bonehead.Model;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CellPresenter : MonoBehaviour
{
    private const string NameKey = "Type Item";
    private const string NameValue = "Sprite";

    [SerializedDictionary(NameKey, NameValue)]
    [SerializeField] private SerializedDictionary<Config.TypeItem, Sprite> _sprites;

    private Cell _model;
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

    public void Init(Cell model)
    {
        _model = model;
        enabled = true;
    }

    private void OnChanged(Item item)
    {
        if (_sprites.TryGetValue(item.TypeItem, out Sprite sprite) == false)
            throw new ArgumentNullException(nameof(item.TypeItem));

        _image.sprite = sprite;
    }
}
