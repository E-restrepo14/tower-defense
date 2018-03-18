using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsScript : MonoBehaviour 
{
    public static WaypointsScript Instance;
    // este script se encarga de instanciar los enemigos en la escena
   
    public float nextWave;
    public float waitTime;
    public GameObject[] baseEnemiga;
    public GameObject[] baseAliada;
    public GameObject castillo;
    public float castleFloatLife= 10f;
    public int gold = 12;

    public GameObject[] enemigos;
    public int rand1;

    void Awake () 
	{
        Instance = this;
    //primero todos los elementos con el tag castillo, se almacenan en un array, y esta pasa su unico elemento al gameobject castillo... que será el objetivo de todos los enemigos que se instanciaran desde este codigo
        baseAliada = GameObject.FindGameObjectsWithTag("Castillo");
        castillo =  baseAliada[0];
      
    }    

    void Update()
    {
        //este script almacena la vida del castillo, y si esta llega a 0, se inicia el proceso de terminar el juego.
        if (castleFloatLife <= 0)
        {
            AudioManager.Instance.TerminarJuego();
        }

      
        //cada cierto tiempo se instanciaran enemigos random de un array de gameobjects, desde una posicion random de un array de spawnpoints  
        if (Time.time > nextWave)
        {
            rand1 = Random.Range(0, 4);
            nextWave = Time.time + waitTime;
            Instantiate(enemigos[Random.Range(0, 3)], baseEnemiga[rand1].transform.position, Quaternion.identity);
        

        }
    }

}
