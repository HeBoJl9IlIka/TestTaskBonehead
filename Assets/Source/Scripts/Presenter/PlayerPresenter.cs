using Bonehead.Model;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerPresenter : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimationAttack()
    {
        _animator.SetTrigger(Config.TriggerAnimationAttack);
    }
}
