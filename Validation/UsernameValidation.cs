using System.IO;
using System.Text.RegularExpressions;
using console_bank_system.Decorator;

namespace console_bank_system.Validation
{
	public class UsernameValidation : AbstractValidation
	{
		public UsernameValidation(AbstractValidation next) : base(next)
		{
			Regex = new Regex(@"^[a-zA-Z]{1}[a-zA-Z0-9_]{0,10}$");
		}
		
		public override bool Validate(Account account)
		{
			//TODO Check username uniqueness and password
			if (!Regex.IsMatch(account.Username))
				throw new InvalidDataException("Username must be: ^[a-zA-Z]{1}[a-zA-Z0-9_]{0,10}$");
			return Next?.Validate(account) ?? true;
		}
	}
}