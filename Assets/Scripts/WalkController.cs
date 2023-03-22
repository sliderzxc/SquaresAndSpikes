using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private int speed;
    private Vector3 dir = new Vector3(0, -5, 0);

    private void FixedUpdate() {
        controller.Move(dir * Time.deltaTime * speed);
    }
}