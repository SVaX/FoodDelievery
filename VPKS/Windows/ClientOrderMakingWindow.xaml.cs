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
	/// Interaction logic for ClientOrderMakingWindow.xaml
	/// </summary>
	public partial class ClientOrderMakingWindow : Window
	{
		public static string userName;
		private Food chosenFood;
		private User currentUser;
		private Client currentClient;
		private Order currentOrder;
		private FoodDelieveryContext db = new FoodDelieveryContext();
		public ClientOrderMakingWindow(string login)
		{
			InitializeComponent();
			userName = login;
			userNameLabel.Content = userName;
			currentUser = (User)db.Users.Where(x => x.Login == userName).First();
			currentClient = (Client)db.Clients.Where(x => x.ClientId == currentUser.UserId).First();
			GetOrder();
			InitOrderInfo();
			InitFoodListBox();
			orderCostLabel.Content = "На балансе: " + currentUser.Balance.ToString();
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

		private void cartButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new ClientCartWindow(userName);
			window.Show();
			this.Close();
		}

		/// <summary>
		/// Окончательное оформление заказа.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void makeOrderButton_Click(object sender, RoutedEventArgs e)
		{
			TextBox[] textBoxes = { adressTextBox, phoneNumberTextBox };
			foreach (var textBox in textBoxes)
			{
				if (String.IsNullOrEmpty(textBox.Text))
				{
					MessageBox.Show("Введите текст");
					return;
				}
			}

			if (currentOrder.Cost > currentUser.Balance)
			{
				MessageBox.Show("На счету недостаточно средств");
				return;
			}

			currentOrder.State = "In process";
			currentOrder.Adress = adressTextBox.Text;
			db.Orders.Entry(currentOrder).State = EntityState.Modified;
			db.SaveChanges();
			MessageBox.Show("Заказ успешно создан!");
			var window = new ClientCurrentOrderWindow(userName);
			window.Show();
			this.Close();
		}

		private void replenishButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new ClientBalanceWindow(userName);
			window.Show();
			this.Close();
		}

		private void InitOrderInfo()
		{
			adressTextBox.Text = currentClient.Adress;
			phoneNumberTextBox.Text = currentClient.PhoneNumber;
			costTextBox.Text = currentOrder.Cost.ToString();
		}
	}
}
