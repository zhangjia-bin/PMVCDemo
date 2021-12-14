using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using System;
using PureMVC.Interfaces;

public class MainPanelMediator : Mediator
{
    public new const string NAME = "MainPanelMediator";

    private MainPanelView View;

    PlayerDataProxy playerData;

    ItemProxy ItemProxy;

    
    public MainPanelMediator(object viewComponent) : base(NAME, viewComponent)
    {
        //前提只有ViewComponent初始化成功，才可以进行UI的操作
        //绑定事件
        View = ((GameObject)viewComponent).GetComponent<MainPanelView>();
        //获取到所有的抽奖面板消息
        ItemProxy = Facade.RetrieveProxy(ItemProxy.NAME) as ItemProxy;
        //封装一个方法实例化每个Item项
        View.CreateItems(ItemProxy);
        //获取到玩家所有的数据信息
        playerData = Facade.RetrieveProxy(PlayerDataProxy.NAME) as PlayerDataProxy;

        //绑定按钮事件
        View.buttonPlaye.onClick.AddListener(OnClickPlay);
        View.CloseMian.onClick.AddListener(OnClickMian);
    }

    private void OnClickMian()
    {
        SetState(false);
    }

    private void OnClickPlay()
    {

        SendNotification(MyFacade.REWARD_TIP_VIEW);
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>() {  MyFacade.UPDATE_PLAYER_DATA };

        return list;
    }
    public void SetState(bool flag)
    {
        View.gameObject.SetActive(flag);
    }


}
