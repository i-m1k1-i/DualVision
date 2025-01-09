using UnityEngine;

public class PlayTime : MonoBehaviour
{
    private float _current = 0;
    private bool _stop;

    public float Current => _current;

    private void FixedUpdate()
    {
        if (_stop)
            return;
        _current += Time.fixedDeltaTime;
    }

    public void StartCounting()
    {
        _stop = false;
    }

    public void StopCounting()
    {
        _stop = true;
    }
}
