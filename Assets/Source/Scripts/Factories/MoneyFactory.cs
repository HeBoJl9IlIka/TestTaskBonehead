using Bonehead.Model;
using System.Collections.Generic;
using UnityEngine;

public class MoneyFactory : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private MoneyPresenter _moneyTemplate;

    private List<MoneyPresenter> _moneys = new List<MoneyPresenter>();

    public MoneyPresenter[] Moneys => _moneys.ToArray();

    private void Awake()
    {
        for (int i = 0; i < Config.MaxCountMoney; i++)
        {
            MoneyPresenter moneyPresenter = Instantiate(_moneyTemplate, _container);
            _moneys.Add(moneyPresenter);
        }
    }
}
