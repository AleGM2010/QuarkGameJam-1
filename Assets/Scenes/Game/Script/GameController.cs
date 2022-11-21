using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject CanvasPausePanel;
    [SerializeField] private GameObject LoserPanel;
    [SerializeField] private GameObject btn_Pause;
    [SerializeField] private string SceneNameReturn;
    [SerializeField] public Text textPoint;
    [SerializeField] public Text textPointLose;
    [SerializeField] private GameObject Jugador;

    public int Recorrido;

    private void Start() {
        Recorrido = 0;
        Time.timeScale = 1f;
    }
    void Update() {
        if (Time.timeScale == 1) {
            AumentarRecorrido();
        }
   
        if (!Jugador.activeInHierarchy) {
            LoserPanel.SetActive(true);
            btn_Pause.SetActive(false);
            CanvasPausePanel.SetActive(false);
            textPoint.text = "";
            Time.timeScale = 0f;
        }
    

    }
    private void AumentarRecorrido() {
        
        textPoint.text = Recorrido.ToString();
        textPointLose.text = "Haz conseguido\n"+textPoint.text+" Puntos!";
        Recorrido++ ;
        
    }


    public void ChangeGameRunning() {     
        Time.timeScale = 0f ;
        btn_Pause.SetActive(false);
        CanvasPausePanel.SetActive(true);      
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        btn_Pause.SetActive(true);
        CanvasPausePanel.SetActive(false);
    }

    public void ReturnMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneNameReturn);      
    }

    public void QuitGame() {       
        Application.Quit();
    }

    public void playAgain() {
        LoserPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // metodo que muestre un mensaje en pantalla cuando este activado

}
