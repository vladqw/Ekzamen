using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для PageUserList.xaml
    /// </summary>
    public partial class PageUserList : Page
    {
        List<User> Luser = BaseConnect.BaseModel.User.ToList();
        public PageUserList()
        {
            InitializeComponent();
            DgUser.ItemsSource = Luser;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            List<User> LuserDb = BaseConnect.BaseModel.User.ToList();
            var Luser1 = LuserDb.Except(Luser);
            foreach (User u in Luser1)
            {
                BaseConnect.BaseModel.User.Remove(u);
            }

            foreach (User u in Luser)
            {
                BaseConnect.BaseModel.User.AddOrUpdate(u);
            }

            BaseConnect.BaseModel.SaveChanges();
            MessageBox.Show("Изменения успешны!");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.FrameMain.Navigate(new Pages.PageLogin());
        }

        private void Preobr_Click(object sender, RoutedEventArgs e)
        {
            int pass = Hash.Text.GetHashCode();
            Hash1.Text = Convert.ToString(pass);
        }
    }
}
