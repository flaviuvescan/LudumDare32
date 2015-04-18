using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = 0.01f;
            Time.fixedDeltaTime = 0.01f;
        }
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 1f;
        }
    }
}
