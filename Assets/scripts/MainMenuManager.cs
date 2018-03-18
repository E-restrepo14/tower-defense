using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour 
{
    // este script se encarga de proveer subprocesos... dirigidos mayormente a botones que a otros scripts
    // tambien se encarga de activarlos y de ocultarlos mientras se este el juego en ejecucion

	public static MainMenuManager Instance;
    public bool soundMuted = false;
	public bool musicMuted = false;
	public bool menuIsPressed = false;
	public GameObject menuImage;

	void Awake () 
	{
		Instance = this;
	}

    public void PresionoMenu ()
	{
		AudioManager.Instance.SonarClick ();
		menuIsPressed = !menuIsPressed;
        GameState.Instance.AlterarTiempo();
    }

	void Update ()
	{
        // en este update se ordena pausar o resumir el juego por medio de un bool 
		if (menuIsPressed == true)
		{           
            menuImage.SetActive (true);            
            AudioManager.Instance.back.SetActive (true);
			AudioManager.Instance.noPauso.enabled =false;
		}
		if (menuIsPressed == false)
		{
            menuImage.SetActive (false);
            AudioManager.Instance.back.SetActive (false);
			AudioManager.Instance.noPauso.enabled =true;
		}
	}
    //==================================================================================

	//de esta linea hacia abajo solo hay subprocesos simples que la verdad no hace falta comentarlos, se ve a simple vista lo que hacen

	void GameStarted ()
	{
		AudioManager.Instance.mainMenu.gameObject.SetActive (false);
    }

    public void QuitarSprite()
    {
        AudioManager.Instance.tutorial.gameObject.SetActive(false);
    }

	public void Iniciar()
	{
		AudioManager.Instance.SonarClick();
        GameState.Instance.AlterarTiempo();
        GameStarted ();
	}

	public void Tutorial()
	{
		AudioManager.Instance.SonarClick();
        //este es como el iniciar, pero no quita la pausa, y activa la imagen de las instrucciones
        AudioManager.Instance.tutorial.gameObject.SetActive(true);
        GameStarted ();
	}

	public void Salir()
	{
		AudioManager.Instance.SonarClick();
		Application.Quit ();
	}

	public void MuteSound()
    { 	
		AudioManager.Instance.SonarClick();
		soundMuted = !soundMuted;
		AudioManager.Instance.noSound.enabled = soundMuted;
	}

	public void MuteMusic()
	{
		AudioManager.Instance.SonarClick();
		musicMuted = !musicMuted;
		AudioManager.Instance.noMusic.enabled = musicMuted;
	}


}
