using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxCameraTransform : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] float vel;
   


    void FixedUpdate() {
        transform.position += new Vector3(vel, 0, 0);

    }

}

