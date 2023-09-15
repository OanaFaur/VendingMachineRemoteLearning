using LiteDB;

namespace DataAccess.Models
{
    public class CashMoney
    {
        [BsonId]
        public int MoneyId { get; set; }

        public double MoneyType { get; set; }

        public CashMoney(int moneyId, double moneyType)
        {
            MoneyId = moneyId;
            MoneyType = moneyType;
        }
    }
}
