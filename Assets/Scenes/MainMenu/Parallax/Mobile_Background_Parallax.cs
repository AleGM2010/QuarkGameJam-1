using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile_Background_Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier;

    private Transform cameraTransform;
    private Vector3 previusCameraPosition;
    private float spriteWitdth, startPosition;

    private void Start() {
        cameraTransform = Camera.main.transform;
        previusCameraPosition = cameraTransform.position;
        spriteWitdth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;
    }

    private void LateUpdate() {
        float deltaX = (cameraTransform.position.x - previusCameraPosition.x) * parallaxMultiplier;
        float moveAmount = cameraTransform.position.x * (1 - parallaxMultiplier);
        transform.Translate(new Vector3(deltaX, 0, 0));
        previusCameraPosition = cameraTransform.position;

        if (moveAmount > startPosition + spriteWitdth) {
            transform.Translate(new Vector3(spriteWitdth, 0, 0));
            startPosition += spriteWitdth;
        }
    }


}
