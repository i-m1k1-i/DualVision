using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform _topAim;
    [SerializeField] private Transform _topAimPoint;
    [SerializeField] private Transform _sideAim;
    [SerializeField] private Transform _sideAimPoint;

    private Transform _currentAim;
    private Transform _currentShotPoint;

    public Vector3 Direction => _currentShotPoint.position - transform.position;
    public Transform ShotPoint => _currentShotPoint;

    private void Start()
    {
        _currentAim = _sideAim;
    }

    private void Update()
    {
        LookAtMouse();
    }

    public void SetActiveAim(View view)
    {
        if (view == View.Side)
        {
            _currentAim = _sideAim;
            _currentShotPoint = _sideAimPoint;
        }
        else
        {
            _currentAim = _topAim;
            _currentShotPoint = _topAimPoint;
        }
    }

    private void LookAtMouse()
    {
        if (_currentAim == _sideAim)
        {
            LookAtMouseSide();
        }
        else
        {
            LookAtMouseTop();
        }
    }

    private void LookAtMouseTop()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.transform.position.y));

        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.Normalize();
        mouseDirection.y = 0; // Обнуление Z для работы в 2D

        float angle = Mathf.Atan2(mouseDirection.x, -mouseDirection.z) * Mathf.Rad2Deg;
        _currentAim.rotation = Quaternion.Euler(0, -angle, 0);
    }

    private void LookAtMouseSide()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane));

        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.Normalize();
        mouseDirection.z = 0; // Обнуление Z для работы в 2D

        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
        _currentAim.rotation = Quaternion.Euler(0, 0, angle);
    }
}
