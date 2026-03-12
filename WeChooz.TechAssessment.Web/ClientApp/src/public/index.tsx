import "../../assets/global.css";
import * as ReactDOM from "react-dom/client";
import { useEffect, useState } from "react";

type FormationDto = {
    id: number;
    nom: string;
    descriptionCourte: string;
    dureeEnJours: number;
    populationCible: string[];
    capaciteMaximale: number;
    formateurNom: string;
    formateurPrenom: string;
    dateCreation: string; // ISO
};

type CoursRow = {
    nom: string;
    descriptionCourte: string;
    populationCible: string[];
    delivrance: { id: number, libelle: string }[];
    cible: { id: number, libelle: string }[];
    dateDebut: string;
    duree: string;
    placesRestantes: number;
    formateur: string;
};

const fallbackCours: CoursRow[] = [];

const toFrDate = (iso: string) => {
    const d = new Date(iso);
    if (Number.isNaN(d.getTime())) return iso;
    return d.toLocaleDateString("fr-FR");
};

const PublicPage = () => {
    const [selectedDate, setSelectedDate] = useState<string>("");
    const [populationCible, setPopulationCible] = useState<string>("");
    const [deliveryMode, setDeliveryMode] = useState<string>("");
    const [sessions, setSessions] = useState<CoursRow[]>(fallbackCours);
    const [filteredSessions, setFilteredSessions] = useState<CoursRow[]>(fallbackCours);

    const [filterObject, setFilterObject] = useState({
        populationCible: "",
        deliveryMode: "",
        selectedDate: "",
    });

    // Intégration du fetch /_api/formations (au chargement)
    useEffect(() => {
        const controller = new AbortController();

        (async () => {
            try {
                const res = await fetch("/_api/formations", { signal: controller.signal });
                if (!res.ok) return;

                const cours = (await res.json()) as FormationDto[];

                console.log(cours);

                const mapped: CoursRow[] = cours.map((cour) => ({
                    nom: cour.nom,
                    descriptionCourte: cour.descriptionCourte,
                    populationCible: [cour.populationCible.map(pc => pc.libelle)],
                    cible: cour.populationCible,
                    delivrance: cour.delivrance,
                    dateDebut: toFrDate(cour.dateCreation),
                    duree: `${cour.dureeEnJours} jours`,
                    placesRestantes: cour.capaciteMaximale,
                    formateur: `${cour.formateur.prenom} ${cour.formateur.nom}`.trim(),
                }));

                console.log(mapped);

                setSessions(mapped);
                setFilteredSessions(mapped);
            } catch {
                // On garde fallbackCours si l'API n'est pas dispo
            }
        })();

        return () => controller.abort();
    }, []);

    const globalFilter = (
        populationCibleTmp: string,
        deliveryModeTmp: string,
        selectedDateTmp: string,
    ) => {
        setFilteredSessions(sessions);

        const tmp = {
            populationCible: populationCibleTmp,
            deliveryMode: deliveryModeTmp,
            selectedDate: selectedDateTmp,
        };
  
        console.log(tmp);
        const filTmp = sessions.filter((session) => {

            function estTrouve(population: any) {
                const toto = population.id === Number(tmp.populationCible)
                return toto
            }

            // ici mode contient population cible, il faut rechercher la correspondance dans le tableau de population cible
            const populationCibleComparison =
                tmp.populationCible.length > 0
                    ? session.mode.filter((m) =>  m.id === Number(tmp.populationCible)).length > 0 : true;

            const deliveryModeComparison =
                tmp.deliveryMode.length > 0 ? session.mode.filter((m) =>  m.id === Number(tmp.deliveryMode)) : true;

            const dateComparison =
                tmp.selectedDate.length > 0
                    ? session.dateDebut.includes(tmp.selectedDate.split("-").reverse().join("/"))
                    : true;

            return populationCibleComparison && deliveryModeComparison && dateComparison;
        });

        setFilterObject(tmp);
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
                <option value="1">Elu</option>
                <option value="2">Président de CSE</option>
            </select>

            <select
                name="mode-delivery"
                id="mode-delivery"
                onChange={(event) => setDeliveryMode(event.target.value)}
            >
                <option value="">-- Mode de délivrance --</option>
                <option value="1">Présentiel</option>
                <option value="2">À distance</option>
            </select>

            <input
                type="date"
                name="date"
                value={selectedDate}
                onChange={(event) => setSelectedDate(event.target.value)}
            />

            <button onClick={() => globalFilter(populationCible, deliveryMode, selectedDate)}>
                Appliquer les filtres
            </button>
            <button onClick={() => setFilteredSessions(sessions)}>Vider les filtres</button>

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
                            {/*<th>Mode</th>*/}
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

const root = ReactDOM.createRoot(document.getElementById("react-app") as HTMLElement);

root.render(<PublicPage />);