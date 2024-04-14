using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llavev1 : MonoBehaviour
{
    public string identificadorPuerta;
    bool activo = true;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && activo)
        {
            other.GetComponent<Personaje>().Congelado();
            StartCoroutine("esperarDestruccion");
            activo = false;
        }
    }

    IEnumerator esperarDestruccion()
    {
        yield return new WaitForSeconds(1.8f);
        GameObject puertaADestruir = GameObject.Find(identificadorPuerta);
        Destroy(puertaADestruir);
    }

}
