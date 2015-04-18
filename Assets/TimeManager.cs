using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    public static TimeManager instance;

    public float nonPlayerTime = 1f;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Time.timeScale = 0.01f;
            nonPlayerTime = 0.01f;
        }
                
        if (Input.GetMouseButtonUp(1))        
        {
            Time.timeScale = 1f;
            nonPlayerTime = 1f;
        }
    }

}
