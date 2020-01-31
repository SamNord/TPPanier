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

namespace TP_Panier.Views
{
    /// <summary>
    /// Logique d'interaction pour NoAccess2.xaml
    /// </summary>
    public partial class NoAccess2 : Window
    {
        public NoAccess2()
        {
            InitializeComponent();
            AffImg();
        }

        private void AffImg()
        {
            string destinPath = @"c:\Users\PC_DellPro\Desktop\PROJET\Cours-session2\TPCSharp-Session2\PanierTP\TPPanier\TP_Panier\Image\chat2.jpg";
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri(destinPath, UriKind.Absolute);
            ImageBrush fond = new ImageBrush(imageSource);
            this.Background = fond;
            imageSource.EndInit();
        }

    }
}
