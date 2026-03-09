🚀 Cahier des Charges : Better Serial Plotter ✨ 
1. Présentation du Projet
  
      L'objectif de ce projet est de développer une alternative viable au "Serial Plotter" implémenté de base
      sur l'IDE Arduino. 
      Le but est de visualiser en temps réel les données reçues via un port COM, afin de les afficher
      dans un graphique.
      On pourra ainsi visualiser les données en réglant l'échelle de temps, en mettant plusieurs données sur un seul graphique...
        

2. Fonctionnalités Requises

   🟦 Configuration de la Liaison Série
      - Scan automatique des ports COM disponibles (détéction automatique, si possible des cartes)
      - Sélection du BaudRate (9600, 115200, etc.)
      - Boutons de Connexion / Déconnexion
        
   📈 Visualisation Graphique
      - Tracé multi-courbe sur un seul graphique (ou une courbe par graph au choix).
      - Ajustement automatique des échelles (ou configuration manuelle).
      - Possibilité d'explorer le graphique avec la souris (revenir en arrière sur des données, zoomer sur un groupe de points)
      - Mettre en pause la lecture des données pour reprendre plus tard

   🛠️ Outils & Options
      - Console Texte : Affichage des données brutes en parallèle du graphique.
      - Export de données : Sauvegarde des points reçus au format .csv ou .txt.
      - Créer des pages dans lequels on peut mettre les graphiques, les customiser...

    🎖️ Bonus (Idées à ajouter en plus):
      - Permettre a l'utilisateur de faire des modifications graphiques (changer le thème de l'app, changer le style des graphs)
      - Ajouter des courbes mathématiques (par exemple l'utilisateur peut choisir d'afficher `val1 * val2²`
      - Ajouter un trigger sur l'aquisition (on ne capture les données qu'a partir d'une certaine valeur, ou d'un certain temps par ex)
      - Mettre en place la gestion de librairies de logging wifi (par exemple sur un esp32, on peut transmettre les données écrites dans la console pour les récuperer via le wifi).
  
3. Interface utilisateur 🖥️
   
     Le but est d'avoir un style semblable a VS Code par exmple avec les fenetres latérales qui permettent de visualiser les projets.
     Dans notre cas, à gauche on aura une fenetre (à voir si on peut la masquer), qui contiendra, en haut, les valeurs qui sont loggés et en bas les fenêtres configurées.
     On pourra aussi s'affranchir de cela, si on choisit de ne pas créer de projet (car ça peut être un peu lourd, si on a seulement besoin de plotter une valeur ou deux...)
     Dans ce cas on aura pas de gestion de page.

5. Roadmap 🗓️
     - [X] Phase 1 : design graphique principal
     - [X] Phase 2 : Connexion aux ports COM et récupération des données pour affichage dans un graph
     - [ ] Phase 3 : Mise en place des pages et de la configuration des graphiques.
     - [ ] Phase 4 : Ajout des fonctions d'export et de la console
     - [ ] Phase 5 : Ajout des fonctionnalités bonus (par forcément dans l'ordre).
     
6. Dépendances / Frameworks
   
   -Visual Studio Communnity 2026, application pour coder et programmer le code pour le Projet
   -Périphériques permmettant de pouvoir visualiser les données (comme une carte Arduino connecté sur l'ordinateur)
   -ScottPlot permet de pouvoir faire une modélisation graphique 
   -SQLite permettra de créer une base de données avec les données envoyées par le périphérique
   -Krypton permettra de donner à l'application, un meilleur aspect esthétique
   
