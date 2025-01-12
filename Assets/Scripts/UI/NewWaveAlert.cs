using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class NewWaveAlert : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveValue;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private float _displayDuration;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        gameObject.SetActive(false);
    }

    public async Task StartAlert(int waveNum)
    {
        _waveValue.text = waveNum.ToString();
        gameObject.SetActive(true);
        await FadeInAndOut();
    }

    private async Task FadeInAndOut()
    {
        while (_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += Time.deltaTime / _fadeDuration;
            await Task.Yield();
        }

        await Task.Delay((int)(_displayDuration * 100));

        while (_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= Time.deltaTime / _fadeDuration;
            await Task.Yield();
        }

        gameObject.SetActive(false);
    }
}
