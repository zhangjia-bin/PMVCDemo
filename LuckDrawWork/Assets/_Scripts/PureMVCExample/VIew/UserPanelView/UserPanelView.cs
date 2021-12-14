using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UserPanelView:MonoBehaviour
{
    public Text name;
    public Image icon;
    public Button user;
    public Button close;
    public string id;
    public void UpdataItem(ItemModel item)
    {
        if (item != null)
        {
            id = item.iocn;
            name.text = item.name + "\n" + item.price;
            icon.sprite = Resources.Load<Sprite>("Goods/" + item.iocn);
        }
    }
}

