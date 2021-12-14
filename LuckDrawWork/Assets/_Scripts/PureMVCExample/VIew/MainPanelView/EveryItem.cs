using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EveryItem : MonoBehaviour
{
    ItemModel ItemModel;

    public Text name;
    public Image icon;
    public Button BackMainPanel;

    /// <summary>
    /// 改变单个的item项
    /// </summary>
    /// <param name="item"></param>
  public void UpdateItem(ItemModel item)
    {
        ItemModel = item;
        if (ItemModel!=null)
        {
            name.text = item.name + "\n" + item.price; 
            icon.sprite = Resources.Load<Sprite>("Goods/" + item.iocn);
        }
    }
}
