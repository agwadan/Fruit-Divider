using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour{
    
    public GameObject fruitPrefab;
    public Transform[] spawnPoints;

    public float minDelay = .1f,
                maxDelay = 1f;

    void Start(){
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits(){
        while (true){
            //Create a delay between spawning fruits.
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(1f);
            
            //Random SpawnPoint
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            //Spawn fruit
            GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
        }
    }
}
