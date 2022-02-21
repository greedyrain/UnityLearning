using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectServersPanel : BasePanel<ProjectServersPanel>
{
    public GameObject serverListSV;
    public GameObject serversSelSV;

    public UILabel lastServerLabel,tipsLabel;
    public ServersData serversData;
    private List<ServerItem> serverList = new List<ServerItem>();

    public override void Init()
    {
        int startIndex, endIndex;
        serversData = LoginManager.Instance.ServersData;
        if (LoginManager.Instance.LoginData.lastTimeServerID != 0)
        {
            lastServerLabel.text = serversData.serverDic[LoginManager.Instance.LoginData.lastTimeServerID].serverName;
        }
        //根据XML文件来动态创建Servers；

        for (int i = 0; i < serversData.serverDic.Count/6 +1; i++)
        {
            ServersItem leftSer = Instantiate(Resources.Load<ServersItem>("Prefabs/Servers"),serverListSV.transform);
            leftSer.transform.localPosition = new Vector3(0, 31, 0) + new Vector3(0, -90 * i, 0);
            startIndex = 1 + 6 * i;
            endIndex = 6+ 6 * i;
            if (endIndex >= serversData.serverDic.Count)
                endIndex = serversData.serverDic.Count;
            leftSer.InitInfo(startIndex,endIndex);
        }
        UpdateServerSV(1, 6);
        HideMe();
    }

    public void UpdateServerSV(int startIndex,int endIndex)
    {
        Server server;
        tipsLabel.text = startIndex + "-" + endIndex + "区";
        foreach (var item in serverList)
        {
            Destroy(item.gameObject);
        };
        serverList.Clear();
        for (int i = startIndex; i <= endIndex; i++)
        {
            server = LoginManager.Instance.ServersData.serverDic[i];
            ServerItem rightSer = Instantiate(Resources.Load<ServerItem>("Prefabs/Server"), serversSelSV.transform);
            rightSer.transform.localPosition = new Vector3(20,-112,0) + new Vector3((i-1)%6 % 2*300,(i-1)%6/2*-90,0);
            rightSer.InitInfo(server);
            serverList.Add(rightSer);
        }
    }
}
