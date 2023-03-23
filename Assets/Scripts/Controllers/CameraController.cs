using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Transform player;
    private float differenceByX = 2.25f, differenceByY = -3.65f; 

    private void FixedUpdate() {
        Vector3 newPosition = new Vector3(player.position.x - differenceByX, player.position.y - differenceByY, transform.position.z);
        transform.position = newPosition;
    }
}