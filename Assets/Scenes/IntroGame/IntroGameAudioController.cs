using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroGameAudioController : MonoBehaviour {

    [SerializeField] AudioSource audio_1;
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;

    // Start is called before the first frame update
    void Start() {
        
        audio_1 = GetComponent<AudioSource>();
        // Corrutina empieza el juego
        StartCoroutine(CambiarEscena());
  
    }

    
    public void playAudio() {
        audio_1.Play();
    }

    // Corrutina , tiene una tardanza que dura lo que dura la animacion y luego cambia al juego
    IEnumerator CambiarEscena() {
        
        yield return new WaitForSeconds(animacionFinal.length ); // Retardo de segundos
        SceneManager.LoadScene("Game"); // Cambio de escena
    }

    public void SaltarIntro() {
        SceneManager.LoadScene("Game");
    }
}
