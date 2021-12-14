using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class UserPanelCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var userpanel = Facade.RetrieveMediator(UserPanelViewMediator.NAME) as UserPanelViewMediator;
        userpanel.SetState(true);
    }
}


