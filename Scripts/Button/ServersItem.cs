using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServersItem : MonoBehaviour
{
    public UIButton button;
    public UILabel label;

    public int startIndex, endIndex;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.Add(new EventDelegate(()=>
        {
            //更新右侧的服务器列表；
            ProjectServersPanel.Instance.UpdateServerSV(startIndex, endIndex);
        }));
    }

    public void InitInfo(int startID,int endID)
    {
        startIndex = startID;
        endIndex = endID;
        label.text = startID + "_" + endID + "区";
    }
}
