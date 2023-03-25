using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 2.5f;

    private Side currentSide = Side.Right;
    private float lineDistance = 4f;
    private Vector3 playerPosition;

    private void Start()
    {
        playerPosition = transform.position;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw(Constants.HORIZONTAL);
        float vertical = Input.GetAxisRaw(Constants.VERTICAL);

        Vector3 movement = new Vector3(horizontal, 1, vertical);
        controller.Move(movement.normalized * speed * Time.fixedDeltaTime);
    }

    private void MovePlayer(Side side)
    {
        float vertical = Input.GetAxisRaw(Constants.VERTICAL);

        float direction = (side == Side.Left) ? -1f : 1f;
        Vector3 movement = new Vector3(lineDistance * direction, 0, vertical);
        controller.Move(movement.normalized * speed * Time.fixedDeltaTime);

        currentSide = side;
    }
}