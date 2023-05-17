namespace ProductManagement.libs 
{
	public class Product
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public float Price { get; private set; }
		public DateTime RegistrationDate { get; private set; }
		public Brand Brand { get; private set; }
		public User UserWhoRegistered { get; private set; }
		
		private static LinkedList<Product> products = new LinkedList<Product>();

		public Product(string name, float price, Brand brand, User userWhoRegistered) 
		{
			this.Id = products.Count == 0 ? 0 : products.Last().Id + 1;
			this.Name = name;
			this.Price = price;
			this.RegistrationDate = DateTime.Now;
			this.Brand = brand;
			this.UserWhoRegistered = userWhoRegistered;
		}
		
		public static string Registrate(Product product) 
		{
			products.AddLast(product);
			return $"The brand ${product.Name} has been registrated!";
		} 
		
		public static List<Product> List() 
		{
			return products.ToList();
		}
		
		public string Delete(byte id) 
		{
			Product product = products.ToList().Find(product => product.Id == id);
			
			if (product != null) 
			{
				products.Remove(product);
			}
			
			return $"The brand ${product.Name} has been deleted!";
		}
	}
}