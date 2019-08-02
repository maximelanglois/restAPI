# restAPI


**how to get /or/ modify a battery status**

GET https://maxwillmathrestapi.azurewebsites.net/api/batteries/{id}/status
PUT https://maxwillmathrestapi.azurewebsites.net/api/batteries/{id}/status

**how to get /or/ modify a column status**

GET https://maxwillmathrestapi.azurewebsites.net/api/columns/{id}/status
PUT https://maxwillmathrestapi.azurewebsites.net/api/columns/{id}/status


**how to get /or/ modify a elevator status**

GET https://maxwillmathrestapi.azurewebsites.net/api/elevators/{id}/status
PUT https://maxwillmathrestapi.azurewebsites.net/api/elevators/{id}/status


**how to get inactive elevators list**

GET https://maxwillmathrestapi.azurewebsites.net/api/elevators/inactive


**how to get buildings list where a intervention is required on its batterys or its columns or its elevators**

GET https://maxwillmathrestapi.azurewebsites.net/api/buildings/intervention

**how to get leads created in the last 30 days and that they are not a customer**

GET https://maxwillmathrestapi.azurewebsites.net/api/leads/30days
