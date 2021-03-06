﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chase : MonoBehaviour
{
    public Transform player;
    public Transform head;
    Animator anim;

    public Slider healthbar;

    string state = "patrol";
    public GameObject[] waypoints;
    int currentWP = 0;
    public float rotspeed = 0.2f;
    public float speed = 1.5f;
    float accuracyWP = 5.0f;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthbar.value <= 0) return;

        Vector3 direction = player.position - this.transform.position;
        direction.y = 0;
        float angle = Vector3.Angle(direction, head.up);

        if (state == "patrol" && waypoints.Length > 0)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
            {
                currentWP = Random.Range(0, waypoints.Length);
                /*currentWP++;
                if (currentWP >= waypoints.Length)
                {
                    currentWP = 0;
                }*/
            }
            direction = waypoints[currentWP].transform.position - transform.position;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotspeed * Time.deltaTime);
            this.transform.Translate(0, 0, Time.deltaTime * speed);

        }
        if (Vector3.Distance(player.position, this.transform.position) < 10 && (angle < 30 || state == "pursuing"))
        {
            state = "pursuing";
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotspeed * Time.deltaTime);
            if (direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, Time.deltaTime * speed);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
            state = "patrol";
        }
    }
}
