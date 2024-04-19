using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
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




        private async void Button_Click_1(object sender, RoutedEventArgs e)
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
                    HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7020/api/Film/", Film);
                    
                    response.EnsureSuccessStatusCode();

                    message = await response.Content.ReadAsStringAsync();  
                } catch(Exception ex) 
                {
                    message = ex.Message;
                }

                MessageBox.Show(this, "Le film " + message.Split(",")[1].Split(":")[1].Replace('"', ' ') + " à bien été ajouté" , "Message", MessageBoxButton.OK);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            this.GetFilms();
        }

        private async void GetFilms()
        {
            var response = await client.GetStringAsync("https://localhost:7020/api/Film/GetAll");
            var films = JsonConvert.DeserializeObject<List<Film>>(response);
            FilmList.DataContext = films;

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            var Film = new Film()
            {
                filmId = Convert.ToInt32(txtId.Text),
                nom = txtNom.Text,
                description = txtDesc.Text,
            };
            string message = string.Empty;
            this.UpdateFilm(Film);
        }

        private async void UpdateFilm(Film film)
        {
            await client.PutAsJsonAsync("https://localhost:7020/api/Film/" + film.filmId, film);
        }

        private async void DeleteFilm(int filmId)
        {
            await client.DeleteAsync("https://localhost:7020/api/Film/" + filmId);
        }


        private void BtnUpdateFilm(object sender, RoutedEventArgs e)
        {
            Film film = ((FrameworkElement)sender).DataContext as Film;
            txtId.Text = film.filmId.ToString();
            txtNom.Text = film.nom;
            txtDesc.Text = film.description;  
            this.UpdateFilm(film);
        }

        private void BtnDeleteFilm(object sender, RoutedEventArgs e)
        {
            Film film = ((FrameworkElement)sender).DataContext as Film;
            this.DeleteFilm(film.filmId);
            MessageBox.Show(this, "Supprimé", "Message", MessageBoxButton.OK);
            this.GetFilms();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.Show();
            this.Hide();
        }
    }
}
