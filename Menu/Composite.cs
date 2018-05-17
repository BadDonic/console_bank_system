using System;
using System.Collections.Generic;

namespace console_bank_system
{
	public class Composite : Component
	{
		private List<Component> children = new List<Component>();

		public Composite(string name, bool hasParent = true) : base(name, hasParent)
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
				Console.WriteLine($"\t{Name}\t");
				Console.WriteLine("-----------------------------------------------");
				for (int i = 0; i < children.Count; i++)
					Console.WriteLine($"  {i + 1}. {children[i].Name}");
				if (HasParent) Console.WriteLine("  'b'. Back to prev Menu");
				Console.WriteLine("  'q'. Exit");
				Console.WriteLine("-----------------------------------------------");
				Console.Write("\t>> Select Command: ");
				char input = Char.ToLower(Console.ReadKey().KeyChar);
				if ("bq".Contains(input.ToString()))
					return input == 'b';
				int command = Char.IsDigit(input) ? (int) Char.GetNumericValue(input) : 0;
				if (command != 0 && children[command] != null)
					result = children[command].Execute();
				else
				{
					Console.WriteLine("-----------------------------------------------");
					Console.WriteLine("\t>> Incorrect Command. Enter some button to continue <<");
					Console.WriteLine("-----------------------------------------------");
					Console.ReadKey();
				}
			}

			return false;
		}
	}

	public class Button : Component
	{
		public Button(string name) : base(name)
		{
		}

		public override bool Execute()
		{
			return false;
		}
	}

	public abstract class Component
	{
		public string Name { get; protected set; }
		protected bool HasParent { get; set; }

		protected Component(string name, bool hasParent = true)
		{
			Name = name;
			HasParent = hasParent;
		}

		public abstract bool Execute();
	}
}