using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class playerMovement : MonoBehaviour {
    [SerializeField]float movementSpeed = 30f;
    [SerializeField]float turnSpeed = 50f;
    [SerializeField]
    thrusters[] thrust; 
    Transform myTransform;
    void Awake ()
    {
        myTransform = transform;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        move ();
        Turn();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("roll");

        myTransform.Rotate(-pitch, yaw, -roll);
    }
    void move ()
    {
        //move virtical
      //  if(Input.GetAxis("Vertical") >0)
      //  {
            myTransform.position += myTransform.forward * movementSpeed / 2 * Time.deltaTime * Input.GetAxis("Vertical");

            foreach (thrusters t in thrust)
            {
                t.Intensity(Input.GetAxis("Vertical"));
            }
      //  }
            


        //if we start to thrust , call thruster.activate()
        //when we stop thrusting,call thruster.activate(false)

        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach(thrusters t in thrust)
            {
                t.Activate();
            }
        }else if(Input.GetKeyUp(KeyCode.W))
        {
            foreach (thrusters t in thrust)
            {
                t.Activate(false);
            }
        }*/
    }


}
