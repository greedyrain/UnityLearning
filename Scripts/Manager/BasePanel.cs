using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePanel<T> : MonoBehaviour where T:class
{
    private static T instance;

    public static T Instance => instance;


    protected virtual void Awake()
    {
        instance = this as T;
    }

    protected virtual void Start()
    {
        //初始化 主要用于 监听按钮等事件
        Init();
    }

    public abstract void Init();

    public virtual void ShowMe()
    {
        gameObject.SetActive(true);
    }

    public virtual void HideMe()
    {
        gameObject.SetActive(false);
    }
}
