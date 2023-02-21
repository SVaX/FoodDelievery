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
	/// Interaction logic for ClientBalanceWindow.xaml
	/// </summary>
	public partial class ClientBalanceWindow : Window
	{
		public static string userName;
		private User currentUser;
		private FoodDelieveryContext db = new FoodDelieveryContext();
		public ClientBalanceWindow(string login)
		{
			InitializeComponent();
			userName = login;
			userNameLabel.Content = userName;
			currentUser = (User)db.Users.Where(x => x.Login == userName).First();
			balanceLabel.Content = "На балансе: " + currentUser.Balance.ToString();
		}

		private void menuButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new ClientMenuWindow(userName);
			window.Show();
			this.Close();
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new LoginWindow();
			window.Show();
			this.Close();
		}

		private void replenishButton_Click(object sender, RoutedEventArgs e)
		{
			if (String.IsNullOrEmpty(replenishTextBox.Text) && int.TryParse(replenishTextBox.Text, out _))
			{
				MessageBox.Show("Введите сколько начислить на баланс");
				return;
			}
			var money = int.Parse(replenishTextBox.Text);
			currentUser.Balance += money;
			db.Users.Entry(currentUser).State = EntityState.Modified;
			db.SaveChanges();
			MessageBox.Show("Деньги успешно начислены на счет!");
			replenishTextBox.Clear();
			balanceLabel.Content = "На балансе: " + currentUser.Balance.ToString();
		}

		private void cartButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new ClientCartWindow(userName);
			window.Show();
			this.Close();
		}

		private void orderButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new ClientOrderMakingWindow(userName);
			window.Show();
			this.Close();
		}
	}
}
