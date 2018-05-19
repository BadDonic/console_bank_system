using System.IO;
using System.Text.RegularExpressions;
using console_bank_system.Decorator;

namespace console_bank_system.Validation
{
	public class PhoneValidation : AbstractValidation
	{
		public PhoneValidation(AbstractValidation next) : base(next)
		{
			Regex = new Regex(@"\d{3} (- )?\d{3} (- )?\d{2} (- )?\d{2}");
		}

		public override bool Validate(Account account)
		{
			if (!Regex.IsMatch(account.Phone))
				throw new InvalidDataException("Phone must be: \\d{3} (- )?\\d{3} (- )?\\d{2} (- )?\\d{2}");
			return Next?.Validate(account) ?? true;
		}
	}
}