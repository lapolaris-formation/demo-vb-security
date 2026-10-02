using System;
using System.Linq;
using System.Collections.Generic;

/**
 * Exercice en ligne - parcours de grille (brouillon perso)
 **/
class Solution
{
    static bool[,] vu;

    static void Main(string[] args)
    {
        int w = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());
        vu = new bool[h, w];
        Console.WriteLine(w * h);
    }
}
