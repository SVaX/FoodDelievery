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
	/// Interaction logic for ClientCurrentOrder.xaml
	/// </summary>
	public partial class ClientCurrentOrderWindow : Window
	{
		public static string userName;
		private FoodDelieveryContext db = new FoodDelieveryContext();
		private User currentUser;
		private Client currentClient;
		private Order currentOrder;
		public ClientCurrentOrderWindow(string login)
		{
			InitializeComponent();
			userName = login;
			userNameLabel.Content = userName;
			currentUser = (User)db.Users.Where(x => x.Login == userName).First();
			currentClient = (Client)db.Clients.Where(x => x.ClientId == currentUser.UserId).First();
			GetOrder();
			InitFoodListBox();
			InitOrderInfo();
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

		private void foodListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
		
		private void InitFoodListBox()
		{
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

		private void GetOrder()
		{
			foreach (var order in db.Orders)
			{
				if (order.IdClient == currentClient.ClientId && order.State == "In process")
				{
					currentOrder = order;
				}
			}
		}

		private void InitOrderInfo()
		{
			adressTextBox.Text = currentOrder.Adress;
			dateTextBox.Text = currentOrder.Date.ToShortDateString();
			stateTextBox.Text = currentOrder.State;
		}
	}
}
