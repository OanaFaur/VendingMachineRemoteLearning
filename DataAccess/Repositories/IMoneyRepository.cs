using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IMoneyRepository
    {
        CashMoney FindByMoneyType(double moneyType);
        IEnumerable<CashMoney> GetAll();
    }
}
