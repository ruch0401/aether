using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreTimer : MonoBehaviour {
    float currentTime = 0f;
    float startingTime = 120f;

    public TMP_Text scoreText;

    void Start() {
        currentTime = startingTime;
    }

    void Update() {
        currentTime -= 1 * Time.deltaTime;
        scoreText.text = currentTime.ToString("0");

        if (currentTime < 0) {
            Debug.Log("Player Dead! Timer = 0");
            currentTime = 0;
            FindObjectOfType<PlayerMovement>().Die();
        }
    }
}