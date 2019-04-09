using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataManagement {

    public static string getData(string typeOfData)
    {
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;

        WebRequest request = WebRequest.Create("REMOVED URL FOR UPLOAD TO GITHUB" + PlayerInfo.LoginToken +
            "&dataToGet=" + typeOfData);
        request.Credentials = CredentialCache.DefaultCredentials;
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        Debug.Log(responseFromServer);
        reader.Close();
        dataStream.Close();
        response.Close();

        //TODO
        return "";
    }

    public static bool setData(string typeOfData, string data)
    {
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;

        WebRequest request = WebRequest.Create("REMOVED URL FOR UPLOAD TO GITHUB" + PlayerInfo.LoginToken +
            "&dataToSet=" + typeOfData + "&data=" + data);
        request.Credentials = CredentialCache.DefaultCredentials;
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        Debug.Log(responseFromServer);
        reader.Close();
        dataStream.Close();
        response.Close();

        if (responseFromServer.Equals("false"))
        {
            return false;
        } else if (responseFromServer.Equals("true"))
        {
            return true;
        } else
        {
            //something done fucked up better do something about it here.
            return false; //default to false if somethign errored
        }
    }


    public static bool MyRemoteCertificateValidationCallback(System.Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        bool isOk = true;
        // If there are errors in the certificate chain, look at each error to determine the cause.
        if (sslPolicyErrors != System.Net.Security.SslPolicyErrors.None)
        {
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                if (chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown)
                {
                    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                    bool chainIsValid = chain.Build((X509Certificate2)certificate);
                    if (!chainIsValid)
                    {
                        isOk = false;
                    }
                }
            }
        }
        return isOk;
    }

}
