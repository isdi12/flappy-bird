using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 300f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //void Update()
    //{
//#if UNITY_EDITOR_WIN || UNITY_STANDALONE //PARA QUE FUNCIONE EN PC
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            rb.velocity = Vector2.up * jumpForce;
//            AudioManager.instance.PlayAudio(jumpSound, "JumpSound", false, 0.08f);
//        }

//#elif UNITY_ANDROID //PARA QUE FUNCIONE EN ANDROID

//        foreach (Touch touch in Input.touches)
//        {
//            if (touch.phase == TouchPhase.Began)
//            {
//                rb.velocity = Vector2.up * jumpForce;
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        // Aquí puedes reiniciar el juego o mostrar Game Over
//        Debug.Log("Game Over");
//    }

}
