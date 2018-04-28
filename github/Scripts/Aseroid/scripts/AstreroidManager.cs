using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreroidManager : MonoBehaviour {
    [SerializeField]Asteroid[] asteroid;
    [SerializeField]int numberOfAsteroidsOnAnAxis = 10;
    [SerializeField]int gridSpacing = 15;

    // Use this for initialization
    void Start()
    {
        PlaceAsteroids();
    }




    void PlaceAsteroids()
    {
        for(int x= 0; x < numberOfAsteroidsOnAnAxis; x++)
        {
            for (int y = 0; y < numberOfAsteroidsOnAnAxis; y++)
            {
                for (int z = 0; z < numberOfAsteroidsOnAnAxis; z++)
                {
                    InstantiateAstroid(x, y, z);
                }
            }
        }
    }

    void InstantiateAstroid(int x, int y , int z)
    {
        foreach (Asteroid ast in asteroid)
        {
            Instantiate(ast,
           new Vector3(transform.position.x + (x * gridSpacing) + AsteroidOffset(),
                        transform.position.y + (y * gridSpacing) + AsteroidOffset(),
                        transform.position.z + (z * gridSpacing) + AsteroidOffset()),
                   Quaternion.identity,
                   transform);
        }
       
    }
   
	
    float AsteroidOffset()
    {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
