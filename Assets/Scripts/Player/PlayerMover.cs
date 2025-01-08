using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    public void Move(Vector2 inputDirection)
    {
        Vector3 moveDirection = new Vector3(inputDirection.x, 0, inputDirection.y);

        if (CanMove(moveDirection) == false)
            return;

        Vector3 move = _moveSpeed * Time.deltaTime * moveDirection;
        transform.Translate(move);
    }

    private bool CanMove(Vector3 direction)
    {
        bool isObstacle = Physics.Raycast(transform.position, direction, out RaycastHit hitInfo, 0.6f);
        if (isObstacle == false)
            return true;

        return false;
    }
}
