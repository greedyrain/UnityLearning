using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerItem : MonoBehaviour
{
    public UIButton button;
    public UILabel label;
    public UISprite newSprite;
    public UISprite state;

    Server nowServerInfo;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.Add(new EventDelegate(()=>
        {
            LoginManager.Instance.LoginData.lastTimeServerID = nowServerInfo.id;
            //ProjectSerSelPanel.Instance.serverNameLabel.text = nowServerInfo.serverName;
            //ProjectServersPanel.Instance.lastServerLabel.text = nowServerInfo.serverName;
            ProjectSerSelPanel.Instance.Init();
            ProjectSerSelPanel.Instance.ShowMe();
            ProjectServersPanel.Instance.HideMe();
        }));
    }

    public void InitInfo(Server server)
    {
        nowServerInfo = server;
        label.text = server.id + "区";
        //newSprite.gameObject.SetActive(server.isNew);
        switch (server.state)
        {
            case 0:
                state.gameObject.SetActive(false);
                break;
            case 1:
                state.spriteName = "ui_DL_liuchang_01";
                break;
            case 2:
                state.spriteName = "ui_DL_fanhua_01";
                break;
            case 3:
                state.spriteName = "ui_DL_huobao_01";
                break;
            case 4:
                state.spriteName = "ui_DL_weihu_01";
                break;
        }
    }
}
