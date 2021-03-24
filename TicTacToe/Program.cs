using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void symbols(ref string n1,ref string n2,ref string sym1,ref string sym2)
        {
            Random rnd = new Random();
            int start = rnd.Next(1, 3);
            if (start == 1)
            { 
                Console.WriteLine($"{n1} starts...Select symbol 'x' or 'o' ?");
                sym1 = "x";
                sym1= Console.ReadLine();
                if (sym1 == "o") 
                { sym2 = "x"; }
                else
                { sym2 = "o"; }

            }
            else
            {
                Console.WriteLine($"{n2} starts...Select symbol 'x' or 'o' ?");
                string temp = n1;
                n1 = n2;
                n2 = temp;               
                sym1 = "x";
                sym1 = Console.ReadLine();
                if (sym1 == "o")
                {  sym2 = "x"; }
                else
                { sym2 = "o"; }
            }
        }

        static void appearence(string [,] table)
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    Console.Write($"\t{table[i,j]}");
                }
                Console.WriteLine();
            }
        }


        static void game(string n1,string n2)
        {
            string sym1 = "", sym2 = "";
            int i = 0, j = 0;            
            int ps = 9; // oi theseis pou einai kenes ston pinaka
            string[,] table = new string[3, 3];
            symbols(ref n1,ref n2,ref sym1,ref sym2);
            Console.WriteLine($"{n1} has {sym1} and {n2} has {sym2}");
            string symtemp = sym1;
            string ntemp = n1;
            while (ps != 0)
            {
                do
                {
                    appearence(table);
                    Console.WriteLine($"\n \t{ntemp} your turn\nChoose a new square...\nWrite first the number of the ROWS...");
                    i = int.Parse(Console.ReadLine());
                    Console.WriteLine("and now the number of the COLUMNS...");
                    j = int.Parse(Console.ReadLine());
                    if (table[i, j] != null)
                    {                    
                        Console.WriteLine("The place is already taken...");
                    }
                } while (table[i, j] != null);
                table[i, j] = symtemp;
                ps--; // μειωνεται μια θεση του πινακα
                if (ps<=4) // παρατηρουμε οτι το αποτελεσμα του παιχνιδιου θα εμφανιστει αφου εχουν μεινει 4 ή και λιγοτερες κενες θεσεις
                {
                    for(j=0;j<=2;j++) // τριλιζα στις στηλες
                    {
                        
                        if ((table[0,j]!= null && table[1,j]!= null && table[0,j]==table[1,j])&&(table[1,j]==table[2,j]))
                        {
                            Console.WriteLine($"{ntemp} is WINNER!!!!");
                            appearence(table);
                            return;
                        }
                    }
                    for (i = 0; i <= 2; i++) // τριλιζα στις σειρές
                    {
                        
                        if (table[i,0]!= null && table[i,1]!= null && table[i, 0] == table[i, 1] && table[i, 1] == table[i, 2])
                        {
                            Console.WriteLine($"{ntemp} is WINNER!!!!");
                            appearence(table);
                            return;
                        }
                    }
                    if (table[0,0]==table[1,1]&&table[1,1] == table[2,2] || table[2,0]==table[1,1]&&table[1,1]==table[0,2]) // τριλιζα στη διαγωνιο
                    {
                        Console.WriteLine($"{ntemp} is WINNER!!!!");
                        appearence(table);
                        return;
                    }
                }
                if (symtemp==sym1)// προσωρινη τιμη στο ποιο συμβολο χρησιμοποιουμε και ποιος παικτης παζει
                {
                    symtemp = sym2;
                    ntemp = n2;
                }
                else
                {
                    symtemp = sym1;
                    ntemp = n1;
                }
            }
            if (ps==0)
            { 
               Console.WriteLine("The match is even");
               appearence(table);
            }

        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hey!\nPlayer one...Give me your name");
            string n1 = Console.ReadLine();
            Console.WriteLine("Player two...Give me your name");
            string n2 = Console.ReadLine();
            string question = "yes";
            while(question=="yes")
            {
                Console.WriteLine($"Player 1 = {n1} player 2 = {n2}");
                game(n1,n2);
                Console.WriteLine("Do you want to play again?\nyes or no ?");
                question = Console.ReadLine();
            }
            

        }
    }
}
