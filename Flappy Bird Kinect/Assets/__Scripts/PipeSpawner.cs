using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject[] pipePrefabs;
    private List<GameObject> activePipes;
    private Transform parent;
    private GameObject pipes;
    private int lastIndex;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPipes", 0, 2f); // Spawn two pipes every 2 seconds
    }

    private void SpawnPipes()
    {
        pipes = Instantiate(pipePrefabs[RandomPrefabIndex()]);
        Destroy(pipes, 10); // Destroys pipe after 10 seconds.
    }

    private int RandomPrefabIndex()
    {
        if (pipePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastIndex;
        while (randomIndex == lastIndex)
        {
            randomIndex = Random.Range(0, pipePrefabs.Length);
        }

        lastIndex = randomIndex;
        return randomIndex;
    }
}
