using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTarget : MonoBehaviour
{
    public float speed;

    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gO = GameObject.FindGameObjectWithTag("Controller");
        gc = gO.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {      
        this.transform.Translate(new Vector3(-0.1f*speed*(1f+(gc.getCreationCounter()/4)/4f), 0, 0));
    }
}
