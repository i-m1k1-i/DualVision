using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Aim _aim;
    [SerializeField] private View _currentView;

    private PlayerInput _playerInput;
    private Vector2 _inputDirection;
    

    private void Awake()
    {
        _currentView = View.Side;
        _aim.SetActiveAim(_currentView);
        _cameraManager.SetActiveCamera(_currentView);

        _playerInput = new PlayerInput();

        _playerInput.Player.SwitchView.performed += OnSwitchView;
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

        _cameraManager.SetActiveCamera(_currentView);

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
