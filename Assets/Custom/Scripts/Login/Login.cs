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

public class Login : MonoBehaviour {

    public InputField username;
    public InputField pass;
    public Text errorText;

	public void LogIn()
    {
        //SceneManager.LoadScene("TheEnd");

        if (username.text.Equals("") || pass.text.Equals(""))
        {
            errorText.text = "Please fill in all fields.";
        }
        else
        {
            ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;

            WebRequest request = WebRequest.Create("REMOVED URL FOR UPLOAD TO GITHUB" + username.text + "&pass=" + pass.text);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Debug.Log(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();

            if (responseFromServer.Substring(0, 5).Equals("error") || responseFromServer.Substring(0, 6).Equals("<br />"))
            {
                errorText.text = "Login info incorrect.";
            } else
            {
                string[] responseArray = Regex.Split(responseFromServer, "<br>");

                PlayerInfo.UserID = Int32.Parse(responseArray[0]);
                PlayerInfo.GroupID = Int32.Parse(responseArray[1]);
                PlayerInfo.Staff = Int32.Parse(responseArray[2]);

                SceneManager.LoadScene("desktop");
            }
        }
    }


    public bool MyRemoteCertificateValidationCallback(System.Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
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
