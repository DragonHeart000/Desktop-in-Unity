using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconPlacment : MonoBehaviour{

    private IconBehaviour activeIcon;

    private GameObject iconContainer;
    #region Icon refferences
    public GameObject icon1;
    public GameObject icon2;
    #endregion

    void Start()
    {
        IconData.setIconPlacer(this);

        iconContainer = new GameObject("Icon Container");
        iconContainer.transform.parent = gameObject.transform;

        IconData.generateNewIconLayout();

        updateIconPlaces();
    }

    private void Update()
    {
        if ((IconData.screenSize.x != Screen.width) || (IconData.screenSize.y != Screen.height))
        {
            IconData.screenSize.x = Screen.width;
            IconData.screenSize.y = Screen.height;
            updateIconPlaces();
        }
    }

    #region Icon Managment

    

    #endregion

    #region Icon placeing

    public GameObject getIcon(int ID)
    {
        switch (ID)
        {
            case 0:
                return null;

            case 1:
                return icon1;
            
            case 2:
                return icon2;
            
            default:
                Debug.LogWarning("WARNING: Icon ID " + ID + " requested but no icon exists for ID.");
                return null;
        }
    }

    public GameObject getIcon(int x, int y)
    {
        return getIcon(IconData.getIconAt(x,y));
    }

    public void updateIconPlaces()
    {
        //Destroy all icons
        GameObject.Destroy(iconContainer);

        //Create new container
        iconContainer = new GameObject("Icon Container");
        iconContainer.transform.parent = gameObject.transform;

        //Place prefabs in correct locations
        for (int i = 0; i < IconData.iconMatrixXSize; i++)
        {
            for (int j = 0; j < IconData.iconMatrixYSize; j++)
            {
                GameObject temp = getIcon(i,j);

                if (temp != null)
                {
                    int newIconX = 10;
                    int newIconY = 10;

                    //Instantiate a new icon and place it according to the matrix and set child to the container.
                    newIconX = ((i+1) * IconData.iconsPerX);
                    newIconY = Screen.height - (j * IconData.iconsPerY);

                    Vector3 newIconPosition = new Vector3(newIconX, newIconY, 0);
                    GameObject newIcon = Instantiate(temp, newIconPosition, Quaternion.identity);
                    newIcon.transform.SetParent(iconContainer.transform);

                    IconBehaviour newIconBehaviourScript = newIcon.GetComponent<IconBehaviour>();
                    newIconBehaviourScript.iconID = IconData.getIconAt(i, j);
                    newIconBehaviourScript.iconXInMatrix = i;
                    newIconBehaviourScript.iconYInMatrix = j;
                    newIconBehaviourScript.iconPosition = newIconPosition;
                    
                }
            }
        }
    }

    public void updateSinleIconPlace(int x, int y, int newID)
    {
        //TODO
    }

    #endregion
}
