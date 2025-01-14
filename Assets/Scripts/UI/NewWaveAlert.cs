using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class NewWaveAlert : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveValue;
    [SerializeField] private TextMeshProUGUI _changingsText;
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private float _fadeInDuration;
    [SerializeField] private float _fadeOutDuration;
    [SerializeField] private float _displayDuration;

    private AudioSource _audioSource;
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 1;
        FirstWaveAlert();
    }

    public async Task StartAlert(int waveNum, string changingsText)
    {
        _waveValue.text = waveNum.ToString();
        _changingsText.text = changingsText;
        gameObject.SetActive(true);
        await FadeInAndOut();
    }

    private async void FirstWaveAlert()
    {
        await FadeInAndOut();
    }

    private async Task FadeInAndOut()
    {
        _backgroundMusic.volume = 0.1f;
        _audioSource.Play();
        while (_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += Time.deltaTime / _fadeInDuration;
            await Task.Yield();
        }

        if (_canvasGroup == null)
        {
            return;
        }

        while (_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= Time.deltaTime / _fadeOutDuration;
            if (_backgroundMusic.volume < 0.5f)
            {
                _backgroundMusic.volume += Mathf.Clamp01(Time.deltaTime / (_fadeOutDuration));
            }
            await Task.Yield();
        }

        gameObject.SetActive(false);
    }
}
