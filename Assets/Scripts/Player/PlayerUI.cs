using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Canvas _pauseCanvas;
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private Texture2D _cursorTexture;

    private bool _isPaused;

    public bool IsPaused => _isPaused;

    public void OnEscape()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
        _pauseCanvas.gameObject.SetActive(_isPaused);
        SetCursor(!_isPaused);
        SetMusic();
    }

    private void SetMusic()
    {
        if (_isPaused)
        {
            _backgroundMusic.Pause();
        }
        else
        {
            _backgroundMusic.Play();
        }
    }

    private void SetCursor(bool battleCursor)
    {
        if (battleCursor)
        {
            Vector2 curosrHospot = new Vector2(_cursorTexture.width / 2, _cursorTexture.height / 2);
            Cursor.SetCursor(_cursorTexture, curosrHospot, CursorMode.Auto);
        }
        else
        {
            Vector2 curosrHospot = new Vector2(0, 0);
            Cursor.SetCursor(null, curosrHospot, CursorMode.Auto);
        }
    }
}
