using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    internal class CashMoneyRepository : IMoneyRepository
    {
        private readonly List<CashMoney> machineMoney = new List<CashMoney>
        {
            new CashMoney(1, 0.01),
            new CashMoney(2, 0.05),
            new CashMoney(3, 0.10),
            new CashMoney(4, 0.50),
            new CashMoney(5, 1),
            new CashMoney(6, 5),
            new CashMoney(7, 10),
            new CashMoney(8, 50),
            new CashMoney(9, 100),
            new CashMoney(10, 200),
            new CashMoney(11, 500)
        };

        public IEnumerable<CashMoney> GetAll()
        {
            return machineMoney;
        }

        public CashMoney FindByMoneyType(double moneyType)
        {
            return GetAll().FirstOrDefault(m => m.MoneyType == moneyType);
        }
    }
}
