using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 1f;

    private Side side = Side.Right;
    private float lineDistance = 4f;

    private void Update() {
        float horizontal = Input.GetAxis(Constants.HORIZONTAL);
        float vertical = Input.GetAxis(Constants.VERTICAL);

        Vector3 movement = new Vector3(horizontal, 1, vertical);
        controller.Move(movement * Time.deltaTime * speed);
    }
}