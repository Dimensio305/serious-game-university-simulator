using System;
using System.Collections.Generic;
using Godot;

public class Projet
{
    public string Nom { get; private set; }
    public string Description { get; private set; }

    public Projet(string nom, string description)
    {
        Nom = nom;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Nom}: {Description}";
    }

    public static List<Projet> GenererProjetsAleatoires()
    {
        List<Projet> projets = new List<Projet>();
        string[] nomsProjets = { 
    "Campus Connect", 
    "Espace Collaboratif", 
    "Laboratoire Innovant", 
    "Bibliothèque Numérique", 
    "Énergie Verte", 
    "Smart Campus", 
    "Formation Continue", 
    "Système de Suivi Étudiant", 
    "Hub de Recherche", 
    "Programme de Bien-Être", 
    "Développement Durable", 
    "Modernisation des Amphithéâtres", 
    "Portail Alumni", 
    "E-Learning Expansion", 
    "Accélérateur de Startups"
};

string[] descriptionsProjets = { 
    "Développement d'une plateforme de communication pour le campus", 
    "Création d'espaces collaboratifs pour étudiants et chercheurs", 
    "Installation d'équipements de pointe pour la recherche", 
    "Numérisation des ressources de la bibliothèque", 
    "Passage aux énergies renouvelables pour réduire l'empreinte carbone", 
    "Transformation numérique du campus avec des technologies intelligentes", 
    "Développement de programmes de formation continue pour les professionnels", 
    "Mise en place d'un système pour le suivi des progrès étudiants", 
    "Renforcement des infrastructures pour la recherche avancée", 
    "Promotion de la santé et du bien-être pour les étudiants et le personnel", 
    "Initiatives pour un campus plus durable et écoresponsable", 
    "Modernisation des salles de cours avec des technologies interactives", 
    "Création d'un réseau d'anciens étudiants pour favoriser le mentorat", 
    "Développement de nouvelles plateformes pour l'enseignement à distance", 
    "Programme de soutien pour les projets d'entrepreneuriat étudiant"
};

        Random random = new Random();
        int nombreProjets = random.Next(1, 5); // Entre 1 et 4 projets

        for (int i = 0; i < nombreProjets; i++)
        {
            int p = random.Next(nomsProjets.Length);
            string nom = nomsProjets[p];
            string description = descriptionsProjets[p];
            projets.Add(new Projet(nom, description));
        }

        return projets;
    }
}