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



## Retrospektive

### Hindernisse

- 

- 

-

### Lösungen

- 

- 

-
