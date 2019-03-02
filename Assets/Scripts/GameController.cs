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
    public int rotationSpeed;

    private int lives;
    private int score;
    private float timer = 0f;
    private int numTargets = 11;
    private int creationCounter = 0;
    private int destructionCounter = 0;
    private bool gameOverFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
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
            clearTargets();
        }

        if (Input.GetKey("a"))
        {
            colorWheel.transform.Rotate(new Vector3(0, 0, rotationSpeed));
        }

        if (Input.GetKey("d"))
        {
            colorWheel.transform.Rotate(new Vector3(0, 0, -1*rotationSpeed));
        }

        if(Input.GetKeyDown("enter") || Input.GetKeyDown("space"))
        {
            if (gameOverFlag)
            {
                //Restart the game
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (!gameOverFlag)
        {
            if (destructionCounter == numTargets)
            {
                gOText.text = "Congratulations! You won! \n Your score was " + score;
                gOText.gameObject.SetActive(true);
                gameOverFlag = true;
            }

            UpdateSpawning();
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

    public void IncrementDestructionCounter()
    {
        destructionCounter++;
    }

    public int getLives()
    {
        return lives;
    }

    public int getScore()
    {
        return score;
    }

    public void clearTargets()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        for (var i=0; i < targets.Length; i++)
        {
            Destroy(targets[i]);
        }
    }

    void UpdateSpawning()
    {
        if (timer >= 1 && creationCounter == 0)
        {
            Instantiate(targetBlue, spawnMiddle.transform);
            creationCounter++;
        }
        if (timer >= 3 && creationCounter == 1)
        {
            Instantiate(targetGreen, spawnDown.transform);
            creationCounter++;
        }
        if (timer >= 5 && creationCounter == 2)
        {
            Instantiate(targetYellow, spawnUp.transform);
            creationCounter++;
        }
        if (timer >= 7 && creationCounter == 3)
        {
            Instantiate(targetGreen, spawnMiddle.transform);
            creationCounter++;
        }
        if (timer >= 8 && creationCounter == 4)
        {
            Instantiate(targetRed, spawnUp.transform);
            creationCounter++;
        }
        if (timer >= 10 && creationCounter == 5)
        {
            Instantiate(targetGreen, spawnDown.transform);
            creationCounter++;
        }
        if (timer >= 12 && creationCounter == 6)
        {
            Instantiate(targetBlue, spawnDown.transform);
            creationCounter++;
        }
        if (timer >= 13 && creationCounter == 7)
        {
            Instantiate(targetYellow, spawnDown.transform);
            creationCounter++;
        }
        if (timer >= 14 && creationCounter == 8)
        {
            Instantiate(targetYellow, spawnMiddle.transform);
            creationCounter++;
        }
        if (timer >= 16 && creationCounter == 9)
        {
            Instantiate(targetRed, spawnMiddle.transform);
            creationCounter++;
        }
        if (timer >= 18 && creationCounter == 10)
        {
            Instantiate(targetBlue, spawnUp.transform);
            creationCounter++;
        }
    }

}
