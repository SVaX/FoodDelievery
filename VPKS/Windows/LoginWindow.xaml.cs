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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VPKS.DbEntities;

namespace VPKS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
	{
		/// <summary>
		/// Инициализация окна.
		/// </summary>
		public LoginWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Переход к окну регистрации.
		/// </summary>
		private void registerButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new RegistrationWindow();
			window.Show();
			this.Close();
		}

		/// <summary>
		/// Переход к окну восстановления пароля.
		/// </summary>
		private void forgotButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new ForgotPasswordWindow();
			window.Show();
			this.Close();
		}

		/// <summary>
		/// Авторизация в системе.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void loginButton_Click(object sender, RoutedEventArgs e)
		{
			bool userExists = false;
			#region Валидация.
			if (String.IsNullOrEmpty(loginTextBox.Text))
			{
				MessageBox.Show("Логин нужно заполнить");
				return;
			}

			if(String.IsNullOrEmpty(passwordTextBox.Text)) 
			{
				MessageBox.Show("Пароль нужно заполнить");
				return;
			}
			#endregion

			using (FoodDelieveryContext db = new FoodDelieveryContext())
			{
				foreach(User user in db.Users)
				{
					if (user.Login == loginTextBox.Text)
					{
						if (user.Password == passwordTextBox.Text)
						{
							MessageBox.Show("Успешная авторизация");
							userExists = true;

							if (user.PermissionLevel == "Client")
							{
								var window = new ClientMenuWindow(user.Login);
								window.Show();
								this.Close();
							}

							if (user.PermissionLevel == "Admin")
							{
								var window = new AdminWindow(user.Login);
								window.Show();
								this.Close();
							}
						}
						else
						{
							MessageBox.Show("Пароль был неверным");
							return;
						}
					}
				}

				if (!userExists)
				{
					MessageBox.Show("Пользователя с таким логином не существует");
					return;
				}
			}
		}
	}
}
