import { useState, useEffect } from "react";
import ReactDOM from "react-dom/client";

const cours = [
  {
    nom: "Introduction à la gestion du CSE",
    descriptionCourte: "Découvrez les bases",
    description_longue: "Social et Économiqu manière autonome et efficace.",
    duree_jours: 3,
    population_cible: ["élu", "président de CSE"],
    capacite_maximale: 15,
    formateur: "Jean Dupont",
  },
];

const CoursPage = () => {
  const [coursList, setCoursList] = useState(cours);

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log("Form submitted");
  };

  return (
    <div>
      <h1>Création de cours</h1>
      <form onSubmit={(e) => handleSubmit(e)}>
        <input type="text" placeholder="Nom du cours" />
        <input type="text" placeholder="Description courte" />
        <input type="text" placeholder="Description longue" />
        <input type="number" placeholder="Durée en jours" />
        <input
          type="text"
          placeholder="Population cible (séparée par des virgules)"
        />
        <input type="number" placeholder="Capacité maximale" />
        <input type="text" placeholder="Formateur" />
        <button type="submit">Créer le cours</button>
      </form>

      <ul>
        {coursList.map((cours, index) => (
          <li key={index}>{cours.nom}</li>
        ))}
      </ul>
    </div>
  );
};
const root = ReactDOM.createRoot(
  document.getElementById("react-app") as HTMLElement,
);
root.render(<CoursPage />);
