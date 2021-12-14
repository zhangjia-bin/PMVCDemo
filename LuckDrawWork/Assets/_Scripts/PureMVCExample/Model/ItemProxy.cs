using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class ItemProxy : Proxy
{
   public ItemProxy(string proxyName):base(proxyName)
    {
        Debug.Log("bonusProxy create");
        CreateRewardPool();
    }
    public new static string NAME = "Item";
    //奖励列表的显示
    public List<ItemModel> ItemsLists = new List<ItemModel>();
    private static string[] REWARD_NAME = new string[] { "金创药", "薄荷叶", "橡木果", "圣灵药", "还魂丹", "解毒药", "治疗药" , "眼药水" };
    private static int[] REWARD_PRICE = new int[] { 100, 300, 500, 800, 1200 ,1500,1800,2100};
    public void AddItems(ItemModel item)
    {
        ItemsLists.Add(item);
    }
    public void ClearItemLists()
    {
        ItemsLists.Clear();
    }
    //创建奖池的
    public void CreateRewardPool()
    {
        for (int i = 0; i < 8; i++)
        {
            ItemModel item = new ItemModel() { };
            item.iocn = i.ToString();
            item.name = REWARD_NAME[i];
            item.price = REWARD_PRICE[i];
            item.num = 1;
            ItemsLists.Add(item);
        }
    }

}
