using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using UnityEngine.Events;
using System;
using PureMVC.Interfaces;

public class BagPanelMediator : Mediator
{
    public new const string NAME = "BagPanelMediator";
    PlayerDataProxy PlayerData;
    private BagPanelView View;
    public BagPanelMediator(object viewComponent) : base(NAME)
    {
        View = ((GameObject)viewComponent).GetComponent<BagPanelView>();
        View.Close.onClick.AddListener(CloseBagPanel);
       
        GetPlayerData();
    }
    public override void HandleNotification(INotification notification)
    {
        Debug.Log("这里进来了");
        switch (notification.Name)
        {
            case MyFacade.Updata_BagPanel_View:

                PlayerData.playerData = notification.Body as PlayerDataModel;
                //update text
                //删除之前存在的Item
                View.ClearBagPanel();
                View.UpdataBagPanel(PlayerData.playerData);
                Debug.Log("PlayerData数据是：" + PlayerData.playerData.Models.Count + "Item的数量:" + View.bagitems.Count);
                break;
        }
    }
    private void CloseBagPanel()
    {
        //隐藏掉背包
        SetState(false);
    }

    void GetPlayerData()
    {
        //获取到要显示在背包上的数据
        PlayerData = Facade.RetrieveProxy(PlayerDataProxy.NAME) as PlayerDataProxy;
        //删除之前存在的Item
        View.ClearBagPanel();
        //要显示的数据
        View.UpdataBagPanel(PlayerData.playerData);
        Debug.Log("PlayerData数据是：" + PlayerData.playerData.Models.Count+"Item的数量:"+View.bagitems.Count);
        
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>() { MyFacade.Updata_BagPanel_View,MyFacade.User_Item_View };

        return list;
    }
    public void SetState(bool flag)
    {
        if (flag)
        {
            GetPlayerData();
        }
        View.gameObject.SetActive(flag);
    }
}
