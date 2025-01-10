using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _sideCamera;
    [SerializeField] private Camera _topCamera;
    [SerializeField] private RawImage _sideView;
    [SerializeField] private RawImage _topView;

    private bool _isSideCamera = true;

    public Camera CurrentCamera => _isSideCamera ? _sideCamera : _topCamera;

    private void Awake()
    {
        UpdateActiveCamera();
    }

    public void SetActiveCamera(View view)
    {
        _isSideCamera = view == View.Side;
        UpdateActiveCamera();
    }

    private void UpdateActiveCamera()
    {
        _sideCamera.gameObject.SetActive(_isSideCamera);
        _topView.gameObject.SetActive(_isSideCamera);

        _topCamera.gameObject.SetActive(!_isSideCamera);
        _sideView.gameObject.SetActive(!_isSideCamera);
    }
}
