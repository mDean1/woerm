using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    public GameObject[] foodObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++){
            int randomIndex = Random.Range(0, foodObjects.Length);
            Vector3 randomSpawnPosition=new Vector3(Random.Range(30,970), 0, Random.Range(30,970));
            Instantiate(foodObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            int randomIndex = Random.Range(0, foodObjects.Length);
            Vector3 randomSpawnPosition=new Vector3(Random.Range(30,970), 0, Random.Range(30,970));

            Instantiate(foodObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
        }
    }
}
