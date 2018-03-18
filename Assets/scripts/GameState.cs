using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;
    public bool estaPausado;

    private void Awake()
    {
        Instance = this;
        AlterarTiempo();
    }

    // como en muchas partes se hacia uso de cambiar el valor del time.timescale. cree un script que se encarga de hacerlo si es llamado desde cualquier parte.

    public void AlterarTiempo()
    {
        estaPausado = !(estaPausado);
        if (estaPausado == true)
        { 
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

}
