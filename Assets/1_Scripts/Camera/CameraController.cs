using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;

    private void Update()
    {
        if (transform.position.y > minY && Input.mousePosition.y < Screen.height * 0.05)
            transform.Translate(Vector3.down * (Time.deltaTime * scrollSpeed), Space.World);
        else if (transform.position.y < maxY && Input.mousePosition.y > Screen.height * 0.95)
            transform.Translate(Vector3.up * (Time.deltaTime * scrollSpeed), Space.World);
    }
}
