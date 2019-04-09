using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightClickOptionBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouseHovering = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseHovering = true;
        this.GetComponent<Image>().color = new Color32(79, 79, 79, 100);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseHovering = false;
        this.GetComponent<Image>().color = new Color32(79, 79, 79, 0);
    }
}
