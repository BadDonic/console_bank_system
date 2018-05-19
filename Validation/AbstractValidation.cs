using System.Text.RegularExpressions;
using console_bank_system.Decorator;

namespace console_bank_system.Validation
{
	public abstract class AbstractValidation
	{
		public AbstractValidation Next { get; set; }
		protected Regex Regex { get; set; }

		protected AbstractValidation(AbstractValidation next)
		{
			Next = next;
		}

		public abstract bool Validate(Account account);
	}
}