using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class meterTracker : MonoBehaviour
{
    //hunger variables
    public float maxHunger = 100;
    public float currentHunger;
    public HungerBar hungerBar;

    //water variables
    public float maxWater = 100;
    public float currentWater;
    public WaterBar waterBar;

    //happiness variables
    public float maxHappy = 100;
    public float currentHappy;
    public HappyBar happyBar;

    public Rigidbody rb;
    bool inPuddle;
    [SerializeField] private float coef = .2f;
    public SceneFader sceneFader;
    public wormDialogue dialogue;
    bool dialogueCalled = false;



    // Start is called before the first frame update
    void Start()
    {    
        //start hunger bar full
        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);

        //start thirst bar full
        currentWater = maxWater;
        waterBar.SetMaxThirst(maxWater);

        //start happiness bar empty
        currentHappy = 0;
        happyBar.SetHappy(currentHappy);
    }

    
    void Update()
    {
        //Return to afterlife once objective is complete
        if ((currentHappy >= maxHappy) && !dialogueCalled){
            dialogue.StartDialogue();
            dialogueCalled = true;
            //SceneManager.LoadScene("Heaven");   //TRANSITION TO NEXT HEAVEN LEVEL
        }

        if ((currentHunger <= 0) && (currentWater <= 0)){
            SceneManager.LoadScene("Heaven");   //RETURN TO PREVIOUS HEAVEN LEVEL
        }

        //slowly refills water meter as long as worm is in puddle
        if (inPuddle){
            if (currentWater > maxWater){
            currentWater = maxWater;
            }
            currentWater += 2 * Time.deltaTime;
            waterBar.SetThirst(currentWater);
        }

        //decrease hunger bar over time, cap at max bar value
        if (currentHunger > maxHunger){
            currentHunger = maxHunger;
        }
        hungerBar.SetHunger(currentHunger);
        currentHunger -= coef * Time.deltaTime;

        //decrease thirst bar over time, cap at max bar value
        if (currentWater > maxWater){
            currentWater = maxWater;
        }
        waterBar.SetThirst(currentWater);
        currentWater -= coef * Time.deltaTime;

    }

    //refill hunger bar 
    void hungerFill (int foodWorth){
        currentHunger += foodWorth;
        hungerBar.SetHunger(currentHunger);
    }

        
    private void OnTriggerEnter (Collider collison)
    {
        //behavior for when worm touches a mushroom
        if (collison.CompareTag("Mushroom"))
        {
            hungerFill(10);
            currentHappy += 20;
            happyBar.SetHappy(currentHappy);
            Destroy(collison.gameObject);
        }

        if (collison.CompareTag("Berry"))
        {
            hungerFill(3);
            currentHappy += 5;
            happyBar.SetHappy(currentHappy);
            Destroy(collison.gameObject);
        }

        //behavior for when worm sits in a puddle
        if (collison.CompareTag("Puddle"))
        {
            inPuddle = true;          
        }

    }

    //stops refilling water meter when worms leave puddle
    private void OnTriggerExit (Collider collison){
        if (collison.CompareTag("Puddle"))
        {
            inPuddle = false;
        }
    }
    
}
