using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public GameObject fruitSlicedPrefab;

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Blade"){
            Debug.Log("We hit a watermelon");
            Instantiate(fruitSlicedPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
