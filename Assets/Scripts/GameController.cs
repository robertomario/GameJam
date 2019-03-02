using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Text gOText;

    public float maxTime;
    public float waitTime;

    private int lives;
    private int score;
    private float timer = 0f;
    private int counter = 0;
    private bool gameOverFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
        Instantiate(targetBlue, spawnMiddle.transform);
        counter++;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (lives <= 0)
        {
            gOText.text = "Try again \n Your score was " + score;
            gOText.gameObject.SetActive(true);
            gameOverFlag = true;
        }

        if (Input.GetKey("a"))
        {
            colorWheel.transform.Rotate(new Vector3(0, 0, 10));
        }

        if (Input.GetKey("d"))
        {
            colorWheel.transform.Rotate(new Vector3(0, 0, -10));
        }

        if(Input.GetKeyDown("enter") || Input.GetKeyDown("space"))
        {
            if (gameOverFlag)
            {
                //Restart the game
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (timer >= maxTime && gameOverFlag==false)
        {
            gOText.text = "Congratulations! You won! \n Your score was " + score;
            gOText.gameObject.SetActive(true);
            gameOverFlag = true;
        }
        UpdateSpawning();        
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

    void UpdateSpawning()
    {
        if(timer >= 2 && counter == 1)
        {
            Instantiate(targetGreen, spawnDown.transform);
            counter++;
        }
        if (timer >= 4 && counter == 2)
        {
            Instantiate(targetYellow, spawnUp.transform);
            counter++;
        }
    }

}
