namespace console_bank_system.Menu
{
	public abstract class Component
	{
		public string Name { get; private set; }
		public Access Access {get; set; }

		protected Component(string name, Access access)
		{
			Name = name;
			Access = access;
		}
		public abstract bool Execute();
	}
}