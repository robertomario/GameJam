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
    public float minSpawnTime;
    public float maxSpawnTime;
    public int numTargets;

    private int lives;
    private int score;
    private float timer = 0f;
    private int creationCounter = 0;
    private int destructionCounter = 0;
    private bool gameOverFlag = false;
    private float nextSpawnTime = 3;
    private GameObject nextSpawnColor;
    private GameObject nextSpawnLocation;

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
            if (destructionCounter == numTargets+1)
            {
                gOText.text = "Congratulations! You won! \n Your score was " + score;
                gOText.gameObject.SetActive(true);
                gameOverFlag = true;
                clearTargets();
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

    public int getCreationCounter()
    {
        return creationCounter;
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
        if (timer >= nextSpawnTime)
        {
            switch(Random.Range(0, 4))
            {
                case 0:
                    nextSpawnColor = targetBlue;
                    break;
                case 1:
                    nextSpawnColor = targetGreen;
                    break;
                case 2:
                    nextSpawnColor = targetYellow;
                    break;
                case 3:
                    nextSpawnColor = targetRed;
                    break;
            }
            switch (Random.Range(0, 3))
            {
                case 0:
                    nextSpawnLocation = spawnDown;
                    break;
                case 1:
                    nextSpawnLocation = spawnMiddle;
                    break;
                case 2:
                    nextSpawnLocation = spawnUp;
                    break;
            }
            Instantiate(nextSpawnColor, nextSpawnLocation.transform);
            creationCounter++;
            timer = 0f;
            nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

}
