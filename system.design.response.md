---
### Question
L'application dans son état pour le test technique n'est pas utilisable en production.

Faites une liste de l'ensemble des éléments que vous estimez devoir être corrigés et/ou améliorés
 pour avoir une application "prod-ready". Pour chaque élément, proposez également un plan de remédiation.
 
 ### Réponse
 L'application dans son état actuel pourrait être découpée en plusieurs parties une front purement react qui sera déployée sur une machine , 
 un backend .net core sur une autre machine (url dirrefente) et qui sera avec la base de données sur le même serveur ou un cloud comme azure, par exemple.
 
 Le tout pouvant etre déployé danbs azure. 

 ---
### Question
Décrivez également comment ajouter une fonctionnalité permettant aux clients de s'inscrire par eux-même 
à une session de formation après l'avoir acheté auprès d'un commercial WeChooz. 
Décrivez les flux d'intéraction utilisateurs, ainsi que les différents mécanismes de sécurité
 envisagés pour éviter les risques d'inscription frauduleuse 
(sans imposer aux clients de se connecter).

### Réponse
on peut créer une fonctionnalité où, le client aura la liste des sessions visibles avec des créneaux disponibles et il pourra les sélectionner. 
le client aura un id de session qu'il pourra utiliser pour s'inscrire, celui sera unique et dedié au client ainsi personne d'autre l'utilisera (nominatif) 
Pour éviter au client de se connecter on peut lui envoyer un email ou un texto avec un code de vérification et il pourra s'authentifier par ce moyen. 
