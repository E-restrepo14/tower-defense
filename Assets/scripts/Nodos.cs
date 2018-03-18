using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodos : MonoBehaviour {
    //este script lo tienen todos los prefabs de towerpoints

    public Renderer rend;
    public Color colorInicial;
    public GameObject torreR;
    public GameObject torreA;
    public GameObject torreV;
  
    //este bloque de codigo es para que el towerpoint (nodo) cambie de color cuando el mouse esta encima de este. y muestre la tienda cuando se selecciona con el clic
    void Start()
    {
        rend = GetComponent<Renderer>();
        colorInicial = rend.material.color;
    }
    void OnMouseEnter()
    {
            rend.material.color = Color.red;
    }
    void OnMouseDown()
    {
        AudioManager.Instance.MostrarTienda();
        AudioManager.Instance.nodoSeleccionado = gameObject;
    }
    void OnMouseExit()
    {
            rend.material.color = colorInicial;
    }

    //=============================================================================================================================================================================================================

        // y estos tres subprocesos se llaman desde botones, y cada uno son para crear cierto prefab de torre.

    public void CrearTorreRoja()
    {
        //y todos funcionan solo cuando la variable que almacena el oro... en el waypointsscript es mayor que nueve...       
        if ((WaypointsScript.Instance.gold - 9) > 0)
        {
            WaypointsScript.Instance.gold -= 9;
            Instantiate(torreR, AudioManager.Instance.nodoSeleccionado.transform.position, AudioManager.Instance.nodoSeleccionado.transform.rotation);
        }
    }
    public void CrearTorreazul()
    {
        if ((WaypointsScript.Instance.gold - 9) > 0)
        {
            WaypointsScript.Instance.gold -= 9;
            Instantiate(torreA, AudioManager.Instance.nodoSeleccionado.transform.position, AudioManager.Instance.nodoSeleccionado.transform.rotation);
        }
    }
    public void CrearTorreVerde()
    {
        if ((WaypointsScript.Instance.gold - 9) > 0)
        {
            WaypointsScript.Instance.gold -= 9;
            Instantiate(torreV, AudioManager.Instance.nodoSeleccionado.transform.position, AudioManager.Instance.nodoSeleccionado.transform.rotation);
        }
    }
}
