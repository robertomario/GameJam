using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateSpin : MonoBehaviour {
    public RectTransform tr;
    public float rotate = 0;
    public Quaternion qt = new Quaternion(0,0,0,1);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tr.rotation = qt;
        qt.z = rotate;
        rotate += 1;
	}
}
