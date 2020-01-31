using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour NoAccess.xaml
    /// </summary>
    public partial class NoAccess : Window
    {
        public NoAccess()
        {
            InitializeComponent();
            AfficherImg();
        }

        private void AfficherImg()
        {     
            //le chemin de l'image (path) est différent selon les PC, il faudra mettre votre propre chemin de fichier
            string path = @"C:\Users\Administrateur\Source\Repos\TPPanier\TP_Panier\Image\chat1.jpg";
            //File.Copy(path, destinPath);
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri(path, UriKind.Absolute);          
            ImageBrush fond = new ImageBrush(imageSource);
            this.Background = fond;
            imageSource.EndInit();
        }
    }
}
