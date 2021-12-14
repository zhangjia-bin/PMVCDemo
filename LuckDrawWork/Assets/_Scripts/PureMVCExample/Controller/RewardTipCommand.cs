using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class RewardTipCommand : SimpleCommand
{
    Transform parent;
    GameObject obj;
    public override void Execute(INotification notification)
    {

        //obj = GameObject.Instantiate(Resources.Load<GameObject>("_Prefabs/RewardTipView"), parent, false);

        RewardTipViewMediator mediator = Facade.RetrieveMediator(RewardTipViewMediator.NAME) as RewardTipViewMediator;

        ItemProxy itemProxy = Facade.RetrieveProxy(ItemProxy.NAME) as ItemProxy;
        //获取到抽奖的数据
        ItemModel s = itemProxy.ItemsLists[Random.Range(0, itemProxy.ItemsLists.Count)];
        ItemModel model = new ItemModel();
        model.iocn = s.iocn;
        model.name = s.iocn;
        model.num = s.num;
        model.price = s.price;
        //发送给RewardTipView层显示
        mediator.SendNotification(MyFacade.UPDATE_REWARD_TIP_VIEW, model);
        //把抽取到的数据放入PlayerData数据当中！
        PlayerDataProxy playerDataProxy = Facade.RetrieveProxy(PlayerDataProxy.NAME) as PlayerDataProxy;
        playerDataProxy.AddRewarditem(model);
    }
}
