using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkGeneration : MonoBehaviour
{
    private List<GameObject> activeWalks = new List<GameObject>();
    private float spawnPosition = 0;
    private float walkLength = 16.8f;

    [SerializeField] private GameObject[] walkPrefabs;
    [SerializeField] private Transform player;

    private void Update()
    {
        if (player.position.y + walkLength >= spawnPosition) { 
            CreateWalk(Random.Range(0, walkPrefabs.Length));
            spawnPosition += walkLength;
        }
    }

    private void CreateWalk(int walkIndex)
    {
        Vector3 position = new Vector3(0, spawnPosition, 0);
        GameObject nextWalk = Instantiate(walkPrefabs[walkIndex], position, Quaternion.identity);
        activeWalks.Add(nextWalk);
    }

    private void DeleteWalk()
    {
        Destroy(activeWalks[0]);
        activeWalks.RemoveAt(0);
    }
}