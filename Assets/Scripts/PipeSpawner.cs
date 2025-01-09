using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float spawnRate ;
    private float nextSpawn = 0f;
       public float lowestPoint = 3;
      public  float highestPoint = 3;

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
        float height = Random.Range(lowestPoint, highestPoint);

        // Usar la pool para obtener una tuber�a
        GameObject pipe = PipePool.Instance.GetPipe();
        pipe.transform.localPosition = new Vector3(transform.localPosition.x, height, 0);

        // Aseguramos de que el script PipeMovement est� en el prefab de la tuber�a para moverla
        PipeMovement pipeMovement = pipe.GetComponent<PipeMovement>();
        if (pipeMovement != null)
        {
            //pipeMovement.ResetPosition();
        }
    }
}
