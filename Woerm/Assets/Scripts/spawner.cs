using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    
    public GameObject[] foodObjects;
    public GameObject puddle;
    public GameObject berry;
    
    // Start is called before the first frame update
    void Start()
    {
        //randomly spawn 30 mushrooms at start of the game
        for (int i = 0; i < 30; i++){
            int randomFood = Random.Range(0, foodObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(30,970), 0, Random.Range(30,970));
            Instantiate(foodObjects[randomFood], randomSpawnPosition, Quaternion.identity);
        }

        //randomly spawn 30 puddles at start of the game
        for (int i = 0; i < 30; i++){
            Vector3 randomSpawnPosition = new Vector3(Random.Range(30,970), 0, Random.Range(30,970));
            Instantiate(puddle, randomSpawnPosition, Quaternion.identity);
        }

        //randomly spawn 40 berries at start of the game
        for (int i = 0; i < 40; i++){
            Vector3 randomSpawnPosition = new Vector3(Random.Range(30,970), 0, Random.Range(30,970));
            Instantiate(berry, randomSpawnPosition, Quaternion.identity);
        }

        //spawn 1 random mushroom every minute
        StartCoroutine(foodSpawnerRoutine());

    }

    IEnumerator foodSpawnerRoutine()
    {
			while (true)
            {
                yield return new WaitForSeconds(40);

				int randomFood = Random.Range(0, foodObjects.Length);
                Vector3 randomSpawnPosition = new Vector3(Random.Range(30,970), 0, Random.Range(30,970));
                Vector3 randomSpawnPosition2 = new Vector3(Random.Range(30,970), 0, Random.Range(30,970));
                Instantiate(foodObjects[randomFood], randomSpawnPosition, Quaternion.identity);
                Instantiate(berry, randomSpawnPosition2, Quaternion.identity);

			}

            yield return null;
		}
}
