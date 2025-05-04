# AutoFix - system zarządzania warsztatem samochodowym

AutoFix to dwuczęściowa aplikacja webowa dla warsztatu samochodowego:
- **Portal zewnętrzny** (dla klientów) – umożliwia rejestrację pojazdów, składanie rezerwacji oraz przeglądanie informacji o firmie.
- **Panel intranetowy** (dla pracowników) – umożliwia zarządzanie rezerwacjami, klientami, pojazdami, naprawami, mechanikami, historią napraw i autami zastępczymi.

## Funkcjonalności

### Portal WWW (część klienta)
- Dodawanie klienta i pojazdu
- Składanie rezerwacji
- Potwierdzenia rezerwacji
- Strona główna z dynamicznymi usługami i promocjami
- Strony informacyjne: O nas, Historia firmy, Polityka prywatności – zarządzane z bazy danych

### Panel Intranetowy (część pracownika)
- Zarządzanie rezerwacjami, klientami, pojazdami i naprawami
- Obsługa historii napraw
- Zarządzanie autami zastępczymi
- Panel mechaników, usług, promocji
- Przenoszenie napraw do historii z automatycznym kopiowaniem powiązanych danych
- Wydruk zlecenia naprawy
- Historia zmian w bazie danych

## Technologie

- ASP.NET Core MVC
- Entity Framework Core (code-first, migracje)
- Bootstrap 5
- SQL Server LocalDB
- Razor Views, ViewModels
- JavaScript + fetch (do szukania pojazdów po rejestracji)

## Uruchamianie projektu

1. Otwórz projekt w Visual Studio 2022+
2. Ustaw projekt startowy – PortalWWW lub Intranet
3. Naciśnij „Start” 

Visual Studio automatycznie:
- Przywróci zależności (NuGet restore)
- Wykona migracje lokalnej bazy danych, jeśli to potrzebne

Nie trzeba wykonywać żadnych dodatkowych komend.

## Struktura projektu

- AutoFix.Data – warstwa danych i konfiguracja EF
- AutoFix.Intranet – panel administracyjny
- AutoFix.PortalWWW – strona publiczna dla klientów

Jeśli chcesz go uruchomić lub dostosować – śmiało. W razie pytań możesz zostawić wiadomość na GitHubie.
