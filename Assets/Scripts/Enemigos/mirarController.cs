using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirarController : MonoBehaviour
{
    private GameObject[] ojos;
    private GameObject objetivo;
    private bool encontrado;
    [SerializeField]GameObject puntoLanzamiento;
    private Animator animador;
    [SerializeField] GameObject barraPan;
    private bool lanzando = false;

    private void Awake()
    {
        ojos = new GameObject[35];
        animador = GetComponentInParent<Animator>();
        // arriba

        ojos[0] = transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        ojos[1] = transform.GetChild(0).transform.GetChild(1).transform.gameObject;
        ojos[2] = transform.GetChild(0).transform.GetChild(2).transform.gameObject;
        ojos[3] = transform.GetChild(0).transform.GetChild(3).transform.gameObject;
        ojos[4] = transform.GetChild(0).transform.GetChild(4).transform.gameObject;
        ojos[5] = transform.GetChild(0).transform.GetChild(5).transform.gameObject;
        ojos[6] = transform.GetChild(0).transform.GetChild(6).transform.gameObject;

        // frente

        ojos[7] = transform.GetChild(1).transform.GetChild(0).transform.gameObject;
        ojos[8] = transform.GetChild(1).transform.GetChild(1).transform.gameObject;
        ojos[9] = transform.GetChild(1).transform.GetChild(2).transform.gameObject;
        ojos[10] = transform.GetChild(1).transform.GetChild(3).transform.gameObject;
        ojos[11] = transform.GetChild(1).transform.GetChild(4).transform.gameObject;
        ojos[12] = transform.GetChild(1).transform.GetChild(5).transform.gameObject;
        ojos[13] = transform.GetChild(1).transform.GetChild(6).transform.gameObject;

        // abajo

        ojos[14] = transform.GetChild(2).transform.GetChild(0).transform.gameObject;
        ojos[15] = transform.GetChild(2).transform.GetChild(1).transform.gameObject;
        ojos[16] = transform.GetChild(2).transform.GetChild(2).transform.gameObject;
        ojos[17] = transform.GetChild(2).transform.GetChild(3).transform.gameObject;
        ojos[18] = transform.GetChild(2).transform.GetChild(4).transform.gameObject;
        ojos[19] = transform.GetChild(2).transform.GetChild(5).transform.gameObject;
        ojos[20] = transform.GetChild(2).transform.GetChild(6).transform.gameObject;

    }

    private void FixedUpdate()
    {
        mirar();
    }

    private void mirar()
    {
        encontrado = false;
        for (int i = 0; i < 21; i++)
        {
            RaycastHit hit;

            if (Physics.Raycast(ojos[i].transform.position, ojos[i].transform.forward, out hit, 15))
            {
                if ((hit.transform.gameObject.tag == "Jugador")&&(lanzando==false))
                {
                    lanzando = true;
                    Debug.Log("Voy a lanzar la corutina");
                    StartCoroutine("LanzarPan", hit.transform.position);
                    Debug.DrawRay(ojos[i].transform.position, ojos[i].transform.forward * hit.distance, Color.yellow);
                }
                else if (hit.transform.gameObject.tag == "Jugador")
                {
                    Debug.DrawRay(ojos[i].transform.position, ojos[i].transform.forward * hit.distance, Color.red);
                }
                else 
                {
                    Debug.DrawRay(ojos[i].transform.position, ojos[i].transform.forward * hit.distance, Color.white);
                }
            }
            else
            {
                Debug.DrawRay(ojos[i].transform.position, ojos[i].transform.forward * 15, Color.white);
            }
        }
    }

    public GameObject Objetivo()
    {
        return objetivo;
    }
    public bool Encontrado()
    {
        return encontrado;
    }
    IEnumerator LanzarPan(Vector3 posicion)
    {
        GameObject proyectilPan;
        Vector3 diresion = (posicion - puntoLanzamiento.transform.position).normalized;
        animador.SetBool("Lanzar", true);
        yield return new WaitForSeconds(0.5f);
        proyectilPan=Instantiate(barraPan,puntoLanzamiento.transform.position,Quaternion.identity);
        proyectilPan.GetComponent<Rigidbody>().AddForce(diresion * 10, ForceMode.Impulse);
        yield return new WaitForSeconds(2f);
        animador.SetBool("Lanzar", false);
        lanzando = false;
    }
}
