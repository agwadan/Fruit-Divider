using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour{


    public GameObject BladeTrailPrefab;
    private GameObject currentBladeTrail;
    public bool isCutting;
    public float minCuttingVelocity = 0.001f;
    Vector2 previousPosition;
    Rigidbody2D rb;
    CircleCollider2D circleCollider;
    Camera cam;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main; //------------------------------------ Assigning the value of cam to the main camera of the scene. 
        circleCollider = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){//---------------------- "0" is to check if the left mouse button is clicked.
            StartCutting();
        } else if(Input.GetMouseButtonUp(0)){
            StopCutting();
        }

        if (isCutting){
            UpdateCut();
        }
    }

    void UpdateCut(){
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;
        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;

        if(velocity > minCuttingVelocity){
            circleCollider.enabled = true;//------------------------------------- turning on the collider of the blade.
        } else {
            circleCollider.enabled = false;//------------------------------------ turning off the collider of the blade.
        }
        previousPosition = newPosition;
    }

    void StartCutting(){
        isCutting               = true;
        currentBladeTrail       = Instantiate(BladeTrailPrefab, transform);
        previousPosition        = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled  = false;
    }

    void StopCutting(){
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);//------------------------------------ Destroy current bladetrail after 2s.
        circleCollider.enabled = false;
    }
}
