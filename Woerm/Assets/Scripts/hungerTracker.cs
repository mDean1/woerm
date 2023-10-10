using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hungerTracker : MonoBehaviour
{
    
    public float maxHunger = 100;
    public float currentHunger;
    public HungerBar hungerBar;
    [SerializeField] private float coef = 0.2f;


    // Start is called before the first frame update
    void Start()
    {    
        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);
    }

    // Update is called once per frame
    void Update()
    {
        hungerBar.SetHunger(currentHunger);
        currentHunger -= coef * Time.deltaTime;
    }

    void hungerDrop (int damage){
        currentHunger -= damage;
        hungerBar.SetHunger(currentHunger);
    }
    /*
    OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }

    }  
    */
}
