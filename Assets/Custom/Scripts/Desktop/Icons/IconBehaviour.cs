using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class IconBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int iconID;
    public int iconXInMatrix;
    public int iconYInMatrix;
    public Vector3 iconPosition;

    public Image highLightImagePrefab;
    private Image highLightImage;

    private bool pointerHover = false;

    private bool pointerDraggingIcon = false;

    private int iconMatrixXSize;
    private int iconMatrixYSize;


    // Use this for initialization
    void Start () {
        highLightImage = Instantiate(highLightImagePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        highLightImage.transform.SetParent(gameObject.transform);
        highLightImage.color = new Color32(0, 92, 194, 0);

        iconMatrixXSize = Screen.width / IconData.iconsPerX;
        iconMatrixYSize = Screen.height / IconData.iconsPerY;
    }
	
	// Update is called once per frame
	void Update () {
        if (pointerHover)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pointerDraggingIcon = true;
            } else if (!Input.GetMouseButton(0))
            {
                if (pointerDraggingIcon)
                {
                    try
                    {
                        //Check if icon even moved
                        if (((((int)Input.mousePosition.x / IconData.iconsPerX)) - 1 != iconXInMatrix) || ((IconData.iconMatrixYSize - ((int)Input.mousePosition.y / IconData.iconsPerY)) != iconYInMatrix))
                        {
                            IconData.moveIcon(((int)Input.mousePosition.x / IconData.iconsPerX) - 1, IconData.iconMatrixYSize - ((int)Input.mousePosition.y / IconData.iconsPerY), iconID,
                                iconXInMatrix, iconYInMatrix);
                        }
                        else
                        {
                            gameObject.transform.position = iconPosition;
                        }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.LogWarning("Attempt to place icon outside of alloted range.");
                        IconData.updateIcon(iconXInMatrix, iconYInMatrix, iconID);
                    }
                }
                pointerDraggingIcon = false;
            }
        }

        if (pointerDraggingIcon)
        {
            gameObject.transform.position = Input.mousePosition;
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        highLightImage.color = new Color32(0, 92, 194, 130);

        pointerHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highLightImage.color = new Color32(0, 92, 194, 0);

        pointerHover = false;
    }
}
