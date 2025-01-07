using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform _topAim;
    [SerializeField] private Transform _sideAim;

    private Vector2 _mousePosition;
    private Transform _currentAim;
    public Transform CurrentAim => _currentAim;
    public Vector3 Direction => _currentAim.position - transform.position;

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
        _currentAim = view == View.Side ? _sideAim : _topAim;
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

        Vector3 directionToMouse = mouseWorldPosition - transform.position;
        directionToMouse.y = 0; // Обнуление Z для работы в 2D

        float angle = Mathf.Atan2(directionToMouse.x, -directionToMouse.z) * Mathf.Rad2Deg;
        _currentAim.rotation = Quaternion.Euler(0, -angle, 0);
    }

    private void LookAtMouseSide()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane));

        Vector3 directionToMouse = mouseWorldPosition - transform.position;
        directionToMouse.z = 0; // Обнуление Z для работы в 2D

        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        _currentAim.rotation = Quaternion.Euler(0, 0, angle);
    }
}
