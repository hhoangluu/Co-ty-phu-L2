using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserModel
{
    private string userName;
    private string password;
    private string email;
    private string localId;

    public string UserName { get => userName; set => userName = value; }
    public string Email { get => email; set => email = value; }
    public string Password { get => password; set => password = value; }
    public string LocalId { get => localId; set => localId = value; }

    public UserModel()
    {
        userName = SignUp.userName;
        localId = SignUp.localId;

    }
}
