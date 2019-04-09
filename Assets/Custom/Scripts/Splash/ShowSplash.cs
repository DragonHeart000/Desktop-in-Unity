using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowSplash : MonoBehaviour {

    private float time;
    private float splashShowTime = 5f;

	// Use this for initialization
	void Start () {
        time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= time + splashShowTime)
        {
            Debug.Log("Scene load");
            SceneManager.LoadScene("desktop");
        }
    }
}
