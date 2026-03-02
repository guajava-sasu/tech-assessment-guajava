import "../../assets/global.css";
import ReactDOM, { Container } from "react-dom/client";
import { MantineTheme, useMantineTheme } from '@mantine/core';

const sessions = [
    {
        nom: "Introduction à la gestion du CSE",
        descriptionCourte: "Découvrez les bases essentielles pour gérer efficacement un Comité Social et Économique.",
        populationCible: ["élu"],
        dateDebut: "15/03/2026",
        duree: "3 jours",
        mode: "Présentiel",
        placesRestantes: 5,
        formateur: "Jean Dupont"
    },
    {
        nom: "Négociation collective",
        descriptionCourte: "Approfondissez vos compétences en négociation pour défendre les intérêts des salariés.",
        populationCible: ["élu", "président de CSE"],
        dateDebut: "22/03/2026",
        duree: "3 jours",
        mode: "À distance",
        placesRestantes: 8,
        formateur: "Marie Martin"
    },
    {
        nom: "Gestion des budgets du CSE",
        descriptionCourte: "Maîtrisez la gestion financière et les obligations légales du CSE.",
        populationCible: ["président de CSE"],
        dateDebut: "05/04/2026",
        duree: "2 jours",
        mode: "Présentiel",
        placesRestantes: 3,
        formateur: "Pierre Lambert"
    }
];

const participants = [
    { nom: "A", prenom: "", email: "", entreprise: "A" },
    { nom: "B", prenom: "", email: "", entreprise: "B" },
    { nom: "C", prenom: "", email: "", entreprise: "C" },
    { nom: "D", prenom: "", email: "", entreprise: "D" }
];

const root = ReactDOM.createRoot(document.getElementById("react-app") as Container);


root.render(

    <div>
        <h1>Interface publique </h1>

        <select name="pop-cible" id="pop-cible">
            <option value="">-- Veuillez choisir la population cible --</option>
            <option value="0">Elu</option>
            <option value="1">Membre CSE</option>
        </select>


        <select name="pop-cible" id="pop-cible">
            <option value="">-- Mode de délivrance --</option>
            <option value="0">Présentiel</option>
            <option value="1">à Distance</option>
        </select>

        <input type="date" name="date" />


        <div className="sessions-table">
            <h2>Sessions de formation</h2>
            <table>
                <thead>
                    <tr>
                        <th>Nom du cours</th>
                        <th>Description courte</th>
                        <th>Population cible</th>
                        <th>Date de début</th>
                        <th>Durée</th>
                        <th>Mode</th>
                        <th>Places restantes</th>
                        <th>Formateur</th>
                    </tr>
                </thead>
                <tbody>
                    {sessions.map((session, index) => (
                        <tr key={index}>
                            <td>{session.nom}</td>
                            <td>{session.descriptionCourte}</td>
                            <td>{session.populationCible.join(", ")}</td>
                            <td>{session.dateDebut}</td>
                            <td>{session.duree}</td>
                            <td>{session.mode}</td>
                            <td>{session.placesRestantes}</td>
                            <td>{session.formateur}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    </div>
);
