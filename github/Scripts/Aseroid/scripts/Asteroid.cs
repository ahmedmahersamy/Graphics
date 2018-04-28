using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]

[RequireComponent(typeof(Explosion))]
public class Asteroid : MonoBehaviour {

    [SerializeField]
    float minScale = .8f;
    [SerializeField]
    float maxScale = 1.2f;
    [SerializeField]
    float rotationOffset = 100f;
   // [SerializeField]GameObject explosion;


    Transform myTransform;
    Vector3 randomRotation;
    // Use this for initialization
    void Awake()
    {
        myTransform = transform;
    }
    void Start()
    {
        // random size 
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);
        myTransform.localScale = scale;

        // random rotation 
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);


    }

    // Update is called once per frame
    void Update()
    {
        myTransform.Rotate(randomRotation * Time.deltaTime);
    }


    



    /*
    public void IveBeenHit(Vector3 pos)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, 6f);
    }*/
}
