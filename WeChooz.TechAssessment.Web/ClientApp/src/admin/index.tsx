import ReactDOM, { Container } from "react-dom/client";
const cours = [
    {
        "nom": "Introduction à la gestion du CSE",
        "descriptionCourte": "Découvrez les bases",
        "description_longue": "Social et Économiqu manière autonome et efficace.",
        "duree_jours": 3,
        "population_cible": ["élu", "président de CSE"],
        "capacite_maximale": 15,
        "formateur":  "Jean Dupont"        
    }
];



const root = ReactDOM.createRoot(document.getElementById("react-app") as Container);
root.render(

    <div>
        <h1>Hello admin page</h1>
    
    
    
    </div>






);
