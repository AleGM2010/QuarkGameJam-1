using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControllerMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float vel;
    

    void Start() {

    }
    void FixedUpdate() {
        transform.position += new Vector3(vel, 0, 0);



    }
}
