using UnityEngine;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour
{
    [SerializeField] private Camera _sideCamera;
    [SerializeField] private Camera _topCamera;
    [SerializeField] private RawImage _topView;

    private bool _isSideCamera = true;

    public Camera CurrentCamera => _isSideCamera ? _sideCamera : _topCamera;

    private void Awake()
    {
        UpdateView();
    }

    public void SetView(View view)
    {
        _isSideCamera = view == View.Side;
        UpdateView();
    }

    private void UpdateView()
    {
        _sideCamera.gameObject.SetActive(_isSideCamera);
        _topCamera.gameObject.SetActive(!_isSideCamera);
        _topView.gameObject.SetActive(_isSideCamera);
    }
}
