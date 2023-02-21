using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Microsoft.EntityFrameworkCore;
using VPKS.DbEntities;

namespace VPKS
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
	{
		public static string userName;
		private static FoodDelieveryContext db = new FoodDelieveryContext();
		private Food chosenFood;
		private User chosenUser;
		public AdminWindow(string login)
		{
			InitializeComponent();
			userName = login;
			adminNameLabel.Content = userName;
			InitFoodListBox();
			InitUserListBox();
			InitRoleComboBox();
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new LoginWindow();
			window.Show();
			this.Close();
		}

		private void saveButton_Click(object sender, RoutedEventArgs e)
		{
			TextBox[] textBoxes = { nameTextBox, caloriesTextBox, weightTextBox, costTextBox };
			foreach (var textBox in textBoxes)
			{
				if (String.IsNullOrEmpty(textBox.Text))
				{
					MessageBox.Show("Введите текст");
					return;
				}
			}
			if (chosenFood == null)
			{
				MessageBox.Show("Выберите блюдо!");
				return;
			}
			chosenFood.Name = nameTextBox.Text;
			chosenFood.Cost = int.Parse(costTextBox.Text);
			chosenFood.Weight = int.Parse(weightTextBox.Text);
			chosenFood.Calories = int.Parse(caloriesTextBox.Text);
			db.Foods.Entry(chosenFood).State = EntityState.Modified;
			db.SaveChanges();
			MessageBox.Show("Блюдо успешно изменено!");
			InitFoodListBox();
			ClearTextBoxes(textBoxes);
		}

		private void addButton_Click(object sender, RoutedEventArgs e)
		{
			TextBox[] textBoxes = { nameTextBox, caloriesTextBox, weightTextBox, costTextBox };
			foreach (var textBox in textBoxes)
			{
				if (String.IsNullOrEmpty(textBox.Text))
				{
					MessageBox.Show("Введите текст");
					return;
				}
			}
			var newFood = new Food() 
			{	Name = nameTextBox.Text, 
				Calories = int.Parse(caloriesTextBox.Text), 
				Cost = int.Parse(costTextBox.Text),
				Weight = int.Parse(weightTextBox.Text)
			};
			db.Foods.Add(newFood);
			db.SaveChanges();
			MessageBox.Show("Блюдо успешно добавлено!");
			InitFoodListBox();
			ClearTextBoxes(textBoxes);
		}

		private void deleteButton_Click(object sender, RoutedEventArgs e)
		{
			TextBox[] textBoxes = { nameTextBox, caloriesTextBox, weightTextBox, costTextBox };
			foreach (var textBox in textBoxes)
			{
				if (String.IsNullOrEmpty(textBox.Text))
				{
					MessageBox.Show("Введите текст");
					return;
				}
			}

			if (chosenFood == null)
			{
				MessageBox.Show("Выберите блюдо из списка!");
				return;
			}

			db.Foods.Remove(chosenFood);
			db.SaveChanges();
			MessageBox.Show("Блюдо успешно удалено!");
			InitFoodListBox();
			ClearTextBoxes(textBoxes);
		}

		private void saveUserButton_Click(object sender, RoutedEventArgs e)
		{
			TextBox[] textBoxes = { loginTextBox, emailTextBox };
			foreach (var textBox in textBoxes)
			{
				if (String.IsNullOrEmpty(textBox.Text))
				{
					MessageBox.Show("Введите текст");
					return;
				}
			}
			if (roleComboBox.SelectedItem == null)
			{
				MessageBox.Show("Выберите что-то из списка!");
				return;
			}
			chosenUser.Login = loginTextBox.Text;
			chosenUser.Email = emailTextBox.Text;
			chosenUser.PermissionLevel = roleComboBox.SelectedItem.ToString();
			if (chosenUser.PermissionLevel == "Admin")
			{
				db.Clients.Remove((Client)db.Clients.Where(x => x.ClientId == chosenUser.UserId).First());
				db.SaveChanges();
			}
			else if (chosenUser.PermissionLevel == "Client")
			{
				db.Clients.Add(new Client
				{
					ClientId = chosenUser.UserId,
					PhoneNumber = "",
					Adress = ""
				});
				db.SaveChanges();
			}
			db.Users.Entry(chosenUser).State = EntityState.Modified;
			db.SaveChanges();
			MessageBox.Show("Пользователь успешно изменен!");
			InitUserListBox();
			ClearTextBoxes(textBoxes);
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
		private void userListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				chosenUser = (User)db.Users.Where(x => x.Login == userListBox.SelectedItem.ToString()).First();
			}
			catch
			{
				return;
			}
			loginTextBox.Text = chosenUser.Login;
			emailTextBox.Text = chosenUser.Email;
			roleComboBox.SelectedItem = chosenUser.PermissionLevel;
		}

		private void ClearTextBoxes(TextBox[] textBoxes)
		{
			foreach (TextBox textBox in textBoxes)
			{
				textBox.Clear();
			}
		}

		private void InitFoodListBox()
		{
			foodListBox.Items.Clear();
			foreach (var food in db.Foods)
			{
				foodListBox.Items.Add(food.Name);
			}
		}

		private void InitUserListBox()
		{
			userListBox.Items.Clear();
			foreach (var user in db.Users)
			{
				userListBox.Items.Add(user.Login);
			}
		}

		private void InitRoleComboBox()
		{
			roleComboBox.Items.Add("Admin");
			roleComboBox.Items.Add("Client");
		}
	}
}
