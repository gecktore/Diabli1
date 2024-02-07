using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabli1.Classes
{
    internal class ClassesInfo
    {
        internal Dictionary<string, string> heroInfo = new Dictionary<string, string>(){
            {"Warrior", $"Strength {warriorCurrentStats[0]}/{warriorMaxStats[0]}\nDexterity {warriorCurrentStats[1]}/{warriorMaxStats[1]}\nIntelligence {warriorCurrentStats[2]}/{warriorMaxStats[2]}\nVitality {warriorCurrentStats[3]}/{warriorMaxStats[3]}\n"},
            {"Rogue", $"Strength {rogueCurrentStats[0]}/{rogueMaxStats[0]}\nDexterity {rogueCurrentStats[1]}/{rogueMaxStats[1]}\nIntelligence {rogueCurrentStats[2]}/{rogueMaxStats[2]}\nVitality {rogueCurrentStats[3]}/{rogueMaxStats[3]}\n"},
            {"Wizard", $"Strength {wizardCurrentStats[0]}/{wizarMaxStats[0]}\nDexterity {wizardCurrentStats[1]}/{wizarMaxStats[1]}\nIntelligence {wizardCurrentStats[2]}/{wizarMaxStats[2]}\nVitality {wizardCurrentStats[3]}/{wizarMaxStats[3]}\n"},
        };
        internal Dictionary<string, double[]> heroCoefficient = new Dictionary<string, double[]>(){
            {"Warrior", new double[]{2,1,1,1,0,1,0.2,0.5,0.2,0.1}},
            {"Rogue", new double[]{1.5,0.5,1.2,0.5, 0.5, 1.5,0.2,0.5,0.2,0.1}},
            {"Wizard", new double[]{1.4,0.2,1.5, 0.5, 0,1,1,1,0.2, 0.1}},
        };
        internal static int[] warriorCurrentStats = new int[] { 30, 15, 10, 25 };
        internal static int[] warriorMaxStats = new int[] { 250, 80, 50, 100 };
        internal static int[] rogueCurrentStats = new int[] { 20, 30, 15, 20 };
        internal static int[] rogueMaxStats = new int[] { 65, 250, 70, 80 };
        internal static int[] wizardCurrentStats = new int[] { 15, 20, 35, 15 };
        internal static int[] wizarMaxStats = new int[] { 45, 80, 250, 70 };

    }
}
