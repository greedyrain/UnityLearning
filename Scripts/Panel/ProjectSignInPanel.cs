using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectSignInPanel : BasePanel<ProjectSignInPanel>
{
    public UIInput userName, password;
    public UIButton confirmBtn, cancelBtn;

    public override void Init()
    {
        #region 绑定按钮事件
        userName.onChange.Add(new EventDelegate(() =>
        {
            //每当值改变后，就保存当前值，以便与点击确定按钮后进行比较；
        }));

        password.onChange.Add(new EventDelegate(() =>
        {
            //每当值改变后，就保存当前值，以便与点击确定按钮后进行比较；
        }));

        confirmBtn.onClick.Add(new EventDelegate(() =>
        {
            //提交账号密码，保存到XML中；
            if (userName.value.Length >= 8 && password.value.Length >=8 )
            {
                if (LoginManager.Instance.UserSignIn(userName.value,password.value))
                {
                    LoginManager.Instance.LoginData.autoLogin = false;
                    SetLoginInfo();
                    ProjectLoginPanel.Instance.Init();
                    ProjectLoginPanel.Instance.ShowMe();
                    HideMe();
                }
                else
                {
                    ProjectTipsPanel.Instance.ChangeInfo("用户名已重复，请更换用户名。");
                    ProjectTipsPanel.Instance.ShowMe();
                }

                //以字典的形式存储到xml中，下一次匹配时通过键值对（username为键，password为值）进行匹配；
            }
            else
            {
                ProjectTipsPanel.Instance.ChangeInfo("请输入长度大于8位的账号和密码");
                ProjectTipsPanel.Instance.ShowMe();
            }
        }));

        cancelBtn.onClick.Add(new EventDelegate(() =>
        {
            //打开注册界面；
            ProjectLoginPanel.Instance.ShowMe();
            HideMe();
        }));
        HideMe();
        #endregion
    }

    public void SetLoginInfo()
    {
        LoginManager.Instance.LoginData.userName = userName.value;
        LoginManager.Instance.LoginData.passWord = password.value;
        LoginManager.Instance.ClaerData();
    }
}
