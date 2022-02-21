using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTipsPanel : BasePanel<ProjectTipsPanel>
{
    public UIButton confirmBtn;
    public UILabel label;

    public override void Init()
    {
        confirmBtn.onClick.Add(new EventDelegate(() =>
        {
            HideMe();
        }));
        HideMe();
    }

    public void ChangeInfo(string info)
    {
        label.text = info;
    }
}
