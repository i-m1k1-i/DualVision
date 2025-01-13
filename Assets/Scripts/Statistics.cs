using UnityEngine;
using UnityEngine.Events;

public class Statistics : MonoBehaviour
{
    public static Statistics Instance;

    [SerializeField] private WaveController _waveController;

    private const int _pointsForKill = 5;
    private const int _pointsForWave = 15;

    public int WavesSurvived { get; private set; }
    public int Kills { get; private set; }
    public int Total { get; private set; }
    public int BestTotal { get; private set; }

    public event UnityAction<int> ScoreChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnemyKilled()
    {
        Kills++;
        Total += _pointsForKill;
        ScoreChanged?.Invoke(_pointsForKill);
    }

    public void WaveComplete()
    {
        WavesSurvived += 1;
        Total += _pointsForWave;
        ScoreChanged?.Invoke(_pointsForWave);
    }

    public void CountBestScore()
    {
        if (Total > BestTotal)
        {
            BestTotal = Total;
        }
    }

    public void Reset()
    {
        Kills = 0;
        WavesSurvived = 0;
        Total = 0;
    }
}