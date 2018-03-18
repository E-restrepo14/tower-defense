using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torres : MonoBehaviour
{
    public bool estaApuntando;
    public GameObject objetivo;
    public GameObject segundoObjetivo;
    public GameObject particula;

    // la nave no solo se encarga de bajar la vida a todo lo que entra en su collider, estos ifs anidados son para que ataque un enemigo a la vez y que otros enemigos puedan pasar mientras uno recibe todo el daño.

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueEnemy") || other.gameObject.CompareTag("RedEnemy") || other.gameObject.CompareTag("GreenEnemy"))
        {
            
            segundoObjetivo = other.gameObject;

            if (objetivo == null)
            {
                objetivo = segundoObjetivo;
            }

            if (objetivo != null)
            {
                // en esta parte... accede al script del enemigo y le ordena que este ejecute el recibir daño. entregando como argumento una referencia de su game object.
                Enemy _enemy = objetivo.GetComponent<Enemy>();
                if (_enemy != null)
                {
                    _enemy.RecibirDaño(gameObject);
                }
                particula.SetActive(true);
                // y activa su particula que indica que esta atacando.
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BlueEnemy") || other.gameObject.CompareTag("RedEnemy") || other.gameObject.CompareTag("GreenEnemy"))
            particula.SetActive (false);
    }
    
}
