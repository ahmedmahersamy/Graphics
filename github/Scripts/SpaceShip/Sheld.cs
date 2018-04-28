using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheld : MonoBehaviour {
    [SerializeField]
    int maxHealth = 10;
    [SerializeField]
    int curHealth;
    [SerializeField]
    int regenerateAmount = 1;
    [SerializeField]
    float regenerationRate = 2f;

    void Start()
    {
        curHealth = maxHealth;
        InvokeRepeating("Regenerate" , regenerationRate ,regenerationRate);

    }

    void Regenerate()
    {
        if (curHealth < maxHealth)
            curHealth += regenerateAmount;

        if (curHealth > maxHealth)
        {
            curHealth = regenerateAmount;
        }
    }

    public void TakeDamage(int dmg = 1)
    {
        curHealth -= dmg;
        if (curHealth < 1)
        {
            GetComponent<Explosion>().BlowUp();
        }
            Debug.Log("I B DED !");
    }

}
