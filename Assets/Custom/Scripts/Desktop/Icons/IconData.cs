using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * This class will take on the function that IconPlacments was doing for data managment, icon placments will be used just for
 * placing the icons on screen and nothing else.
 * 
 * No game object refferences will need to be stored in this class as IconPlacments has all of them and this just will have IDs
 *  
 */


public static class IconData {

    public static int iconsPerX = 75;
    public static int iconsPerY = 100;

    public static int iconMatrixXSize;
    public static int iconMatrixYSize;

    public static Vector2 screenSize;

    public static Vector2 rightClickedIcon;

    private static int[,] IconLayout;

    private static IconBehaviour activeIcon;

    private static GameObject iconContainer;
    #region Icon refferences
    public static GameObject icon1;
    #endregion

    private static IconPlacment iconPlacer;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void start()
    {
        iconMatrixXSize = Screen.width / iconsPerX;
        iconMatrixYSize = Screen.height / iconsPerY;

        IconLayout = new int[iconMatrixXSize, iconMatrixYSize];

        screenSize = new Vector2(Screen.width, Screen.height);
    }

    #region Icon Managment

    public static int[,] generateNewIconLayout()
    {
        //Fill with ID 0
        for (int i = 0; i < iconMatrixXSize; i++)
        {
            for (int j = 0; j < iconMatrixYSize; j++)
            {
                IconLayout[i, j] = 0;
            }
        }

        //Set default icons
        IconLayout[0, 0] = 1;
        IconLayout[0, 1] = 2;
        IconLayout[0, 2] = 2;
        IconLayout[0, 3] = 1;
        IconLayout[0, 4] = 1;
        IconLayout[1, 0] = 2;
        Debug.Log("iconMatrixXSize: " + iconMatrixXSize);
        Debug.Log("iconMatrixYSize: " + iconMatrixYSize);


        //Place icons on screen
        iconPlacer.updateIconPlaces();

        return IconLayout;
    }

    public static int[,] updateIcon(int x, int y, int newValue)
    {
            IconLayout[x, y] = newValue;

            iconPlacer.updateIconPlaces();

            return IconLayout;
    }

    public static int[,] moveIcon(int newX, int newY, int newValue, int oldX, int oldY)
    {
        if (IconLayout[newX, newY] == 0)
        {
            updateIcon(oldX, oldY, 0);
            updateIcon(newX, newY, newValue);
        }
        else
        {
            /* Undo option
            Debug.LogWarning("Attempted to place icon ontop of another.");
            iconPlacer.updateIconPlaces();
            */

            updateIcon(oldX, oldY, getIconAt(newX, newY));
            updateIcon(newX, newY, newValue);
        }

        return IconLayout;
    }

    public static void shiftDown(int x, int y)
    {
        //IconLayout[x,y] is the point to start the shift

        //TODO
    }

    public static int[,] getIconLayout()
    {
        return IconLayout;
    }

    public static int getIconAt(int x, int y)
    {
        return IconLayout[x, y];
    }

    public static void setIconPlacer(IconPlacment newIconPlacer)
    {
        iconPlacer = newIconPlacer;
    }

    public static void setRightClickedIcon(Vector2 newVec)
    {
        rightClickedIcon = newVec;
    }

    public static void setRightClickedIcon(int x, int y)
    {
        rightClickedIcon = new Vector2(x,y);
    }

    public static void clearRightClickedIcon()
    {
        rightClickedIcon = new Vector2(-1, -1);
    }



    #endregion
}
