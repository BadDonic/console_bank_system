using console_bank_system.Decorator;
using console_bank_system.MoneyState;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system.Strategy
{
	public interface IStrategy
	{
		void TopUpThePhone(double sum, Account account);
	}
}