using System.Collections;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("Core Components")]
    [SerializeField] private GameObject _gameEndUI;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Canvas _fullBlack;
    [SerializeField] private AudioSource _backgroundMusic;

    [Header("Statistic Components")]
    [SerializeField] private PlayTime _playTime;
    [SerializeField] private TextMeshProUGUI _waves;
    [SerializeField] private TextMeshProUGUI _enemy;
    [SerializeField] private TextMeshProUGUI _total;
    [SerializeField] private TextMeshProUGUI _bestTotal;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _gameEndUI.SetActive(false);
        _playerHealth.OnDeath += HandlePlayerDeath;
        Time.timeScale = 1;
    }

    private void HandlePlayerDeath()
    {
        _playTime.StopCounting();
        SetStatisticValues();
        
        Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.Auto);
        _audioSource.Play();
        _gameEndUI.SetActive(true);
        StartCoroutine(FlashTransition());
    }

    private void SetStatisticValues()
    {
        Statistics stats = Statistics.Instance;
        stats.CountBestScore();

        _waves.text = $"{stats.WavesSurvived}";
        _enemy.text = $"{stats.Kills}";
        _total.text = $"{stats.Total}";
        _bestTotal.text = $"{stats.BestTotal}";
    }

    private IEnumerator FlashTransition()
    {
        _fullBlack.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        Time.timeScale = 0;
        _backgroundMusic.Pause();
        _fullBlack.gameObject.SetActive(false);
    }
}
