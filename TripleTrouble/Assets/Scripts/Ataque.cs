using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    [SerializeField] private Transform ControlAtaque;
    [SerializeField] private float radioGolpe;
    private Animator animator;
    private bool golpe = false;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (golpe == false) 
            {
                golpe = true;
                StartCoroutine(Golpe());
            }
            
        }
    }

    private IEnumerator Golpe()
    {
        animator.SetTrigger("Punch");
        yield return new WaitForSeconds(0.42f);
        Collider2D[] objetos = Physics2D.OverlapCircleAll(ControlAtaque.position,radioGolpe);
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Pared"))
            {
                colisionador.transform.GetComponent<Pared>().Destruccion();
            }
        }
        golpe = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControlAtaque.position, radioGolpe);
    }
}
