# restAPI

PATH SOURCE = https://maxrestapi.azurewebsites.net


**how to get /or/ modify a battery status**

GET /api/batteries/{id}/status
PUT /api/batteries/{id}/status

**how to get /or/ modify a column status**

GET /api/columns/{id}/status
PUT /api/columns/{id}/status


**how to get /or/ modify a elevator status**

GET /api/elevators/{id}/status
PUT /api/elevators/{id}/status


**how to get inactive elevators list**

GET /api/elevators/inactive


**how to get buildings list where a intervention is required on its batterys or its columns or its elevators**

GET /api/buildings/intervention

**how to get leads created in the last 30 days and that they are not a customer**

GET /api/leads/30days

------------------------------------  INTERVENTION SECTION  ---------------------------------------

GET /api/interventions/pending
GET /api/interventions/{id}/status
PUT /api/interventions/{id}/inprogress
PUT /api/interventions/{id}/completed
