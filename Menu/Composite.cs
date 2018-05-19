using System;
using System.Collections.Generic;

namespace console_bank_system.Menu
{
	public class Composite : Component
	{
		private List<Component> children = new List<Component>();

		public Composite(string name, Component component, Bank bank) : base(name,component, bank)
		{
		}

		public void AddChild(Component component)
		{
			children.Add(component);
		}

		public void RemoveChild(Component component)
		{
			children.Remove(component);
		}

		public override bool Execute()
		{
			bool result = true;
			while (result)
			{
				Console.Clear();
				Console.WriteLine("-----------------------------------------------");
				Console.WriteLine($"\t\t{Name} " + ((Bank.IsLogin) ? Bank.Account.State.Amount + Bank.Account.State.Sign : ""));
				Console.WriteLine("-----------------------------------------------");
				for (int i = 0; i < children.Count; i++)
					Console.WriteLine($"  {i + 1}. {children[i].Name}");
				if (Parent != null) Console.WriteLine("  'b'. Back to prev Menu");
				Console.WriteLine("  'q'. Exit");
				Console.WriteLine("-----------------------------------------------");
				Console.Write("\t>> Select Command: ");
				char input = Char.ToLower(Console.ReadKey().KeyChar);
				if ("bq".Contains(input.ToString()))
					return input == 'b';
				int command = Char.IsDigit(input) ? (int) Char.GetNumericValue(input) : 0;
				if (command != 0 && children[command - 1] != null)
					result = children[command - 1].Execute();
				else
				{
					Console.WriteLine("\n-----------------------------------------------");
					Console.WriteLine("  >> Incorrect Command. Enter some button to continue <<");
					Console.WriteLine("-----------------------------------------------");
					Console.ReadKey();
				}
			}

			return false;
		}
	}
}