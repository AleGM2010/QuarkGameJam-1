using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
 

public class Menu_Controler : MonoBehaviour
{

    public AudioSource btn_sound;





    public void QuitGame() {
        Application.Quit();
    }

    public void ButtonSound() {
        
        btn_sound.Play();
    } 

}
