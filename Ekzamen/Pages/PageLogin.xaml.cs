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
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void btnVhod_Click(object sender, RoutedEventArgs e)
        {
            int pass = txbPassword.Password.GetHashCode();
            User UserObject = BaseConnect.BaseModel.User.FirstOrDefault(u => u.Login == txbLogin.Text && u.Password == pass);
            if (UserObject == null)
            {
                MessageBox.Show("Такого нето пользователя");
            }
            else
            {
                switch (UserObject.idRole)
                {
                    case 1:
                        MessageBox.Show("Вы вошли, как администратор");
                        FrameLoad.FrameMain.Navigate(new Admin());
                        break;
                    case 2:
                        MessageBox.Show("Вы вошли, как модератор");
                        FrameLoad.FrameMain.Navigate(new Moder());
                        break;
                    case 3:
                        MessageBox.Show("Вы вошли, как пользователь");
                        FrameLoad.FrameMain.Navigate(new Polz());
                        break;
                    default:
                        MessageBox.Show("Всё");
                        break;
                }
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.FrameMain.Navigate(new Reg());
        }
    }
}
