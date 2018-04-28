using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class detectHit : MonoBehaviour
{
    public Slider healthbar;
    Animator anim;
    void OnTriggerEnter(Collider other)
    {
        healthbar.value -= 30;
        if (healthbar.value <= 0)
        {
            anim.SetBool("isDead", true);
        }
    }


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
