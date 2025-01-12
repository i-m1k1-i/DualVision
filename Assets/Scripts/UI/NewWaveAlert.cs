using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class NewWaveAlert : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveValue;
    [SerializeField] private float _fadeInDuration;
    [SerializeField] private float _fadeOutDuration;
    [SerializeField] private float _displayDuration;
    [SerializeField] private AudioSource _backgroundMusic;

    private AudioSource _audioSource;
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _canvasGroup = GetComponent<CanvasGroup>();
        gameObject.SetActive(false);
        _canvasGroup.alpha = 0;
        
    }

    public async Task StartAlert(int waveNum)
    {
        _waveValue.text = waveNum.ToString();
        gameObject.SetActive(true);
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
        
        await Task.Delay((int)(_displayDuration * 100));

        while (_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= Time.deltaTime / _fadeOutDuration;
            if (_backgroundMusic.volume < 0.7f)
            {
                _backgroundMusic.volume += Mathf.Clamp01(Time.deltaTime / (_fadeOutDuration));
            }
            await Task.Yield();
        }

        gameObject.SetActive(false);
    }
}
