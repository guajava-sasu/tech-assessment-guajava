import "../../assets/global.css";
import ReactDOM from "react-dom/client";
import { useState } from "react";

const sessions = [
  {
    nom: "Introduction à la gestion du CSE",
    descriptionCourte:
      "Découvrez les bases essentielles pour gérer efficacement un Comité Social et Économique.",
    populationCible: ["élu"],
    dateDebut: "15/03/2026",
    duree: "3 jours",
    mode: "Présentiel",
    placesRestantes: 5,
    formateur: "Jean Dupont",
  },
  {
    nom: "Négociation collective",
    descriptionCourte:
      "Approfondissez vos compétences en négociation pour défendre les intérêts des salariés.",
    populationCible: ["élu", "président de CSE"],
    dateDebut: "22/03/2026",
    duree: "3 jours",
    mode: "À distance",
    placesRestantes: 8,
    formateur: "Marie Martin",
  },
  {
    nom: "Gestion des budgets du CSE",
    descriptionCourte:
      "Maîtrisez la gestion financière et les obligations légales du CSE.",
    populationCible: ["président de CSE"],
    dateDebut: "05/04/2026",
    duree: "2 jours",
    mode: "Présentiel",
    placesRestantes: 3,
    formateur: "Pierre Lambert",
  },
];

const participants = [
  { nom: "A", prenom: "", email: "", entreprise: "A" },
  { nom: "B", prenom: "", email: "", entreprise: "B" },
  { nom: "C", prenom: "", email: "", entreprise: "C" },
  { nom: "D", prenom: "", email: "", entreprise: "D" },
];

const PublicPage = () => {
  const [selectedDate, setSelectedDate] = useState<string>("");
  const [populationCible, setPopulationCible] = useState<string>("");
  const [deliveryMode, setDeliveryMode] = useState<string>("");
  const [filteredSessions, setFilteredSessions] = useState(sessions);
  const [filterObject, setFilterObject] = useState({
    populationCible: "",
    deliveryMode: "",
    selectedDate: "",
  });

  const globalFilter = (
    populationCibleTmp: string,
    deliveryModeTmp: string,
    selectedDateTmp: string,
  ) => {
    setFilteredSessions(sessions);
    console.log("populationCible : ", populationCibleTmp);
    console.log("deliveryMode : ", deliveryModeTmp);
    console.log("selectedDate : ", selectedDateTmp);
    const tmp = {
      populationCible: populationCibleTmp,
      deliveryMode: deliveryModeTmp,
      selectedDate: selectedDateTmp,
    };

    console.log("tmp : ", tmp);

    const filTmp = sessions.filter((session) => {
      const populationCibleComparison =
        tmp.populationCible.length > 0
          ? session.populationCible.includes(tmp.populationCible)
          : true;
      const deliveryModeComparison =
        tmp.deliveryMode.length > 0
          ? session.mode.includes(tmp.deliveryMode)
          : true;
      const dateComparison =
        tmp.selectedDate.length > 0
          ? session.dateDebut.includes(
              tmp.selectedDate.split("-").reverse().join("/"),
            )
          : true;

      let comparison =
        populationCibleComparison && deliveryModeComparison && dateComparison;
      return comparison;
    });
    console.log("filterObject : ", filterObject);
    setFilterObject(tmp);
    console.log("filterObject : ", filterObject);

    setFilteredSessions(filTmp);
  };

  return (
    <div>
      <h1>Interface publique </h1>

      <select
        name="pop-cible"
        id="pop-cible"
        onChange={(event) => setPopulationCible(event.target.value)}
      >
        <option value="">-- Veuillez choisir la population cible --</option>
        <option value="élu">Elu</option>
        <option value="président de CSE">Président de CSE</option>
      </select>

      <select
        name="mode-delivery"
        id="mode-delivery"
        onChange={(event) => setDeliveryMode(event.target.value)}
      >
        <option value="">-- Mode de délivrance --</option>
        <option value="Présentiel">Présentiel</option>
        <option value="À distance">À distance</option>
      </select>

      <input
        type="date"
        name="date"
        value={selectedDate}
        onChange={(event) => setSelectedDate(event.target.value)}
      />

      <button
        onClick={() =>
          globalFilter(populationCible, deliveryMode, selectedDate)
        }
      >
        Appliquer les filtres
      </button>
      <button onClick={() => setFilteredSessions(sessions)}>
        Vider les filtres
      </button>
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
            {filteredSessions.map((session, index) => (
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
};

const root = ReactDOM.createRoot(
  document.getElementById("react-app") as HTMLElement,
);

root.render(<PublicPage />);
