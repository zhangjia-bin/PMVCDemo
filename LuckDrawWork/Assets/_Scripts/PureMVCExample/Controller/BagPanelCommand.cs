using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class BagPanelCommand:SimpleCommand
{
    public override void Execute(INotification notification)
    {
        //打开背包界面
        var bag = Facade.RetrieveMediator(BagPanelMediator.NAME) as BagPanelMediator;
        bag.SetState(true);
    }
}

