using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedConcepts
{
    class Frozen : IAccountState
    {
        private Action OnUnfreeze { get; }
        public string Title = "Frozen";
        public Frozen(Action unFreeze)
        {
            this.OnUnfreeze = unFreeze;
        }
        
        public IAccountState Deposit(Action addToBalance)
        {
            this.OnUnfreeze();
            addToBalance();
            return new Active(this.OnUnfreeze);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            this.OnUnfreeze();
            subtractFromBalance();
            return new Active(this.OnUnfreeze);
        }

        public IAccountState Freeze() => this;
        public IAccountState HolderVerified() => this;
        public IAccountState Close() => new Closed();
        public string Text() => this.Title;

    }
}
