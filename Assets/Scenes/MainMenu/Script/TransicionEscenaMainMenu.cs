using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscenaMainMenu : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;

    private void Start() {
        animator = GetComponent<Animator>();
        
    }

    public void btn_Play() {
        StartCoroutine(CambiarEscena());
    }

    IEnumerator CambiarEscena() {
        animator.SetTrigger("Play"); // Setea el Trigger "Play"
                                     // Este sera condicion para que se ejecute "Animacion Final" en #2
        yield return new WaitForSeconds(animacionFinal.length); // Retardo de segundos
        SceneManager.LoadScene("IntroGame"); // Cambio de escena
    }


   

} // Fin 
