using AYellowpaper.SerializedCollections;
using Bonehead.Model;
using TMPro;
using UnityEngine;

public class PlayerStatsPresenter : MonoBehaviour
{
    private const string NameKey = "Item stat";
    private const string NameValue = "Value";

    [SerializedDictionary(NameKey, NameValue)]
    [SerializeField] private SerializedDictionary<Config.ItemStats, TMP_Text> _stats;

    public void ShowStats(Config.ItemStats stat, int targetValue)
    {
        if (_stats.TryGetValue(stat, out TMP_Text currentValue))
            currentValue.text = targetValue.ToString();
    }
}
