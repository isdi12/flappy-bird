using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BirdController : MonoBehaviour
{
    public float jumpForce, rotationSpeed;
    public Animator animator;
    public AudioClip jumpSound, hitSound, pointSound;
 
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR_WIN || UNITY_STANDALONE //PARA QUE FUNCIONE EN PC
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            AudioManager.instance.PlayAudio(jumpSound, "JumpSound", false, 0.08f);
        }

#elif UNITY_ANDROID //PARA QUE FUNCIONE EN ANDROID

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                rb.velocity = Vector2.up * jumpForce;
                AudioManager.instance.PlayAudio(jumpSound, "JumpSound", false, 0.08f);
            }
        }
#endif
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * -rotationSpeed);
    }

    public void Hit()
    {
        GameManager.instance.SetHit(0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PipeMovement>())
        {
            GameManager.instance.SetPoints(GameManager.instance.GetPoints() + 1);// sumamos los puntos
            AudioManager.instance.PlayAudio(pointSound, "pointSound", false, 0.08f);
        }
        if (other.GetComponent<PipeMovement>())
        {
            GameManager.instance.SetHit(GameManager.instance.GetHit() + 1); // sumamos los choques 
            AudioManager.instance.PlayAudio(hitSound, "hitSound", false, 0.08f);
            GameManager.instance.LoadScene("Juego");
        }
       
    }
}
