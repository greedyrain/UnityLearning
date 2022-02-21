using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectLoginPanel : BasePanel<ProjectLoginPanel>
{
    public UIButton confirmBtn, signInBtn;
    public UIInput userName, password;
    public UIToggle rememberPW, autoLogin;
    public LoginData loginData;

    public override void Init()
    {
        loginData = LoginManager.Instance.LoginData;
        rememberPW.value = loginData.rememberPW;
        autoLogin.value = loginData.autoLogin;

        if (autoLogin.value)
        {
            HideMe();
            ProjectSerSelPanel.Instance.Init();
            ProjectSerSelPanel.Instance.ShowMe();
        }

        if (loginData.userName != null)
        {
            userName.value = loginData.userName;
        }

        if (loginData.passWord != null)
        {
            if (rememberPW.value == true)
            {
                password.value = loginData.passWord;
            }
            else
                password.value = null;
        }

        #region 绑定按钮事件的代码
        confirmBtn.onClick.Add(new EventDelegate(() =>
        {
            LoginManager.Instance.LoginData.rememberPW = rememberPW.value;
            LoginManager.Instance.LoginData.autoLogin = autoLogin.value;
            LoginManager.Instance.LoginData.passWord = password.value;
            LoginManager.Instance.LoginData.userName = userName.value;
            //提交账号密码，与正确的账号密码进行比对；
            if (LoginManager.Instance.UserLogin(userName.value, password.value))
            {
                LoginManager.Instance.SaveLoginData();
                if (loginData.lastTimeServerID == 0)
                    ProjectServersPanel.Instance.ShowMe();
                else
                    ProjectSerSelPanel.Instance.ShowMe();
                print(Application.streamingAssetsPath);
                print(Application.persistentDataPath);
                HideMe();
            }
            else
            {
                ProjectTipsPanel.Instance.ChangeInfo("账号或密码错误");
                ProjectTipsPanel.Instance.ShowMe();
                autoLogin.value = false;
            }
        }));

        signInBtn.onClick.Add(new EventDelegate(() =>
        {
            //打开注册界面；
            ProjectSignInPanel.Instance.ShowMe();
            HideMe();
        }));

        userName.onChange.Add(new EventDelegate(() =>
        {
            //每当值改变后，就保存当前值，以便与点击确定按钮后进行比较；
        }));

        password.onChange.Add(new EventDelegate(() =>
        {
            //每当值改变后，就保存当前值，以便与点击确定按钮后进行比较；
        }));

        rememberPW.onChange.Add(new EventDelegate(() =>
        {
            //让Label的Starting Value 改变为存储在XML中的密码；
            if (rememberPW.value == false)
                autoLogin.value = false;
        }));

        autoLogin.onChange.Add(new EventDelegate(() =>
        {
            //开始游戏后自动进入服务器选择界面；
            if (autoLogin.value == true)
                rememberPW.value = true;
        }));
        #endregion
    }
}
