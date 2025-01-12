using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private ViewManager _viewManager;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Aim _aim;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private View _currentView;
    [SerializeField] private Texture2D _cursorTexture;

    private PlayerInput _playerInput;
    private Vector2 _inputDirection;

    private void Awake()
    {
        Instance = this;
        Vector2 curosrHospot = new Vector2(_cursorTexture.width / 2, _cursorTexture.height / 2);
        Cursor.SetCursor(_cursorTexture, curosrHospot, CursorMode.Auto);

        _currentView = View.Side;
        _aim.SetActiveAim(_currentView);
        _viewManager.SetView(_currentView);

        _playerInput = new PlayerInput();

        _playerInput.Player.SwitchView.performed += OnSwitchView;
        _playerInput.Player.Shoot.performed += cntx => _shooter.Shoot();
    }

    private void Update()
    {
        _inputDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        if (_inputDirection != Vector2.zero)
        {
            _playerMover.Move(_inputDirection);
        }
    }

    public void OnSwitchView(InputAction.CallbackContext context)
    {
        SwitchView();

        _viewManager.SetView(_currentView);

        _aim.SetActiveAim(_currentView);
    }

    private void SwitchView()
    {
        _currentView = _currentView == View.Side ? View.Top : View.Side;
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
