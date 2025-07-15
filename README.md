# ProjektHaushaltsbuch

Eine moderne Anwendung zur Verwaltung der persönlichen Finanzen und Haushaltsführung.

## 📋 Überblick

ProjektHaushaltsbuch ist eine benutzerfreundliche Anwendung, die es ermöglicht, Einnahmen und Ausgaben zu verwalten, Budgets zu erstellen und finanzielle Übersichten zu generieren. Die Anwendung hilft dabei, den Überblick über die persönlichen Finanzen zu behalten und finanzielle Ziele zu erreichen.

## ✨ Features

- **Ausgabenverwaltung**: Detaillierte Erfassung von Ausgaben mit erweiterten Eigenschaften
- **Kategorisierung**: Flexible Kategorien und Unterkategorien für bessere Organisation
- **Erweiterte Ausgabenfelder**: 
  - Zahlungsmethode und Zahlungskonto
  - Geschäftsausgaben-Kennzeichnung
  - Belegnnummer und Anbieter-Tracking
  - Standort-Erfassung
  - Wiederkehrende Ausgaben
  - Dateianhänge für Belege
  - Budget-Zuordnung
  - Geplante vs. tatsächliche Ausgaben
- **Suchfunktion**: Schnelles Auffinden von Transaktionen
- **Rate Limiting**: Schutz vor Überlastung durch API-Rate-Limiting
- **Sicherheit**: Anti-Forgery Token Schutz

## 🛠️ Technologie-Stack

- **Framework**: ASP.NET Core MVC
- **Sprache**: C#
- **ORM**: Entity Framework Core
- **Mapping**: AutoMapper
- **Datenbank**: MS SQL Server Express
- **Frontend**: Razor Views, HTML/CSS/JavaScript
- **Rate Limiting**: ASP.NET Core Rate Limiting
- **Validierung**: Data Annotations, Anti-Forgery Token

## 🚀 Installation

### Voraussetzungen

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) oder höher
- [Git](https://git-scm.com/)
- SQL Server, PostgreSQL oder SQLite (je nach Konfiguration)
- Visual Studio 2022 oder Visual Studio Code

### Schritte

1. **Repository klonen**
   ```bash
   git clone https://github.com/Kirimoshi/ProjektHaushaltsbuch.git
   cd ProjektHaushaltsbuch
   ```

2. **Abhängigkeiten installieren**
   ```bash
   dotnet restore
   ```

3. **Umgebungsvariablen konfigurieren**
   ```bash
   # appsettings.json bearbeiten und Datenbankverbindung konfigurieren
   ```

4. **Datenbank initialisieren**
   ```bash
   dotnet ef database update
   ```

5. **Anwendung starten**
   ```bash
   dotnet run
   ```

Die Anwendung ist nun unter `https://localhost:5001` oder `http://localhost:5000` erreichbar.

## 📖 Verwendung

### Erste Schritte

1. **Konto erstellen**: Registrieren Sie sich oder loggen Sie sich ein
2. **Kategorien einrichten**: Definieren Sie Ihre Ausgaben- und Einnahmenkategorien
3. **Transaktionen hinzufügen**: Erfassen Sie Ihre ersten Einnahmen und Ausgaben
4. **Budget festlegen**: Erstellen Sie Budgets für verschiedene Kategorien

### Hauptfunktionen

- **Dashboard**: Übersicht über aktuelle Finanzsituation
- **Transaktionen**: Hinzufügen, Bearbeiten und Löschen von Einträgen
- **Budgets**: Erstellen und Überwachen von Budgetzielen
- **Berichte**: Generierung von Finanzberichten und Statistiken

## 🤝 Mitwirken

Beiträge sind willkommen! Bitte beachten Sie folgende Schritte:

1. **Fork** das Repository
2. **Branch** für Ihr Feature erstellen (`git checkout -b feature/AmazingFeature`)
3. **Commit** Ihre Änderungen (`git commit -m 'Add some AmazingFeature'`)
4. **Push** zum Branch (`git push origin feature/AmazingFeature`)
5. **Pull Request** erstellen

### Entwicklungsrichtlinien

- Befolgen Sie die C# Coding Standards
- Verwenden Sie Entity Framework Core für Datenbankoperationen
- Implementieren Sie AutoMapper für Object-Mapping
- Nutzen Sie ViewModels für die Datenübertragung zwischen Controller und View
- Implementieren Sie Rate Limiting für API-Endpunkte
- Verwenden Sie Anti-Forgery Tokens für Formulare
- Schreiben Sie Unit Tests für neue Features
- Dokumentieren Sie Ihre Änderungen

## 🧪 Tests

```bash
# Tests ausführen
dotnet test

# Test-Coverage anzeigen
dotnet test --collect:"XPlat Code Coverage"
```

## 📁 Projektstruktur

```
ProjektHaushaltsbuch/
├── Controllers/          # MVC Controller
│   ├── ExpenseController.cs
│   └── ...
├── Models/              # Datenmodelle
│   ├── ExpenseModel.cs
│   ├── CategoryModel.cs
│   └── ...
├── Views/               # Razor Views
│   ├── Expense/
│   └── ...
├── ViewModels/          # View Models
│   ├── ExpenseDisplayViewModel.cs
│   ├── ExpenseCreateViewModel.cs
│   └── ...
├── Data/                # Entity Framework Context
│   └── ProjektHaushaltsbuchContext.cs
├── wwwroot/             # Statische Dateien (CSS, JS, Images)
├── Migrations/          # Entity Framework Migrations
└── appsettings.json     # Konfiguration
```

## 📜 Lizenz

Dieses Projekt ist unter der [MIT-Lizenz](LICENSE) lizenziert.

## 👥 Autoren

- **Kirimoshi** - *Hauptentwickler* - [GitHub](https://github.com/Kirimoshi)

## 📞 Support

Bei Fragen oder Problemen:

- **Issues**: [GitHub Issues](https://github.com/Kirimoshi/ProjektHaushaltsbuch/issues)
- **Diskussionen**: [GitHub Discussions](https://github.com/Kirimoshi/ProjektHaushaltsbuch/discussions)

---

⭐ Wenn Ihnen dieses Projekt gefällt, geben Sie ihm einen Stern auf GitHub!
