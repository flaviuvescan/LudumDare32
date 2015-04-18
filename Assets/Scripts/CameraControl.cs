using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public float cameraOffset = 2f;

    void Awake()
    {
        transform.position = new Vector3(0, 0, -300);
    }

    void Update()
    {
        Vector2 cameraPos = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);

        Vector3 newCameraPosition = new Vector3(cameraPos.x / cameraOffset, cameraPos.y / cameraOffset, -300);

        transform.localPosition = newCameraPosition;
    }   
}
