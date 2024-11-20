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

    public static Projet GenererUnProjet()
    {
        string[] nouveauxNomsProjets = { 
            "Centre d'Innovation", 
            "FabLab Universitaire", 
            "Programme d'Échange Global", 
            "Incubateur Étudiant", 
            "Réseau Wi-Fi Avancé", 
            "Gestion Intelligente des Déchets", 
            "Mobilité Durable", 
            "Laboratoire de Réalité Virtuelle", 
            "Jardin Botanique Urbain", 
            "Observatoire Environnemental", 
            "Plateforme de Mentorat", 
            "Studio Multimédia", 
            "Initiative Santé Numérique", 
            "Cloud Universitaire", 
            "Smart Parking"
        };

        string[] nouvellesDescriptionsProjets = { 
            "Création d'un espace dédié à l'innovation et aux startups", 
            "Mise en place d'un atelier de fabrication numérique pour les étudiants", 
            "Établissement de partenariats pour des échanges internationaux", 
            "Accompagnement des projets entrepreneuriaux portés par des étudiants", 
            "Amélioration de la connectivité sur l'ensemble du campus", 
            "Développement d'un système intelligent de tri et de recyclage des déchets", 
            "Encouragement des transports écologiques sur le campus", 
            "Équipement d'un laboratoire pour les expériences en réalité virtuelle", 
            "Aménagement d'un espace vert pour la recherche et la détente", 
            "Surveillance et analyse des données environnementales du campus", 
            "Lancement d'une plateforme pour connecter étudiants et mentors", 
            "Création d'un studio pour la production de contenus multimédias", 
            "Développement d'outils numériques pour la gestion de la santé des étudiants", 
            "Centralisation des ressources et services numériques sur le cloud", 
            "Installation d'un système intelligent pour la gestion des parkings"
        };

        Random random = new Random();
        int index = random.Next(nouveauxNomsProjets.Length);

        return new Projet(nouveauxNomsProjets[index], nouvellesDescriptionsProjets[index]);
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

        HashSet<int> indicesUtilises = new HashSet<int>();
        Random random = new Random();
        int nombreProjets = random.Next(1, 5); // Génère entre 1 et 4 projets

        while (projets.Count < nombreProjets)
        {
            int index = random.Next(nomsProjets.Length);
            if (!indicesUtilises.Contains(index))
            {
                indicesUtilises.Add(index);
                projets.Add(new Projet(nomsProjets[index], descriptionsProjets[index]));
            }
        }

        return projets;
    }
}
