using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeHandler : MonoBehaviour
{
    private const string MainMenu = nameof(MainMenu);

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Navigation.Escape.performed += (cntx) => LoadMainMenu();
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
