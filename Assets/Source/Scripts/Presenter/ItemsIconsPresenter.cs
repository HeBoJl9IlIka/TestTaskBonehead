using AYellowpaper.SerializedCollections;
using Bonehead.Model;
using System;
using UnityEngine;

public class ItemsIconsPresenter : MonoBehaviour
{
    private const string NameKey = "Type Item";
    private const string NameValue = "Sprite";

    [SerializedDictionary(NameKey, NameValue)]
    [SerializeField] private SerializedDictionary<Config.TypeItem, Sprite> _sprites;

    public Sprite GetIcon(Config.TypeItem typeItem)
    {
        if (_sprites.TryGetValue(typeItem, out Sprite sprite) == false)
            throw new ArgumentNullException(nameof(typeItem));

        return sprite;
    }
}
