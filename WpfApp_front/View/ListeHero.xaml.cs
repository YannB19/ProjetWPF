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
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class ListeHero : Window
    {
        

        private void Button_Return(object sender, RoutedEventArgs e)
        {
            ListeFilm listeFilm = new ListeFilm();
            listeFilm.Show();
            this.Hide();
        }
        
        HttpClient client;
        public ListeHero()
        {
            client = new HttpClient();
            InitializeComponent();
        }
        



        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNom.Text) || String.IsNullOrEmpty(txtDesc.Text))
            {
                MessageBox.Show(this, "Le champ est vide", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                var Hero = new Hero()
                {
                    nom = txtNom.Text,
                    description = txtDesc.Text,
                };
                string message = string.Empty;

                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7246/api/Hero/InsertHero", Hero);

                    response.EnsureSuccessStatusCode();

                    message = await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
                this.GetHeros();
                MessageBox.Show(this, "Le Hero" + Hero.nom + "à bien été ajouté", "Message", MessageBoxButton.OK);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            this.GetHeros();
        }

        private async void GetHeros()
        {
            var response = await client.GetStringAsync("https://localhost:7246/api/Hero/GetHeros");
            var heros = JsonConvert.DeserializeObject<List<Hero>>(response);
            HeroList.DataContext = heros;

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            var hero = new Hero()
            {
                //id = Convert.ToInt32(txtId.Text),
                id = Int32.Parse(txtId.Text),
                nom = txtNom.Text,
                description = txtDesc.Text,
            };
            string message = string.Empty;
            this.UpdateHero(hero);
            this.GetHeros();
        }

        private async void UpdateHero(Hero hero)
        {
            await client.PutAsJsonAsync("https://localhost:7246/api/Hero/UpdateHero", hero);
        }

        private async void DeleteHero(int heroId)
        {
            await client.DeleteAsync("https://localhost:7246/api/Hero/DeleteHero/" + heroId);
        }


        private void BtnUpdateHero(object sender, RoutedEventArgs e)
        {
            Hero hero = ((FrameworkElement)sender).DataContext as Hero;
            txtId.Text = hero.id.ToString();
            txtNom.Text = hero.nom;
            txtDesc.Text = hero.description;
            this.UpdateHero(hero);
            this.GetHeros();
        }

        private void BtnDeleteHero(object sender, RoutedEventArgs e)
        {
            Hero hero = ((FrameworkElement)sender).DataContext as Hero;
            this.DeleteHero(hero.id);
            Trace.WriteLine(hero.id);
            MessageBox.Show(this, "Supprimé", "Message", MessageBoxButton.OK);
            this.GetHeros();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListeHero w2 = new ListeHero();
            w2.Show();
            this.Hide();
        }
    }
}
