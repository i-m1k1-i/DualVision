using UnityEngine;
using UnityEngine.Events;


public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _currentHealth;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public abstract void TakeDamage(float damage);

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
