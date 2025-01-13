using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private Statistics _stats;
    private int _newScore;
    private float _currentScore;

    private void Awake()
    {
        _stats = Statistics.Instance;
        _scoreText.text = 0.ToString();
    }

    private IEnumerator SmoothIncreaseScore(int addedPoints)
    {
        _newScore = _stats.Total;
        float increasingSpeed = addedPoints / 2f;
        Debug.Log(increasingSpeed);
        while (_newScore >= _currentScore)
        {
            _currentScore = Mathf.Clamp(_currentScore + Time.unscaledDeltaTime  * increasingSpeed, 0, _newScore);
            _scoreText.text = ((int)_currentScore).ToString();
            yield return null;
        }
    }

    private void StartSmoothIncreaseScore(int addedPoints)
    {
        StartCoroutine(SmoothIncreaseScore(addedPoints));
    }

    private void OnEnable()
    {
        _stats.ScoreChanged += StartSmoothIncreaseScore;
    }

    private void OnDisable()
    {
        _stats.ScoreChanged -= StartSmoothIncreaseScore;
    }
}
