using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagItem : MonoBehaviour
{
    ItemModel ItemModel;
    public Image icon;
    public Text name;
    public Text num;
    public string id;
    public void UpdataBagItem(ItemModel item)
    {

        ItemModel = item;
        if (ItemModel!=null)
        {
            id = ItemModel.iocn;
            ItemModel = item;
            if (ItemModel != null)
            {
                name.text = ItemModel.name + "\n" + ItemModel.price;
                icon.sprite = Resources.Load<Sprite>("Goods/" + ItemModel.iocn);
                num.text = ItemModel.num.ToString();
            }
        }
    }
}
