insert into Catpersonne( idcat , nom) values ( 1 , 'Administration universitaire');
insert into Catpersonne( idcat , nom) values ( 2 , 'Conseil pédagogique');
insert into Catpersonne( idcat , nom) values ( 3 , 'Service financier');
insert into Catpersonne( idcat , nom) values ( 4 , 'Enseignants');
insert into Catpersonne( idcat , nom) values ( 5 , 'Service d orientation et d insertion professionnelle');
insert into Catpersonne( idcat , nom) values ( 6 , 'Secrétariat pédagogique');
insert into Catpersonne( idcat , nom) values ( 7 , 'Partenaires professionnels ');
insert into Catpersonne( idcat , nom) values ( 8 , 'Ministère');
insert into Catpersonne( idcat , nom) values ( 9 , 'Cellule de qualité et d évaluation');
insert into Catpersonne( idcat , nom) values ( 10 ,'Ressources humaines');
insert into Catpersonne( idcat , nom) values ( 11 ,'Etudiant');

-- Administration universitaire (idcat = 1)
INSERT INTO Question (id, idcat, question) VALUES (1, 1, 'Le budget est serré cette année. Devons-nous réduire le financement des programmes moins populaires ?');
INSERT INTO Question (id, idcat, question) VALUES (2, 1, 'Les étudiants demandent plus de cours pratiques pour améliorer leur employabilité. Devons-nous allouer des fonds pour développer ces cours ?');
INSERT INTO Question (id, idcat, question) VALUES (3, 1, 'Certains enseignants demandent une réduction de leur charge de travail. Cela affectera la quantité de cours proposés. Que devons-nous faire ?');
INSERT INTO Question (id, idcat, question) VALUES (4, 1, 'Pour maintenir notre budget à flot, devons-nous augmenter les frais d’inscription ?');
INSERT INTO Question (id, idcat, question) VALUES (5, 1, 'Une grande entreprise propose de financer des programmes en échange de la création de formations adaptées à leurs besoins. Devons-nous accepter ?');
INSERT INTO Question (id, idcat, question) VALUES (6, 1, 'Certains programmes sont sous-enregistrés. Devons-nous réduire le nombre d''enseignants dans ces programmes pour économiser ?');
INSERT INTO Question (id, idcat, question) VALUES (7, 1, 'Des programmes avec peu d’inscrits consomment beaucoup de ressources. Devons-nous en fermer certains pour concentrer nos efforts sur les plus populaires ?');
INSERT INTO Question (id, idcat, question) VALUES (8, 1, 'Devons-nous imposer davantage de stages aux étudiants pour améliorer leur employabilité après leurs études ?');
INSERT INTO Question (id, idcat, question) VALUES (9, 1, 'Les services de soutien aux étudiants (tutorat, aide psychologique) coûtent cher. Devons-nous réduire ces services pour économiser ?');
INSERT INTO Question (id, idcat, question) VALUES (10, 1, 'Devons-nous fusionner certains cours aux contenus similaires pour réduire les coûts ?');
INSERT INTO Question (id, idcat, question) VALUES (11, 1, 'Devons-nous ouvrir de nouvelles formations pour répondre aux besoins croissants du marché, même si cela entraîne des coûts initiaux élevés ?');
INSERT INTO Question (id, idcat, question) VALUES (12, 1, 'Faut-il augmenter les salaires des professeurs pour attirer des talents, même si cela affecte le budget ?');
INSERT INTO Question (id, idcat, question) VALUES (13, 1, 'Devons-nous investir dans la modernisation de l''infrastructure de l''université pour améliorer l''expérience étudiante ?');
INSERT INTO Question (id, idcat, question) VALUES (14, 1, 'Les étudiants demandent un accès plus large aux programmes de mobilité internationale. Devons-nous les financer ?');
INSERT INTO Question (id, idcat, question) VALUES (15, 1, 'Devons-nous adopter des politiques de développement durable pour améliorer l''image de l''université, même si cela demande un investissement à long terme ?');

-- Conseil pédagogique (idcat = 2)
INSERT INTO Question (id, idcat, question) VALUES (16, 2, 'Certaines de nos formations n''ont pas été mises à jour depuis plusieurs années. Devons-nous allouer des ressources pour réviser ces programmes afin de les aligner sur les besoins actuels du marché du travail ?');
INSERT INTO Question (id, idcat, question) VALUES (17, 2, 'Devons-nous créer de nouvelles spécialisations dans certains domaines émergents (intelligence artificielle, développement durable, etc.) pour rester compétitifs et améliorer l’employabilité des étudiants ?');
INSERT INTO Question (id, idcat, question) VALUES (18, 2, 'Devons-nous investir dans des méthodes pédagogiques innovantes, comme l’apprentissage par projets ou les cours en ligne, pour moderniser nos formations ?');
INSERT INTO Question (id, idcat, question) VALUES (19, 2, 'Les classes sont surchargées, ce qui nuit à la qualité des cours. Devons-nous recruter plus de professeurs pour réduire la taille des groupes et améliorer la réussite des étudiants ?');
INSERT INTO Question (id, idcat, question) VALUES (20, 2, 'Le conseil propose de passer à un système d''évaluation continue plutôt que de se concentrer uniquement sur les examens finaux. Ce changement pourrait améliorer la réussite des étudiants, mais il demanderait plus de travail aux enseignants. Qu’en pensez-vous ?');
INSERT INTO Question (id, idcat, question) VALUES (21, 2, 'Devons-nous financer des formations pour les enseignants afin d''améliorer leurs compétences pédagogiques et les adapter aux nouvelles méthodes d’enseignement ?');
INSERT INTO Question (id, idcat, question) VALUES (22, 2, 'Les étudiants réclament plus de suivi pendant leurs stages pour maximiser leurs chances d’insertion professionnelle. Devons-nous allouer davantage de ressources à l''encadrement des stages ?');
INSERT INTO Question (id, idcat, question) VALUES (23, 2, 'Nous avons l’opportunité d’accréditer certains de nos diplômes à un niveau national ou international, ce qui pourrait attirer plus d''étudiants et améliorer leur employabilité. Faut-il investir dans ce processus ?');
INSERT INTO Question (id, idcat, question) VALUES (24, 2, 'Faut-il encourager les projets interdisciplinaires où les étudiants de différentes filières collaborent ? Cela pourrait améliorer leur employabilité, mais demande une coordination complexe pour les enseignants.');
INSERT INTO Question (id, idcat, question) VALUES (25, 2, 'Le conseil propose d’augmenter la durée des stages obligatoires pour mieux préparer les étudiants à leur entrée sur le marché du travail. Ce changement pourrait toutefois ralentir leur progression dans leurs études. Que faire ?');
INSERT INTO Question (id, idcat, question) VALUES (26, 2, 'Faut-il proposer des cours de développement personnel en plus des cours académiques pour préparer les étudiants à leur vie professionnelle ?');
INSERT INTO Question (id, idcat, question) VALUES (27, 2, 'Les enseignants souhaitent une plus grande autonomie dans la conception de leurs cours. Devons-nous accorder cette liberté ?');
INSERT INTO Question (id, idcat, question) VALUES (28, 2, 'Devons-nous introduire une formation continue obligatoire pour les enseignants afin qu''ils soient au courant des dernières tendances pédagogiques ?');
INSERT INTO Question (id, idcat, question) VALUES (29, 2, 'Les étudiants demandent des cours plus adaptés aux métiers de demain, comme la cybersécurité. Devons-nous les développer ?');
INSERT INTO Question (id, idcat, question) VALUES (30, 2, 'Devons-nous organiser des journées d’échange entre enseignants et étudiants pour discuter de l’amélioration des programmes ?');
-- Service financier (idcat = 3)
INSERT INTO Question (id, idcat, question) VALUES (31, 3, 'Notre budget pour les bourses étudiantes est limité cette année. Devons-nous réduire le nombre de bourses accordées ?');
INSERT INTO Question (id, idcat, question) VALUES (32, 3, 'Les infrastructures vieillissent et nécessitent des rénovations importantes. Devons-nous allouer des fonds à la rénovation des bâtiments ?');
INSERT INTO Question (id, idcat, question) VALUES (33, 3, 'Une augmentation des salaires des enseignants a été demandée pour maintenir leur satisfaction. Devons-nous accepter cette augmentation, malgré son coût pour l’université ?');
INSERT INTO Question (id, idcat, question) VALUES (34, 3, 'Devons-nous investir dans des partenariats avec des entreprises privées pour obtenir des financements supplémentaires ?');
INSERT INTO Question (id, idcat, question) VALUES (35, 3, 'Pour économiser, devons-nous réduire les dépenses dans les équipements de laboratoire et autres matériels pédagogiques ?');
INSERT INTO Question (id, idcat, question) VALUES (36, 3, 'Les coûts d’entretien des campus augmentent. Devons-nous envisager de fermer certains campus secondaires pour réduire les frais ?');
INSERT INTO Question (id, idcat, question) VALUES (37, 3, 'L''université est sollicitée pour investir dans des technologies vertes, ce qui aurait un coût initial élevé mais pourrait réduire les coûts à long terme. Que devons-nous faire ?');
INSERT INTO Question (id, idcat, question) VALUES (38, 3, 'Un audit externe a suggéré de réduire les dépenses dans les services administratifs pour économiser. Devons-nous suivre cette recommandation ?');
INSERT INTO Question (id, idcat, question) VALUES (39, 3, 'Les revenus des droits d’inscription ont diminué. Devons-nous compenser cette perte par une hausse des droits d’inscription l’année prochaine ?');
INSERT INTO Question (id, idcat, question) VALUES (40, 3, 'Devons-nous contracter un emprunt pour financer l''agrandissement de nos infrastructures et améliorer l’accueil des étudiants ?');
INSERT INTO Question (id, idcat, question) VALUES (41, 3, 'Devons-nous augmenter le pourcentage de financement provenant de sources privées pour compenser le manque de fonds publics ?');
INSERT INTO Question (id, idcat, question) VALUES (42, 3, 'Faut-il envisager une augmentation des frais d’inscription pour maintenir la qualité des services aux étudiants ?');
INSERT INTO Question (id, idcat, question) VALUES (43, 3, 'Les frais de scolarité sont trop élevés pour certains étudiants. Devons-nous mettre en place plus de bourses ?');
INSERT INTO Question (id, idcat, question) VALUES (44, 3, 'Devons-nous lancer une campagne de collecte de fonds auprès des anciens élèves pour améliorer les infrastructures ?');
INSERT INTO Question (id, idcat, question) VALUES (45, 3, 'Faut-il réduire certains frais pour attirer plus d’étudiants étrangers, même si cela impacte les finances de l’université ?');

-- Enseignants (idcat = 4)
INSERT INTO Question (id, idcat, question) VALUES (46, 4, 'Les enseignants demandent plus de temps pour la recherche. Cela réduirait le nombre de cours disponibles. Devons-nous accepter cette demande ?');
INSERT INTO Question (id, idcat, question) VALUES (47, 4, 'Certains enseignants souhaitent passer à une évaluation plus flexible, où les étudiants peuvent choisir leur méthode d’évaluation. Faut-il l’autoriser ?');
INSERT INTO Question (id, idcat, question) VALUES (48, 4, 'Les enseignants veulent plus de formations pour développer leurs compétences pédagogiques. Devons-nous allouer des fonds pour ces formations ?');
INSERT INTO Question (id, idcat, question) VALUES (49, 4, 'Des enseignants demandent à pouvoir ajuster leurs horaires en fonction de leur charge de travail et de leurs recherches. Devons-nous leur offrir plus de flexibilité dans les horaires ?');
INSERT INTO Question (id, idcat, question) VALUES (50, 4, 'Certains enseignants proposent de supprimer des cours théoriques au profit de cours plus pratiques, mieux adaptés au marché du travail. Devons-nous accepter ce changement ?');
INSERT INTO Question (id, idcat, question) VALUES (51, 4, 'Pour améliorer la qualité des cours, certains enseignants demandent des classes plus petites. Faut-il recruter plus de personnel pour répondre à cette demande ?');
INSERT INTO Question (id, idcat, question) VALUES (52, 4, 'Les enseignants demandent une augmentation de leur budget pour du matériel pédagogique et des outils numériques. Devons-nous répondre à cette demande ?');
INSERT INTO Question (id, idcat, question) VALUES (53, 4, 'Un groupe d’enseignants veut créer des modules d’enseignement en ligne pour élargir l’accès aux formations. Cela demande un investissement important. Devons-nous le financer ?');
INSERT INTO Question (id, idcat, question) VALUES (54, 4, 'Certains enseignants demandent une meilleure reconnaissance de leurs efforts d’encadrement de projets étudiants. Cela nécessiterait des bonus financiers ou une réduction de charge de travail. Faut-il accéder à cette requête ?');
INSERT INTO Question (id, idcat, question) VALUES (55, 4, 'Les enseignants demandent des réductions de cours pour se concentrer sur des projets interdisciplinaires avec les étudiants. Faut-il leur accorder cette liberté ?');
INSERT INTO Question (id, idcat, question) VALUES (56, 4, 'Devons-nous inclure des compétences pratiques dans tous les programmes pour préparer les étudiants à des métiers spécifiques ?');
INSERT INTO Question (id, idcat, question) VALUES (57, 4, 'Les enseignants demandent des heures de formation pour utiliser des nouvelles technologies en classe. Devons-nous financer cela ?');
INSERT INTO Question (id, idcat, question) VALUES (58, 4, 'Devons-nous offrir des formations sur la gestion de projet aux étudiants en dehors des programmes standard ?');
INSERT INTO Question (id, idcat, question) VALUES (59, 4, 'Certains enseignants demandent un salaire plus élevé pour accepter des cours supplémentaires. Faut-il accéder à cette demande ?');
INSERT INTO Question (id, idcat, question) VALUES (60, 4, 'Faut-il encourager les enseignants à adopter des approches pédagogiques plus collaboratives ?');

-- Service d'orientation et d'insertion professionnelle (idcat = 5)
INSERT INTO Question (id, idcat, question) VALUES (61, 5, 'Les conseillers d’orientation demandent plus de ressources pour organiser des salons de l’emploi et des rencontres avec les entreprises. Devons-nous financer ces initiatives ?');
INSERT INTO Question (id, idcat, question) VALUES (62, 5, 'Le service propose de développer un programme de mentorat avec des anciens étudiants pour aider à l’insertion professionnelle. Faut-il allouer des fonds à ce projet ?');
INSERT INTO Question (id, idcat, question) VALUES (63, 5, 'Le service d’orientation suggère de rendre obligatoire un bilan de compétences pour tous les étudiants en fin de parcours afin d’améliorer leur employabilité. Devons-nous le mettre en place ?');
INSERT INTO Question (id, idcat, question) VALUES (64, 5, 'Pour améliorer l’insertion professionnelle, le service propose d’intégrer des ateliers de préparation aux entretiens dans tous les cursus. Faut-il rendre ces ateliers obligatoires ?');
INSERT INTO Question (id, idcat, question) VALUES (65, 5, 'Certaines entreprises partenaires proposent de sponsoriser des ateliers spécifiques de recrutement pour attirer nos diplômés. Devons-nous accepter ce sponsoring ?');
INSERT INTO Question (id, idcat, question) VALUES (66, 5, 'Le service d’insertion professionnelle suggère d’ajouter une composante entrepreneuriale dans tous les cursus pour encourager la création d’entreprise. Faut-il mettre en œuvre cette idée ?');
INSERT INTO Question (id, idcat, question) VALUES (67, 5, 'Les conseillers d’orientation demandent plus de personnel pour mieux accompagner les étudiants. Ce recrutement augmentera-t-il les chances d’insertion professionnelle des étudiants ?');
INSERT INTO Question (id, idcat, question) VALUES (68, 5, 'Le service propose de renforcer les partenariats avec des entreprises locales pour faciliter les stages et les embauches. Devons-nous investir dans ces partenariats ?');
INSERT INTO Question (id, idcat, question) VALUES (69, 5, 'Les étudiants demandent des événements dédiés aux carrières dans des secteurs émergents (comme la tech ou le développement durable). Devons-nous financer ces événements ?');
INSERT INTO Question (id, idcat, question) VALUES (70, 5, 'Le service propose de créer un réseau d’anciens étudiants pour offrir des opportunités d’emploi aux jeunes diplômés. Devons-nous allouer des ressources à cette initiative ?');
INSERT INTO Question (id, idcat, question) VALUES (71, 5, 'Devons-nous créer un programme de mentorat avec des anciens élèves pour aider les étudiants à trouver des stages ?');
INSERT INTO Question (id, idcat, question) VALUES (72, 5, 'Faut-il organiser des salons de recrutement sur le campus pour renforcer l’insertion professionnelle ?');
INSERT INTO Question (id, idcat, question) VALUES (73, 5, 'Devons-nous intégrer des simulations d’entretiens dans le programme pour préparer les étudiants aux démarches professionnelles ?');
INSERT INTO Question (id, idcat, question) VALUES (74, 5, 'Les étudiants veulent des services de conseil de carrière personnalisés. Devons-nous embaucher plus de conseillers ?');
INSERT INTO Question (id, idcat, question) VALUES (75, 5, 'Faut-il créer un programme de stage de courte durée pour permettre aux étudiants de tester différentes carrières ?');

-- Secrétariat pédagogique (idcat = 6)
INSERT INTO Question (id, idcat, question) VALUES (76, 6, 'Le secrétariat demande d’embaucher des assistants pour réduire les délais de traitement des demandes étudiantes. Devons-nous approuver cette embauche ?');
INSERT INTO Question (id, idcat, question) VALUES (77, 6, 'Pour améliorer l’efficacité, le secrétariat propose de passer à une gestion numérique des dossiers étudiants. Devons-nous financer ce projet ?');
INSERT INTO Question (id, idcat, question) VALUES (78, 6, 'Le secrétariat suggère d’instaurer des permanences supplémentaires pour répondre aux questions des étudiants en période d’examens. Faut-il les mettre en place ?');
INSERT INTO Question (id, idcat, question) VALUES (79, 6, 'Le secrétariat souhaite organiser des sessions d’information sur le déroulement des cours et des examens pour les nouveaux étudiants. Devons-nous financer ces sessions ?');
INSERT INTO Question (id, idcat, question) VALUES (80, 6, 'Pour réduire la charge de travail, le secrétariat propose d’automatiser certaines tâches répétitives avec des outils numériques. Devons-nous investir dans ces outils ?');
INSERT INTO Question (id, idcat, question) VALUES (81, 6, 'Le secrétariat suggère de fournir des guides en ligne pour aider les étudiants à s’inscrire aux cours. Faut-il développer ces guides ?');
INSERT INTO Question (id, idcat, question) VALUES (82, 6, 'Le secrétariat demande des budgets supplémentaires pour mieux accompagner les étudiants internationaux dans leurs démarches. Devons-nous leur accorder ces ressources ?');
INSERT INTO Question (id, idcat, question) VALUES (83, 6, 'Pour diminuer le nombre d’erreurs administratives, le secrétariat souhaite instaurer un programme de formation pour le personnel administratif. Devons-nous le financer ?');
INSERT INTO Question (id, idcat, question) VALUES (84, 6, 'Le secrétariat propose d’introduire un système de suivi des demandes étudiantes en ligne. Devons-nous mettre en place ce système ?');
INSERT INTO Question (id, idcat, question) VALUES (85, 6, 'Le secrétariat demande des ressources pour améliorer la communication interne et diffuser plus efficacement les informations aux étudiants. Devons-nous leur accorder ces ressources ?');
INSERT INTO Question (id, idcat, question) VALUES (86, 6, 'Devons-nous digitaliser tous les documents académiques pour réduire la charge de travail ?');
INSERT INTO Question (id, idcat, question) VALUES (87, 6, 'Faut-il mettre en place une hotline pour les questions administratives des étudiants ?');
INSERT INTO Question (id, idcat, question) VALUES (88, 6, 'Devons-nous améliorer le système de prise de rendez-vous pour optimiser le temps de travail ?');
INSERT INTO Question (id, idcat, question) VALUES (89, 6, 'Faut-il former le personnel pour mieux gérer les situations de crise ou les demandes urgentes ?');
INSERT INTO Question (id, idcat, question) VALUES (90, 6, 'Devons-nous ouvrir des heures supplémentaires pour faciliter l’accès aux services pendant les périodes de forte demande ?');

-- Partenaire Professionnels (idcat = 7)
INSERT INTO Question (id, idcat, question) VALUES (91, 7, 'Un partenaire propose d''organiser des ateliers pratiques dans nos locaux pour familiariser les étudiants avec les outils de l’industrie. Devons-nous accepter ?');
INSERT INTO Question (id, idcat, question) VALUES (92, 7, 'Un réseau d''entreprises propose de parrainer un programme d''études, mais souhaite avoir un droit de regard sur le contenu. Devons-nous accepter ce partenariat ?');
INSERT INTO Question (id, idcat, question) VALUES (93, 7, 'Un partenaire souhaite créer une bourse pour les meilleurs étudiants, mais cela implique de lui fournir les données de performance des étudiants. Devons-nous accepter cette condition ?');
INSERT INTO Question (id, idcat, question) VALUES (94, 7, 'Un groupe industriel propose un financement pour équiper nos laboratoires, en échange d’un quota d’étudiants formés spécifiquement pour ses besoins. Que faire ?');
INSERT INTO Question (id, idcat, question) VALUES (95, 7, 'Une entreprise souhaite organiser un concours d''innovation ouvert à nos étudiants, avec des récompenses et opportunités d''embauche à la clé. Devons-nous encourager les étudiants à y participer ?');
INSERT INTO Question (id, idcat, question) VALUES (96, 7, 'Un partenariat avec une organisation professionnelle pourrait offrir des certifications reconnues aux étudiants, mais cela nécessite une modification des programmes pour répondre à leurs standards. Devons-nous le mettre en place ?');
INSERT INTO Question (id, idcat, question) VALUES (97, 7, 'Un partenaire propose d’offrir des stages rémunérés à nos étudiants en échange d’une réduction de la durée de leurs études pour les rendre disponibles plus tôt. Devons-nous accepter ?');
INSERT INTO Question (id, idcat, question) VALUES (98, 7, 'Une entreprise souhaite donner des conférences régulières à nos étudiants pour améliorer leur compréhension de l’industrie. Devons-nous accepter cette proposition ?');
INSERT INTO Question (id, idcat, question) VALUES (99, 7, 'Un partenariat international pourrait envoyer certains de nos étudiants pour des stages à l’étranger, mais cela nécessite un investissement important de l’université. Devons-nous nous engager ?');
INSERT INTO Question (id, idcat, question) VALUES (100, 7, 'Un partenaire propose un don important à l’université pour financer de nouvelles infrastructures, mais souhaite avoir une influence sur la gouvernance des formations. Faut-il accepter cette contribution ?');
INSERT INTO Question (id, idcat, question) VALUES (101, 7, 'Devons-nous multiplier les partenariats avec des entreprises pour offrir plus de stages aux étudiants ?');
INSERT INTO Question (id, idcat, question) VALUES (102, 7, 'Faut-il créer des programmes de formation en partenariat avec les entreprises pour répondre à leurs besoins spécifiques ?');
INSERT INTO Question (id, idcat, question) VALUES (103, 7, 'Devons-nous organiser des journées de réseautage sur le campus avec des représentants d’entreprises ?');
INSERT INTO Question (id, idcat, question) VALUES (104, 7, 'Faut-il investir dans des projets communs pour développer de nouvelles compétences chez les étudiants ?');
INSERT INTO Question (id, idcat, question) VALUES (105, 7, 'Les entreprises veulent être impliquées dans la conception des programmes. Devons-nous les consulter ?');

-- Ministere (idcat=8)
INSERT INTO Question (id, idcat, question) VALUES (106, 8, 'Le ministère propose un financement supplémentaire en échange de l''augmentation des effectifs dans les filières en tension. Devons-nous accepter ?');
INSERT INTO Question (id, idcat, question) VALUES (107, 8, 'Le ministère souhaite que l''université ouvre davantage de programmes spécialisés pour répondre aux besoins nationaux. Faut-il répondre favorablement à cette demande ?');
INSERT INTO Question (id, idcat, question) VALUES (108, 8, 'Le ministère impose une réforme des programmes pour aligner les formations avec les standards internationaux. Devons-nous appliquer cette réforme dès cette année ?');
INSERT INTO Question (id, idcat, question) VALUES (109, 8, 'Le ministère propose de financer une nouvelle infrastructure pour l''université en échange de résultats plus élevés au taux de réussite des étudiants. Faut-il accepter cette condition ?');
INSERT INTO Question (id, idcat, question) VALUES (110, 8, 'Le ministère souhaite instaurer un quota pour accueillir plus d’étudiants internationaux. Devons-nous suivre cette directive ?');
INSERT INTO Question (id, idcat, question) VALUES (111, 8, 'Le ministère propose de subventionner des cours en ligne pour rendre les formations plus accessibles. Devons-nous mettre en place ces cours rapidement ?');
INSERT INTO Question (id, idcat, question) VALUES (112, 8, 'Le ministère souhaite mettre en place un programme d’évaluation des enseignants basé sur la satisfaction des étudiants. Devons-nous instaurer ce programme ?');
INSERT INTO Question (id, idcat, question) VALUES (113, 8, 'Le ministère impose une réduction des frais d’inscription pour attirer davantage d’étudiants, mais cela entraînerait une baisse des revenus. Que faire ?');
INSERT INTO Question (id, idcat, question) VALUES (114, 8, 'Le ministère offre un financement si l''université augmente les stages obligatoires dans les formations. Devons-nous intégrer cette exigence ?');
INSERT INTO Question (id, idcat, question) VALUES (115, 8, 'Le ministère propose un financement supplémentaire en échange de la suppression de certains programmes considérés comme moins stratégiques. Devons-nous accepter ?');
INSERT INTO Question (id, idcat, question) VALUES (116, 8, 'Le ministère exige un rapport annuel sur la performance de l’université. Devons-nous y investir plus de ressources ?');
INSERT INTO Question (id, idcat, question) VALUES (117, 8, 'Devons-nous suivre les nouvelles normes imposées par le ministère, même si elles augmentent les coûts ?');
INSERT INTO Question (id, idcat, question) VALUES (118, 8, 'Le ministère souhaite des programmes de formation sur la transition écologique. Devons-nous nous y conformer ?');
INSERT INTO Question (id, idcat, question) VALUES (119, 8, 'Faut-il adopter une politique stricte pour respecter les exigences de financement public ?');
INSERT INTO Question (id, idcat, question) VALUES (120, 8, 'Le ministère demande l’intégration d’une politique de diversité. Devons-nous développer des programmes pour répondre à ces critères ?');

-- Cellule de Qualité et d'Évaluation (idcat = 9)
INSERT INTO Question (id, idcat, question) VALUES (121, 9, 'Les derniers sondages montrent une baisse de satisfaction chez les étudiants. Devons-nous lancer une révision complète des programmes concernés ?');
INSERT INTO Question (id, idcat, question) VALUES (122, 9, 'Les évaluations révèlent que certains enseignants reçoivent des critiques récurrentes. Devons-nous instaurer un programme de formation obligatoire pour ces enseignants ?');
INSERT INTO Question (id, idcat, question) VALUES (123, 9, 'Les taux de réussite de certains programmes sont bas depuis plusieurs années. Devons-nous envisager des remaniements importants pour les améliorer ?');
INSERT INTO Question (id, idcat, question) VALUES (124, 9, 'La cellule propose de mettre en place un suivi régulier des diplômés pour obtenir des données précises sur leur insertion professionnelle. Devons-nous investir dans ce projet ?');
INSERT INTO Question (id, idcat, question) VALUES (125, 9, 'Les normes d’évaluation de nos formations ne sont plus en phase avec les standards nationaux. Devons-nous réformer notre processus d’évaluation pour y remédier ?');
INSERT INTO Question (id, idcat, question) VALUES (126, 9, 'Certains programmes n''ont pas atteint leurs objectifs pédagogiques cette année. La cellule propose une évaluation approfondie de ces programmes. Devons-nous allouer des ressources pour cela ?');
INSERT INTO Question (id, idcat, question) VALUES (127, 9, 'Les rapports montrent que les étudiants qui reçoivent un suivi personnalisé réussissent mieux. Devons-nous allouer plus de ressources pour mettre en place ce suivi ?');
INSERT INTO Question (id, idcat, question) VALUES (128, 9, 'La cellule suggère de réduire la taille des classes dans les cours les plus difficiles pour améliorer la réussite des étudiants. Devons-nous suivre cette recommandation ?');
INSERT INTO Question (id, idcat, question) VALUES (129, 9, 'Pour renforcer la qualité, la cellule recommande d’augmenter le nombre de cours en ligne interactifs. Devons-nous investir dans ces ressources ?');
INSERT INTO Question (id, idcat, question) VALUES (130, 9, 'La cellule propose une auto-évaluation annuelle de chaque programme pour suivre la qualité en continu. Faut-il encourager cette démarche ?');
INSERT INTO Question (id, idcat, question) VALUES (131, 9, 'Devons-nous engager un audit externe pour garantir la qualité de nos formations ?');
INSERT INTO Question (id, idcat, question) VALUES (132, 9, 'Faut-il mettre en place un système de feedback anonyme pour améliorer nos programmes ?');
INSERT INTO Question (id, idcat, question) VALUES (133, 9, 'Devons-nous organiser des évaluations semestrielles des enseignants par les étudiants ?');
INSERT INTO Question (id, idcat, question) VALUES (134, 9, 'Faut-il publier un rapport annuel sur la qualité et les résultats des programmes ?');
INSERT INTO Question (id, idcat, question) VALUES (135, 9, 'Devons-nous intégrer la qualité dans chaque aspect du processus académique, y compris les cours en ligne ?');

-- Ressources Humaines (idcat = 10)
INSERT INTO Question (id, idcat, question) VALUES (136, 10, 'Certains enseignants demandent des augmentations salariales pour être en ligne avec les standards du secteur. Devons-nous accorder ces augmentations ?');
INSERT INTO Question (id, idcat, question) VALUES (137, 10, 'Les enseignants rapportent une surcharge de travail. Devons-nous recruter des enseignants supplémentaires pour réduire leur charge ?');
INSERT INTO Question (id, idcat, question) VALUES (138, 10, 'Pour attirer de nouveaux talents, devons-nous revoir notre politique de rémunération et d’avantages sociaux ?');
INSERT INTO Question (id, idcat, question) VALUES (139, 10, 'Les enseignants souhaitent plus de flexibilité dans leurs horaires pour améliorer leur bien-être. Devons-nous leur accorder cette flexibilité ?');
INSERT INTO Question (id, idcat, question) VALUES (140, 10, 'Pour améliorer la qualité de l’enseignement, devons-nous instaurer un programme de formation continue pour les enseignants ?');
INSERT INTO Question (id, idcat, question) VALUES (141, 10, 'Certains enseignants demandent des congés sabbatiques pour se concentrer sur la recherche ou se former. Devons-nous autoriser ces congés ?');
INSERT INTO Question (id, idcat, question) VALUES (142, 10, 'Pour promouvoir la diversité, devons-nous mettre en place des quotas d’embauche pour les nouveaux enseignants ?');
INSERT INTO Question (id, idcat, question) VALUES (143, 10, 'Les enseignants demandent des équipements supplémentaires pour améliorer leurs conditions de travail. Devons-nous allouer un budget pour cela ?');
INSERT INTO Question (id, idcat, question) VALUES (144, 10, 'Certains enseignants souhaitent que leurs performances soient évaluées de manière plus régulière et transparente. Devons-nous instaurer ce système d’évaluation ?');
INSERT INTO Question (id, idcat, question) VALUES (145, 10, 'Les ressources humaines proposent un programme de mentorat pour les nouveaux enseignants. Devons-nous investir dans cette initiative ?');
INSERT INTO Question (id, idcat, question) VALUES (146, 10, 'Devons-nous améliorer les conditions de travail des enseignants pour attirer plus de candidats ?');
INSERT INTO Question (id, idcat, question) VALUES (147, 10, 'Faut-il offrir des programmes de développement personnel aux employés ?');
INSERT INTO Question (id, idcat, question) VALUES (148, 10, 'Devons-nous instaurer un processus de recrutement plus rigoureux pour les nouveaux enseignants ?');
INSERT INTO Question (id, idcat, question) VALUES (149, 10, 'Faut-il mettre en place un programme de mentorat pour les nouveaux employés ?');
INSERT INTO Question (id, idcat, question) VALUES (150, 10, 'Devons-nous envisager des augmentations salariales pour des postes clés afin de conserver les talents ?');

-- Étudiants (idcat = 11)
INSERT INTO Question (id, idcat, question) VALUES (151, 11, 'Certains étudiants réclament des bourses pour les aider financièrement. Devons-nous augmenter le budget pour les bourses étudiantes ?');
INSERT INTO Question (id, idcat, question) VALUES (152, 11, 'Les étudiants souhaitent des horaires de cours plus flexibles, notamment en soirée. Devons-nous adapter les plannings pour répondre à cette demande ?');
INSERT INTO Question (id, idcat, question) VALUES (153, 11, 'Les étudiants demandent un accès accru aux ressources numériques pour leurs études. Devons-nous investir dans des abonnements et bases de données supplémentaires ?');
INSERT INTO Question (id, idcat, question) VALUES (154, 11, 'Certains étudiants demandent plus d’aides pour leur orientation professionnelle, comme des ateliers de rédaction de CV et des simulations d’entretien. Devons-nous mettre en place ces initiatives ?');
INSERT INTO Question (id, idcat, question) VALUES (155, 11, 'Les étudiants souhaitent des programmes d''échanges internationaux pour élargir leurs perspectives. Devons-nous allouer des fonds pour créer de tels programmes ?');
INSERT INTO Question (id, idcat, question) VALUES (156, 11, 'Des étudiants expriment un besoin d''accompagnement psychologique pour mieux gérer leur stress. Devons-nous financer davantage de services d''aide psychologique ?');
INSERT INTO Question (id, idcat, question) VALUES (157, 11, 'Les étudiants souhaitent que les enseignants soient plus disponibles pour des questions et du tutorat. Devons-nous encourager les enseignants à consacrer plus de temps au tutorat ?');
INSERT INTO Question (id, idcat, question) VALUES (158, 11, 'Certains étudiants aimeraient que les stages deviennent obligatoires dans leur parcours. Faut-il instaurer cette exigence ?');
INSERT INTO Question (id, idcat, question) VALUES (159, 11, 'Les étudiants proposent des clubs et associations pour enrichir leur expérience universitaire. Faut-il leur accorder des fonds pour cela ?');
INSERT INTO Question (id, idcat, question) VALUES (160, 11, 'Certains étudiants souhaitent que le cursus soit davantage axé sur les compétences pratiques. Faut-il réviser les programmes en ce sens ?');
INSERT INTO Question (id, idcat, question) VALUES (161, 11, 'Devons-nous renforcer le soutien psychologique des étudiants pour améliorer leur bien-être ?');
INSERT INTO Question (id, idcat, question) VALUES (162, 11, 'Faut-il développer des clubs étudiants pour favoriser leur engagement dans la vie universitaire ?');
INSERT INTO Question (id, idcat, question) VALUES (163, 11, 'Devons-nous créer un programme d’assistance financière pour les étudiants en difficulté ?');
INSERT INTO Question (id, idcat, question) VALUES (164, 11, 'Faut-il augmenter les services d’accompagnement pour les étudiants internationaux ?');
INSERT INTO Question (id, idcat, question) VALUES (165, 11, 'Devons-nous organiser des événements culturels pour renforcer le sentiment de communauté parmi les étudiants ?');

-- Administration universitaire (idcat = 1)
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (1, 1, 'Oui, concentrons nos ressources sur les programmes qui sont plus rentables.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (1, 2, 'Non, chaque programme mérite des ressources suffisantes.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (2, 1, 'Oui, les cours pratiques sont essentiels pour l''employabilité des étudiants.', 10, -10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (2, 2, 'Non, ces cours sont coûteux et demandent beaucoup de préparation.', 10, -10, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (3, 1, 'Oui, réduisons leur charge de travail pour améliorer leur bien-être.', -10, 10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (3, 2, 'Non, nous devons maintenir l’offre de cours pour garantir un bon taux de réussite.', 10, -10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (4, 1, 'Oui, cela permettra de financer les besoins de l’université.', 10, 0, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (4, 2, 'Non, gardons des frais accessibles pour tous.', -10, 0, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (5, 1, 'Oui, cela boostera notre budget et l’employabilité des étudiants.', 10, -10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (5, 2, 'Non, gardons notre indépendance dans le contenu des formations.', -10, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (6, 1, 'Oui, réduisons les effectifs pour équilibrer les coûts.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (6, 2, 'Non, gardons les effectifs actuels pour garantir la qualité de l’enseignement.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (7, 1, 'Oui, cela améliorera l''efficacité globale de l’université.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (7, 2, 'Non, il faut garder une diversité de formations.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (8, 1, 'Oui, les stages sont essentiels pour garantir de bonnes opportunités professionnelles.', 0, -10, 10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (8, 2, 'Non, trop de stages risquent de surcharger les étudiants et les enseignants.', 0, 10, -10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (9, 1, 'Oui, ces services ne sont pas essentiels.', 10, 0, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (9, 2, 'Non, ces services sont importants pour soutenir la réussite des étudiants.', -10, 0, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (10, 1, 'Oui, cela permettra de libérer des ressources financières.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (10, 2, 'Non, gardons les cours séparés pour maintenir la qualité de l’enseignement.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (11, 1, 'Oui, ouvrons de nouvelles formations pour répondre aux besoins du marché.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (11, 2, 'Non, concentrons-nous sur l''amélioration des formations existantes.', 10, 0, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (12, 1, 'Oui, augmentons les salaires pour attirer les meilleurs talents.', -10, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (12, 2, 'Non, nous devons rester dans les limites du budget actuel.', 10, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (13, 1, 'Oui, investissons dans la modernisation pour améliorer l''expérience des étudiants.', -10, 0, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (13, 2, 'Non, nous devons prioriser d''autres investissements.', 10, 0, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (14, 1, 'Oui, finançons davantage de programmes de mobilité internationale.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (14, 2, 'Non, nous ne pouvons pas nous permettre ces dépenses actuellement.', 10, 0, -10, -0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (15, 1, 'Oui, adoptons des politiques de développement durable pour l''avenir.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (15, 2, 'Non, concentrons-nous sur des priorités immédiates.', 10, 0, -10, 0);

-- Conseil pédagogique (idcat = 2)
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (16, 1, 'Oui, il est important de mettre à jour les programmes pour rester compétitifs.', -10, 10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (16, 2, 'Non, cela n’est pas prioritaire tant que les formations actuelles fonctionnent bien.', 10, -10, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (17, 1, 'Oui, investir dans les spécialisations émergentes renforcera notre attractivité et l’employabilité.', -10, 10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (17, 2, 'Non, les spécialisations actuelles sont suffisantes.', 10, -10, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (18, 1, 'Oui, ces méthodes pédagogiques moderniseront nos formations et renforceront la réussite des étudiants.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (18, 2, 'Non, ces innovations sont coûteuses et difficiles à mettre en place rapidement.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (19, 1, 'Oui, il faut embaucher plus de professeurs pour améliorer la qualité des cours.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (19, 2, 'Non, il faut maintenir les effectifs actuels pour des raisons budgétaires.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (20, 1, 'Oui, l’évaluation continue pourrait améliorer les résultats des étudiants.', -10, -10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (20, 2, 'Non, les examens finaux sont suffisants et demander moins de travail aux enseignants.', 10, 10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (21, 1, 'Oui, la formation des enseignants améliorera la qualité des cours.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (21, 2, 'Non, ce n’est pas nécessaire, les enseignants actuels sont déjà compétents.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (22, 1, 'Oui, il est crucial d’investir dans l’encadrement des stages pour maximiser l’insertion professionnelle.', -10, -10, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (22, 2, 'Non, les ressources allouées actuellement sont suffisantes.', 10, 10, -10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (23, 1, 'Oui, obtenir ces accréditations attirera plus d’étudiants et améliorera l’employabilité.', -10, 10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (23, 2, 'Non, ces accréditations ne sont pas indispensables.', 10, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (24, 1, 'Oui, les projets interdisciplinaires amélioreront l’employabilité des étudiants.', -10, 10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (24, 2, 'Non, ces projets demandent une organisation complexe et ne sont pas prioritaires.', 10, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (25, 1, 'Oui, une durée plus longue des stages permettra une meilleure insertion professionnelle.', 0, -10, 10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (25, 2, 'Non, il vaut mieux maintenir la durée actuelle des stages pour éviter de ralentir les études.', 0, 10, -10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (26, 1, 'Oui, proposons des cours de développement personnel pour enrichir leur préparation.', -10, 0, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (26, 2, 'Non, concentrons-nous uniquement sur les cours académiques.', 10, 0, -5, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (27, 1, 'Oui, accordons une plus grande autonomie aux enseignants.', 0, 10, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (27, 2, 'Non, il est important de garder un cadre strict pour assurer la cohérence des cours.', 0, -5, 0, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (28, 1, 'Oui, introduisons une formation continue obligatoire pour les enseignants.', -10, 5, 0, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (28, 2, 'Non, laissons la formation continue au choix des enseignants.', 0, -5, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (29, 1, 'Oui, développons des cours plus adaptés aux métiers de demain.', -15, 0, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (29, 2, 'Non, restons focalisés sur les cours actuels qui ont fait leurs preuves.', 10, 0, -10, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (30, 1, 'Oui, organisons des journées d’échange pour améliorer les programmes.', -10, 5, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (30, 2, 'Non, ces discussions informelles doivent rester spontanées et non institutionnalisées.', 5, 0, 0, -5);

-- Service financier (idcat = 3)
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (31, 1, 'Oui, nous devons réduire le nombre de bourses pour maintenir notre budget.', 10, 0, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (31, 2, 'Non, nous devons maintenir le soutien aux étudiants, quitte à réduire ailleurs.', -10, 0, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (32, 1, 'Oui, il est important de rénover les bâtiments pour assurer de bonnes conditions d’apprentissage.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (32, 2, 'Non, reportons ces rénovations pour concentrer les fonds sur d’autres priorités.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (33, 1, 'Oui, l’augmentation des salaires des enseignants est essentielle pour leur satisfaction et la qualité de l’enseignement.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (33, 2, 'Non, l’université ne peut se permettre cette dépense supplémentaire.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (34, 1, 'Oui, ces partenariats peuvent nous offrir des fonds supplémentaires.', 10, -10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (34, 2, 'Non, nous devons rester indépendants et ne pas nous lier à des intérêts privés.', -10, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (35, 1, 'Oui, réduisons les dépenses sur ces équipements pour économiser.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (35, 2, 'Non, ces équipements sont essentiels pour la qualité de l’enseignement et la réussite des étudiants.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (36, 1, 'Oui, fermer certains campus permettra de réduire nos frais de manière significative.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (36, 2, 'Non, ces campus sont importants pour l’accessibilité des étudiants à l’université.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (37, 1, 'Oui, l’investissement dans les technologies vertes est une bonne stratégie à long terme.', -10, 10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (37, 2, 'Non, les coûts initiaux sont trop élevés pour être absorbés cette année.', 10, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (38, 1, 'Oui, suivons les recommandations de l’audit pour économiser.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (38, 2, 'Non, ces services sont nécessaires au bon fonctionnement de l’université.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (39, 1, 'Oui, une augmentation des droits d’inscription compensera la baisse de revenus.', 10, 0, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (39, 2, 'Non, il faut trouver d’autres sources de financement pour ne pas pénaliser les étudiants.', -10, 0, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (40, 1, 'Oui, contracter un emprunt nous permettra d’agrandir nos infrastructures pour accueillir plus d’étudiants.', 10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (40, 2, 'Non, l’emprunt est risqué, il vaut mieux attendre d’avoir un budget suffisant.', -10, 0, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (41, 1, 'Oui, augmentons la part de financement privé pour compenser le manque de fonds publics.', 10, 0, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (41, 2, 'Non, restons sur un financement public pour éviter une dépendance au secteur privé.', -10, 0, 0, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (42, 1, 'Oui, augmentons les frais d’inscription pour maintenir la qualité.', 10, -5, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (42, 2, 'Non, maintenir les frais actuels est essentiel pour l’accessibilité.', -10, 0, 0, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (43, 1, 'Oui, mettons en place davantage de bourses pour les étudiants défavorisés.', -10, 0, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (43, 2, 'Non, nous devons prioriser d’autres investissements.', 10, 0, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (44, 1, 'Oui, lançons une campagne de collecte de fonds auprès des anciens élèves.', 10, 0, 0, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (44, 2, 'Non, concentrons nos efforts sur d’autres sources de financement.', -10, 0, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (45, 1, 'Oui, réduisons certains frais pour attirer davantage d’étudiants étrangers.', -10, 0, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (45, 2, 'Non, conserver les frais actuels est nécessaire pour la stabilité financière.', 10, 0, -5, -5);

-- Enseignants (idcat = 4)
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (46, 1, 'Oui, cela améliorera la recherche, mais réduira l’offre de cours.', -10, 10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (46, 2, 'Non, nous devons garder un bon équilibre entre enseignement et recherche.', 10, -10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (47, 1, 'Oui, cela pourrait rendre l’évaluation plus équitable pour les étudiants.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (47, 2, 'Non, cela compliquerait l’organisation des examens et affecterait l’uniformité des résultats.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (48, 1, 'Oui, améliorer les compétences pédagogiques est crucial pour la qualité de l’enseignement.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (48, 2, 'Non, les fonds sont limités et doivent être utilisés ailleurs.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (49, 1, 'Oui, offrir plus de flexibilité peut améliorer la satisfaction des enseignants.', -10, 10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (49, 2, 'Non, cela pourrait créer des difficultés d’organisation.', 10, -10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (50, 1, 'Oui, des cours plus pratiques amélioreront l’employabilité des étudiants.', 0, -10, 10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (50, 2, 'Non, les cours théoriques sont essentiels pour la formation académique complète.', 0, 10, -10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (51, 1, 'Oui, embauchons plus de personnel pour améliorer la qualité de l’enseignement.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (51, 2, 'Non, c’est trop coûteux et compliqué à gérer.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (52, 1, 'Oui, plus de matériel et d’outils numériques aideront à moderniser les cours.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (52, 2, 'Non, nous ne pouvons pas nous permettre ces dépenses supplémentaires.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (53, 1, 'Oui, cela augmentera l’accessibilité des formations à plus d’étudiants.', -10, 10, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (53, 2, 'Non, c’est trop coûteux pour notre budget actuel.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (54, 1, 'Oui, cela motivera les enseignants et encouragera des projets de qualité.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (54, 2, 'Non, il est trop coûteux d’augmenter les récompenses ou de réduire la charge de travail.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (55, 1, 'Oui, cela favorisera la collaboration interdisciplinaire et l’innovation.', -10, 10, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (55, 2, 'Non, cela perturberait trop l’organisation des cours.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (56, 1, 'Oui, incluons des compétences pratiques pour préparer les étudiants à des métiers spécifiques.', -10, 0, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (56, 2, 'Non, concentrons-nous sur un apprentissage théorique qui offre plus de polyvalence.', 10, 0, -5, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (57, 1, 'Oui, finançons des heures de formation pour les enseignants sur les nouvelles technologies.', -15, 5, 0, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (57, 2, 'Non, chaque enseignant doit gérer cette transition de manière autonome.', 10, -5, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (58, 1, 'Oui, offrons des formations en gestion de projet pour mieux préparer les étudiants.', -10, 0, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (58, 2, 'Non, concentrons-nous sur les programmes standard.', 10, 0, -5, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (59, 1, 'Oui, augmentons les salaires pour motiver les enseignants à donner des cours supplémentaires.', -20, 15, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (59, 2, 'Non, utilisons des ressources existantes pour couvrir ces besoins.', 10, -5, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (60, 1, 'Oui, encourageons l''adoption de pédagogies plus collaboratives.', -5, 5, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (60, 2, 'Non, laissons les enseignants choisir leur propre approche pédagogique.', 5, 0, 0, -5);

-- Service d'orientation et d'insertion professionnelle (idcat = 5)
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (61, 1, 'Oui, cela renforcera les liens avec les entreprises et améliorera l’insertion professionnelle.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (61, 2, 'Non, cela coûte trop cher pour peu de résultats concrets.', 10, 0, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (62, 1, 'Oui, le mentorat peut aider les étudiants à mieux s’orienter dans leur carrière.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (62, 2, 'Non, les fonds doivent être priorisés pour d’autres projets plus directs.', 10, 0, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (63, 1, 'Oui, un bilan de compétences aidera les étudiants à mieux comprendre leurs forces.', -10, 0, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (63, 2, 'Non, imposer un tel bilan pourrait être perçu comme une contrainte inutile.', 10, 0, -10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (64, 1, 'Oui, ces ateliers aideront les étudiants à mieux se préparer au marché du travail.', -10, 0, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (64, 2, 'Non, les ateliers devraient rester facultatifs pour ceux qui en ont besoin.', 10, 0, -10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (65, 1, 'Oui, cela aidera à promouvoir l’insertion professionnelle tout en gagnant des fonds.', 10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (65, 2, 'Non, nous devons garder notre indépendance par rapport aux entreprises.', -10, 0, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (66, 1, 'Oui, encourager l’entrepreneuriat est une bonne manière de diversifier les opportunités professionnelles.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (66, 2, 'Non, tous les étudiants ne sont pas intéressés par l’entrepreneuriat.', 10, 0, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (67, 1, 'Oui, plus de conseillers améliorera l’accompagnement des étudiants vers l’emploi.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (67, 2, 'Non, il est trop coûteux de recruter plus de personnel.', 10, 0, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (68, 1, 'Oui, des partenariats solides avec les entreprises locales renforceront l’insertion professionnelle.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (68, 2, 'Non, les partenariats ne sont pas toujours efficaces et coûtent trop cher à gérer.', 10, 0, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (69, 1, 'Oui, il est important d’anticiper les besoins des secteurs émergents.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (69, 2, 'Non, ces événements ne sont pas essentiels et coûtent cher à organiser.', 10, 0, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (70, 1, 'Oui, un réseau d’anciens étudiants pourrait grandement faciliter l’insertion des jeunes diplômés.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (70, 2, 'Non, créer un tel réseau demande trop de ressources.', 10, 0, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (71, 1, 'Oui, mettons en place un programme de mentorat avec des anciens élèves.', -10, 0, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (71, 2, 'Non, concentrons-nous sur les services déjà en place.', 10, 0, -5, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (72, 1, 'Oui, organisons des salons de recrutement sur le campus.', -15, 0, 15, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (72, 2, 'Non, encourageons les étudiants à trouver des opportunités par eux-mêmes.', 10, 0, -10, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (73, 1, 'Oui, intégrons des simulations d’entretiens dans le programme.', -5, 0, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (73, 2, 'Non, concentrons-nous sur les cours académiques.', 5, 0, -5, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (74, 1, 'Oui, embauchons plus de conseillers pour offrir des services personnalisés.', -20, 5, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (74, 2, 'Non, utilisons les ressources actuelles pour gérer cette demande.', 10, -5, -5, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (75, 1, 'Oui, créons un programme de stage de courte durée pour aider les étudiants à explorer.', -10, 0, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (75, 2, 'Non, laissons les étudiants trouver ces opportunités en dehors de l’université.', 10, 0, -10, -5);

-- Secrétariat pédagogique (idcat = 6)
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (76, 1, 'Oui, embaucher des assistants réduira les délais et améliorera le service.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (76, 2, 'Non, il faut optimiser les ressources existantes sans embaucher.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (77, 1, 'Oui, une gestion numérique améliorera l’efficacité et réduira les erreurs.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (77, 2, 'Non, cela coûte trop cher pour une amélioration non essentielle.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (78, 1, 'Oui, cela permettra de mieux accompagner les étudiants en période de stress.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (78, 2, 'Non, les permanences actuelles sont suffisantes pour la demande.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (79, 1, 'Oui, ces sessions aideront les étudiants à mieux s’organiser et à réussir.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (79, 2, 'Non, les étudiants peuvent trouver ces informations en ligne.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (80, 1, 'Oui, l’automatisation réduira la charge de travail et minimisera les erreurs.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (80, 2, 'Non, l’investissement est trop élevé pour un bénéfice limité.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (81, 1, 'Oui, des guides en ligne faciliteront les inscriptions et réduiront la charge du secrétariat.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (81, 2, 'Non, ces guides ne sont pas une priorité pour les ressources actuelles.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (82, 1, 'Oui, ces ressources aideront à mieux intégrer les étudiants internationaux.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (82, 2, 'Non, les étudiants internationaux doivent gérer leurs démarches comme les autres.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (83, 1, 'Oui, cela réduira les erreurs administratives et améliorera la qualité du service.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (83, 2, 'Non, les erreurs peuvent être corrigées sans formation coûteuse.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (84, 1, 'Oui, le suivi en ligne réduira les demandes répétées et facilitera l’organisation.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (84, 2, 'Non, le suivi en ligne est un luxe dont nous n’avons pas besoin.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (85, 1, 'Oui, cela améliorera la communication et évitera des malentendus.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (85, 2, 'Non, les informations sont déjà suffisamment accessibles.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (86, 1, 'Oui, digitalisons tous les documents académiques pour réduire la charge de travail.', -15, 5, 0, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (86, 2, 'Non, restons sur un format papier pour conserver les pratiques actuelles.', 10, -5, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (87, 1, 'Oui, mettons en place une hotline pour répondre aux questions administratives.', -10, 0, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (87, 2, 'Non, concentrons-nous sur l’amélioration des services existants.', 5, 0, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (88, 1, 'Oui, améliorons le système de prise de rendez-vous pour optimiser le temps de travail.', -10, 5, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (88, 2, 'Non, utilisons le système actuel pour gérer les rendez-vous.', 5, -5, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (89, 1, 'Oui, formons le personnel pour mieux gérer les situations de crise.', -15, 10, 0, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (89, 2, 'Non, investissons dans d’autres priorités pour le moment.', 10, -5, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (90, 1, 'Oui, ouvrons des heures supplémentaires pour répondre à la forte demande.', -20, 5, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (90, 2, 'Non, nous devons nous en tenir aux heures habituelles.', 10, -5, 0, -10);

-- Partenaires professionnels (idcat = 7)
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (91, 1, 'Oui, cela donnera aux étudiants une expérience pratique précieuse.', -10, 0, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (91, 2, 'Non, cela pourrait interférer avec le programme pédagogique actuel.', 0, 10, -10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (92, 1, 'Oui, le parrainage est une opportunité de financement non négligeable.', 10, -10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (92, 2, 'Non, le contenu doit rester indépendant des intérêts des partenaires.', -10, 10, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (93, 1, 'Oui, cette bourse pourrait soutenir des étudiants talentueux.', 10, -10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (93, 2, 'Non, les données de performance doivent rester confidentielles.', -10, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (94, 1, 'Oui, cela permettra aux étudiants de travailler dans des conditions optimales.', 10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (94, 2, 'Non, la formation doit rester ouverte à tous sans quota.', -10, 10, -10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (95, 1, 'Oui, ce concours pourrait motiver les étudiants et leur ouvrir des portes.', -10, 0, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (95, 2, 'Non, ce concours pourrait détourner les étudiants de leurs études.', 0, 10, -10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (96, 1, 'Oui, ces certifications seront bénéfiques pour l''employabilité des étudiants.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (96, 2, 'Non, modifier les programmes est trop contraignant.', 10, 10, -10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (97, 1, 'Oui, des stages rémunérés peuvent alléger la charge financière des étudiants.', -10, -10, 10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (97, 2, 'Non, réduire la durée des études peut compromettre leur préparation.', 0, 10, -10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (98, 1, 'Oui, ces conférences enrichiront la perspective des étudiants.', 0, 0, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (98, 2, 'Non, le programme pédagogique est déjà dense.', 0, 10, -10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (99, 1, 'Oui, ces stages à l''étranger sont un atout majeur pour les étudiants.', -10, 0, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (99, 2, 'Non, le coût est trop élevé pour l''université.', 10, 0, -10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (100, 1, 'Oui, ce financement aidera à développer l''université.', 10, -10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (100, 2, 'Non, il est essentiel de garder l''indépendance de notre gouvernance.', -10, 10, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (101, 1, 'Oui, multiplions les partenariats avec des entreprises pour offrir plus de stages.', -10, 0, 15, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (101, 2, 'Non, concentrons-nous sur les partenariats existants.', 5, 0, -10, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (102, 1, 'Oui, créons des programmes de formation adaptés aux besoins des entreprises.', -15, 0, 20, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (102, 2, 'Non, privilégions une formation plus généraliste pour les étudiants.', 10, 0, -10, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (103, 1, 'Oui, organisons des journées de réseautage sur le campus.', -10, 0, 15, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (103, 2, 'Non, encourageons les étudiants à chercher des contacts par leurs propres moyens.', 5, 0, -10, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (104, 1, 'Oui, investissons dans des projets communs pour développer de nouvelles compétences.', -15, 5, 15, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (104, 2, 'Non, concentrons nos ressources sur des projets académiques classiques.', 10, -5, -10, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (105, 1, 'Oui, consultons les entreprises pour qu’elles contribuent à la conception des programmes.', -10, 0, 20, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (105, 2, 'Non, gardons une autonomie complète dans la création des programmes.', 10, 0, -10, -5);

-- Ministere (idcat=8)
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (106, 1, 'Oui, le financement supplémentaire est précieux pour l''université.', 10, -10, 10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (106, 2, 'Non, nous ne devons pas sacrifier la qualité pour augmenter les effectifs.', -10, 10, -10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (107, 1, 'Oui, cela aidera les étudiants à se spécialiser dans des secteurs en demande.', 10, -10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (107, 2, 'Non, l''université doit garder un choix de programmes diversifié.', -10, 10, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (108, 1, 'Oui, cela permettra à nos diplômes d’être reconnus internationalement.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (108, 2, 'Non, ce changement soudain pourrait perturber le cursus des étudiants.', 0, 10, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (109, 1, 'Oui, ce financement est important pour améliorer les infrastructures.', 10, 0, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (109, 2, 'Non, nous devons nous concentrer sur la réussite des étudiants sans pression externe.', 0, 10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (110, 1, 'Oui, les étudiants internationaux apporteront de la diversité à l''université.', -10, -10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (110, 2, 'Non, l''université doit se concentrer sur les étudiants nationaux.', 10, 10, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (111, 1, 'Oui, ces cours en ligne rendront les formations plus accessibles.', -10, -10, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (111, 2, 'Non, nous devons prioriser la qualité de l’enseignement en présentiel.', 10, 10, -10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (112, 1, 'Oui, ce programme d’évaluation contribuera à améliorer la qualité de l''enseignement.', 0, -10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (112, 2, 'Non, cette évaluation peut introduire des biais et affecter la satisfaction des enseignants.', 0, 10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (113, 1, 'Oui, cela rendra l’université plus accessible pour tous.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (113, 2, 'Non, cette baisse de revenus pourrait nous mettre en difficulté financière.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (114, 1, 'Oui, cela permettra aux étudiants de gagner en expérience professionnelle.', -10, -10, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (114, 2, 'Non, trop de stages pourraient nuire au parcours académique.', 10, 10, -10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (115, 1, 'Oui, concentrons nos ressources sur les programmes stratégiques.', 10, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (115, 2, 'Non, tous les programmes méritent d''être soutenus.', -10, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (116, 1, 'Oui, investissons plus de ressources pour préparer le rapport annuel.', -10, 5, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (116, 2, 'Non, utilisons les ressources existantes pour le rapport annuel.', 10, -5, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (117, 1, 'Oui, suivons les nouvelles normes imposées par le ministère, même si elles augmentent les coûts.', -15, 0, 5, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (117, 2, 'Non, cherchons des moyens de réduire les coûts tout en restant conformes aux exigences.', 10, -5, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (118, 1, 'Oui, conformons-nous aux exigences du ministère sur la transition écologique.', -10, 5, 15, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (118, 2, 'Non, limitons les investissements liés à la transition écologique pour l’instant.', 10, -5, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (119, 1, 'Oui, adoptons une politique stricte pour respecter les exigences de financement public.', -10, 0, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (119, 2, 'Non, cherchons à maintenir la flexibilité tout en respectant les exigences.', 10, -5, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (120, 1, 'Oui, développons des programmes pour répondre aux critères de diversité du ministère.', -15, 10, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (120, 2, 'Non, conservons les programmes actuels et limitons l’investissement dans la diversité.', 10, -5, 0, -5);

-- Cellule de Qualité et d'Évaluation (idcat = 9)
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (121, 1, 'Oui, il est important de revoir les programmes pour maintenir un haut niveau de satisfaction.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (121, 2, 'Non, une révision complète serait trop coûteuse pour l’instant.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (122, 1, 'Oui, il est nécessaire d''assurer la qualité des cours.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (122, 2, 'Non, cela pourrait être mal perçu et démotiver les enseignants.', 0, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (123, 1, 'Oui, une restructuration pourrait améliorer la réussite.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (123, 2, 'Non, cela risquerait de perturber les étudiants en cours de formation.', 0, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (124, 1, 'Oui, un suivi des diplômés est important pour adapter les programmes.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (124, 2, 'Non, cela serait trop coûteux et complexe à gérer.', 10, 0, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (125, 1, 'Oui, il est crucial d’être en phase avec les standards.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (125, 2, 'Non, cela pourrait être coûteux et perturber les processus actuels.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (126, 1, 'Oui, une évaluation approfondie aidera à améliorer ces programmes.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (126, 2, 'Non, nous devons limiter les coûts cette année.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (127, 1, 'Oui, un suivi personnalisé peut fortement améliorer la réussite.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (127, 2, 'Non, cela serait trop coûteux à long terme.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (128, 1, 'Oui, cela améliorerait les résultats dans les cours difficiles.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (128, 2, 'Non, cela demanderait trop de ressources.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (129, 1, 'Oui, les cours en ligne interactifs sont un investissement dans la qualité.', -10, 10, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (129, 2, 'Non, nous devons prioriser les cours en présentiel pour le moment.', 10, -10, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (130, 1, 'Oui, une auto-évaluation régulière assurera une amélioration continue.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (130, 2, 'Non, une auto-évaluation trop fréquente risquerait d’alourdir la charge des enseignants.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (131, 1, 'Oui, engageons un audit externe pour garantir la qualité de nos formations.', -15, 10, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (131, 2, 'Non, utilisons les ressources internes pour évaluer la qualité.', 10, -5, -5, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (132, 1, 'Oui, mettons en place un système de feedback anonyme pour améliorer nos programmes.', -10, 10, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (132, 2, 'Non, privilégions les méthodes de feedback traditionnelles.', 5, -5, -5, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (133, 1, 'Oui, organisons des évaluations semestrielles des enseignants par les étudiants.', -10, 5, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (133, 2, 'Non, laissons les évaluations se faire de manière informelle.', 5, -5, -5, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (134, 1, 'Oui, publions un rapport annuel sur la qualité et les résultats des programmes.', -15, 5, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (134, 2, 'Non, limitons la publication des résultats à des rapports internes.', 10, -5, -5, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (135, 1, 'Oui, intégrons la qualité dans chaque aspect du processus académique, y compris les cours en ligne.', -10, 10, 15, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (135, 2, 'Non, concentrons-nous sur la qualité des cours en présentiel uniquement.', 10, -5, -5, -5);


-- Ressources Humaines (idcat = 10)
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (136, 1, 'Oui, cela améliorera leur satisfaction et leur motivation.', -10, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (136, 2, 'Non, cela dépasserait notre budget pour cette année.', 10, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (137, 1, 'Oui, cela réduira la surcharge et augmentera leur satisfaction.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (137, 2, 'Non, cela coûterait trop cher pour cette année.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (138, 1, 'Oui, une politique attractive peut attirer de nouveaux talents.', -10, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (138, 2, 'Non, la rémunération actuelle est suffisante.', 10, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (139, 1, 'Oui, cela pourrait réduire le stress et améliorer leur satisfaction.', 0, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (139, 2, 'Non, cela risque de compliquer la planification des cours.', 0, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (140, 1, 'Oui, cela peut améliorer les méthodes pédagogiques.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (140, 2, 'Non, cela représente un investissement important pour l’instant.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (141, 1, 'Oui, cela pourrait encourager la recherche et le développement.', -10, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (141, 2, 'Non, cela pourrait créer un manque de personnel.', 10, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (142, 1, 'Oui, cela favorise la diversité et l''inclusion.', -10, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (142, 2, 'Non, cela peut poser des questions d’équité.', 10, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (143, 1, 'Oui, cela améliorera leurs conditions de travail.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (143, 2, 'Non, l’achat d’équipements supplémentaires serait trop coûteux.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (144, 1, 'Oui, une évaluation régulière est essentielle pour le suivi de performance.', -10, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (144, 2, 'Non, trop d’évaluations risquent de stresser les enseignants.', 10, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (145, 1, 'Oui, le mentorat peut aider les nouveaux enseignants à s''intégrer.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (145, 2, 'Non, cela demanderait trop de temps aux enseignants seniors.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (146, 1, 'Oui, améliorons les conditions de travail des enseignants pour attirer plus de candidats.', -10, 10, 5, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (146, 2, 'Non, concentrons-nous sur la fidélisation des enseignants existants.', 10, -5, -5, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (147, 1, 'Oui, offrons des programmes de développement personnel aux employés.', -5, 10, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (147, 2, 'Non, privilégions la formation académique plutôt que le développement personnel.', 10, -5, -5, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (148, 1, 'Oui, instaurons un processus de recrutement plus rigoureux pour les nouveaux enseignants.', -10, 5, 10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (148, 2, 'Non, facilitons le recrutement pour attirer davantage de candidats.', 10, -5, -5, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (149, 1, 'Oui, mettons en place un programme de mentorat pour les nouveaux employés.', -5, 10, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (149, 2, 'Non, laissons les nouveaux employés s’adapter à leur rythme.', 10, -5, -5, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (150, 1, 'Oui, envisageons des augmentations salariales pour des postes clés afin de conserver les talents.', -15, 5, 5, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (150, 2, 'Non, évitons d’augmenter les salaires et privilégions d’autres avantages.', 10, -5, -5, -5);


-- Étudiants (idcat = 11)
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (151, 1, 'Oui, un soutien financier pourrait aider les étudiants en difficulté.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (151, 2, 'Non, notre budget actuel ne permet pas d’augmenter les bourses.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (152, 1, 'Oui, des horaires flexibles pourraient améliorer la réussite des étudiants.', -10, 0, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (152, 2, 'Non, cela rendrait la gestion des emplois du temps plus compliquée.', 10, 0, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (153, 1, 'Oui, cela enrichirait les ressources disponibles pour leurs études.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (153, 2, 'Non, cela serait trop coûteux pour notre budget actuel.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (154, 1, 'Oui, cela augmenterait leurs chances de trouver un emploi après leurs études.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (154, 2, 'Non, cela demanderait trop de ressources pour l’instant.', 10, 0, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (155, 1, 'Oui, les échanges internationaux enrichissent l’expérience universitaire.', -10, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (155, 2, 'Non, ces programmes d’échanges coûtent trop cher.', 10, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (156, 1, 'Oui, ces services sont essentiels pour leur bien-être.', -10, 0, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (156, 2, 'Non, cela représente un coût trop important pour notre budget.', 10, 0, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (157, 1, 'Oui, un tutorat renforcé augmenterait le taux de réussite.', -10, 10, 0, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (157, 2, 'Non, cela surchargerait les enseignants.', 10, -10, 0, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (158, 1, 'Oui, les stages obligatoires améliorent l’employabilité.', 0, -10, 10, -10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (158, 2, 'Non, cela risquerait de prolonger leur durée d’études.', 0, 10, -10, 10);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (159, 1, 'Oui, les clubs enrichissent leur expérience universitaire.', -10, 10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (159, 2, 'Non, cela n’est pas prioritaire dans notre budget.', 10, -10, 0, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (160, 1, 'Oui, un apprentissage plus pratique augmentera leur employabilité.', -10, 0, 10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4)
VALUES (160, 2, 'Non, les cours actuels couvrent déjà bien les bases théoriques.', 10, 0, -10, 0);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (161, 1, 'Oui, renforçons le soutien psychologique des étudiants pour améliorer leur bien-être.', -5, 10, 0, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (161, 2, 'Non, concentrons-nous sur d’autres priorités pour améliorer la vie universitaire.', 10, -5, 0, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (162, 1, 'Oui, développons des clubs étudiants pour favoriser leur engagement dans la vie universitaire.', -5, 5, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (162, 2, 'Non, les clubs étudiants ne sont pas une priorité et peuvent entraîner des distractions.', 10, -5, -5, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (163, 1, 'Oui, créons un programme d’assistance financière pour les étudiants en difficulté.', -10, 5, 5, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (163, 2, 'Non, privilégions d’autres moyens pour soutenir les étudiants en difficulté financière.', 10, -5, -10, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (164, 1, 'Oui, augmentons les services d’accompagnement pour les étudiants internationaux.', -5, 5, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (164, 2, 'Non, les étudiants internationaux doivent s’adapter aux ressources existantes.', 10, -5, -5, -5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (165, 1, 'Oui, organisons des événements culturels pour renforcer le sentiment de communauté parmi les étudiants.', -5, 10, 10, 5);
INSERT INTO Reponse (idquestion, idreponse, reponse, j1, j2, j3, j4) 
VALUES (165, 2, 'Non, cela représente un coût inutile et pourrait être une distraction pour les étudiants.', 10, -5, -5, -5);

-- Insertion dans la table Formation
INSERT INTO Formation VALUES (1, 'BUT Informatique', 2, 140, 50, 'Parcours Réalisation et Développement'); 
INSERT INTO Formation VALUES (2, 'BUT Informatique', 5, 160, 55, 'Parcours Réseaux et Sécurité'); 
INSERT INTO Formation VALUES (3, 'Licence Mathématiques', 7, 180, 60, 'Option Analyse Numérique'); 
INSERT INTO Formation VALUES (4, 'Licence Physique', 3, 150, 45, 'Option Physique Quantique'); 
INSERT INTO Formation VALUES (5, 'Licence Chimie', 4, 120, 50, 'Option Chimie Organique'); 
INSERT INTO Formation VALUES (6, 'BUT Génie Civil', 3, 200, 70, 'Parcours Bâtiments et Travaux Publics'); 
INSERT INTO Formation VALUES (7, 'BUT Génie Civil', 5, 180, 65, 'Parcours Éco-construction'); 
INSERT INTO Formation VALUES (8, 'Licence Économie', 6, 100, 40, 'Option Finance Publique'); 
INSERT INTO Formation VALUES (9, 'Licence Droit', 3, 120, 50, 'Option Droit des Affaires'); 
INSERT INTO Formation VALUES (10, 'Licence Histoire', 2, 90, 35, 'Option Archéologie');
INSERT INTO Formation VALUES (11, 'Master Informatique', 3, 90, 100, 'Parcours Intelligence Artificielle'); 
INSERT INTO Formation VALUES (12, 'Master Biologie', 8, 200, 120, 'Parcours Biotechnologies'); 
INSERT INTO Formation VALUES (13, 'Master Économie', 4, 150, 110, 'Parcours Développement Durable'); 
INSERT INTO Formation VALUES (14, 'Licence Mathématiques', 6, 160, 50, 'Option Statistiques Appliquées'); 
INSERT INTO Formation VALUES (15, 'Licence Physique', 4, 130, 45, 'Option Optique Quantique'); 
INSERT INTO Formation VALUES (16, 'Licence Chimie', 6, 140, 50, 'Option Chimie Analytique'); 
INSERT INTO Formation VALUES (17, 'Licence Génie Civil', 3, 180, 60, 'Option Structures et Bâtiments'); 
INSERT INTO Formation VALUES (18, 'Master Droit', 5, 220, 130, 'Parcours Droit International'); 
INSERT INTO Formation VALUES (19, 'Master Informatique', 4, 180, 100, 'Parcours Big Data'); 
INSERT INTO Formation VALUES (20, 'BUT GEA', 3, 110, 40, 'Option Comptabilité et Finances'); 
INSERT INTO Formation VALUES (21, 'Master Physique', 5, 210, 150, 'Parcours Mécanique Quantique'); 
INSERT INTO Formation VALUES (22, 'Licence Histoire', 3, 110, 40, 'Option Histoire des Civilisations'); 
INSERT INTO Formation VALUES (23, 'Licence Géographie', 4, 140, 45, 'Option Géopolitique'); 
INSERT INTO Formation VALUES (24, 'Licence Informatique', 6, 200, 80, 'Option Développement Web'); 
INSERT INTO Formation VALUES (25, 'Master Chimie', 3, 150, 100, 'Parcours Chimie des Matériaux'); 
INSERT INTO Formation VALUES (26, 'Master Biologie', 7, 170, 110, 'Parcours Écologie'); 
INSERT INTO Formation VALUES (27, 'Licence Économie', 5, 130, 60, 'Option Microéconomie'); 
INSERT INTO Formation VALUES (28, 'Master Économie', 4, 160, 120, 'Parcours Macroéconomie'); 
INSERT INTO Formation VALUES (29, 'BUT Génie Électrique', 3, 160, 55, 'Parcours Électronique'); 
INSERT INTO Formation VALUES (30, 'Master Informatique', 4, 210, 110, 'Parcours Sécurité Informatique');
INSERT INTO Formation VALUES (31, 'Licence Droit', 3, 130, 50, 'Option Droit Pénal'); 
INSERT INTO Formation VALUES (32, 'Licence Sociologie', 5, 140, 45, 'Option Sociologie Urbaine'); 
INSERT INTO Formation VALUES (33, 'Licence Lettres', 2, 120, 40, 'Option Littérature Comparée'); 
INSERT INTO Formation VALUES (34, 'Master Génie Civil', 5, 200, 120, 'Parcours Génie Urbain'); 
INSERT INTO Formation VALUES (35, 'Master Économie', 6, 180, 130, 'Parcours Monnaie et Finances'); 
INSERT INTO Formation VALUES (36, 'Licence Informatique', 3, 150, 55, 'Option Réseaux Informatiques'); 
INSERT INTO Formation VALUES (37, 'Master Droit', 5, 220, 140, 'Parcours Droit des Affaires Internationales'); 
INSERT INTO Formation VALUES (38, 'Master Chimie', 4, 150, 110, 'Parcours Chimie Verte'); 
INSERT INTO Formation VALUES (39, 'Licence Biologie', 3, 140, 50, 'Option Génétique'); 
INSERT INTO Formation VALUES (40, 'Master Génie Civil', 5, 210, 130, 'Parcours Construction Durable'); 
INSERT INTO Formation VALUES (41, 'Master Histoire', 3, 100, 70, 'Parcours Archéologie'); 
INSERT INTO Formation VALUES (42, 'Licence Sociologie', 2, 120, 45, 'Option Sociologie du Travail'); 
INSERT INTO Formation VALUES (43, 'Master Économie', 6, 190, 120, 'Parcours Politique Économique'); 
INSERT INTO Formation VALUES (44, 'Licence Informatique', 3, 160, 55, 'Option Programmation Mobile'); 
INSERT INTO Formation VALUES (45, 'Licence Physique', 4, 180, 60, 'Option Mécanique'); 
INSERT INTO Formation VALUES (46, 'Licence Chimie', 5, 140, 55, 'Option Chimie des Environnements'); 
INSERT INTO Formation VALUES (47, 'Master Biologie', 7, 210, 140, 'Parcours Biologie Marine'); 
INSERT INTO Formation VALUES (48, 'Master Droit', 4, 190, 130, 'Parcours Droit Public'); 
INSERT INTO Formation VALUES (49, 'Licence Droit', 3, 130, 50, 'Option Droit des Contrats'); 
INSERT INTO Formation VALUES (50, 'Licence Histoire', 2, 100, 35, 'Option Histoire Moderne'); 
INSERT INTO Formation VALUES (51, 'Licence Économie', 4, 130, 60, 'Option Économie du Travail'); 
INSERT INTO Formation VALUES (52, 'Licence Mathématiques', 6, 160, 70, 'Option Calcul Scientifique'); 
INSERT INTO Formation VALUES (53, 'Licence Informatique', 5, 180, 75, 'Option Systèmes et Réseaux'); 
INSERT INTO Formation VALUES (54, 'Master Génie Civil', 4, 200, 100, 'Parcours Génie des Infrastructures'); 
INSERT INTO Formation VALUES (55, 'Master Chimie', 5, 170, 100, 'Parcours Chimie Biologique'); 
INSERT INTO Formation VALUES (56, 'Licence Sociologie', 3, 140, 50, 'Option Sociologie des Médias'); 
INSERT INTO Formation VALUES (57, 'Licence Génie Civil', 5, 180, 60, 'Option Construction Écologique'); 
INSERT INTO Formation VALUES (58, 'Master Biologie', 6, 200, 120, 'Parcours Biologie Cellulaire'); 
INSERT INTO Formation VALUES (59, 'Master Informatique', 3, 130, 90, 'Parcours Cloud Computing'); 
INSERT INTO Formation VALUES (60, 'Licence Droit', 4, 150, 65, 'Option Droit International Public'); 

-- Insertion dans la table ChoixFormation
INSERT INTO ChoixFormation VALUES (1, 1, -10, -2, 5, 3); 
INSERT INTO ChoixFormation VALUES (1, 2, 5, 1, 0, 0); 
INSERT INTO ChoixFormation VALUES (2, 1, -5, 0, 5, 5); 
INSERT INTO ChoixFormation VALUES (2, 2, 10, 0, -2, 0); 
INSERT INTO ChoixFormation VALUES (3, 1, -5, 3, 7, 6); 
INSERT INTO ChoixFormation VALUES (3, 2, 10, -1, 0, 0); 
INSERT INTO ChoixFormation VALUES (4, 1, -2, 0, 4, 3); 
INSERT INTO ChoixFormation VALUES (4, 2, 5, 0, 2, 3); 
INSERT INTO ChoixFormation VALUES (5, 1, -1, 0, 3, 2); 
INSERT INTO ChoixFormation VALUES (5, 2, 5, 2, 0, 2);
INSERT INTO ChoixFormation VALUES (6, 1, -5, -2, 3, 4);
INSERT INTO ChoixFormation VALUES (6, 2, 10, 0, -3, 0);
INSERT INTO ChoixFormation VALUES (7, 1, -10, -3, 5, 4);
INSERT INTO ChoixFormation VALUES (7, 2, 15, 0, 2, 3);
INSERT INTO ChoixFormation VALUES (8, 1, -10, -1, 2, 5);
INSERT INTO ChoixFormation VALUES (8, 2, 5, 0, -2, 0);
INSERT INTO ChoixFormation VALUES (9, 1, -5, -2, 4, 4);
INSERT INTO ChoixFormation VALUES (9, 2, 8, 0, 1, 1);
INSERT INTO ChoixFormation VALUES (10, 1, -7, -3, 3, 2);
INSERT INTO ChoixFormation VALUES (10, 2, 12, 1, 0, 0);
INSERT INTO ChoixFormation VALUES (11, 1, -10, 2, 5, 7);
INSERT INTO ChoixFormation VALUES (11, 2, 8, 0, -1, 0);
INSERT INTO ChoixFormation VALUES (12, 1, -15, 3, 7, 8);
INSERT INTO ChoixFormation VALUES (12, 2, 10, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (13, 1, -10, 2, 6, 5);
INSERT INTO ChoixFormation VALUES (13, 2, 8, 0, 0, 2);
INSERT INTO ChoixFormation VALUES (14, 1, -6, 1, 5, 6);
INSERT INTO ChoixFormation VALUES (14, 2, 12, 0, 1, 1);
INSERT INTO ChoixFormation VALUES (15, 1, -8, -2, 4, 3);
INSERT INTO ChoixFormation VALUES (15, 2, 10, 1, 0, 0);
INSERT INTO ChoixFormation VALUES (16, 1, -7, 1, 3, 4);
INSERT INTO ChoixFormation VALUES (16, 2, 15, 0, 0, 1);
INSERT INTO ChoixFormation VALUES (17, 1, -5, -1, 4, 5);
INSERT INTO ChoixFormation VALUES (17, 2, 12, 0, 0, 2);
INSERT INTO ChoixFormation VALUES (18, 1, -12, 4, 6, 6);
INSERT INTO ChoixFormation VALUES (18, 2, 8, 1, 0, 0);
INSERT INTO ChoixFormation VALUES (19, 1, -8, 3, 7, 6);
INSERT INTO ChoixFormation VALUES (19, 2, 15, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (20, 1, -10, -2, 4, 5);
INSERT INTO ChoixFormation VALUES (20, 2, 12, 0, 1, 2);
INSERT INTO ChoixFormation VALUES (21, 1, -8, 4, 5, 6);
INSERT INTO ChoixFormation VALUES (21, 2, 14, 0, -2, 0);
INSERT INTO ChoixFormation VALUES (22, 1, -6, 1, 3, 5);
INSERT INTO ChoixFormation VALUES (22, 2, 10, 0, 0, 1);
INSERT INTO ChoixFormation VALUES (23, 1, -5, 1, 4, 4);
INSERT INTO ChoixFormation VALUES (23, 2, 15, 0, 2, 3);
INSERT INTO ChoixFormation VALUES (24, 1, -10, 2, 4, 6);
INSERT INTO ChoixFormation VALUES (24, 2, 13, 0, -1, 0);
INSERT INTO ChoixFormation VALUES (25, 1, -12, 2, 6, 7);
INSERT INTO ChoixFormation VALUES (25, 2, 10, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (26, 1, -15, 3, 5, 6);
INSERT INTO ChoixFormation VALUES (26, 2, 12, 0, 1, 0);
INSERT INTO ChoixFormation VALUES (27, 1, -6, 2, 5, 4);
INSERT INTO ChoixFormation VALUES (27, 2, 10, 0, -2, 0);
INSERT INTO ChoixFormation VALUES (28, 1, -8, 3, 6, 5);
INSERT INTO ChoixFormation VALUES (28, 2, 14, 0, 1, 1);
INSERT INTO ChoixFormation VALUES (29, 1, -7, 2, 4, 6);
INSERT INTO ChoixFormation VALUES (29, 2, 10, 0, -2, 2);
INSERT INTO ChoixFormation VALUES (30, 1, -10, 3, 5, 6);
INSERT INTO ChoixFormation VALUES (30, 2, 15, 0, 1, 1);
INSERT INTO ChoixFormation VALUES (31, 1, -5, 2, 3, 4);
INSERT INTO ChoixFormation VALUES (31, 2, 12, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (32, 1, -7, 1, 4, 5);
INSERT INTO ChoixFormation VALUES (32, 2, 15, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (33, 1, -6, 2, 5, 3);
INSERT INTO ChoixFormation VALUES (33, 2, 10, 0, -1, 0);
INSERT INTO ChoixFormation VALUES (34, 1, -10, 3, 6, 5);
INSERT INTO ChoixFormation VALUES (34, 2, 12, 0, 2, 2);
INSERT INTO ChoixFormation VALUES (35, 1, -12, 4, 7, 6);
INSERT INTO ChoixFormation VALUES (35, 2, 10, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (36, 1, -8, 2, 4, 3);
INSERT INTO ChoixFormation VALUES (36, 2, 14, 0, -1, 0);
INSERT INTO ChoixFormation VALUES (37, 1, -6, 3, 5, 6);
INSERT INTO ChoixFormation VALUES (37, 2, 12, 0, 2, 1);
INSERT INTO ChoixFormation VALUES (38, 1, -7, 3, 4, 5);
INSERT INTO ChoixFormation VALUES (38, 2, 13, 0, -2, 2);
INSERT INTO ChoixFormation VALUES (39, 1, -5, 2, 4, 5);
INSERT INTO ChoixFormation VALUES (39, 2, 12, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (40, 1, -8, 3, 5, 6);
INSERT INTO ChoixFormation VALUES (40, 2, 15, 0, 2, 0);
INSERT INTO ChoixFormation VALUES (41, 1, -10, 2, 5, 6);
INSERT INTO ChoixFormation VALUES (41, 2, 12, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (42, 1, -5, 1, 4, 4);
INSERT INTO ChoixFormation VALUES (42, 2, 15, 0, -2, 1);
INSERT INTO ChoixFormation VALUES (43, 1, -6, 2, 5, 5);
INSERT INTO ChoixFormation VALUES (43, 2, 10, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (44, 1, -8, 3, 4, 5);
INSERT INTO ChoixFormation VALUES (44, 2, 14, 0, -1, 0);
INSERT INTO ChoixFormation VALUES (45, 1, -7, 3, 4, 4);
INSERT INTO ChoixFormation VALUES (45, 2, 13, 0, 2, 3);
INSERT INTO ChoixFormation VALUES (46, 1, -6, 2, 5, 4);
INSERT INTO ChoixFormation VALUES (46, 2, 10, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (47, 1, -12, 4, 7, 8);
INSERT INTO ChoixFormation VALUES (47, 2, 10, 0, -1, 0);
INSERT INTO ChoixFormation VALUES (48, 1, -8, 2, 5, 5);
INSERT INTO ChoixFormation VALUES (48, 2, 14, 0, 1, 2);
INSERT INTO ChoixFormation VALUES (49, 1, -6, 1, 4, 6);
INSERT INTO ChoixFormation VALUES (49, 2, 12, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (50, 1, -10, 2, 5, 5);
INSERT INTO ChoixFormation VALUES (50, 2, 12, 0, -2, 2);
INSERT INTO ChoixFormation VALUES (51, 1, -7, 3, 4, 6);
INSERT INTO ChoixFormation VALUES (51, 2, 13, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (52, 1, -10, 3, 5, 5);
INSERT INTO ChoixFormation VALUES (52, 2, 12, 0, 0, 1);
INSERT INTO ChoixFormation VALUES (53, 1, -12, 4, 6, 7);
INSERT INTO ChoixFormation VALUES (53, 2, 10, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (54, 1, -8, 2, 4, 4);
INSERT INTO ChoixFormation VALUES (54, 2, 14, 0, -2, 1);
INSERT INTO ChoixFormation VALUES (55, 1, -6, 1, 3, 3);
INSERT INTO ChoixFormation VALUES (55, 2, 15, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (56, 1, -5, 2, 4, 5);
INSERT INTO ChoixFormation VALUES (56, 2, 12, 0, 1, 2);
INSERT INTO ChoixFormation VALUES (57, 1, -8, 3, 5, 5);
INSERT INTO ChoixFormation VALUES (57, 2, 10, 0, 0, 1);
INSERT INTO ChoixFormation VALUES (58, 1, -10, 2, 4, 4);
INSERT INTO ChoixFormation VALUES (58, 2, 12, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (59, 1, -6, 1, 3, 3);
INSERT INTO ChoixFormation VALUES (59, 2, 13, 0, 0, 0);
INSERT INTO ChoixFormation VALUES (60, 1, -8, 2, 4, 4);
INSERT INTO ChoixFormation VALUES (60, 2, 12, 0, 0, 0);