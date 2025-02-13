using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidbody;
    public float flyPower = 10;
    public float flyInterval = 0.5f;
    private float flyCooldown = 0;
    void Start(){
        thisRigidbody = GetComponent<Rigidbody>();
    }
    void Update(){
        flyCooldown -= Time.deltaTime;
        bool isGameActive = GameManager.Instance.IsGameActive();
        bool canFly = flyCooldown <= 0 && isGameActive;

        if(canFly){
            bool flyInput = Input.GetKey(KeyCode.Space);
            if(flyInput){
                Fly();
            }
        }

        thisRigidbody.useGravity = isGameActive;
    }

    void OnCollisionEnter(Collision other){
        OnCustomCollisionEnter(other.gameObject);
    }
    void OnTriggerEnter(Collider other){
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCustomCollisionEnter(GameObject other){
        bool isSensor = other.CompareTag("Sensor");
        if(isSensor){
            GameManager.Instance.score++;
            Debug.Log("Score: " + (GameManager.Instance.score / 2));
        }else{
            GameManager.Instance.GameOver();
        }
    }

    private void Fly(){
        flyCooldown = flyInterval;
        thisRigidbody.linearVelocity = Vector3.zero;
        thisRigidbody.AddForce(new Vector3(0, flyPower, 0), ForceMode.Impulse);        
    }
}
