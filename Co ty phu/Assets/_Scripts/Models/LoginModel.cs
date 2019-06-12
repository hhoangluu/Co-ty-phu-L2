using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginModel : MonoBehaviour
{
    public InputField emailText;
    public InputField passwordText;
    private string idToken;
    private Firebase.Auth.FirebaseAuth auth;
    private bool isauth;

    public string localId { get; private set; }

    public void SignInUserButton()
    {
       
        SignInUser(emailText.text, passwordText.text);
    }
    private void SignInUser(string email, string password)
    {
        //string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";

        //RestClient.Post<SignResponse>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=AIzaSyAboxte-Q7j--uV4HFXfjA5WxfIALTPaM8", userData).Then(
        //    response =>
        //    {
        //        idToken = response.idToken;
        //        localId = response.localId;

        //        SceneManager.LoadScene(2);
        //    }).Catch(
        //    error =>
        //    {
        //        Debug.Log(error);
        //    });
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                isauth = false;
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                isauth = false;
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            PlayerModel.Uid = newUser.UserId;
            isauth = true;
        });
    }
    public void SignUpBtn()
    {
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
      if (isauth) SceneManager.LoadScene(2);
        
    }

}
