using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [SerializeField]laser[] lasers;

	
	
	// Update is called once per frame
	void Update ()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach (laser l in  lasers)
            {
                //Vector3 pos = transform.position + (transform.forward * l.Distance);
                l.FireLaser();
            }

        }
		
	}
}
