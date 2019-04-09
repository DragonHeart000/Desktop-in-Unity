using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour, RightClickFunctionInterface
{
    public void onClick()
    {
        IconData.updateIcon((int)IconData.rightClickedIcon.x, (int)IconData.rightClickedIcon.y, 0);
    }
}
