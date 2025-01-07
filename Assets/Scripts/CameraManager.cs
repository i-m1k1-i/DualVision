using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _sideCamera;
    [SerializeField] private Camera _topCamera;

    private bool _isSideCamera = true;

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
        _topCamera.gameObject.SetActive(!_isSideCamera);
    }
}
