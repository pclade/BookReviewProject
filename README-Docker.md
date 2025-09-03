# BookReview – Docker/Compose Add-on (NET 9)

Dieses Paket ergänzt dein bestehendes BookReview-Projekt um Container-Support.

## Struktur
- `.dockerignore`
- `docker-compose.yml`
- `src/BookReview.Api/Dockerfile`
- `src/BookReview.Web/Dockerfile`
- `src/BookReview.Web/appsettings.Docker.json`

## Voraussetzungen
- Docker Desktop installiert und gestartet
- Dein Repo enthält die Ordner `src/BookReview.Api` und `src/BookReview.Web`

## Nutzung
1. **Dieses Add-on in das Repo-Root kopieren** (gleiche Ebene wie der Ordner `src/`).
2. Terminal im Repo-Root öffnen und ausführen:
   ```bash
   docker compose up --build
   ```
3. Im Browser prüfen:
   - Web:  http://localhost:5010/
   - API:  http://localhost:5009/api/books

## Hinweise
- Im Container laufen beide Dienste über **HTTP auf Port 8080**. Die Host-Ports werden via Compose auf **5009 (API)** und **5010 (Web)** gemappt.
- Die Web-App nutzt im Docker-Environment `appsettings.Docker.json` → ruft die API unter `http://api:8080/` (Compose-Service-Name) auf.
- Für lokale Nicht-Docker-Starts bleiben deine bisherigen `appsettings*.json`/`launchSettings.json` unverändert.
