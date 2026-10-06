using System;
using System.Linq.Expressions;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        static double Polonaise(String formule) 
        {
            // Déclaration
            float résultat;
            string[] tab = formule.Split(' ');
            int nbCases = tab.Length;

            try
            {

                for (int i = tab.Length - 1; i >= 0; i--)
                {
                    if (tab[i] == "+" || tab[i] == "-" || tab[i] == "*" || tab[i] == "/")
                    {
                        if (nbCases <= i + 2)
                        {
                            return float.NaN;
                        }

                        float valeur1 = float.Parse(tab[i + 1]);
                        float valeur2 = float.Parse(tab[i + 2]);
                        if (tab[i] == "+")
                        {
                            résultat = valeur1 + valeur2;
                        }
                        else if (tab[i] == "-")
                        {
                            résultat = valeur1 - valeur2;
                        }
                        else if (tab[i] == "*")
                        {
                            résultat = valeur1 * valeur2;
                        }
                        else
                        {
                            if (valeur2 == 0)
                            {
                                return float.NaN;
                            }
                            else
                            {
                                résultat = valeur1 / valeur2;
                            }


                        }

                        tab[i] = résultat.ToString();
                        for (int j = i + 1; j < nbCases - 2; j++)
                        {
                            tab[j] = tab[j + 2];
                        }

                        nbCases = nbCases - 2;
                    }
                }
                if (nbCases == 1)
                {
                    return float.Parse(tab[0]);
                }
                else
                {
                    return float.NaN;
                }

            }
            catch 
            {
                return float.NaN;
            }
                
            
            

        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
