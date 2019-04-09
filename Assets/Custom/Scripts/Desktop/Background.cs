using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {

    public Image backgroundImageObject;

	// Use this for initialization
	void Start () {

        if (PlayerInfo.UserBackground.Equals(""))
        {
            //set to default one
        } else
        {

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator setImageFromURL(string url)
    {
        Texture2D texture = backgroundImageObject.canvasRenderer.GetMaterial().mainTexture as Texture2D;

        WWW www = new WWW(url);
        yield return www;

        www.LoadImageIntoTexture(texture);
        www.Dispose();
        www = null;
    }
}
