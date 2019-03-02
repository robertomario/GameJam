using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public GameController gc;
    public GameObject coloredCube;

    private Color myColor;

    // Start is called before the first frame update
    void Start()
    {
        myColor = coloredCube.GetComponent<Renderer>().material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            Color otherColor = other.GetComponent<Renderer>().material.GetColor("_Color");
            if (otherColor == myColor)
            {
                gc.IncrementScore();
            }
            else
            {
                gc.LoseLife();
            }
            Destroy(other.gameObject);
            gc.IncrementDestructionCounter();
        }
    }
}
