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
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;
using VPKS.DbEntities;

namespace VPKS
{
    /// <summary>
    /// Interaction logic for ForgotPasswordWindow.xaml
    /// </summary>
    public partial class ForgotPasswordWindow : Window
	{
		/// <summary>
		/// Код восстановления.
		/// </summary>
		private int _restorationCode;

		/// <summary>
		/// Код операции.
		/// </summary>
		private int _operationCode = 0;

		/// <summary>
		/// Существование пользователя.
		/// </summary>
		private bool _userExists = false;
		
		/// <summary>
		/// Пользователь.
		/// </summary>
		private User _user;

		/// <summary>
		/// Инициализация окна.
		/// </summary>
		public ForgotPasswordWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Отправка кода на почту.
		/// </summary>
		private void SendCode()
		{
			MailAddress from = new MailAddress("dotacourierentertainment@mail.ru", "Bloodseeker");
			MailAddress to = new MailAddress(emailTextBox.Text);
			MailMessage m = new MailMessage(from, to);
			m.Subject = "Use code to restore your password";

			if (_userExists)
			{
				var rand = new Random();
				_restorationCode = rand.Next(900000, 1000000);
				m.Body = "<h1>Code to new password: " + _restorationCode + "</h1>";
			}
			else
			{
				MessageBox.Show("Пользователя с такой почтой не существует.");
				return;
			}

			m.IsBodyHtml = true;
			SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
			smtp.Credentials = new NetworkCredential("dotacourierentertainment@mail.ru", "7XkEWMDBex6F2dxshKcX");
			smtp.EnableSsl = true;
			smtp.Send(m);
		}

		/// <summary>
		/// Обработчик кнопки отправки.
		/// </summary>
		private void sendButton_Click(object sender, RoutedEventArgs e)
		{
			#region Валидация.
			if (_operationCode == 0 && String.IsNullOrEmpty(emailTextBox.Text))
			{
				MessageBox.Show("Введите почту.");
				return;
			}

			if (_operationCode == 1 && String.IsNullOrEmpty(codeTextBox.Text))
			{
				MessageBox.Show("Введите код");
				return;
			}

			if (_operationCode == 2 && String.IsNullOrEmpty(newPasswordTextBox.Text))
			{
				MessageBox.Show("Введите новый пароль");
				return;
			}
			#endregion
			using (var db = new FoodDelieveryContext())
			{
				foreach (User user in db.Users)
				{
					if (emailTextBox.Text == user.Email)
					{
						_userExists = true;
						_user = user;
					}
				}

				if (_operationCode == 0)
				{
					try
					{
						SendCode();
						emailTextBox.IsEnabled = false;
						sendButton.Content = "Ввести код";
						codeLabel.Visibility = Visibility.Visible;
						codeBorder.Visibility = Visibility.Visible;
						_operationCode = 1;
					}
					catch
					{
						MessageBox.Show("Что-то пошло не так");
						return;
					}
				}
				else if (_operationCode == 1)
				{
					if (_restorationCode == int.Parse(codeTextBox.Text))
					{
						codeTextBox.IsEnabled = false;
						sendButton.Content = "Подтвердить пароль";
						newPassLabel.Visibility = Visibility.Visible;
						newPasswordBorder.Visibility = Visibility.Visible;
						_operationCode = 2;
					}
				}
				else if (_operationCode == 2)
				{
					_user.Password = newPasswordTextBox.Text;
					db.Entry(_user).State = EntityState.Modified;
					db.SaveChanges();
					MessageBox.Show("Пароль успешно изменен");
					loginButton_Click(sender, e);
				}
			}
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
		/// Переход к окну входа.
		/// </summary>
		private void loginButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new LoginWindow();
			window.Show();
			this.Close();
		}
	}
}
