using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Puerta : MonoBehaviour
{
    [SerializeField] Text textoUi;
    [SerializeField] GameObject puerta;
    [SerializeField] GameObject pivote;
    private bool tieneLlave = false;
    private bool abierta = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Llave")
        {
            AbrirPuerta();
            Destroy(other.gameObject);
        }
    }
    private void AbrirPuerta()
    {
        puerta.gameObject.transform.RotateAround(pivote.transform.position, Vector3.up, 120);
    }

}
