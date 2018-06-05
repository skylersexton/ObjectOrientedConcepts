using System;

namespace ObjectOrientedConcepts
{
    class NotVerified : IAccountState
    {
        private Action Unfreeze { get; }
        public string Title = "Not Verified";

        public NotVerified(Action unFreeze)
        {
            this.Unfreeze = unFreeze;
        }

        public IAccountState Close() => new Closed();
        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }
        public IAccountState Freeze() => this;
        public IAccountState HolderVerified() => new Active(this.Unfreeze);
        public IAccountState Withdraw(Action subtractFromBalance) => this;
        public string Text() => this.Title;
    }
}
