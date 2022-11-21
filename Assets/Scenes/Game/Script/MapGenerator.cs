using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    [SerializeField] private int cantidadInicial;
    [SerializeField] private GameObject[] partesNivel;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private Transform puntoFinal;

    private Transform jugador;

     private void Start() {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i=0;i<cantidadInicial;i++) {
            PartMapGenerator();
        }
    }

    private void Update() {
        if (Vector2.Distance(jugador.position, puntoFinal.position) < distanciaMinima) {
            PartMapGenerator();
        }
    }

    private void PartMapGenerator() {
        int numeroAleatario = Random.Range(0, partesNivel.Length);
        GameObject nivel = Instantiate(partesNivel[numeroAleatario], puntoFinal.position, Quaternion.identity);
        puntoFinal = BuscarPuntoFinal(nivel,"PuntoFinal");
    }

    private Transform BuscarPuntoFinal(GameObject parteNivel, string etiqueta) {
        Transform punto = null;
        foreach(Transform ubicacion in parteNivel.transform) {
            if (ubicacion.CompareTag(etiqueta)) {
                punto = ubicacion;
                break;
            }
        }
        return punto;
    }



} // Fin 
