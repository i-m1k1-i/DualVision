using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    private Button _button;
    private AudioSource _audioSource;

    private void Start()
    {
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();

        _button.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        _audioSource.Play();
        SceneManager.LoadScene(currentScene);
        
        _button.onClick.RemoveAllListeners();
    }
}
