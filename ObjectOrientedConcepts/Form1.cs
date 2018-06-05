using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ObjectOrientedConcepts
{
    public partial class Form1 : Form
    {
        Account _account = new Account(() => { Console.WriteLine("Begin..."); });
        List<Transaction> _transactions = new List<Transaction>();

        public Form1()
        {
            InitializeComponent();
            _account.Balance = decimal.Parse(lblBalance.Text.Replace("$", ""));
            lblState.Text = _account.StateText;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            _account.HolderVerified();
            lblVerified.Text = "Verified";
            ChangeState();
        }

        private void ChangeState()
        {
            lblState.Text = _account.StateText;
            lblBalance.Text = "$" + _account.Balance.ToString();
        }

        private void btnFreeze_Click(object sender, EventArgs e)
        {
            _account.Freeze();
            ChangeState();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            _account.Withdraw(decimal.Parse(txtAmount.Text));
            AddTransaction((decimal.Parse(txtAmount.Text) * -1));
            ChangeState();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            _account.Deposit(decimal.Parse(txtAmount.Text));
            AddTransaction(decimal.Parse(txtAmount.Text));
            ChangeState();
        }

        private void AddTransaction(decimal amount)
        {
            _transactions.Add(new Transaction() { Amount = amount });
            lblSmallestTrans.Text = "$" + _transactions.Where(transaction => transaction.Amount > 0)
                                                        .Minimum(transaction => transaction.Amount)
                                                        .Amount;
        }
    }
}
