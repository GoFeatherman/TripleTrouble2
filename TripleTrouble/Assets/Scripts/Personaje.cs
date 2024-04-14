using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    public float jumpForce = 10;
    public LayerMask layerJump;
    bool grounded;
    Vector2 moveInput;
    Rigidbody2D rb;
    Animator animator;
    private float velocidadOriginal;

    private float escalaGravedad;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        velocidadOriginal = speed;
        rb = GetComponent<Rigidbody2D>();
        escalaGravedad = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput.x * speed,rb.velocity.y);
        

        if (grounded) {
            animator.SetFloat("Run", Mathf.Abs(moveInput.x));
        }

        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1,1, 1);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, layerJump);

        if (hit)
        {
            grounded = true;
        }
        else
        {
            grounded= false;
        }
        animator.SetBool("grounded", grounded);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            animator.SetTrigger("Jump");
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
        if (Input.GetButton("Jump") && !grounded && rb.velocity.y < 0)
        {
            rb.gravityScale = escalaGravedad/5;
        }
        else
        {
            rb.gravityScale = escalaGravedad;
        }

    }

    public void Congelado()
    {
        if (speed > 0)
        {
            speed = 0;
            StartCoroutine("Esperar");
        }
    }

    //SetTriger para poner la animación

    public void Descongelado()
    {
        speed = velocidadOriginal;
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(2);
        Descongelado();
    }

}

