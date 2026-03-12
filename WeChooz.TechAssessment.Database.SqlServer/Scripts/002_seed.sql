

IF NOT EXISTS (SELECT 1 FROM dbo.Formateurs)
BEGIN
    INSERT INTO dbo.Formateurs (Nom, Prenom) VALUES
    ('Dupont', 'Jean'),
    ('Martin', 'Marie'),
    ('Lambert', 'Pierre'),
    ('Bernard', 'Lucie'),
    ('Robert', 'Camille'),
    ('Petit', 'Sarah'),
    ('Roux', 'Antoine'),
    ('Fournier', 'Inès'),
    ('Girard', 'Chloé'),
    ('Lopez', 'Karim'),
    ('Nguyen', 'Linh'),
    ('Garcia', 'Emma'),
    ('Durand', 'Paul'),
    ('Leclerc', 'Anaïs'),
    ('Perrin', 'Youssef'),
    ('Moreau', 'Julie'),
    ('Faure', 'Nicolas'),
    ('Gauthier', 'Zoé'),
    ('Blanc', 'Thomas'),
    ('Boyer', 'Manon'),
    ('Renaud', 'Hugo'),
    ('Lefèvre', 'Claire'),
    ('Riviere', 'Noah'),
    ('Andre', 'Léa'),
    ('Colin', 'Mélissa'),
    ('Hubert', 'Khaled'),
    ('Francois', 'Elise'),
    ('Mercier', 'Baptiste'),
    ('Legrand', 'Sofia'),
    ('Dupuis', 'Yanis'),
    ('Rousseau', 'Jules'),
    ('Vincent', 'Lou'),
    ('Lucas', 'Inaya'),
    ('David', 'Omar'),
    ('Noel', 'Yara'),
    ('Boucher', 'Adrien'),
    ('Moulin', 'Salma'),
    ('Garnier', 'Maxime'),
    ('Roy', 'Fatou'),
    ('Ponce', 'Alex'),
    ('Marchand', 'Noémie'),
    ('Gillet', 'Bastien'),
    ('Barre', 'Lina'),
    ('Charles', 'Mehdi'),
    ('Aubert', 'Pauline'),
    ('Marie', 'Thierry'),
    ('Bailly', 'Imane'),
    ('Leger', 'Enzo'),
    ('Schmidt', 'Aya'),
    ('Levy', 'Gabriel'),
    ('Tessier', 'Milan'),
    ('Gomez', 'Roxane'),
    ('Navarro', 'Arthur'),
    ('Brun', 'Maëlys');
END;


IF NOT EXISTS (SELECT 1 FROM dbo.Cours)
BEGIN
    INSERT INTO dbo.Cours (
        Nom, DescriptionCourte, DescriptionLongueMarkdown, DureeEnJours, CapaciteMaximale, IdFormateur, DateCreation
    ) VALUES
    ('Introduction à la gestion du CSE', N'Découvrez les bases essentielles pour gérer efficacement un Comité Social et Économique.', N'# Introduction à la gestion du CSE\nObjectifs, rôles, obligations et bonnes pratiques.\n- Cadre légal\n- Organisation\n- Outils de pilotage', 3, 12, 1, '2026-03-08T09:00:00'),
    ('Négociation collective', N'Approfondissez vos compétences en négociation pour défendre les intérêts des salariés.', N'# Négociation collective\nPréparer, conduire, conclure et formaliser une négociation.\n- BATNA\n- Écoute active\n- Rédaction d''accord', 3, 14, 2, '2026-03-09T09:00:00'),
    ('Gestion des budgets du CSE', N'Maîtrisez la gestion financière et les obligations légales du CSE.', N'# Budgets du CSE\nSuivi, pièces justificatives, règles URSSAF, séparation AEP/ASC.\n- Tableaux de bord\n- Contrôles\n- Bonnes pratiques', 2, 10, 3, '2026-03-10T09:00:00'),
    ('Rôles et responsabilités des élus', N'Clarifiez les missions des élus et sécurisez vos pratiques au quotidien.', N'# Rôles et responsabilités\nPérimètre d''action, délégation, confidentialité, communication.', 2, 16, 4, '2026-03-11T09:00:00'),
    ('Préparer un ordre du jour de CSE', N'Construisez un ordre du jour pertinent, priorisé et conforme aux délais.', N'# Ordre du jour\nCollecte, priorisation, délais, traçabilité, articulation avec l''employeur.', 1, 18, 5, '2026-03-12T09:00:00'),
    ('PV de réunion : méthode et conformité', N'Rédigez des PV clairs, factuels et exploitables.', N'# Procès-verbal\nStructure, décisions, actions, annexes, validation et diffusion.', 1, 20, 6, '2026-03-13T09:00:00'),
    ('CSSCT : fonctionnement et actions', N'Découvrez le rôle de la CSSCT et déployez des actions de prévention.', N'# CSSCT\nMissions, visites, enquêtes, plan d''actions, indicateurs.', 2, 12, 7, '2026-03-14T09:00:00'),
    ('Santé au travail : fondamentaux', N'Comprenez les principes de prévention et les obligations employeur.', N'# Santé au travail\nDUERP, prévention, indicateurs, acteurs internes/externes.', 2, 15, 8, '2026-03-15T09:00:00'),
    ('Prévention des RPS', N'Identifiez les facteurs de risques psychosociaux et construisez un plan d''action.', N'# RPS\nDiagnostic, signaux faibles, actions collectives, suivi.', 2, 14, 9, '2026-03-16T09:00:00'),
    ('Harcèlement : prévenir et agir', N'Mettez en place une démarche de prévention et un traitement des alertes.', N'# Harcèlement\nCadre, procédures, écoute, enquête interne, traçabilité.', 2, 16, 10, '2026-03-17T09:00:00'),
    ('Droit du travail : bases pour CSE', N'Assimilez les notions clés utiles en réunion et en consultation.', N'# Droit du travail\nContrats, temps de travail, disciplinaire, ruptures, documents.', 3, 18, 11, '2026-03-18T09:00:00'),
    ('Consultations obligatoires du CSE', N'Maîtrisez le calendrier, les informations attendues et la formulation d''avis.', N'# Consultations\nCSE, BDESE, délais, expertise, rédaction d''avis.', 2, 12, 12, '2026-03-19T09:00:00'),
    ('BDESE : lecture et exploitation', N'Analysez une BDESE et transformez les données en questions utiles.', N'# BDESE\nIndicateurs, tendances, questions, préparation de consultation.', 2, 14, 13, '2026-03-20T09:00:00'),
    ('Communication interne du CSE', N'Améliorez la communication vers les salariés et la remontée des besoins.', N'# Communication CSE\nCanaux, charte, messages, enquêtes, tableaux de bord.', 1, 20, 14, '2026-03-21T09:00:00'),
    ('Conduire une enquête après accident', N'Structurez une enquête terrain et proposez des mesures de prévention.', N'# Enquête accident\nMéthode, recueil, arbre des causes, plan d''actions.', 2, 12, 15, '2026-03-22T09:00:00'),
    ('DUERP : comprendre et contribuer', N'Contribuez à la mise à jour du DUERP et au suivi des actions.', N'# DUERP\nPérimètre, cotation, priorisation, suivi et preuves.', 2, 15, 16, '2026-03-23T09:00:00'),
    ('Gestion des ASC : organiser l''offre', N'Structurez les activités sociales et culturelles et pilotez l''offre.', N'# ASC\nBudget, critères, communication, prestataires, conformité.', 2, 16, 17, '2026-03-24T09:00:00'),
    ('Marchés & prestataires du CSE', N'Sécurisez vos achats : sélection, contrats, suivi et litiges.', N'# Achats CSE\nMise en concurrence, clauses, suivi, RGPD prestataires.', 1, 14, 18, '2026-03-25T09:00:00'),
    ('RGPD pour le CSE', N'Appliquez les bonnes pratiques RGPD sur les données salariés/ASC.', N'# RGPD\nBases légales, registre, conservation, sous-traitants, droits.', 1, 18, 19, '2026-03-26T09:00:00'),
    ('Sécuriser une consultation avec expert', N'Cadrez l''expertise, le périmètre et les livrables.', N'# Expertise\nLettre de mission, calendrier, échanges, restitution.', 2, 12, 20, '2026-03-27T09:00:00'),
    ('Conflits et médiation en entreprise', N'Gérez les tensions et mettez en place une médiation efficace.', N'# Médiation\nPostures, outils, cadrage, suivi, prévention.', 2, 16, 21, '2026-03-28T09:00:00'),
    ('Comprendre les IRP et leurs interactions', N'Situez le CSE, la CSSCT et les autres instances.', N'# IRP\nRôles, périmètres, articulation, flux d''information.', 1, 20, 22, '2026-03-29T09:00:00'),
    ('Accords d''entreprise : lire et utiliser', N'Analysez un accord et identifiez les points d''application concrète.', N'# Accords\nStructure, clauses, indicateurs, points de vigilance.', 1, 18, 23, '2026-03-30T09:00:00'),
    ('Temps de travail : règles et contrôles', N'Comprenez les règles et repérez les risques de non-conformité.', N'# Temps de travail\nForfaits, heures sup, repos, astreintes, suivi.', 2, 16, 24, '2026-03-31T09:00:00'),
    ('Handicap : inclusion et obligations', N'Agissez pour l''inclusion et le respect des obligations légales.', N'# Handicap\nOETH, aménagement, sensibilisation, partenaires.', 1, 20, 25, '2026-04-01T09:00:00'),
    ('QVT : démarche et indicateurs', N'Déployez une démarche QVT structurée et mesurable.', N'# QVT\nDiagnostic, co-construction, indicateurs, pilotage.', 2, 14, 26, '2026-04-02T09:00:00'),
    ('Conduire un plan de prévention', N'Construisez un plan de prévention et suivez l''efficacité des actions.', N'# Plan de prévention\nObjectifs, actions, responsables, échéances, preuves.', 2, 12, 27, '2026-04-03T09:00:00'),
    ('Lecture des comptes : bases', N'Apprenez à lire un compte de résultat et un bilan.', N'# Comptes\nBilan, CR, SIG, trésorerie, alertes.', 2, 18, 28, '2026-04-04T09:00:00'),
    ('Analyse financière pour élus', N'Approfondissez l''analyse : ratios, marges, cash, investissements.', N'# Analyse financière\nRatios, CAPEX, OPEX, cash-flow, signaux de risque.', 3, 12, 29, '2026-04-05T09:00:00'),
    ('Formation économique CSE (essentiels)', N'Acquérez les fondamentaux économiques nécessaires au mandat.', N'# Formation économique\nMarché, stratégie, coûts, productivité, indicateurs.', 5, 15, 30, '2026-04-06T09:00:00'),
    ('Conduire une réunion efficace', N'Animez des réunions plus courtes, plus claires et orientées décisions.', N'# Réunion efficace\nCadre, timing, décisions, suivi d''actions.', 1, 24, 31, '2026-04-07T09:00:00'),
    ('Prise de parole en CSE', N'Gagnez en impact à l''oral : structuration, posture, réponses.', N'# Prise de parole\nArgumentation, assertivité, gestion des objections.', 2, 18, 32, '2026-04-08T09:00:00'),
    ('Gestion des conflits : outils', N'Désamorcez les conflits et maintenez un climat de travail sain.', N'# Conflits\nEscalade, communication non violente, accords.', 2, 16, 33, '2026-04-09T09:00:00'),
    ('Process d''alerte : savoir déclencher', N'Apprenez quand et comment déclencher une procédure d''alerte.', N'# Procédures d''alerte\nAlerte économique, danger grave, harcèlement, étapes.', 1, 14, 34, '2026-04-10T09:00:00');
END;


-- Suppression des doublons et correction des erreurs
DELETE FROM dbo.CoursPopulationCible;


IF NOT EXISTs (SELECT 1 FROM dbo.CoursPopulationCible)
BEGIN
-- Insertion des associations cours-population cible
INSERT INTO dbo.CoursPopulationCible (IdCours, IdPopulationCible) VALUES
(1, 1), (1, 2),  
(2, 1), (2, 2),  
(3, 2),          
(4, 1),          
(5, 1), (5, 2),  
(6, 1), (6, 2),  
(7, 1), (7, 2),  
(8, 1), (8, 2),  
(9, 1),          
(10, 1), (10, 2),
(11, 1),         
(12, 1),         
(13, 1), (13, 2),
(14, 2),         
(15, 1), (15, 2),
(16, 1), (16, 2),
(17, 1), (17, 2),
(18, 1),         
(19, 1), (19, 2),
(20, 1), (20, 2),
(21, 1), (21, 2),
(22, 1), (22, 2),
(23, 1), (23, 2),
(24, 1), (24, 2),
(25, 1),         
(26, 1), (26, 2),
(27, 1), (27, 2),
(28, 1), (28, 2),
(29, 1), (29, 2),
(30, 1);         
END; 

IF NOT EXISTS (SELECT 1 FROM dbo.Participants)
BEGIN
    INSERT INTO dbo.Participants (Nom, Prenom, Email, NomEntreprise) VALUES
    (N'Dupont',   N'Camille',  N'camille.dupont@exemple.com',   N'Guajava'),
    (N'Martin',   N'Lucas',    N'lucas.martin@exemple.com',     N'WeChooz'),
    (N'Bernard',  N'Inès',     N'ines.bernard@exemple.com',     N'ACME'),
    (N'Petit',    N'Yanis',    N'yanis.petit@exemple.com',      N'Globex'),
    (N'Robert',   N'Chloé',    N'chloe.robert@exemple.com',     N'Initech'),
    (N'Richard',  N'Nathan',   N'nathan.richard@exemple.com',   N'Umbrella'),
    (N'Durand',   N'Sarah',    N'sarah.durand@exemple.com',     N'Soylent'),
    (N'Leroy',    N'Mathis',   N'mathis.leroy@exemple.com',     N'Stark Industries'),
    (N'Moreau',   N'Jade',     N'jade.moreau@exemple.com',      N'Wayne Enterprises'),
    (N'Fournier', N'Enzo',     N'enzo.fournier@exemple.com',    N'Hooli'),
    (N'Girard',   N'Thomas',   N'thomas.girard@exemple.com',     N'OmniCorp'),
    (N'Mercier',  N'Emma',     N'emma.mercier@exemple.com',     N'Cyberdyne'),
    (N'Blanc',    N'Olivier',  N'olivier.blanc@exemple.com',    N'Wonka'),
    (N'Roux',     N'Anaïs',    N'anais.roux@exemple.com',       N'Virtucon');
END;


IF NOT EXISTS (SELECT 1 FROM dbo.Sessions)
BEGIN
    INSERT INTO dbo.Sessions (
        IdCours, IdModeDelivrance, DateDebut, DateFin, Lieu, NombrePlacesMax, NombrePlacesRestantes
    ) VALUES
    -- Sessions en présentiel
    (1, 1, '2026-06-01 09:00:00', '2026-06-03 17:00:00', 'Salle A - Paris', 20, 15),
    (3, 1, '2026-06-05 09:00:00', '2026-06-06 17:00:00', 'Salle B - Lyon', 15, 10),
    (5, 1, '2026-06-10 09:00:00', '2026-06-10 17:00:00', 'Salle C - Marseille', 18, 8),
    (7, 1, '2026-06-15 09:00:00', '2026-06-16 17:00:00', 'Salle D - Bordeaux', 16, 5),
    (9, 1, '2026-06-20 09:00:00', '2026-06-21 17:00:00', 'Salle E - Toulouse', 14, 12),
    -- Sessions à distance
    (2, 2, '2026-06-08 09:00:00', '2026-06-10 17:00:00', 'En ligne', 20, 18),
    (4, 2, '2026-06-12 09:00:00', '2026-06-12 17:00:00', 'En ligne', 12, 7),
    (6, 2, '2026-06-18 09:00:00', '2026-06-19 17:00:00', 'En ligne', 16, 14),
    (8, 2, '2026-06-22 09:00:00', '2026-06-24 17:00:00', 'En ligne', 18, 10),
    (10, 2, '2026-06-25 09:00:00', '2026-06-26 17:00:00', 'En ligne', 20, 15),
    -- Sessions mixtes
    (11, 1, '2026-07-01 09:00:00', '2026-07-01 17:00:00', 'Salle F - Nantes', 12, 5),
    (12, 2, '2026-07-05 09:00:00', '2026-07-06 17:00:00', 'En ligne', 24, 20),
    (13, 1, '2026-07-10 09:00:00', '2026-07-11 17:00:00', 'Salle G - Lille', 15, 8);
END;

IF EXISTS (SELECT 1 FROM dbo.SessionsPopulationCible)
BEGIN
DELETE FROM dbo.SessionsPopulationCible;

    -- Sessions existantes
    INSERT INTO dbo.SessionsPopulationCible (IdSession, IdPopulationCible) VALUES
    (1, 1), (1, 2),  
    (2, 1), (2, 2),  
    (3, 2),          
    (4, 1),          
    (5, 1), (5, 2),  
    (6, 1), (6, 2),  
    (7, 1), (7, 2),  
    (8, 1), (8, 2),  
    (9, 1),          
    (10, 1), (10, 2),
    (11, 1),         
    (12, 1),         
    (13, 1), (13, 2);

END;




