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

    public int TakeDamage(float damage)
    {
        if (_currentHealth <= 0)
            return -1;

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);

        if (_currentHealth <= 0)
        {
            Death();
            OnDeath?.Invoke();
        }
        return (int)_currentHealth;
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
