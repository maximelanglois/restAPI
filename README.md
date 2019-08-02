# restAPI


**how to get /or/ modify a battery status**

GET http://localhost:5000/api/batteries/{id}/status
PUT http://localhost:5000/api/batteries/{id}/status

**how to get /or/ modify a column status**

GET http://localhost:5000/api/columns/{id}/status
PUT http://localhost:5000/api/columns/{id}/status


**how to get /or/ modify a elevator status**

GET http://localhost:5000/api/elevators/{id}/status
PUT http://localhost:5000/api/elevators/{id}/status


**how to get inactive elevators list**

GET http://localhost:5000/api/elevators/inactive


**how to get buildings list where a intervention is required on its batterys or its columns or its elevators**

GET http://localhost:5000/api/buildings/intervention

**how to get leads created in the last 30 days and that they are not a customer**

GET http://localhost:5000/api/leads/30days
