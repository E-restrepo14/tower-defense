using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour 
{
    //este script se encarga de mover el prefab del enemigo por el mapa
    public NavMeshAgent navmeshagent;
    public Transform target;
    private int vida = 6;
    public GameObject Explosionprefab;

    void Start()
    {
        //en el momento de ser instanciados... deben de subir una variable que indica cuantos enemigos han aparecido en escena
        AudioManager.Instance.SubirWaves();
        AudioManager.Instance.goldText.text = "Gold: " + WaypointsScript.Instance.gold.ToString();
        //como son prefabs... por medio de este script les asigné como target, una variable de otro script 
        target = WaypointsScript.Instance.castillo.transform;
        navmeshagent = gameObject.GetComponent<NavMeshAgent>();
    }


    void Update()
	{
      
        //desde que se instancian, solo tienen un objetivo de llegar al target.position
        navmeshagent.destination = target.position;
        if (HemosLlegado())
            //en caso de que este bool se cumpla, este bloque de codigo se encarga de bajar la vida del castillo, y de actualizar la escala de la barra de vida de este y de iniciar la coroutine explotar del prefab del enemigo.
        {
            Vector3 porcentajedevida = new Vector3(1f, (WaypointsScript.Instance.castleFloatLife / 10f), 1f);
            AudioManager.Instance. castlelifebar.transform.GetChild(0).gameObject.transform.localScale = porcentajedevida;
            Explotar();
            WaypointsScript.Instance.castleFloatLife -= 1;
          
        }
        //si antes de llegar, su variable de vida llega a 0.. entran a la coroutina de explotar, y esta se encarga de destruirlos
        if (vida <= 0)
        {
            Explotar();
            
        }

    }

    void Explotar()
    {
        //este codigo consiste en instanciar la particula de explosion, aumentar el oro almacenado en el singleton waypointsscript, de actualizar el valor de este en el canvas y destruir la nave 
        Instantiate(Explosionprefab, transform.position, Quaternion.identity);
        WaypointsScript.Instance.gold += 2;
     
        AudioManager.Instance.goldText.text = "Gold: " + WaypointsScript.Instance.gold.ToString();

        Destroy(gameObject);
    }

    public bool HemosLlegado()
    {
        //esta variable se bolverá verdadera si llega a estar lo suficientemente cerca del objetivo
        return navmeshagent.remainingDistance <= navmeshagent.stoppingDistance && !navmeshagent.pathPending;
    }

    public void RecibirDaño(GameObject torreMisteriosa)
    {
        // este script se llamará desde una de los tres prefabs de torres que tiene este gameobject referenciado... y dependiendo del tag de estas... y de su propio tag... recibiran determinado daño en su variable de vida 
        if (torreMisteriosa.CompareTag("BlueTower"))
        {
            //las torres se encargan de instanciar sus particulas de flechas, veneno, y ondas de sonido... pero el audio manager es quien se encarga de hacerlas sonar.
            AudioManager.Instance.blueparticle.Play();
            if (gameObject.tag == ("RedEnemy"))
            {
                vida -= 1;
            }

            if (gameObject.tag == ("BlueEnemy"))
            {
                vida -= 3;
            }

            if (gameObject.tag == ("GreenEnemy"))
            {
                vida -= 5;
            }
        }
        //-------------------------------------------------------igualmente para los otros dos tipos de torres... se llamara el proceso anterior
        if (torreMisteriosa.CompareTag("RedTower"))
        {
            AudioManager.Instance.redparticle.Play();
            if (gameObject.tag == ("RedEnemy"))
            {
                vida -= 3;
            }

            if (gameObject.tag == ("BlueEnemy"))
            {
                vida -= 5;
            }

            if (gameObject.tag == ("GreenEnemy"))
            {
                vida -= 1;
            }
        }
        //------------------------------------------------------
        if (torreMisteriosa.CompareTag("GreenTower"))
        {
            AudioManager.Instance.greenparticle.Play();
            if (gameObject.tag == ("RedEnemy"))
            {
                vida -= 5;
            }

            if (gameObject.tag == ("BlueEnemy"))
            {
                vida -= 1;
            }

            if (gameObject.tag == ("GreenEnemy"))
            {
                vida -= 3;
            }
        }

    }



}
