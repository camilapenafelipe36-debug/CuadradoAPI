# CuadradoAPI

API Web desarrollada en .NET que recibe un número y devuelve su cuadrado.

## Endpoint

GET `/api/math/square/{number}`

### Ejemplos

- `2` → `4`
- `5` → `25`
- `10` → `100`
- `-3` → error 400 porque no se permiten números negativos.

## Ejecutar

```bash
dotnet run
```

Luego abrir:

```text
https://localhost:PUERTO/api/math/square/5
```
