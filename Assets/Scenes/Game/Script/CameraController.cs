using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTo;
    public Transform limit;
    public static CameraController instance;
    [Range(-10, 10)][SerializeField]
    float minRangeX, minRangeY, maxRangeX, maxRangeY;


    private void Awake() {
        if (instance = null) {
            instance = this;
        }
    }

    private void Update() {

        var minPosY = limit.GetComponent<BoxCollider2D>().bounds.min.y+ minRangeY;
        var minPosX = limit.GetComponent<BoxCollider2D>().bounds.min.x+ minRangeX;
        var maxPosY = limit.GetComponent<BoxCollider2D>().bounds.max.y+ maxRangeY;
        var maxPosX = limit.GetComponent<BoxCollider2D>().bounds.max.x+ maxRangeX;

        Vector3 boxLimitCamera = new Vector3(
            Mathf.Clamp(followTo.position.x,minPosX,maxPosX),
            Mathf.Clamp(followTo.position.y-2, minPosY, maxPosY),
            Mathf.Clamp(followTo.position.z, -10f, -10f)
            );


        transform.position = new Vector3(boxLimitCamera.x, boxLimitCamera.y, -10f);
    }

}
