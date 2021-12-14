using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagPanelView : MonoBehaviour
{
    public Transform parentTransform;
    public Text hp;
    //来一个关闭背包的按钮
    public Button Close;

    public List<GameObject> bagitems = new List<GameObject>();


    public void UpdataBagPanel(PlayerDataModel model)
    {
        hp = GameObject.Find("Panel/Power/num").GetComponent<Text>();
        if (model == null) return;
        for (int i = 0; i < model.Models.Count; i++)
        {
            AddbagItem(model.Models[i]);
        }
        hp.text = model.Power.ToString();
    }
    //添加数据以及显示
    public void AddbagItem(ItemModel item)
    {
        GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("_Prefabs/bagitem"), parentTransform, false);
        go.GetComponent<BagItem>().UpdataBagItem(item);
        //点击使用的物品
        go.GetComponent<Button>().onClick.AddListener(()=> { OnclickUser(go.GetComponent<BagItem>()); });
        bagitems.Add(go);
    }

    private void OnclickUser(BagItem item)
    {
        //直接发送到view成
        MyFacade.GetInstance().SendNotification(MyFacade.Updata_User_Item_View, item.id);
    }


    public void ClearBagPanel()
    {
        //清除数据
        for (int i = 0; i < bagitems.Count; i++)
        {
            GameObject.Destroy(bagitems[i]);
        }
        bagitems.Clear();
    }

}
