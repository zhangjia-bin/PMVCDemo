using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using UnityEngine.UI;

public class UserPanelViewMediator : Mediator
{

    public UserPanelView View;
    public new const string NAME = "UserPanelViewMediator";

    public PlayerDataProxy playerDataProxy;
    public UserPanelViewMediator(object viewComponent) : base(NAME, viewComponent)
    {
        //前提只有ViewComponent初始化成功，才可以进行UI的操
        View = ((GameObject)viewComponent).GetComponent<UserPanelView>();
         playerDataProxy = Facade.RetrieveProxy(PlayerDataProxy.NAME) as PlayerDataProxy;
        //绑定按钮事件
        View.close.onClick.AddListener(OnClose);
        View.user.onClick.AddListener(OnUser);
    }

    private void OnClose()
    {
        SetState(false);

    }
    private void OnUser()
    {
        
        playerDataProxy.UserPlayerDataitem(View.id);
    }

    public override IList<string> ListNotificationInterests()
    {

        IList<string> list = new List<string>() { MyFacade.Updata_User_Item_View };

        return list;
    }
    public override void HandleNotification(INotification notification)
    {
       
        switch (notification.Name)
        {
            case MyFacade.Updata_User_Item_View:
                {
                    if (!View.isActiveAndEnabled)
                    {
                        View.gameObject.SetActive(true);
                    }
                    string id = notification.Body as string;
                    ItemModel itemModel= playerDataProxy.GetUsrData(id);
                    //update text

                    View.UpdataItem(itemModel);
                    break;
                }
            default:
                break;
        }
    }



    public void SetState(bool flag)
    {
        View.gameObject.SetActive(flag);
    }

}