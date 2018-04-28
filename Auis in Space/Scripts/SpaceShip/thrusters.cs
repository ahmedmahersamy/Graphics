using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(Light))]
public class thrusters : MonoBehaviour {
   // TrailRenderer tr;
    Light thrusterLight;

    void Awake()
    {
      //  tr = GetComponent<TrailRenderer>();
        thrusterLight = GetComponent<Light>();
    }

    void Start()
    {
        thrusterLight.intensity = 0f;
        //tr.enabled = false;
        //thrusterLight.enabled = false;
    }
    /*
    public void Activate (bool activate = true)
    {
        if (activate)
        {
            tr.enabled = true;
            thrusterLight.enabled = true;
            //turn on partical effects
            //turn on sound  
            //etc
        }
        else
        {
            tr.enabled = false;
            thrusterLight.enabled = false;

            // turn of anything associated with thrusting
        }
    }*/

    //change  intensity of light
public void Intensity (float inten)
    {
        thrusterLight.intensity = inten * 2f;
    }
}
