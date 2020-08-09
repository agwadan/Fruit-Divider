using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public float startForce = 2f;
    Rigidbody2D rb;
   
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }
    public GameObject fruitSlicedPrefab;

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Blade"){
            Vector3 direction = (col.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            Debug.Log("We hit a watermelon");
            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, transform.rotation);
            Destroy(slicedFruit, 3f);
            Destroy(gameObject);
        }
    }
}
