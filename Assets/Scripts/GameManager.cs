using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int time = 20;
    public int difficulty = 1;
    public bool gameOver;
    [SerializeField] int score;

    public int Score {
        get => score;
        set {
            score = value;
            UIManager.Instance.UpdateUIScore(score);
            if(score % 1000 == 0) {
                difficulty++;
            }
        }
    }
    
    private void Awake() {
        if(Instance == null) {
            // this contains all the information of the class
            Instance = this;
        }
    }

    private void Start() {
        StartCoroutine(CountdownRutine());
        UIManager.Instance.UpdateUIScore(score);
    }

    IEnumerator CountdownRutine() {
        while(time > 0) {
            yield return new WaitForSeconds(1);
            time--;
            UIManager.Instance.UpdateUITime(time);
        }

        // Game Over
        gameOver = true;
        UIManager.Instance.ShowGameOverScreen();
    }

    public void PlayAgain() {
        SceneManager.LoadScene("Game");
    }
}
