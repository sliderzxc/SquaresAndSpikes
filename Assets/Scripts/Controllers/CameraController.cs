using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Transform player;
    private float differenceByX = 1.63f, differenceByY = -3.65f; 

    private void Update() {
        Vector3 newPosition = new Vector3(player.position.x - differenceByX, player.position.y - differenceByY, transform.position.z);
        transform.position = newPosition;
    }
}