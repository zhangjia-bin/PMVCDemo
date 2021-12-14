using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class RewardTipView:MonoBehaviour
{
    public Text name;
    public Image icon;
    public Button Back;
    public void UpdataItem(ItemModel item)
    {
        if (item!=null)
        {
            name.text = item.name + "\n" + item.price;
            icon.sprite = Resources.Load<Sprite>("Goods/" + item.iocn);
        }
    }
}

