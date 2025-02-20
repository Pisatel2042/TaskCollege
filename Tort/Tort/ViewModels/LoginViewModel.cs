using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Input;

using Tmds.DBus.Protocol;
using Tort.Command;
using Tort.Views;
using Tort.Data;
using Avalonia.Controls;

namespace Tort.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
        private string _login { get; set; }
        public string LoginUser { get { return _login; } set { _login = value; OnPropertyChanged(); } }

        private string _password { get; set; }
        public string PasswordUser { get { return _password; } set { _password = value; OnPropertyChanged(); } }


        private string _errorMessage;
        public string ErrorMessage { get { return _errorMessage; } set { _errorMessage = value; OnPropertyChanged(); } }

        LoginDBContext dbContext { get; set; }

        public LoginViewModel()
        {
            string connectionString = "Host= localhost;Port=5432;Database=postgres;Username=postgres;Password=1111;";

            LoginCommand = new ReplayCommand(Login, CanLogin);
            CloseCommand = new ReplayCommand(Close, CanClose);


            dbContext = new LoginDBContext(connectionString);

        }



        #region Command
        public ICommand LoginCommand { get; set; }
        private bool CanLogin(object obj)
        {
            return true;
        }
        private void Login(object obj)
        {
            try
            {
                bool s = dbContext.Login(LoginUser, PasswordUser);
                if (s)
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                }
                else
                {
                    ErrorMessage = "Incorrect login or password entered";
                }
            }
            catch (Exception ex)
            {
                // Логируем ошибку
                Console.Error.WriteLine($"Ошибка при вызове Login: {ex}");
                // Обрабатываем ошибку (например, показываем сообщение пользователю)
                // MessageBox.Show($"Ошибка при входе: {ex.Message}");
            }


        }

        public ICommand CloseCommand { get; set; }
        private bool CanClose(object obj)
        {
            return true;
        }
        private void Close(object obj)
        {

        }
        #endregion
    }
}
