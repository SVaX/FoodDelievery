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
	/// Interaction logic for ClientCartWindow.xaml
	/// </summary>
	public partial class ClientCartWindow : Window
	{
		public static string userName;
		private Food chosenFood;
		private User currentUser;
		private Client currentClient;
		private Order currentOrder;
		private FoodDelieveryContext db = new FoodDelieveryContext();
		public ClientCartWindow(string login)
		{
			InitializeComponent();
			userName = login;
			userNameLabel.Content = userName;
			currentUser = (User)db.Users.Where(x => x.Login == userName).First();
			currentClient = (Client)db.Clients.Where(x => x.ClientId == currentUser.UserId).First();
			GetOrder();
			InitFoodListBox();
			GetOrderCost();
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new LoginWindow();
			window.Show();
			this.Close();
		}

		private void menuButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new ClientMenuWindow(userName);
			window.Show();
			this.Close();
		}

		private void orderButton_Click(object sender, RoutedEventArgs e)
		{
			if (foodListBox.Items.Count == 0) 
			{
				MessageBox.Show("Сначала выберите блюда!");
				return;
			}
			var window = new ClientOrderMakingWindow(userName);
			window.Show();
			this.Close();
		}

		private void deleteButton_Click(object sender, RoutedEventArgs e)
		{
			if (foodListBox.SelectedItem == null)
			{
				MessageBox.Show("Выберите блюдо из корзины!");
				return;
			}

			foreach (var cart in db.Carts)
			{
				if (cart.IdOrder == currentOrder.OrderId)
				{
					if (chosenFood.FoodId == cart.IdFood)
					{
						foodListBox.Items.Remove(chosenFood.Name);
						db.Carts.Remove(cart);
						db.SaveChanges();
						MessageBox.Show("Блюдо успешно удалено из корзины!");
					}

				}
			}
			InitFoodListBox();
			GetOrderCost();
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
		private void InitFoodListBox()
		{
			foodListBox.Items.Clear();
			foreach (var cart in db.Carts)
			{
				if (cart.IdOrder == currentOrder.OrderId)
				{
					foreach (var food in db.Foods)
					{
						if (food.FoodId == cart.IdFood)
						{
							foodListBox.Items.Add(food.Name);
						}
					}
				}
			}
		}

		private void GetOrderCost()
		{
			currentOrder.Cost = 0;
			foreach (var cart in db.Carts)
			{
				if (cart.IdOrder == currentOrder.OrderId)
				{
					foreach (var food in db.Foods)
					{
						if (food.FoodId == cart.IdFood)
						{
							currentOrder.Cost += food.Cost;
						}
					}
				}
			}
			db.Orders.Entry(currentOrder).State = EntityState.Modified;
			db.SaveChanges();
			orderCostLabel.Content = "Сумма заказа: " + currentOrder.Cost.ToString();
		}

		private void GetOrder()
		{
			foreach (var order in db.Orders)
			{
				if (order.IdClient == currentClient.ClientId && order.State == "Created")
				{
					currentOrder = order;
				}
			}
		}
	}
}
