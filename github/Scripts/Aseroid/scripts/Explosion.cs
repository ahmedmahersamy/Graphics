﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Explosion : MonoBehaviour {
    [SerializeField]GameObject explosion;
    [SerializeField]
    GameObject blowUp;
    [SerializeField]
    Rigidbody rigidBody;
    [SerializeField]
    float laserHitModifier = 100f;
    [SerializeField]
    Sheld sheld;

    void IveBeenHit(Vector3 pos)
    {
        if (sheld == null)
            return;
        sheld.TakeDamage();
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, 6f);


       
    }

    void OnCollisionEnter (Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
            IveBeenHit(contact.point);
    }
    public void AddForce(Vector3 hitPosition ,Transform hitSource)
    {
        IveBeenHit(hitPosition);
        if(rigidBody == null)
            return;

        Vector3 forceVector = (hitSource.position - hitPosition).normalized;
        rigidBody.AddForceAtPosition(forceVector * laserHitModifier , hitPosition , ForceMode.Impulse);     
    }

    public  void BlowUp()
    {
        Instantiate(blowUp , transform.position , Quaternion.identity);
        Destroy(gameObject );
    }



}
