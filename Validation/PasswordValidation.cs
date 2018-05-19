using System.IO;
using System.Text.RegularExpressions;
using console_bank_system.Decorator;

namespace console_bank_system.Validation
{
	public class PasswordValidation : AbstractValidation
	{
		public PasswordValidation(AbstractValidation next) : base(next)
		{
			Regex = new Regex(@"^(?=.*\d)(?=.*[a-zA-Z]).{6,15}");
		}

		public override bool Validate(Account account)
		{
			if (!Regex.IsMatch(account.Password))
				throw new InvalidDataException("Password must be: ^(?=.*\\d)(?=.*[a-zA-Z]).{6,15}");
			return Next?.Validate(account) ?? true;
		}
	}
}