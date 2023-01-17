### Documentation for Developers

## Endpoints
```
GET http://localhost:5000/api/locations/
GET http://localhost:5000/api/locations/{id}
POST http://localhost:5000/api/locations/
PUT http://localhost:5000/api/locations/{id}
DELETE http://localhost:5000/api/locations/{id}
```
## Attribute Queries
You may also query certain attributes by using the following syntax in your GET requests:
| Parameter | DataType | Returns |
| ------ | ------ | ----------------------------------------------------- |
| Country | String | All countries matching the input string |
| Name | String | All cities matching the input string |
| Walkability | Integer | All cities with a walking score of at least [input value] |
| Rating | Integer | All cities with a rating of at least [input value] |

    
## Examples
  * The following query will return all locations named "Portland":
      ```
      GET http://localhost:5000/api/locations?name=Portland
      ```
  * The following query will return all locations with a walkability of at least 3:
      ```
      GET http://localhost:5000/api/Location?minimumWalkability=3
      ```
  * You can query multiple fields by concatening requests with &, like this:
      ```
      GET http://localhost:5000/api/Location?country=United%20States&minimumWalkability=3

  * A body is required for POST requests. Example of a good request would be:
    ```
    {
    "name": "Heidelberg",
    "country": "Germany",
    "description": "doch der Schoensten Stadt der Welt"
    "walkability": 5,
    "publictransit": 5,
    "rating": 5
    }
    ```
  * An ID is required for PUT requests (modifying an existing entry):
    ```
    {
    "locationId": "8"
    "name": "Heidelberg",
    "country": "Germany",
    "description": "doch der Schoensten Stadt der Welt"
    "walkability": 5,
    "publictransit": 5,
    "rating": 5
    }
    ```
  # additional information for the extended project (cors, tokens, etc) when implemented
  