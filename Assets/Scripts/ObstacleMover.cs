using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    
    void Start(){
        
    }
    void FixedUpdate(){
        var gameManager = GameManager.Instance;

        if(gameManager.IsGameOver()){
            return;
        }

        float x = gameManager.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        if(transform.position.x <= -gameManager.obstacleOffsetX){
            Destroy(gameObject);
        }
    }
    
}
