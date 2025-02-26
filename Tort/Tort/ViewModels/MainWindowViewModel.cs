using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using SkiaSharp;
using Tort.Data;
using Tort.Models;

namespace Tort.ViewModels
{
    public  class MainWindowViewModel : ViewModelBase
    {
        #region DataMeneger
        private int _id { get; set; }
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(); } }

        private string? _name { get; set; }
        public string? Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }

        private string? _firstName { get; set; }
        public string? FirstName { get { return _firstName; } set { _firstName = value; OnPropertyChanged(); } }

        private string? _lastName { get; set; }
        public string? LastName { get { return _lastName; } set { _lastName = value; OnPropertyChanged(); } }

        private string? _login { get; set; }
        public string? Login { get { return _login; } set { _login = value; OnPropertyChanged(); } }

        private int _role { get; set; }
        public int Role { get { return _role; } set { _role = value; OnPropertyChanged(); } }

        private string? _password { get; set; }
        public string? Password { get { return _password; } set { _password = value; OnPropertyChanged(); } }

        private string? _email { get; set; }
        public string? Email { get { return _email; } set { _email = value; OnPropertyChanged(); } }

        private User _selectUser { get; set; }
        public User SelectUser
        {
            get { return _selectUser; }
            set
            {
                _selectUser = value; OnPropertyChanged(); 
                if (_selectUser != null)
                {
                    Id = _selectUser.User_id;
                    Name = _selectUser.User_Name;
                    FirstName = _selectUser.User_FirstName;
                    LastName = _selectUser.User_LastName;
                    Login = _selectUser.User_Login;
                    Role = _selectUser.User_Role;
                    Password = _selectUser.Password;
                    Email = _selectUser.User_Email;
                }
            }
        }
        public ObservableCollection<User> Users { get; set; }
        public MainDBContext dBContext;
        #endregion

        public MainWindowViewModel()
        {
            string connectionstring = "Host= localhost;Port=5432;Database=postgres;Username=postgres;Password=1111;";
            Users = new ObservableCollection<User>();


           
            dBContext = new MainDBContext(connectionstring);
            LoadUser();
        }


        private void LoadUser()
        {
            Users.Clear();
            var task = dBContext.LoadDataGrid();
            foreach (var _task in task)
                Users.Add(_task);
        }



    }
}
