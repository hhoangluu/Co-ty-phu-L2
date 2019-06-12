using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public class SignUp : MonoBehaviour
{
    public InputField emailText;
    public InputField usernameText;
    public InputField passwordText;

    private string idToken;
    private Firebase.Auth.FirebaseAuth auth;


    private bool isauth;
    
    public static string playerScore;
    public static string userName;
    public static string localId;

    private void SignUpUser(string email, string username, string password)
    {
        //string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";

        //RestClient.Post<SignResponse>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key=AIzaSyAboxte-Q7j--uV4HFXfjA5WxfIALTPaM8", userData).Then(
        //    response =>
        //    {
        //        idToken = response.idToken;
        //        localId = response.localId;
        //        userName = username;
        //        SceneManager.LoadScene(0);
        //    }).Catch(
        //    error =>
        //    {
        //        Debug.Log(error);
        //    });
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                isauth = false;
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                isauth = false;
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            isauth = true;
          
        });
        Debug.Log(isauth);
        
            
    }
    private void Update()
    {
        if (isauth) SceneManager.LoadScene(0);
    }

    public void SignUpUserButton()
    {
        SignUpUser(emailText.text, usernameText.text, passwordText.text);
    }

    private void LoadSceneLogin()
    {
       
    }
}