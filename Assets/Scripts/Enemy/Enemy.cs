using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Player _player;

    public void Initialize(Player player)
    {
        _player = player;
    }

    protected abstract void Move();
}
