using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbody2d;
    [SerializeField] private Animator animator;
    [SerializeField] private float run;

    [Header("Salto")]
    [SerializeField] private float fuerzaSalto ;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;

    [Header("Salto Regulable")]
    [Range(0,1)][SerializeField] private float multiplicadorCancelarSalto;
    [SerializeField] private float multiplicadorGravedad;
    [SerializeField] private float escalaGravedad;
     //private bool botonSaltarArriba;
    //private bool salto;

  
    

    
    private void Start() {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        
        //salto = false;
        //botonSaltarArriba = true;
    }

    private void Update() {
         //PC mouse or keyboard

         if (Input.GetButton("Jump") || Input.touchCount>0 ) {
             animator.SetBool("Saltar", true);
             Jump();
         }
         // Esto es cuando soltas
         if (Input.GetButtonUp("Jump") || Input.touchCount > 0) {
             animator.SetBool("Saltar", true);
             BotonSaltoArriba();
         }

        /*
        if (Input.touchCount > 0) {
            var _touch = Input.GetTouch(0);
            animator.SetBool("Saltar", true);
            Jump();

            if (_touch.phase == TouchPhase.Began && _touch.phase == TouchPhase.Stationary) {
                
                BotonSaltoArriba();            
            } 
        }
         */


        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);


        animator.SetBool("EnSuelo", enSuelo);
        if (enSuelo) {

            Run(run * Time.fixedDeltaTime);
        }

        // Cada que caigas y estes en el aire , bajar mas rapido
        if (rigidbody2d.velocity.y < 0 && !enSuelo) {
            rigidbody2d.gravityScale = escalaGravedad * multiplicadorGravedad;

        } //else {rigidbody2d.gravityScale = escalaGravedad;}       
    }

    private void BotonSaltoArriba() {
        if (rigidbody2d.velocity.y>0) {
            rigidbody2d.AddForce(Vector2.down * rigidbody2d.velocity.y * (1 - multiplicadorCancelarSalto), ForceMode2D.Impulse);
            animator.SetBool("Saltar", false);
        }
        
        
    }


    private void Jump() {
        if (enSuelo ) {
            rigidbody2d.AddForce(new Vector2(0f, fuerzaSalto));
            enSuelo = false;
            animator.SetBool("Saltar", false);
        }
    }

    private void Run(float run) {
        // Vector2 velocidad = new Vector2(run,0);
        //rigidbody2d.velocity = velocidad;

        rigidbody2d.velocity = new Vector2(run, 0f);
       
    }
    // Metodo para hacer visible la caja deControladorsuelo
    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }

    
    private void OnBecameInvisible() {
        gameObject.SetActive(false);
        

    }

}
