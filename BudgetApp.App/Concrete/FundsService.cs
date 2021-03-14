using System;

using BudgetApp.Domain.Models;

namespace BudgetApp.App.Concrete
{
    public class FundsService
    {
        public Fund EditIrregularExpensesFund (Fund irregularExpensesFund, decimal income)
        {
            irregularExpensesFund.Balance += income;
            return irregularExpensesFund;
        }

        public Fund EditEmergencyFund (Fund emergencyFund, decimal income)
        {
            emergencyFund.Balance += income;
            return emergencyFund;
        }

        public Fund EditSecurityFund (Fund securityFund, decimal income)
        {
            securityFund.Balance += income;
            return securityFund;
        }
    }
}