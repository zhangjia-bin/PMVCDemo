using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanelView : MonoBehaviour
{
    public GameObject Item;
    //关闭事件
    public Button CloseMian;

    //点击抽奖事件
    public Button buttonPlaye;
    
    public Transform parentBonusItem;//父节点

    private List<GameObject> BonusItemLists = new List<GameObject>();
    public void ClearGameObjects()
    {
        for (int i = 0; i < BonusItemLists.Count; i++)
        {
            GameObject.Destroy(BonusItemLists[i]);
            BonusItemLists.RemoveAt(i);
        }
    }
    public void CreateItems(ItemProxy item)
    {
        for (int i = 0; i < item.ItemsLists.Count; i++)
        {
            GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("_Prefabs/item"),transform.Find("BG"),false);
            go.GetComponent<EveryItem>().UpdateItem(item.ItemsLists[i]);
            BonusItemLists.Add(go);
        }
    }
}
