using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Оформление_заказов.MySQL;
using Оформление_заказов.Tool;

namespace Оформление_заказов.ViewModel
{
     class OptionVM
    {
		PasswordBox passwordBox;

		public string Server { get; set; }
		public string User { get; set; }
		public string DB { get; set; }

		public Command TestConnection { get; set; }
		public Command SaveSettings { get; set; }

		public OptionVM(PasswordBox passwordBox)
		{
			this.passwordBox = passwordBox;

			Server = Properties.Settings.Default.server;
			User = Properties.Settings.Default.user;
			DB = Properties.Settings.Default.db;
			passwordBox.Password = Properties.Settings.Default.pass;

			TestConnection = new Command(() => {
				var db = MySqlDB.GetDB();
				db.InitConnection(Server, User, DB, passwordBox.Password);
				if (db.OpenConnection())
				{
					db.CloseConnection();
					System.Windows.MessageBox.Show("Соединение успешно!");
				}
			});

			SaveSettings = new Command(() => {
				Properties.Settings.Default.user = User;
				Properties.Settings.Default.db = DB;
				Properties.Settings.Default.pass = passwordBox.Password;
				Properties.Settings.Default.server = Server;
				Properties.Settings.Default.Save();
				System.Windows.MessageBox.Show("Данные сохранены!");
			});
		}
	}
}
