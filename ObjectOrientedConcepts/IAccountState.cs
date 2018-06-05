using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedConcepts
{
    interface IAccountState
    {
        string Text();
        IAccountState Freeze();
        IAccountState Withdraw(Action subtractFromBalance);
        IAccountState Deposit(Action addToBalance);
        IAccountState HolderVerified();
        IAccountState Close();
    }
}
