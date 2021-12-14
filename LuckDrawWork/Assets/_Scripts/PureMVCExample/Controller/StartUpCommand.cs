using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class StartUpCommand : SimpleCommand
{
    public Transform parent;
    public override void Execute(INotification notification)
    {
        var mainPanelMediator = MyFacade.GetInstance().RetrieveMediator(MainPanelMediator.NAME) as MainPanelMediator;
        mainPanelMediator.SetState(true);
    }
}
