using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float cooldown = 0;
    void Start(){
        
    }
    void Update(){
        var gameManager = GameManager.Instance;

        if(gameManager.IsGameOver()){
            return;
        }

        cooldown -= Time.deltaTime;
        if(cooldown <= 0f){
            cooldown = gameManager.obstacleInterval;

            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
            GameObject prefab = gameManager.obstaclePrefabs[prefabIndex];


            float x = gameManager.obstacleOffsetX;
            float y = Random.Range(gameManager.obstacleOffsetY.x, gameManager.obstacleOffsetY.y);
            float z = -1.678f;
            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = prefab.transform.rotation;
            Instantiate(prefab, position, rotation);
        }
    }
    
}
