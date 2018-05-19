namespace console_bank_system.Menu
{
	public abstract class Component
	{
		public string Name { get; protected set; }
		public Component Parent { get; set; }
		public Bank Bank { get; set; }

		protected Component(string name, Component component, Bank bank)
		{
			Name = name;
			Parent = component;
			Bank = bank;
		}
		public abstract bool Execute();
	}
}