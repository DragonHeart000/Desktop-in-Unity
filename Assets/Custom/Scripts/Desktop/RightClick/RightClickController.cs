using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickController : MonoBehaviour {

    public GameObject rightClickMenu;
    public GameObject rightClickMenu_NoSelect;

    public GameObject activeRightClickMenu;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
        {
            if (activeRightClickMenu != null)
            {
                //Destroy rightclick menu that may already still be up
                GameObject.Destroy(activeRightClickMenu);
            }

            Vector2 temp = new Vector2(((int)Input.mousePosition.x / IconData.iconsPerX) - 1, IconData.iconMatrixYSize - ((int)Input.mousePosition.y / IconData.iconsPerY));
            try
            {
                if (IconData.getIconAt((int)temp.x, (int)temp.y) == 0)
                {
                    activeRightClickMenu = Instantiate(rightClickMenu_NoSelect, new Vector3((int)Input.mousePosition.x + 75, (int)Input.mousePosition.y - 46, 0), Quaternion.identity);
                    IconData.clearRightClickedIcon();
                }
                else
                {
                    activeRightClickMenu = Instantiate(rightClickMenu, new Vector3((int)Input.mousePosition.x + 75, (int)Input.mousePosition.y - 76, 0), Quaternion.identity);
                    IconData.setRightClickedIcon(temp);
                }
            } catch (IndexOutOfRangeException e)
            {
                activeRightClickMenu = Instantiate(rightClickMenu_NoSelect, new Vector3((int)Input.mousePosition.x + 75, (int)Input.mousePosition.y - 46, 0), Quaternion.identity);
                IconData.setRightClickedIcon(temp);
            }
            //Put in right layer
            activeRightClickMenu.transform.SetParent(this.transform);

        }

        if (Input.GetMouseButtonUp(0) && activeRightClickMenu != null)
        {
            GameObject.Destroy(activeRightClickMenu);
            IconData.clearRightClickedIcon();
        }
	}
}
