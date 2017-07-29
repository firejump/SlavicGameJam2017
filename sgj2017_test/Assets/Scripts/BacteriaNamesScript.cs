using System.Collections;
using Rand = System.Random;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaNamesScript  {
    static private string[] names = new string[] {
            "Actinomyces gerencseriae",
            "Entamoeba histolytica",
            "Bacillus anthracis",
            "Ascaris lumbricoides",
            "Balantidium coli",
            "Dracunculus medinensis",
            "Enterobius vermicularis",
            "Neisseria meningitidis",
            "Mycoplasma pneumoniae",
            "Paracoccidioides brasiliensis",
            "Rickettsia rickettsii",
            "Trichinella spiralis",
            "Vibrio vulnificus",
    };
    private static Rand r = new Rand();
    static public string getNewName() {
        
        return names[r.Next(names.Length)].Split(' ')[0] + " " + names[r.Next(names.Length)].Split(' ')[1];
    }
}
