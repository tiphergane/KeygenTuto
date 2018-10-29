using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace KeygenTuto
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Keygen for WinBlahBlah";
            this.IDC_Name.TextAlignment = TextAlignment.Center;
            this.IDC_Serial.TextAlignment = TextAlignment.Center;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
        }
        #region Bouton
        private void IDC_Quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IDC_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ceci est un About", "About meoow");
        }
        #endregion

        private void IDC_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IDC_Name.GetLineLength(0) > 3 && IDC_Name.GetLineLength(0) < 28)
            {
                GenSerial();
            }
            else
            {
                IDC_Serial.Text = "Vous devez être entre 3 et 28 caractères";
            }
        }

        private void GenSerial()
        {
            // Pour encoder en UTF8 notre chaine de caractère
            byte[] Name = Encoding.Default.GetBytes(IDC_Name.Text);
            string Nickname = Encoding.UTF8.GetString(Name);

            string Serial_debut = null;
            string Serial_fin = null;
            int Serial = 0;
            char[] asciiBytes = Nickname.ToCharArray();
            byte[] array = {0x0B, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00,
                            0x11, 0x00, 0x00, 0x00, 0x0D, 0x00, 0x00, 0x00,
                            0x0D, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00,
                            0x05, 0x00, 0x00, 0x00, 0x0D, 0x00, 0x00, 0x00,
                            0x10, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00,
                            0x0B, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00,
                            0x0E, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00,
                            0x04, 0x00, 0x00, 0x00, 0x0B, 0x00, 0x00, 0x00,
                            0x06, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00,
                            0x0E, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00,
                            0x0B, 0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00,
                            0x0D, 0x00, 0x00, 0x00, 0x0B, 0x00, 0x00, 0x00,
                            0x0A, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00,
                            0x0A, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00,
                            0x10, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00,
                            0x04, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00,
                            0x0A, 0x00, 0x00, 0x00, 0x0D, 0x00, 0x00, 0x00,
                            0x10, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00,
                            0x0A, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00,
                            0x10};

            //Génération du début du serial
            for (int i = 3; i < IDC_Name.GetLineLength(0); ++i)
            {
                Serial += asciiBytes[i] * array[(i - 3) * 4];
                Serial_debut = Serial.ToString();
            }

            Serial = 0;

            //Génération du début du serial
            for (int i = 3; i < IDC_Name.GetLineLength(0); ++i)
            {
                Serial += asciiBytes[i] * asciiBytes[i-1] * array[(i - 3) * 4];
                Serial_fin = Serial.ToString();
            }

            //Affichage du Serial
            IDC_Serial.Text = String.Format("{0}-{1}", Serial_debut, Serial_fin);
        }
    }
}
