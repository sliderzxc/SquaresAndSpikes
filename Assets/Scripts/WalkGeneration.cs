using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] walks;
    
    private List<GameObject> activeWalks = new List<GameObject>();
    private float spawnPosition = 0;
    private int startWalks = 2;
    private float walkLength = 16.7f;
    private float staticPositionGeneration = 13.5f;

    private void Start() {
        for (int i = 0; i < startWalks; i++){
            SpawnWalk(Random.Range(0, walks.Length));
        }
    }

    private void Update() {
        if (activeWalks[0].transform.position.y < -20) {
            SpawnWalkOnTheSamePlace(Random.Range(0, walks.Length));
            DeleteWalk();
        }
    }

    private void SpawnWalk(int walkIndex) {
        GameObject nextWalk = Instantiate(walks[walkIndex], new Vector3(0, spawnPosition, 0), Quaternion.identity);
        activeWalks.Add(nextWalk);
        spawnPosition += walkLength;
    }

    private void SpawnWalkOnTheSamePlace(int walkIndex) {
        GameObject nextWalk = Instantiate(walks[walkIndex], new Vector3(0, staticPositionGeneration, 0), Quaternion.identity);
        activeWalks.Add(nextWalk);
    }

    private void DeleteWalk() {
        Destroy(activeWalks[0]);
        activeWalks.RemoveAt(0);
    }
}