using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.libs 
{
	public class Application
	{
		private Login login;
		
		public Application()
		{
			User.Register(new User("Matheus Macedo", "matheus@email.com", "123456"));
			
			bool systemOpened = loginArea();
			if (systemOpened) 
			{
				byte option = 0;
				do 
				{
					Console.Clear();
					Console.WriteLine($"Management options");
					Console.WriteLine($"(1) Register a new user");
					Console.WriteLine($"(2) List users");
					Console.WriteLine($"(3) Delete some user");
					Console.WriteLine($"(4) Register a new brand");
					Console.WriteLine($"(5) List brands");
					Console.WriteLine($"(6) Remove brand");
					Console.WriteLine($"(7) Exit");
					Console.WriteLine($"");
					
					Console.Write($"Type here: ");
					option = byte.Parse(Console.ReadLine()); 
					
					switch(option) 
					{
						case 1:
							registerNewUserArea();
							break;
						case 2:
							listUsersArea();
							break;
						case 3:
							deleteUserArea();
							break;
						case 4:
							registerNewBrandArea();
							break;
						case 5:
							listBrandsArea();
							break;
						case 6:
							deleteBrandArea();
							break;
						case 7: 
							break;
						default:
							Console.WriteLine($"Invalid option!");
							break;
					}
					
					waitForAnyButton();
				}
				while (option != 7);
			}
		}
		
		private bool loginArea() 
		{
			Console.Write($"Email: ");
			string email = Console.ReadLine();
			
			Console.Write($"Password: ");
			string password = Console.ReadLine();
			
			login = new Login();
			
			string loginResponse = login.turnLoggedIn(email, password);
			Console.WriteLine(loginResponse);
			
			return login.IsLoggedIn;
		}
		
		private void registerNewUserArea() 
		{
			Console.Clear();
			
			Console.WriteLine($"Type the user information");

			Console.Write($"Name: ");
			string name = Console.ReadLine();

			Console.Write($"E-mail: ");
			string email = Console.ReadLine();

			Console.Write($"Password: ");
			string password = Console.ReadLine();
			
			User newUser = new User(name, email, password);
			User.Register(newUser);
		}
		
		private void listUsersArea() 
		{
			Console.Clear();
			
			Console.WriteLine($"");
			Console.WriteLine($"List of users");
			
			List<User> users = User.List();
			
			foreach (User user in users) 
			{
				Console.WriteLine($"{user.Id}: {user.Name} <{user.Email}>");
			}
		}
		
		private void deleteUserArea() 
		{
			Console.Clear();
			
			Console.WriteLine($"Delete user");
			Console.Write($"Type the user id: ");
			byte id = byte.Parse(Console.ReadLine());
			User.Delete(id);
		}
		
		private void registerNewBrandArea() 
		{
			Console.Clear();
			
			Console.WriteLine($"Type the brand information");

			Console.Write($"Name: ");
			string name = Console.ReadLine();
			
			Brand newBrand = new Brand(name);
			Brand.Registrate(newBrand);
		}
		
		private void listBrandsArea() 
		{
			Console.Clear();
			
			Console.WriteLine($"");
			Console.WriteLine($"List of brands");
			
			List<Brand> brands = Brand.List();
			
			foreach (Brand brand in brands) 
			{
				Console.WriteLine($"{brand.Id}: {brand.Name} ({brand.RegistrationDate})");
			}
		}
		
		private void deleteBrandArea() 
		{
			Console.Clear();
			
			Console.WriteLine($"Delete user");
			Console.Write($"Type the user id: ");
			byte id = byte.Parse(Console.ReadLine());
			Brand.Delete(id);
		}
		
		private void waitForAnyButton() 
		{
			Console.WriteLine($"");
			Console.WriteLine($"Type any key to continue...");
			Console.ReadLine();
		}
	}
}