using System;
using System.Collections.Generic;

namespace console_bank_system.Menu
{
	public class Composite : Component
	{
		private List<Component> children = new List<Component>();
		public Bank Bank { get; set; }
		public Component Parent { get; set; }

		public Composite(string name, Bank bank, Component component = null, Access access = Access.Default) : base(name,
			access)
		{
			Bank = bank;
			Parent = component;
		}

		public void AddChild(Component component)
		{
			if (component.Access == Access.Default) component.Access = Access;
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
				Console.WriteLine($"\t\t{Bank.Account} ");
				Console.WriteLine($"\t\t{Name} ");
				Console.WriteLine(Bank.IsLogin
					? $"\t{Bank.Account.Username} - " + Bank.Account.State.Amount + Bank.Account.State.Sign
					: "");
				Console.WriteLine("-----------------------------------------------");
				List<Component> activeList = new List<Component>();
				for (int i = 0; i < children.Count; i++)
					if (!(Bank.IsLogin && children[i].Access == Access.OnlyGuest ||
					      !Bank.IsLogin && children[i].Access == Access.User))
					{
						activeList.Add(children[i]);
						Console.WriteLine($"  {activeList.Count}. {children[i].Name}");
					}

				if (Parent != null) Console.WriteLine("  'b'. Back to prev Menu");
				Console.WriteLine("  'q'. Exit");
				Console.WriteLine("-----------------------------------------------");
				Console.Write("\t>> Select Command: ");
				char input = Char.ToLower(Console.ReadKey().KeyChar);
				if ("bq".Contains(input.ToString()))
					return input == 'b';
				int command = Char.IsDigit(input) ? (int) Char.GetNumericValue(input) : 0;
				if (command > 0 && command <= activeList.Count)
					result = activeList[command - 1].Execute();
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