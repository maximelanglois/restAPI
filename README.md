# restAPI



**[]Récupération / Modification du Statut d’une Batterie d’ascenseurs spécifiée**

GET http://localhost:5000/api/batteries/{id}/status
PUT http://localhost:5000/api/batteries/{id}/status

**[]Récupération / Modification du Statut actuel d’une Colonne d’ascenseurs pour une colonne spécifiée**

GET http://localhost:5000/api/columns/{id}/status
PUT http://localhost:5000/api/columns/{id}/status


**[]Récupération / Modification du Statut d’une Cage d’ascenseur pour une cage spécifiée**

GET http://localhost:5000/api/elevators/{id}/status
PUT http://localhost:5000/api/elevators/{id}/status


**[]Récupération d’une liste d’ascenseurs qui ne sont pas en opération au moment de la requête**

GET http://localhost:5000/api/elevators/inactive


**[]Récupération d’une liste de buildings qui contiennent au moins une batterie, une colonne ou un ascenseur requérant une intervention**

GET http://localhost:5000/api/buildings/intervention

**[]Récupération d’une liste de leads créés au cours des 30 derniers jours qui ne sont pas encore devenus des clients.**

GET http://localhost:5000/api/leads/30days
