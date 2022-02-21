using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager
{
    private static LoginManager instance = new LoginManager();
    public static LoginManager Instance => instance;

    private SignInData signInData;
    public SignInData SignInData
    {
        get { return signInData; }
    }

    //设置一个属性，可以直接利用单例获得这份LoginDara数据；
    private LoginData loginData;
    public LoginData LoginData
    {
        get { return loginData; }
    }

    private ServersData serversData;
    public ServersData ServersData
    {
        get { return serversData; }
    }

    //构造函数，直接初始化LoginData、SignInData；
    private LoginManager()
    {
        loginData = XMLDataManager.Instance.LoadData(typeof(LoginData), "LoginData") as LoginData;
        signInData = XMLDataManager.Instance.LoadData(typeof(SignInData), "SignInData") as SignInData;
        serversData = XMLDataManager.Instance.LoadData(typeof(ServersData), "ServersData") as ServersData;
    }

    //向外部提供一个可直接调用的保存数据的方法；
    public void SaveLoginData()
    {
        XMLDataManager.Instance.SaveData(loginData, "LoginData");
    }

    public void SaveSignInData()
    {
        XMLDataManager.Instance.SaveData(signInData, "SignInData");
    }

    public bool UserSignIn(string userName,string password)
    {
        if (signInData.signInInfo.ContainsKey(userName))
        {
            return false;
        }
        else
        {
            signInData.signInInfo.Add(userName, password);
            SaveSignInData();
            return true;
        }
    }

    public bool UserLogin(string userName,string password)
    {
        if (signInData.signInInfo.ContainsKey(userName))
        {
            if (signInData.signInInfo[userName] == password)
            {
                return true;
            }
        }
        return false;
    }

    public void ClaerData()
    {
        loginData.lastTimeServerID = 1;
    }
}
