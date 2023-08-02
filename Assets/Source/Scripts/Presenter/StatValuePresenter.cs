using Bonehead.Model;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class StatValuePresenter : MonoBehaviour
{
    [SerializeField] private Config.ItemStats _itemStat;

    private TMP_Text _value;

    public Config.ItemStats ItemStat => _itemStat;

    private void Awake()
    {
        _value = GetComponent<TMP_Text>();
    }

    public void SetValue(int value)
    {
        _value.text = value.ToString();
    }
}
