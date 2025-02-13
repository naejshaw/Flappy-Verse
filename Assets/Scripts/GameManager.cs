using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public List<GameObject> obstaclePrefabs;
    public float obstacleInterval = 1;
    public float obstacleSpeed = 10;
    public float obstacleOffsetX = 0;
    public Vector2 obstacleOffsetY = new Vector2(0, 0);
    [HideInInspector]
    public int score = 0;
    
    private bool isGameOver = false;

    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        } else{
            Instance = this;
        }
    }    

    public bool IsGameActive(){
        return !isGameOver;
    }
    public bool IsGameOver(){
        return isGameOver;
    }
    public void GameOver(){
        isGameOver = true;
        Debug.Log("Game Over! Your Score is: " + (score / 2));
        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay){
        yield return new WaitForSeconds(delay);

        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
