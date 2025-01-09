using UnityEngine;

public class PlayerHealth : Health
{
    protected override void Death()
    {
        gameObject.SetActive(false);
    }
}