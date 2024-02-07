using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Diabli1.Pages
{
    /// <summary>
    /// Логика взаимодействия для PropertyPage.xaml
    /// </summary>
    public partial class PropertyPage : Page
    {
        public PropertyPage()
        {
            InitializeComponent();
            if(App.Hero == "Warrior"){
                InfoTb.Text = "Health 2/1vit , 1/str\nMana 1/1 int            p.damage 1/str\narmor 1/dex          m.damage 0.2/int\nm.defense 05/int           crt.chanse 0.2/dex\ncrt.damage 0.1/dex";
            }
            else if(App.Hero == "Rogue")
            {
                InfoTb.Text = "Health 1.5/1vit 0.5/1str\nMana 1.2/int            p.damage 0.5/str+0.5dex\narmor 1.5/dex          m.damage 0.2/int\nm.defense 0.5/int            crt.chanse 0.2/dex\ncrt.damage 0.1/dex";
            }
            else if (App.Hero == "Wizard")
            {
                InfoTb.Text = "Health 1.4/Vit 0.2/str               Mana 1.5/int\np.damage 0.5/str           armor 1/dex\nm.damage 1/int            m.defense 1/int\ncrt.chanse O.2/dex         crt.damage 0.1/dex";
            }
        }
    }
}
