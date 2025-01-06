using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float spawnRate = 2f;
    public float heightOffset = 3f;
    private float nextSpawn = 0f;

    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            SpawnPipe();
            nextSpawn = Time.time + 1f / spawnRate;
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = -3;
        float highestPoint = 3;
        float height = Random.Range(lowestPoint, highestPoint);

        // Usar la pool para obtener una tubería
        GameObject pipe = PipePool.Instance.GetPipe();
        pipe.transform.position = new Vector3(transform.position.x, height, 0);

        // Aseguramos de que el script PipeMovement esté en el prefab de la tubería para moverla
        PipeMovement pipeMovement = pipe.GetComponent<PipeMovement>();
        if (pipeMovement != null)
        {
            pipeMovement.ResetPosition();
        }
    }
}
