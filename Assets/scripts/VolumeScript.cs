using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour
{
    //para controlar el volumen de los sonidos del juego, utilice  un audiomixer que almacene 
    public AudioMixer masterMixer;
  
    // estos procesos se modificaran por medio de sliders, uno almacenara los sonidos de botones y musica de fondo.
    public void MusicSetSound(float soundLevel)
    {
        masterMixer.SetFloat("musicVol", soundLevel);
    }
    // y otro modifica los audiosources de explosiones e impactos de las torres.
    public void SfxSetSound(float soundLevel)
    {
        masterMixer.SetFloat("sfxVol", soundLevel);
    }
}