using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp_front.Model;
using Newtonsoft.Json;
using System.Diagnostics;


namespace WpfApp_front.View
{
    /// <summary>
    /// Logique d'interaction pour ListeFilm.xaml
    /// </summary>
    public partial class ListeFilm : Window
    {
        HttpClient client;
        public ListeFilm()
        {
            client = new HttpClient();
            InitializeComponent();
        }




        private async void BtnAjouterFilm(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(txtNom.Text) || String.IsNullOrEmpty(txtDesc.Text))
            {
                MessageBox.Show(this, "Le champ est vide", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                var Film = new Film()
                {
                    nom = txtNom.Text,
                    description = txtDesc.Text,
                };
                string message = string.Empty;

                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7246/api/Film/InsertFilm", Film);
                    
                    response.EnsureSuccessStatusCode();

                    message = await response.Content.ReadAsStringAsync();  
                } catch(Exception ex) 
                {
                    message = ex.Message;
                }
                this.GetFilms();
                MessageBox.Show(this, "Le film " + Film.nom + " à bien été ajouté", "Message", MessageBoxButton.OK);
            }
        }

        private void BtnChargerListe(object sender, RoutedEventArgs e)
        {
           
            this.GetFilms();
        }

        private async void GetFilms()
        {
            var response = await client.GetStringAsync("https://localhost:7246/api/Film/GetFilms");
            var films = JsonConvert.DeserializeObject<List<Film>>(response);
            FilmList.DataContext = films;

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            var Film = new Film()
            {
                id = Int32.Parse(txtId.Text),
                nom = txtNom.Text,
                description = txtDesc.Text,
            };
            string message = string.Empty;
            this.UpdateFilm(Film);
            this.GetFilms();
        }

        private async void UpdateFilm(Film film)
        {
            await client.PutAsJsonAsync("https://localhost:7246/api/Film/UpdateFilm", film);
        }

        private async void DeleteFilm(int filmId)
        {
            await client.DeleteAsync("https://localhost:7246/api/Film/DeleteFilm/" + filmId);
        }


        private void BtnUpdateFilm(object sender, RoutedEventArgs e)
        {
            Film film = ((FrameworkElement)sender).DataContext as Film;
            txtId.Text = film.id.ToString();
            txtNom.Text = film.nom;
            txtDesc.Text = film.description;  
            this.UpdateFilm(film);
            this.GetFilms();
        }

        private void BtnDeleteFilm(object sender, RoutedEventArgs e)
        {
            Film film = ((FrameworkElement)sender).DataContext as Film;
            this.DeleteFilm(film.id);
            MessageBox.Show(this, "Supprimé", "Message", MessageBoxButton.OK);
            this.GetFilms();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListeHero w2 = new ListeHero();
            w2.Show();
            this.Hide();
        }
    }
}
