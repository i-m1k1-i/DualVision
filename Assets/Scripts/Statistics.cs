using UnityEngine;

public class Statistics : MonoBehaviour
{
    public static Statistics Instance;

    private const int _pointsForKill = 5;

    public int SurvivedTime { get; private set; }
    public int KillPoints { get; private set; }
    public int Total { get; private set; }
    public static int BestTotal { get; private set; }

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
        KillPoints += _pointsForKill;
    }

    public void CountStatistics()
    {
        SurvivedTime = (int)PlayTime.Current;
        Total = SurvivedTime + KillPoints;

        if (Total > BestTotal)
        {
            BestTotal = Total;
        }
    }

    public void Reset()
    {
        KillPoints = 0;
    }
}