﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTarget : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(-0.1f*speed, 0, 0));
    }
}
