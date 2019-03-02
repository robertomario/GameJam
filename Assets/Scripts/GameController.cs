using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject colorWheel;

    private int lives;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            //Restart the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKey("a"))
        {
            colorWheel.transform.Rotate(new Vector3(0, 0, 10));
        }

        if (Input.GetKey("d"))
        {
            colorWheel.transform.Rotate(new Vector3(0, 0, -10));
        }
    }

    public void IncrementScore()
    {
        score++;
    }

    public void LoseLife()
    {
        lives--;
    }
}
