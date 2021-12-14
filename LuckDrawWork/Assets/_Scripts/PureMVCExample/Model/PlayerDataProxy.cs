using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
public class PlayerDataProxy : Proxy
{
    public new static string NAME = "PlayerDataProxy";

    public PlayerDataModel playerData;
    public PlayerDataProxy(string name) : base(name, null)
    {

        playerData = new PlayerDataModel();
        playerData.Power = 0;
        playerData.Models = new List<ItemModel>();
    }
    public ItemModel GetUsrData(string icon)
    {
        for (int i = 0; i < playerData.Models.Count; i++)
        {
            if (icon == playerData.Models[i].iocn)
            {
                ItemModel ss = playerData.Models[i];
                return ss;
            }
        }

        return null;
    }

    public void UserPlayerDataitem(string iocn)
    {
        for (int i = 0; i < playerData.Models.Count; i++)
        {
            if (iocn == playerData.Models[i].iocn)
            {
                //已经有了减去数量
                playerData.Power += playerData.Models[i].price;
                playerData.Models[i].num--;
                if (playerData.Models[i].num <= 0)
                {
                    //从数据当中移除！！
                    playerData.Models.Remove(playerData.Models[i]);
                    var user = Facade.RetrieveMediator(UserPanelViewMediator.NAME) as UserPanelViewMediator;
                    user.SetState(false);
                }
                break;
            }
        }
        //这里也要写一个更新背包数据的方法
        SendModelToBagPanelViwe();
    }
    public void AddRewarditem(ItemModel item)
    {
        if (item == null) return;
        //显示背包面板
        for (int i = 0; playerData.Models != null && i < playerData.Models.Count; i++)
        {
            if (item.iocn == playerData.Models[i].iocn)
            {
                //已经有了减去数量
                playerData.Models[i].num++;
                //按理来说这里应该写一个更新背包界面的方法
                SendModelToBagPanelViwe();
                return;
            }
        }

        playerData.Models.Add(item);
        //按理来说这里应该写一个更新背包界面的方法
        SendModelToBagPanelViwe();

    }
    //这里发消息告诉背包面板进行更新
    public void SendModelToBagPanelViwe()
    {
        SendNotification(MyFacade.Updata_BagPanel_View, playerData);
    }

    public override void OnRegister()
    {
        Debug.Log("PlayerDataProxy OnRegister");
    }

    public override void OnRemove()
    {
        Debug.Log("PlayerDataProxy OnRemove");
    }
}
