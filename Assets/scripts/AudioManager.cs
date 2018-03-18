using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    //este script se encarga de permitirle a otros scripts reproducir audiosources y de restringir acciones del jugador por medio de condicionales if.
    public static AudioManager Instance;
    public AudioSource musica;
    public AudioSource click;
    public AudioSource blueparticle;
    public AudioSource greenparticle;
    public AudioSource redparticle;
    public Image noSound;
    public Image noMusic;
    public Image mainMenu;
    public Image tienda;
    public GameObject back;
    public GameObject nodoSeleccionado;
    public Image noPauso;
    public Image castlelifebar;
    public Image rojito;
    public Image Gameover;
    public Image tutorial;
    public Text goldText;
    public Text waves;
    public Text gameOverText;
    
    //esta i se incrementa por medio de otros scripts, esta solo almacena el numero de enemigos instanciados en todo el juego... para ser llamada luego
    public int i = 0;

    void Awake()
    {
        Instance = this;
        //este como muchos otros audiosources. se manejan desde este codigo, como subropcesos, aveces desde otros scripts, y aveces desde botones del canvas.
        musica.Play();
    }

    public void SubirWaves()
    {
        //este actualiza el valor de los enemigos instanciados, que se muestran en el hud
        i++;
       waves.text = "Enemigos: " + i.ToString();
    }
  

    public void TerminarJuego()
    {
     // este script, no termina realmente el juego...solo instancia el boton, que al ser accionado... permite activar el void que ordena iniciar la coroutina de reiniciar la aplicacion. 
        Time.timeScale = 0;
        gameOverText.text = "felicitaciones, sobreviviste hasta la oleada " + i.ToString();
        Gameover.gameObject.SetActive(true);
    }

    public void Terminar ()
    {
        //este void se creó para acceder a esta coroutina desde un boton del canvas
        StartCoroutine(TerminarAhoraSi());
    }
    IEnumerator TerminarAhoraSi()
    {
        SceneManager.LoadScene("main");
        Gameover.gameObject.SetActive(false);
        Time.timeScale = 1;
        yield return new WaitForSeconds(1);
    }

	void Update()
	{
        //el update de este codigo se encarga de restringir ciertas acciones del jugador por medio de condicionales if y de activar algunos subprocesos.
        if (i >= 150)
        {
            //en caso de sobrevivir a 150 enemigos, se inicia el proceso de terminar juego.
            TerminarJuego();
        }

        //todo en la tienda cuesta 9 de oro, en caso de tener menos de esta... se pondra una capa roja sobre el hud que muestra el oro
        if (WaypointsScript.Instance.gold >= 9)
        {
            rojito.GetComponent<Image>().color = Color.white;
        }
        else
        {
            rojito.GetComponent<Image>().color = Color.red;
        }


        if (MainMenuManager.Instance.soundMuted == true)
        {
		  	Mutear (click);
            //si desde el menu principal se desea mutear el audiosource del click, se puede hacer desde este subproceso, y es llamado desde un boton.
	    } 
		else 
		{
			DesMutear (click);
            //igual para desmutearlo
		}

		if (MainMenuManager.Instance.musicMuted == true) {
            Mutear(musica);
		} 
		else 
		{
			DesMutear (musica);
		}
	}
    // esto de crear un void para convertirlo en coroutina siempre se utiliza para poder acceder a esta desde un boton.
    public void MostrarTienda()
    {
        StartCoroutine(TiendaCoroutine());
    }

    public IEnumerator TiendaCoroutine()
    {
        //cuando se clickea para acceder a la tienda, esta aparece antes de que el jugador suelte el boton del mouse y por error el jugador clickea donde no deseaba hacerlo. por eso el waitforseconds de la coroutina 
        yield return new WaitForSeconds(0.5f);
        tienda.gameObject.SetActive(true); 
    }

    public void OcultarTienda()
    {
        // esta no es necesario convertirla en coroutina.
        tienda.gameObject.SetActive(false);
    }
    //------------------------------------------------------------------

    public void SonarClick()
	{
		click.Play();
	}

	public void Mutear(AudioSource audio)
	{
		audio.volume = 0.0f;
	}
	public void DesMutear(AudioSource audio)
	{
		audio.volume = 0.5f;
	}
}