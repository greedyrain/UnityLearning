using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectSerSelPanel : BasePanel<ProjectSerSelPanel>
{
    public UIButton confirmBtn, backBtn,changeBtn;
    public UILabel serverNameLabel;

    public override void Init()
    {
        confirmBtn.onClick.Add(new EventDelegate(() =>
        {
            //进入游戏；
            LoginManager.Instance.SaveLoginData();
            SceneManager.LoadScene("GameScene");
        }));

        backBtn.onClick.Add(new EventDelegate(() =>
        {
            //返回登录页面；
            //ProjectLoginPanel.Instance.Init();
            ProjectLoginPanel.Instance.ShowMe();
            HideMe();
        }));

        changeBtn.onClick.Add(new EventDelegate(() =>
        {
            //打开服务器列表；
            ProjectServersPanel.Instance.ShowMe();
            HideMe();
        }));

        serverNameLabel.text = LoginManager.Instance.ServersData.serverDic[LoginManager.Instance.LoginData.lastTimeServerID].serverName;
        HideMe();
    }
}
