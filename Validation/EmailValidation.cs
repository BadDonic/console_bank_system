using System.IO;
using System.Text.RegularExpressions;
using console_bank_system.Decorator;

namespace console_bank_system.Validation
{
	public class EmailValidation : AbstractValidation
	{
		public EmailValidation(AbstractValidation next) : base(next)
		{
			Regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
		}

		public override bool Validate(Account account)
		{
			if (!Regex.IsMatch(account.Email))
				throw new InvalidDataException("Email must be: ^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{6,15}$");
			return Next?.Validate(account) ?? true;
		}
	}
}