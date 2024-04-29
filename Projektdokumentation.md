# Projektdokumentation

von Julius Burlet und Timo Goedertier

## User Stories

| ID  | Priorität | Wer/Was/warum                                                                                                                  |
| --- | --------- | ------------------------------------------------------------------------------------------------------------------------------ |
| 1.1 | Mittel    | Als Spieler möchte ich eine art 'Main Menu' haben.                                                                             |
| 1.2 | Hoch      | Als Spieler möchte ich zwischen Roulette und Slot Machine auswählen können.                                                    |
| 1.3 | Hoch      | Als Spieler möchte ich Geld in Chips umwandeln können.                                                                         |
| 1.4 | Tief      | Als Spieler möchte ich die Anwendung beenden können.                                                                           |
| 1.5 | Tief      | Als Spieler möchte ich jederzeit zurück zum Menu kommen können.                                                                |
| 2.1 | Hoch      | Als Spieler möchte ich Slot Machines spielen können.                                                                           |
| 3.1 | Hoch      | Als Spieler möchte ich Roulette spielen können.                                                                                |
| 4.1 | Hoch      | Als Spieler möchte ich, dass mein Geld über eine Session bleibt, aber nicht gespeichert wird nach dem beenden der Applikation. |

## Scrum Board

| Backlog | To Do | In Progress | Testing | Done |
| ------- | ----- | ----------- | ------- | ---- |
|         |       |             |         | 1.1  |
|         |       |             |         | 1.2  |
|         |       |             |         | 1.3  |
|         |       |             |         | 1.4  |
|         |       |             |         | 2.1  |
|         |       |             |         | 3.1  |
|         |       |             |         | 4.1  |
|         |       |             |         | 1.5  |

## Aufteilungs Planung

| US-ID | Bis        | Wer             |
| ----- | ---------- | --------------- |
| 1.1   | 29.04.2024 | Timo Goedertier |
| 1.2   | 29.04.2024 | Julius Burlet   |
| 1.3   | 29.04.2024 | Timo Goedertier |
| 1.4   | 29.04.2024 | Julius Burlet   |
| 1.5   | 29.04.2024 | Timo Goedertier |
| 2.1   | 29.04.2024 | Timo Goedertier |
| 3.1   | 29.04.2024 | Julius Burlet   |
| 4.1   | 29.04.2024 | Timo Goedertier |

Da J. Burlet ein Problem mit Visual Studio 2022 hatte, wegen der Lizenz der BBB konnte er nicht zur gleichen Zeit wie T. Goedertier anfangen.

## Realisation

| US-ID | Datum      | Von             |
| ----- | ---------- | --------------- |
| 1.1   | 27.04.2024 | Timo Goedertier |
| 1.2   | 29.04.2024 | Julius Burlet   |
| 1.3   | 27.04.2024 | Timo Goedertier |
| 1.4   | 27.04.2024 | Timo Goedertier |
| 1.5   | 27.04.2024 | Timo Goedertier |
| 2.1   | 28.04.2024 | Timo Goedertier |
| 3.1   | 29.04.2024 | Julius Burlet   |
| 4.1   | 28.04.2024 | Timo Goedertier |

## Test Driven Development (TDD)

### Timo

Ich konnte gut mit TDD arbeiten und es hat teils auch sehr geholfen es so zu machen. Das einzige Problem, welches ich habe, ist, dass meine Unit Tests versuchen Konsole-Interaktionen zu testen, wobei dies bei Unit Tests nicht möglich ist.

Erklärung von ChatGPT: https://chat.openai.com/share/421616bc-0a81-445e-bd0f-fc5078af3193

### Julius

Ich konnte das TDD eigentlich gut implementieren. Jedoch ist es recht kompliziert mit random Zahlen Unittests zu machen, deswegen habe ich noch Payouts getestet. Ansonsten hat es mir auch sehr geholfen, da ich immer wusste obs jetzt richtig funktioniert oder nicht, ohne immer die ganze Applikation zu starten.

## Observer-Pattern

Das Observer-Pattern wird in diesem Code durch die Klassen `IChipsObserver`, `ChipsObservable` und `CasinoMenu` implementiert.

1. `IChipsObserver` ist das Interface, das die Beobachter (Observers) implementieren müssen. Es definiert die Methode `ChipsUpdated(int newChips)`, die aufgerufen wird, wenn sich die beobachtete Eigenschaft (in diesem Fall die Anzahl der Chips) ändert.

2. `ChipsObservable` ist die Subjekt-Klasse, die die beobachtete Eigenschaft (`Chips`) enthält. Sie hat eine Liste von `IChipsObserver`-Objekten, die über Änderungen der `Chips`-Eigenschaft informiert werden sollen. Wenn sich der Wert von `Chips` ändert, wird die Methode `NotifyObservers()` aufgerufen, die wiederum die `ChipsUpdated`-Methode für alle registrierten Beobachter aufruft.

3. `CasinoMenu`, `SlotMachine` und `Roulette` sind die Beobachter (Observer). Es implementiert das `IChipsObserver`-Interface und registriert sich selbst als Beobachter in der `ChipsObservable`-Instanz im Konstruktor. Wenn die `ChipsUpdated`-Methode aufgerufen wird, gibt `CasinoMenu` eine Meldung auf der Konsole aus.

Durch diese Entkopplung können beliebig viele Beobachter an der `ChipsObservable` registriert werden, ohne dass die Implementierung der Subjekt-Klasse geändert werden muss. Wenn sich die Anzahl der Chips ändert, werden alle Beobachter über die Änderung informiert und können entsprechend reagieren.

## Command-Pattern

Ich habe das Command Pattern implementiert, indem ich eine Trennung 
zwischen einem Befehlsobjekt `ICommand` und den Empfängern 
`RouletteTable` und `RouletteGame` geschaffen habe.

1. 
   
   - Ich habe das `ICommand`-Interface definiert, um die abstrakte Schnittstelle für alle Befehlsklassen festzulegen.
   - Die `SpinCommand`-Klasse wurde von mir erstellt, um das `ICommand`-Interface zu implementieren und den Befehl, das Roulette zu drehen, zu kapseln.
   - Ich habe das `RouletteGame`-Objekt verwendet, um das `SpinCommand` zu erstellen und zu halten, um die Drehung des Rouletterads auszuführen.

2. 
   
   - Ich habe das `ICommand`-Interface mit einer Methode `Execute()` definiert, die von allen konkreten Befehlsklassen implementiert wird.
   - In der `SpinCommand`-Klasse habe ich einen `RouletteTable` als Empfänger übernommen und die Methode `Spin()` des `RouletteTable`-Objekts aufgerufen, wenn die `Execute()`-Methode aufgerufen wird.
   - Ich habe das `RouletteGame`-Objekt erstellt und ein `SpinCommand`-Objekt verwendet, um die `Execute()`-Methode aufzurufen und eine Drehung des Rouletterads auszulösen.

3. 
   
   - Ich habe das Command Pattern verwendet, um die Auslösung eines Befehls von seiner Implementierung zu trennen, was die Flexibilität und Erweiterbarkeit meines Codes verbessert.
   - Durch die Verwendung des Command Patterns kann ich Befehle als Objekte behandeln, sie parametrisieren und in Warteschlangen speichern.
   - Das Command Pattern ermöglicht mir, meinen Code zu entkoppeln, was die Wiederverwendbarkeit und Testbarkeit erhöht.



## SOLID-Kriterien

Einzelne Verantwortlichkeit (Single Responsibility Principle - SRP):
- Die Klassen `CasinoMenu`, `RouletteGame`, `SlotMachine` und `RouletteTable` haben jeweils eine klar definierte Verantwortung und sollten das SRP nicht zu verletzen.

Open/Closed Prinzip (Open/Closed Principle - OCP):
- Die Verwendung des Command-Musters in `SpinCommand` und `ICommand` ermöglicht eine Erweiterbarkeit, indem neue Befehle hinzugefügt werden können, ohne den bestehenden Code zu ändern.
- Das Switch-Case von `CasinoMenu` erlaubt es, wenn gebraucht, neue Spiele für das Casino und danach kann man einfach eine Klasse für die Initialisierung hinzufügen, wie `PlaySlotMachine()` und `PlayRoulette`.

Liskov-Substitutionsprinzip (Liskov Substitution Principle - LSP):
- Wir haben keine Vererbungsbeziehungen vorhanden benutzt, damit ist das LSP nicht unmittelbar relevant.

Interface-Segregationsprinzip (Interface Segregation Principle - ISP):
- Das `ICommand`-Interface ist klein und fokussiert, was das ISP erfüllt.
- Genau so ist auch `IChipsObserver` klein gehalten mit nur einer Methode.

Dependency Inversion Prinzip (Dependency Inversion Principle - DIP):
- Die Verwendung von Dependency Injection in `CasinoMenu` und `RouletteGame` ermöglicht es, die Abhängigkeiten von der konkreten Implementierung zu trennen, indem Abstraktionen wie `ChipsObservable` und `ICommand` verwendet werden. Dies erfüllt das DIP.

Mögliche Verbesserungen:

1. **Liskov-Substitutionsprinzip (LSP)**: Obwohl in der bereitgestellten Software keine Vererbungsbeziehungen vorhanden sind, könnte das LSP in Zukunft relevant werden. Wenn Vererbung eingeführt wird, sollte sichergestellt werden, dass abgeleitete Klassen die Verhaltensweisen ihrer Basisklassen nicht verletzen. Beispielsweise könnte eine abgeleitete Klasse von `RouletteGame` für eine neue Spielvariante erstellt werden. In diesem Fall sollte die abgeleitete Klasse die Schnittstelle der Basisklasse vollständig implementieren und keine Verletzungen der Vor- und Nachbedingungen verursachen.

2. **Entkopplung und Erweiterbarkeit**: Die `RouletteGame`-Klasse könnte durch die Verwendung von Polymorphismus oder Strategien erweitert werden, um neue Spielarten des Roulette-Spiels hinzuzufügen. Beispielsweise könnte eine abstrakte Klasse oder ein Interface für verschiedene Roulette-Varianten erstellt werden, von denen `RouletteGame` ableitet oder implementiert.

3. **Fehlerbehandlung**: Die Fehlerbehandlung könnte in einigen Fällen verbessert werden, indem mehr aussagekräftige Fehlermeldungen ausgegeben und Ausnahmen geworfen werden, anstatt einfach auf die Eingabeaufforderung zurückzukehren. Dies würde die Benutzerfreundlichkeit erhöhen und die Fehlersuche erleichtern.

Insgesamt haben wir versucht, die SOLID-Prinzipien zu berücksichtigen, aber es gibt definitiv Raum für Verbesserungen in Bezug auf Wartbarkeit, Erweiterbarkeit und Testbarkeit des Codes. Die oben genannten Punkte könnten dazu beitragen, den Code robuster, flexibler und einfacher zu warten zu machen.

## Retrospektive

### Hindernisse

- **Zusammenarbeit** Wir konnten zuerst schwieriger zusammen arbeiten, da Julius's Visual Studio Lizenz abgelaufen ist und er so nicht von Anfang an der Software arbeiten.

- **Kommunikation** Wir haben uns am Anfang misverstanden und haben so an verschiedenen Tagen arbeiten wollen.

- **Code-Richtlinien** Wir haben verschiedene Benennungen benutzt.

### Lösungen

- Julius musste sich eine Community Version von Visual Studio herunterladen.

- Wir können Erinnerungen von Nachrichten in den Kalender schreiben.

- Wir hätten uns absprechen können, wie wir die Sachen benennen.
