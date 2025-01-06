using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public static PipePool Instance;

    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private int poolSize = 10; // Ajusta según necesites

    private List<GameObject> pipes;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        pipes = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pipePrefab);
            obj.SetActive(false);
            pipes.Add(obj);
        }
    }

    public GameObject GetPipe()
    {
        foreach (GameObject pipe in pipes)
        {
            if (!pipe.activeInHierarchy) // verificamos si la tubería actual no está activa en la jerarquía del juego.
            {
                pipe.SetActive(true);
                return pipe;
            }
        }

        // Si no hay tuberías disponibles en la pool, crea una nueva
        GameObject newPipe = Instantiate(pipePrefab);
        pipes.Add(newPipe);
        return newPipe;
    }

    public void ReturnPipe(GameObject pipe)
    {
        pipe.SetActive(false);
    }
}
