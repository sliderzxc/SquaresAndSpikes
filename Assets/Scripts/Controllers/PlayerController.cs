using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 1f;

    private Side currentSide = Side.Right;
    private float lineDistance = 4f;

    private void FixedUpdate() {
        float horizontal = Input.GetAxis(Constants.HORIZONTAL);
        float vertical = Input.GetAxis(Constants.VERTICAL);

        Vector3 movement = new Vector3(horizontal, 1, vertical);
        controller.Move(movement * Time.deltaTime * speed);

        // if (SwipeController.isNeedToMove) {
        //     MovePlayer(SwipeController.side);
        // }
    }

    private void MovePlayer(Side side) {
        float vertical = Input.GetAxis(Constants.VERTICAL);

        if (side == Side.Right && currentSide == Side.Left) {
            Vector3 movement = new Vector3(10, 1, vertical);
            controller.Move(movement * Time.deltaTime * speed);
            currentSide = Side.Right;
        }

        if (side == Side.Left && currentSide == Side.Right) {
            Vector3 movement = new Vector3(-10f, 1, vertical);
            controller.Move(movement * Time.deltaTime * speed);
            currentSide = Side.Left;
        }
    }
}