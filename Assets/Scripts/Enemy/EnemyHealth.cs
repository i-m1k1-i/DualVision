using UnityEngine;

public class EnemyHealth : Health
{
    public override void TakeDamage(float damage)
    {
        if (_currentHealth <= 0)
            return;

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);

        if (_currentHealth <= 0)
        {
            Death();
            Statistics.Instance.EnemyKilled();
            SoundEffectsManager.Instance.PlayEnemyDeathSound();
        }
    }
}