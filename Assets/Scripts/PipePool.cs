using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public static PipePool Instance;

    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private int poolSize = 10; // Ajusta según necesites

    private List<GameObject> pipes;
    public bool shouldExpand = false; 
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
            AddGameObject();
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

    GameObject AddGameObject()
    {

        GameObject pipe = Instantiate(pipePrefab);
        pipe.SetActive(false);
        pipes.Add(pipe);

        return pipe ; 
    }
    public GameObject GimmeInactiveGameObject()
    {
        foreach (GameObject obj in pipes) // para recorrer la lista 
        {
            if (!obj.activeSelf) // si el objeto no esta activo
            {
                return obj;
            }
        }
        if (shouldExpand) // si queremos expandir la pool 
        {
            return AddGameObject();
        }
        return null;
    }
}
