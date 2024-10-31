using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float maxSpeed;
    public float jumpForce;
    private bool isGround;
    private bool isJump;
    public GameObject image_obj;

    public AudioClip idleSound; 
    public AudioClip jumpSound; 
    public AudioClip biteSound; 
    private AudioSource audioSource; 
 
    private bool isIdle; 

    Rigidbody2D rigid;
    Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();  
    }

    private void Update()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0)
        {
            image_obj.transform.localScale = new Vector3(Mathf.Sign(h) * -0.08f, 0.08f, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGround = false;
            isJump = true;
        }

        if (animator != null)
        {
            if (Mathf.Abs(rigid.velocity.x) < 0.1)
            {
                animator.SetBool("onMoving", false);
                isIdle = true;
                PlayIdleSound();
            }
            else
            {
                animator.SetBool("onMoving", true);
                isIdle = false;
                
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("onJump");
                PlayJumpSound();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("onBite");
                animator.SetTrigger("onIdlee");
                PlayBiteSound();
            }

            if (isJump && rigid.velocity.y < 0 && isGround == false)
            {
                animator.SetTrigger("onLand");
                isJump = false;
            }

            if (isGround)
            {
                animator.SetTrigger("onIdle");
            }
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(h * maxSpeed, rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
        }
    }
    private void PlayIdleSound()
    {
        if (!audioSource.isPlaying && isIdle) 
        {
            audioSource.clip = idleSound;
            audioSource.Play();
        }
    }

    private void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    private void PlayBiteSound()
    {
        audioSource.PlayOneShot(biteSound); 
    }

}
