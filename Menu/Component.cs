namespace console_bank_system.Menu
{
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