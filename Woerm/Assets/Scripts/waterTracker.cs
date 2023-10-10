using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTracker : MonoBehaviour
{
    public float maxWater = 100;
    public float currentWater;
    public WaterBar waterBar;
    [SerializeField] private float coef = 0.2f;


    // Start is called before the first frame update
    void Start()
    {    
        currentWater = maxWater;
        waterBar.SetMaxThirst(maxWater);
    }

    // Update is called once per frame
    void Update()
    {
        waterBar.SetThirst(currentWater);
        currentWater -= coef * Time.deltaTime;
    }

    void hungerDrop (int damage){
        currentWater -= damage;
        waterBar.SetThirst(currentWater);
    }
}
