using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Jugador")
        {
            Debug.Log("Ostion al jugador");
            collision.gameObject.GetComponent<JugadorController>().QuitarVida();
        }
        else
        {
            Debug.Log("collison con " + collision.gameObject);
        }
    }
}
