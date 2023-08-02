using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;
using Bonehead.Model;

public class MoneyPresenter : MonoBehaviour
{
    [SerializeField] private Image _money;
    [SerializeField] private Transform _defaultPosition;
    [SerializeField] private Transform _finishPosition;
    [SerializeField] private float _duration = 0.8f;
    [SerializeField] private Transform[] _path;
    [SerializeField] private Transform[] _path1;
    [SerializeField] private Transform[] _path2;
    [SerializeField] private Transform[] _path3;

    private void OnEnable()
    {
        List<Transform[]> paths = new List<Transform[]>();
        paths.Add(_path);
        paths.Add(_path1);
        paths.Add(_path2);
        paths.Add(_path3);

        Transform[] newPath = paths[Random.Range(0, paths.Count)];
        List<Vector3> normalizedPath = new List<Vector3>();

        foreach (var path in newPath)
        {
            float axis = Random.Range(Config.MinRandomMoneyPosition, Config.MaxRandomMoneyPosition);
            normalizedPath.Add(path.position + new Vector3(axis, axis));
        }

        float duration = _duration + Random.Range(Config.MinRandomMoneyDuration, Config.MaxRandomMoneyDuration);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(_money.transform.DOPath(normalizedPath.ToArray(), duration, PathType.CatmullRom));
        sequence.Append(_money.transform.DOMove(_finishPosition.position, _duration));
        sequence.AppendCallback(Disable);
    }

    private void OnDisable()
    {
        _money.transform.position = _defaultPosition.position;
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
