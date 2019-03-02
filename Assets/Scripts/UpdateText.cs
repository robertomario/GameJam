﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    public GameController gc;
    public Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        debugText.text = "Lives: " + gc.getLives() + " | Score: " + gc.getScore();
    }
}
