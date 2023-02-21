using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VPKS.DbEntities;

namespace VPKS
{
	/// <summary>
	/// Interaction logic for ClientMenuWindow.xaml
	/// </summary>
	public partial class ClientMenuWindow : Window
	{
		public static string userName;
		private Food chosenFood;
		private User currentUser;
		private Client currentClient;
		private FoodDelieveryContext db = new FoodDelieveryContext();
		public ClientMenuWindow(string login)
		{
			InitializeComponent();
			userName = login;
			userNameLabel.Content = userName;
			InitFoodListBox();
			currentUser = (User)db.Users.Where(x => x.Login == userName).First();
			currentClient = (Client)db.Clients.Where(x => x.ClientId == currentUser.UserId).First();
		}
		private void InitFoodListBox()
		{
			foodListBox.Items.Clear();
			foreach (var food in db.Foods)
			{
				foodListBox.Items.Add(food.Name);
			}
		}

		private void foodListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				chosenFood = (Food)db.Foods.Where(x => x.Name == foodListBox.SelectedItem.ToString()).First();
			}
			catch
			{
				return;
			}
			nameTextBox.Text = chosenFood.Name;
			costTextBox.Text = chosenFood.Cost.ToString();
			weightTextBox.Text = chosenFood.Weight.ToString();
			caloriesTextBox.Text = chosenFood.Calories.ToString();
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new LoginWindow();
			window.Show();
			this.Close();
		}

		private void cartButton_Click(object sender, RoutedEventArgs e)
		{
			bool orderExists = false;
			foreach (var order in db.Orders)
			{
				if (order.IdClient == currentClient.ClientId && order.State == "Created")
				{
					orderExists = true;
				}
			}
			if(!orderExists)
			{
				MessageBox.Show("Корзина пуста!");
				return;
			}
			var window = new ClientCartWindow(userName);
			window.Show();
			this.Close();
		}

		private void orderHistoryButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new ClientOrderHistoryWindow(userName);
			window.Show();
			this.Close();
		}

		private void currentOrderButton_Click(object sender, RoutedEventArgs e)
		{
			bool currentOrderExists = false;
			foreach (var order in db.Orders)
			{
				if (order.IdClient == currentClient.ClientId && order.State == "In process")
				{
					currentOrderExists = true;
				}
			}
			if (currentOrderExists)
			{
				var window = new ClientCurrentOrderWindow(userName);
				window.Show();
				this.Close();
			}
			else
			{
				MessageBox.Show("Нет текущих заказов!");
				return;
			}
		}

		private void toCartButton_Click(object sender, RoutedEventArgs e)
		{
			if (foodListBox.SelectedItem == null)
			{
				MessageBox.Show("Выберите блюдо!");
				return;
			}
			var userOrder = new Order();
			bool orderExists = false;
			foreach (var orders in db.Orders)
			{
				if (orders.IdClient == currentClient.ClientId && orders.State == "Created")
				{
					orderExists = true;
					userOrder = orders;
				}
			}
			foreach (var cart in db.Carts)
			{
				if (cart.IdFood == chosenFood.FoodId && userOrder.OrderId == cart.IdOrder)
				{
					cart.Quantity++;
					db.Carts.Entry(cart).State = EntityState.Modified;
					db.SaveChanges();
					MessageBox.Show("Блюдо успешно добавлено");
					return;

				}
			}
			var newOrder = userOrder;
			if (!orderExists)
			{
				newOrder = new Order()
				{
					IdClient = currentUser.UserId,
					Cost = 0,
					Date = DateTime.Now,
					Adress = currentClient.Adress,
					State = "Created"
				};
				db.Orders.Add(newOrder);
				db.SaveChanges();
			}
			var newCart = new Cart()
			{
				IdOrder = newOrder.OrderId,
				IdFood = chosenFood.FoodId,
				Quantity = 1
			};
			db.Carts.Add(newCart);
			db.SaveChanges();
			MessageBox.Show("Блюдо успешно добавлено");
		}
	}
}
