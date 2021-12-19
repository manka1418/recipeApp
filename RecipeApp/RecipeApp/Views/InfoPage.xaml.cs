using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();

            var htmlSource = new HtmlWebViewSource();

            htmlSource.Html = @"
                <html>
                    <body>
                        <h1>Információk az Appról:</h1>
                        <h2>Jelenlegi funkciók:</h2>
                        <p>Az <b>Új Receptre</b> kattintva be lehet írni új receptet és már el is menti.<br />
                           <br />
                           A <b>menüre</b> kattintva bejön a menüsor:<br />
                           <br />
                           <ins>Receptek:</ins> itt a már beírt receptek abc rendben jelennek meg.<br />
                           <ins>Keresés:</ins> itt a recept neve, a labelek/cimkék és a hozzávalók szerint lehet keresni.<br />
                           <ins>Információ:</ins> éppen itt vagyunk. Itt egy leírás van arról, hogyan is működik az app, mit tud eddig, illetve lejebb a folyamatban lévő, várható fejlesztésekról van info.<br />
                           <br />                        
                           A <b>recept adatlapjára</b> a receptre kattintva lehet eljutni.
                           Itt látszódik a recept pontos leírása, illetve itt van egy szerkesztés és egy törlés gomb.</p>

                        <h2>Várható fejlesztése:</h2>
                        <p>A késöbbiekben az adatokat <b>adatbázisban</b> tárolnánk majd, hogy egy esetleges telefonváltás alkalmával ne az adatokat kiexportálni.<br />
                           A felhasználók azonosítása E-maillel fog történni.<br />
                           <br />
                           A megadott link segítségével az oldalon lévő <b>adatok beolvasása</b> az Új Recept menü mezőibe, ezzel megkímélve a felhasználót a gépeléstől.</p>

                        <h2>Kontakt:</h2>
                        <p>manka1418@gmail.com</p>
                    </body>
                </html>";

            DescriptionWebView.Source = htmlSource;
        }
    }
}