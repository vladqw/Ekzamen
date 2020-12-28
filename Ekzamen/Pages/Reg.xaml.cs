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

namespace Ekzamen.Pages
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (txbPassword2.Password == txbPassword.Password)
            {
                {
                    int pass = txbPassword.Password.GetHashCode();
                    User NewUser = new User()
                    {
                        Login = txbLogin.Text,
                        Password = pass,
                        idRole = 3,

                    };
                    BaseConnect.BaseModel.User.Add(NewUser);
                    BaseConnect.BaseModel.SaveChanges();
                    FrameLoad.FrameMain.Navigate(new PageLogin());
                    MessageBox.Show("Вы успешно зарегистрировались, войдите используя свой логин и пароль");
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
            }
        }
    }
}
