using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _healthBarImage;

    private float _prevHealth;


    private void Update()
    {
        if (_prevHealth == _health.CurrentHealth)
            return;

        float healthNormalized = (_health.CurrentHealth / _health.MaxHealth);
        _healthBarImage.fillAmount = healthNormalized;

        _prevHealth = _health.CurrentHealth;
    }
}
