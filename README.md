# Sqlite-Csharp-API

Voit testata koodia lähettämällä:

POST requestin http://localhost:5000/Omistajat Jossa käytin JSON bodyä: { "Id": 1, "Nimi": "Kalle Kivioja", "Puhelin": "1234567890" }


POST requestin http://localhost:5000/Lemmikit Jossa käytin JSON bodyä: { "Id": 1, "Nimi": "Kallen koira", "Laji": "Koira", "Omistajan_id": "1" }
                              
GET requestin http://localhost:5000/Lemmikit/Kallen%20koira

id:t toimivat vain yhdelle ainoalle henkilölle, joten jos koittaa lisätä henkilön samalla idllä niin tulee 500: Internal server errori, jota en osannut korjata näyttämään jotain muuta.

Requestejen tekemiseen käytin Insomniaa.
