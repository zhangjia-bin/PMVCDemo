using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class MyFacade : Facade
{
    Transform parentTransform;
    public const string START_UP = "start_up";
    public const string UPDATE_PLAYER_DATA = "update_player_data";
    public const string UPDATE_REWARD_TIP_VIEW = "update_reward_tip_view";
    public const string REWARD_TIP_VIEW = "reward_tip_view";
    public const string BagPanel_View = "bagpanel_view";
    public const string Updata_BagPanel_View = "updata_bagpanel_view";


    public const string User_Item_View = "user_item_view";
    public const string Updata_User_Item_View = "updata_user_item_view";
    /// <summary>
    /// 静态初始化 
    /// </summary>
    static MyFacade()
    {
        m_instance = new MyFacade();
    }
    /// <summary>
    /// 获取单例
    /// </summary>
    /// <returns></returns>
    public static MyFacade GetInstance()
    {
        
        return m_instance as MyFacade;
    }
    /// <summary>
    /// 启动MVC
    /// </summary>
    public void Launch()
    {
         parentTransform = GameObject.Find("Panel").transform;
        SendNotification(MyFacade.START_UP);
    }
    public void LaunchBag()
    {
        SendNotification(MyFacade.BagPanel_View);
    }
    
    
    /// <summary>
    /// 初始化Controller，完成Notification和Command的映射
    /// </summary>
    protected override void InitializeController()
    {
        base.InitializeController();

        
        //注册Command
        RegisterCommand(START_UP, typeof(StartUpCommand));
        RegisterCommand(REWARD_TIP_VIEW, typeof(RewardTipCommand));
        RegisterCommand(BagPanel_View, typeof(BagPanelCommand));
        RegisterCommand(User_Item_View, typeof(UserPanelCommand));
        //RegisterCommand(PLAY, typeof(PlayCommand));
        //RegisterCommand(REWARD_TIP_VIEW, typeof(RewardTipCommand));
    }
    /// <summary>
    /// 初始化Model层
    /// </summary>
    protected override void InitializeModel()
    {
        base.InitializeModel();

        RegisterProxy(new PlayerDataProxy(PlayerDataProxy.NAME));
        RegisterProxy(new ItemProxy(ItemProxy.NAME));
    }
    /// <summary>
    /// 初始化View层
    /// </summary>
    protected override void InitializeView()
    {
        base.InitializeView();
       
        RegisterMediator(new MainPanelMediator(GameObjectUtility.Instance.LoadUI("_Prefabs/MainPanelView", parentTransform, false)));
        RegisterMediator(new RewardTipViewMediator(GameObjectUtility.Instance.LoadUI("_Prefabs/RewardTipView", parentTransform, false)));
        RegisterMediator(new BagPanelMediator(GameObjectUtility.Instance.LoadUI("_Prefabs/BagPanelView", parentTransform, false)));
        RegisterMediator(new UserPanelViewMediator(GameObjectUtility.Instance.LoadUI("_Prefabs/UserPanelView", parentTransform, false)));
       // RegisterMediator(new UserPanelViewMediator(MyFacade.START_UP, GameObjectUtility.Instance.LoadUI("_Prefabs/UserPanelView", parentTransform, false)));
        
    }
}
