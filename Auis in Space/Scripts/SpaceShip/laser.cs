using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Light))]
public class laser : MonoBehaviour {
    [SerializeField]float laserOFFTime = .5f;
    [SerializeField]float maxDistance = 300f;
    [SerializeField]float fireDelay = 2f;

    LineRenderer lr;
    Light laserLight;

    bool canFire;



    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        laserLight = GetComponent<Light>();
    } 

    void Start()
    {
        lr.enabled = false;
        laserLight.enabled = false;
        canFire = true;
    }

   void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance, Color.yellow);
        //FireLaser(transform.forward * maxDistance);
    }

    // -------------------- make me know what is front me and not 
    // ray hit elements 
        Vector3 CastRay()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDistance;
        if(Physics.Raycast(transform.position ,fwd ,out hit))
        {
            Debug.Log("we hit :" + hit.transform.name);
            //hit.transform.GetComponent<Asteroid>().IveBeenHit(hit.point);
            SpawnExplosion(hit.point, hit.transform);
            return hit.point;
        }
        Debug.Log("we missed");
        return (transform.position + (transform.forward * maxDistance));
    }

    // check target is Explosion 
    void SpawnExplosion (Vector3 hitPosition , Transform target)
    {
        Explosion temp = target.GetComponent<Explosion>();
        if(temp != null)
            temp.AddForce(hitPosition , transform);
        
    }

    public void FireLaser()
    {

        Vector3 pos  = CastRay();
        FireLaser(pos);

    }
    public void FireLaser(Vector3 targetPosition , Transform target = null)
    {
        if (canFire)
        {
            if(target != null)
            {
                SpawnExplosion(targetPosition, target);

            }

            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, targetPosition);
            lr.enabled = true;
            laserLight.enabled = true;
            canFire = false;
            Invoke("TurnOffLaser", laserOFFTime);
            Invoke("CanFire", fireDelay);
        }

    }

    // fire laser from the space ship to target from raycast with no parameters
    
        void TurnOffLaser()
    {
        lr.enabled = false;
        laserLight.enabled = false;
    }
	
    public float Distance
    {
        get { return maxDistance; }
    }
	
    void CanFire()
    {
        canFire = true;
    }
	
}
