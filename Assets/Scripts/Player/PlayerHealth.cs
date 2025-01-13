using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public event UnityAction OnDeath;

    public override void TakeDamage(float damage)
    {
        if (_currentHealth <= 0)
            return;

        SoundEffectsManager.Instance.PlayPlayerHitSound();

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);

        if (_currentHealth <= 0)
        {
            Death();
            OnDeath?.Invoke();
        }
    }

    protected override void Death()
    {
        gameObject.SetActive(false);
    }
}