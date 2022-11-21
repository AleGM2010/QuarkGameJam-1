using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMuv : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float vel;
    [SerializeField] float maxXRangeDestroyNivel;
            



    void Start() {
        
        
    }

    private void Update() {
        if (transform.position.x < maxXRangeDestroyNivel) {
            Destroy(gameObject);
        }       
    }

    void FixedUpdate() {
        transform.position -= new Vector3(vel, 0, 0);
        
    }
   
}
