using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensajesUI : MonoBehaviour
{
    [SerializeField]private Text textoui;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Jugador")
        {
            switch(this.name)
            {
                case "Bienvenida":
                    textoui.text = "Has conseguido abrir la celda, busca EL ARMA y la llave para acceder a la proxima sala";
                    break;
                case "PuertaCerrada":
                    textoui.text = "Esta puerta esta cerrada y no se puede abrir, busque otra y puerta y use la llave que acaba de conseguir";
                    break;
                default:
                    break;    
            }
        }
    }
}
