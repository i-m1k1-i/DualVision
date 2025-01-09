using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private RectTransform _currentHealthBar;

    private RectTransform _maxHealthBar;
    private float _prevHealth;

    private void Start()
    {
        _maxHealthBar = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (_prevHealth == _health.CurrentHealth)
        {
            return;
        }

        float width = (_health.CurrentHealth / _health.MaxHealth) * _maxHealthBar.sizeDelta.x;
        float height = _currentHealthBar.sizeDelta.y;

        _currentHealthBar.sizeDelta = new Vector2(width, height);

        _prevHealth = _health.CurrentHealth;
    }
}
