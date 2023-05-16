namespace ProductManagement.libs 
{
	public class Brand 
	{
		public int Id { get; private set; } 
		public string Name { get; private set; }
		public DateTime RegistrationDate { get; private set; }
		
		private static LinkedList<Brand> brands = new LinkedList<Brand>();

		public Brand(int id, string name) 
		{
			this.Id = id;
			this.Name = name;
			this.RegistrationDate = DateTime.Now;
		}
		
		public static string Registrate(Brand brand) 
		{
			brands.AddLast(brand);
			return $"The brand ${brand.Name} has been registrated!";
		} 
		
		public static List<Brand> List() 
		{
			return brands.ToList();
		}
		
		public string Delete(Brand brand) 
		{
			brands.Remove(brand);
			return $"The brand ${brand.Name} has been deleted!";
		}
	}
}