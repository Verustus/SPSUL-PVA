using System;
using System.Drawing;
using System.Windows.Forms;
/*using RestSharp;
using Newtonsoft.Json.Linq;*/

namespace GUI_1 {
    public partial class Form1 : Form {

        private static string[] WomenFirstNames = {
            "Anna", "Eva", "Jana", "Hana", "Marie", "Lenka", "Kateřina", "Lucie", "Petra", "Martina",
            "Barbora", "Veronika", "Tereza", "Zuzana", "Markéta", "Simona", "Michaela", "Alena", "Iva", "Denisa",
            "Adéla", "Eliška", "Magdaléna", "Irena", "Monika", "Šárka", "Věra", "Nela", "Natálie", "Karolína",
            "Kamila", "Dominika", "Daniela", "Iveta", "Lucia", "Milada", "Božena", "Dana", "Vlasta", "Jaroslava",
            "Nikola", "Růžena", "Kristýna", "Marta", "Věnceslava", "Blanka", "Helena", "Gabriela", "Olga", "Jarmila"
        };
        private static string[] MenFirstNames = {
            "Jan", "Petr", "Pavel", "Tomáš", "Martin", "Lukáš", "Michal", "Jakub", "Jiří", "Marek",
            "Zdeněk", "David", "Josef", "Jaroslav", "Václav", "Karel", "Daniel", "Miroslav", "Radek", "Milan",
            "Richard", "František", "Vladimír", "Ondřej", "Stanislav", "Jindřich", "Ladislav", "Filip", "Bohumil",
            "Vojtěch", "Adam", "Štěpán", "Miroslav", "Oldřich", "Libor", "Antonín", "Dalibor", "Miroslav", "Roman",
            "Rudolf", "Robert", "Patrik", "Marian", "Eduard", "Rostislav", "Marcel", "Bedřich", "Vlastimil", "Jozef",
        };
        private static string[] WomenLastNames = {
            "Nováková", "Svobodová", "Novotná", "Dvořáková", "Černá", "Procházková", "Kučerová", "Veselá", "Horáčková", "Němcová",
            "Marešová", "Kratochvílová", "Benešová", "Fišerová", "Šimková", "Konečná", "Poláková", "Jiráková", "Vaněčková", "Hájková",
            "Vlčková", "Holubová", "Bartošová", "Křížová", "Bílá", "Pospíšilová", "Pokorná", "Havlíčková", "Čermáková", "Růžičková",
            "Králíčková", "Urbanová", "Hrubá", "Tomášová", "Prokopová", "Zemanová", "Čechová", "Štěpánová", "Doubravová", "Kolářová",
            "Kovářová", "Neumannová", "Malá", "Blažková", "Kopecká", "Holá", "Nedvědová", "Ševčíková", "Machová", "Valentová"
        };
        private static string[] MenLastNames = {
            "Novák", "Svoboda", "Novotný", "Dvořák", "Černý", "Procházka", "Kučera", "Veselý", "Horáček", "Němec",
            "Mareš", "Kratochvíl", "Beneš", "Fišer", "Šimek", "Konečný", "Polák", "Jiráček", "Vaněk", "Hájek",
            "Vlček", "Holub", "Bartoš", "Kříž", "Bílý", "Pospíšil", "Pokorný", "Havlíček", "Čermák", "Růžička",
            "Králíček", "Urban", "Hrubý", "Tomáš", "Prokop", "Zeman", "Čech", "Štěpánek", "Doubrava", "Kolář",
            "Kovář", "Neumann", "Malý", "Blažek", "Kopecký", "Holý", "Nedvěd", "Ševčík", "Mach", "Valenta"
        };
        private Random rand;
        private bool firstShuffle;

        public Form1() {
            InitializeComponent();
            rand = new Random();
            firstShuffle = true;
        }

        private void FightClick(object sender, EventArgs e) {
            if (!firstShuffle) {

            }
        }
        private void ShufflePlayers(object sender, EventArgs e) {
            string FirstName;
            string LastName;

            if (rand.Next(0, 2) == 0) {
                FirstName = GetRandomFromArray(WomenFirstNames);
                LastName = GetRandomFromArray(WomenLastNames);
            } else {
                FirstName = GetRandomFromArray(MenFirstNames);
                LastName = GetRandomFromArray(MenLastNames);
            }
            this.playerA.Text = FirstName + " " + LastName;

            if (rand.Next(0, 2) == 0) {
                FirstName = GetRandomFromArray(WomenFirstNames);
                LastName = GetRandomFromArray(WomenLastNames);
            } else {
                FirstName = GetRandomFromArray(MenFirstNames);
                LastName = GetRandomFromArray(MenLastNames);
            }
            this.playerB.Text = FirstName + " " + LastName;

            firstShuffle = false;
        }

        private T GetRandomFromArray<T>(T[] array) {
            return array[rand.Next(0, array.Length)];
        }
        
        private void OnResize(object sender, EventArgs e) {
            UpdateLocations();
        }

        private void UpdateLocations() {
            ScaleWidthPercent(this.playerGroup, 0.6f, this);
            CenterWidth(this.fightButton, this);
            CenterWidth(this.shufflePlayersButton, this);
            CenterWidth(this.playerGroup, this);
        }

        private void CenterWidth<Parent>(Control toCenter, Parent parent) where Parent : Control {
            if (parent is Form) 
                toCenter.Location = new Point((parent as Form).ClientSize.Width/2 - toCenter.Width/2, toCenter.Location.Y);
            else toCenter.Location = new Point(parent.Width/2 - toCenter.Width/2, toCenter.Location.Y);
        }
        private void CenterHeight<Parent>(Control toCenter, Parent parent) where Parent : Control {
            if (parent is Form) 
                toCenter.Location = new Point(toCenter.Location.Y, (parent as Form).ClientSize.Height/2 - toCenter.Height/2);
            else toCenter.Location = new Point(toCenter.Location.Y, parent.Height/2 - toCenter.Height/2);
        }

        private void ScaleWidthPercent<Parent>(Control toSize, float scale, Parent scaleTo) where Parent : Control {
            if (scaleTo is Form)
                toSize.Size = new Size((int) Math.Floor((scaleTo as Form).ClientSize.Width*scale), toSize.Height);
            else toSize.Size = new Size((int) Math.Floor(scaleTo.Width*scale), toSize.Height);
        }
        private void ScaleHeightPercent<Parent>(Control toSize, float scale, Parent scaleTo) where Parent : Control {
            if (scaleTo is Form)
                toSize.Size = new Size(toSize.Width, (int) Math.Floor((scaleTo as Form).ClientSize.Height*scale));
            else toSize.Size = new Size(toSize.Width, (int) Math.Floor(scaleTo.Height*scale));
        }

        private void OnLoad(object sender, EventArgs e) {
            UpdateLocations();
        }
    }
}
