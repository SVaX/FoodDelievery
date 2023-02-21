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
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
	{
		private FoodDelieveryContext db = new FoodDelieveryContext();
		public RegistrationWindow()
		{
			InitializeComponent();
		}

		private void loginButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new LoginWindow();
			window.Show();
			this.Close();
		}

		private void registerButton_Click(object sender, RoutedEventArgs e)
		{
			TextBox[] textBoxes = { loginTextBox, passwordTextBox, emailTextBox, phoneTextBox};
			foreach (var textBox in textBoxes)
			{
				if (String.IsNullOrEmpty(textBox.Text))
				{
					MessageBox.Show("Введите текст");
					return;
				}
			}
			var newUser = new User()
			{
				Login = loginTextBox.Text,
				Email = emailTextBox.Text,
				Password = passwordTextBox.Text,
				PermissionLevel = "Client"
			};
			db.Users.Add(newUser);
			db.SaveChanges();
			var newClient = new Client()
			{
				ClientId = newUser.UserId,
				PhoneNumber = phoneTextBox.Text,
				Adress = ""
			};
			db.Clients.Add(newClient);
			db.SaveChanges();
			MessageBox.Show("Пользователь успешно зарегистрирован!");
			loginButton_Click(sender, e);
		}

		private void forgotButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new ForgotPasswordWindow();
			window.Show();
			this.Close();
		}
	}
}
