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
    [SerializeField] private TextMeshProUGUI _bestTotal;


    private void Start()
    {
        _gameEndUI.SetActive(false);
        _playerHealth.OnDeath += HandlePlayerDeath;
        Time.timeScale = 1;
    }

    private void HandlePlayerDeath()
    {
        _playTime.StopCounting();
        SetStatisticValues();
        Time.timeScale = 0;
        _gameEndUI.SetActive(true);
        Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.Auto);
    }

    private void SetStatisticValues()
    {
        Statistics stats = Statistics.Instance;
        stats.CountStatistics();

        _time.text = $"{stats.SurvivedTime}";
        _enemy.text = $"{stats.KillPoints}";
        _total.text = $"{stats.Total}";
        _bestTotal.text = $"{stats.BestTotal}";

    }
}
