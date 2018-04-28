using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    [SerializeField]
    Transform target;
    [SerializeField]
    laser lasers;
    Vector3 hitPosition;


    void Update()
    {
        if (!FindTarget())
            return;

        Infront();
         HaveLineOfSightRayCast();
        if(Infront() && HaveLineOfSightRayCast() )
        {
            FireLaser();
        }
    }

    bool Infront()
    {
        Vector3 directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward , directionToTarget);

        // if in range 
        if(Mathf.Abs(angle) >90  && Mathf.Abs(angle)<270)
        {
//            Debug.DrawLine(transform.position, target.position, Color.green);
            return true;
         }
//        Debug.DrawLine(transform.position, target.position, Color.yellow);
        return false;
    }

    bool HaveLineOfSightRayCast()
    {
        RaycastHit hit;
        Vector3 direction = target.position - transform.position;
 //       Debug.DrawRay(lasers.transform.position, direction, Color.red);
        if(Physics.Raycast(lasers.transform.position , direction ,out hit , lasers.Distance))
        {
            if(hit.transform.CompareTag("Player"))
            {
                Debug.DrawRay(lasers.transform.position, direction, Color.green);
                hitPosition = hit.transform.position;
                return true;
            }
        }

        return false;
    }

    void FireLaser ()
    {
        Debug.Log("Fire Lasers on spaaceShip ");
        lasers.FireLaser(hitPosition , target);
    }

    bool FindTarget()
    {
        if (target == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");

            if (temp != null)
                target = temp.transform;
        }
        if (target == null)
            return false;

        return true;
    }
}
