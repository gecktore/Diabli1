using Diabli1.Classes;
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
        private UniversalClass selectedClass;
        private ClassesInfo info = new ClassesInfo();
        int currentPoint;

        public PropertyPage()
        {

                InitializeComponent();
            if(App.Hero == "Warrior"){
                //InfoTb.Text = "Health 2/1vit , 1/str\nMana 1/1 int            p.damage 1/str\narmor 1/dex          m.damage 0.2/int\nm.defense 05/int           crt.chanse 0.2/dex\ncrt.damage 0.1/dex";
                Hero.Source = new BitmapImage(new Uri(@"\Resources\bull.png", UriKind.Relative));
                    selectedClass = new UniversalClass("Warrior", App.Name, 30, 200, 15, 80, 10, 50, 25, 100); ;
            }
            else if(App.Hero == "Rogue")
            {
               // InfoTb.Text = "Health 1.5/1vit 0.5/1str\nMana 1.2/int            p.damage 0.5/str+0.5dex\narmor 1.5/dex          m.damage 0.2/int\nm.defense 0.5/int            crt.chanse 0.2/dex\ncrt.damage 0.1/dex";
                Hero.Source = new BitmapImage(new Uri(@"\Resources\chester.png", UriKind.Relative));
                selectedClass = new UniversalClass("Rogue", App.Name, 20, 65, 30, 200, 15, 70, 20, 80);
            }
            else if (App.Hero == "Wizard")
            {
               // InfoTb.Text = "Health 1.4/Vit 0.2/str               Mana 1.5/int\np.damage 0.5/str           armor 1/dex\nm.damage 1/int            m.defense 1/int\ncrt.chanse O.2/dex         crt.damage 0.1/dex";
                Hero.Source = new BitmapImage(new Uri(@"\Resources\tara.png", UriKind.Relative));
                    selectedClass = new UniversalClass("Wizard", App.Name, 15, 45, 20, 80, 35, 200, 15, 70);
            }
            UpdateUIFromCharacteristics();
            ShowInfo();
            currentPoint = int.Parse(CurrentScoreTB.Text);
        }


        private void UpdateUIFromCharacteristics()
        {
            StrengthTB.Text = selectedClass.Strength.ToString();
            DexterityTB.Text = selectedClass.Dexterity.ToString();
            InteligenceTB.Text = selectedClass.Inteligence.ToString();
            VitalityTB.Text = selectedClass.Vitality.ToString();
        }

        private void IncreaseValue(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextBlock textBlock = (TextBlock)button.Tag;
            double maxValue = GetMaxValueForTextBlock(textBlock);

            if (int.TryParse(textBlock.Text, out int value))
            {
                if (value < maxValue && currentPoint > 0)
                {
                    value++;
                    textBlock.Text = LimitValue(value, (int)maxValue).ToString();
                    UpdateCharacteristicsFromUI();
                    currentPoint--;
                    CurrentScoreTB.Text = currentPoint.ToString();
                    ShowInfo();
                }
            }
        }

        private void DecreaseValue(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextBlock textBlock = (TextBlock)button.Tag;
            double maxValue = GetMaxValueForTextBlock(textBlock);

            if (int.TryParse(textBlock.Text, out int value))
            {
                if (value > 0)
                    currentPoint++;
                value--;
                textBlock.Text = LimitValue(value, (int)maxValue).ToString();
                UpdateCharacteristicsFromUI();
                CurrentScoreTB.Text = currentPoint.ToString();
                ShowInfo();
            }
        }

        private void UpdateCharacteristicsFromUI()
        {
            selectedClass.Strength = int.Parse(StrengthTB.Text);
            selectedClass.Dexterity = int.Parse(DexterityTB.Text);
            selectedClass.Inteligence = int.Parse(InteligenceTB.Text);
            selectedClass.Vitality = int.Parse(VitalityTB.Text);
        }

        private void ShowInfo()
        {
            selectedClass.CalculateStats();
            HeroInfo.Text = $"Class: {selectedClass.ClassName}\nName: {selectedClass.Name}\n" +
                $"Strength: {selectedClass.Strength} / {selectedClass.MaxStrength}" +
                $"\nDexterity: {selectedClass.Dexterity} / {selectedClass.MaxDexterity}\n" +
                $"Inteligence: {selectedClass.Inteligence} / {selectedClass.MaxInteligence}\n" +
                $"Vitality: {selectedClass.Vitality}/{selectedClass.MaxVitality}\n";
            HeroStats.Text = $"Health: {selectedClass.Health}\nArmor: {selectedClass.Armor}\n " +
                            $"Mana: {selectedClass.Mana}\nPhysical Damage: {selectedClass.PhysicalDamage}\n" +
                            $"Magic Damage: {selectedClass.MagicDamage}\nMagic Defense: {selectedClass.MagicDefense}\n" +
                            $"Crit Chanse: {selectedClass.CritChanse}\nCrit Damage: {selectedClass.CritDamage}";
        }
        private double GetMaxValueForTextBlock(TextBlock textBlock)
        {
            switch (textBlock.Name)
            {
                case "StrengthTB":
                    return selectedClass.MaxStrength;
                case "DexterityTB":
                    return selectedClass.MaxDexterity;
                case "InteligenceTB":
                    return selectedClass.MaxInteligence;
                case "VitalityTB":
                    return selectedClass.MaxVitality;
                default:
                    return 0;
            }
        }

        private int LimitValue(int value, int maxValue)
        {
            return Math.Max(0, Math.Min(value, (int)maxValue));
        }
    }

}

