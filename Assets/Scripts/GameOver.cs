using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("Core Components")]
    [SerializeField] private GameObject _gameEndUI;
    [SerializeField] private PlayerHealth _playerHealth;

    [Header("Statistic Components")]
    [SerializeField] private PlayTime _playTime;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _enemy;
    [SerializeField] private TextMeshProUGUI _total;


    private void OnEnable()
    {
        _gameEndUI.SetActive(false);
        _playerHealth.OnDeath += HandlePlayerDeath;
    }

    private void HandlePlayerDeath()
    {
        _playTime.StopCounting();
        SetStatisticValues();
        _gameEndUI.SetActive(true);
    }

    private void SetStatisticValues()
    {
        Statistics stats = Statistics.Instance;
        stats.CountStatistics();

        _time.text = $"{stats.SurvivedTime}";
        _enemy.text = $"{stats.KillPoints}";
        _total.text = $"{stats.Total}";
    }
}
