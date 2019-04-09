using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo {

	private static int userID, groupID, staff;
    private static string userBackgroundImage = "";
    private static string loginToken = "";

    #region Credentials 

    public static string LoginToken
    {
        get
        {
            return loginToken;
        }
        set
        {
            loginToken = value;
        }
    }

    #endregion

    #region User login information

    public static int UserID
    {
        get
        {
            return userID;
        }
        set
        {
            userID = value;
        }
    }

    public static int GroupID
    {
        get
        {
            return groupID;
        }
        set
        {
            groupID = value;
        }
    }

    public static int Staff
    {
        get
        {
            return staff;
        }
        set
        {
            staff = value;
        }
    }

    #endregion

    public static string UserBackground
    {
        get
        {
            return userBackgroundImage;
        }
        set
        {
            userBackgroundImage = value;
        }
    }
}
