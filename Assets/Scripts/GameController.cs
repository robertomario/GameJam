using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject colorWheel;
    public GameObject targetRed;
    public GameObject targetBlue;
    public GameObject targetYellow;
    public GameObject targetGreen;
    public GameObject spawnUp;
    public GameObject spawnMiddle;
    public GameObject spawnDown;

    private int lives;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
        Instantiate(targetBlue, spawnMiddle.transform);
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

    public int getLives()
    {
        return lives;
    }

    public int getScore()
    {
        return score;
    }
}
