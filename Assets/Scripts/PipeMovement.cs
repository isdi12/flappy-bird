using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Cuando la tubería sale de la pantalla, la devolvemos a la pool
        if (transform.position.x < -10) // Ajusta según la extensión de tu pantalla
        {
            PipePool.Instance.ReturnPipe(gameObject);
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
