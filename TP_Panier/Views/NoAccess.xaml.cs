﻿using System;
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
            string destinPath = @"c:\Users\PC_DellPro\Desktop\PROJET\Cours-session2\TPCSharp-Session2\PanierTP\TPPanier\TP_Panier\Image\chat1.jpg";
            //File.Copy(path, destinPath);
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri(destinPath, UriKind.Absolute);          
            ImageBrush fond = new ImageBrush(imageSource);
            this.Background = fond;
            imageSource.EndInit();
        }
    }
}
