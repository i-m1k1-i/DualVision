using UnityEngine;
using UnityEngine.Events;


public abstract class Health : MonoBehaviour
{
    public event UnityAction OnDeath;
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _currentHealth;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth <= 0)
            return;

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Death();
            OnDeath?.Invoke();
        }
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
