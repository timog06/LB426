# Projektdokumentation

von Julius Burlet und Timo Goedertier

## User Stories

| ID | Priorität | Wer/Was/warum |
| ------- | ------- | ------- | 
|1.1|Mittel|Als Spieler möchte ich eine art 'Main Menu' haben.|
|1.2|Hoch|Als Spieler möchte ich zwischen Roulette und Slot Machine auswählen können.|
|1.3|Hoch|Als Spieler möchte ich Geld in Chips umwandeln können.|
|1.4|Tief|Als Spieler möchte ich die Anwendung beenden können.|
|1.5|Tief|Als Spieler möchte ich jederzeit zurück zum Menu kommen können.
|2.1|Hoch|Als Spieler möchte ich Slot Machines spielen können.|
|3.1|Hoch|Als Spieler möchte ich Roulette spielen können.|
|4.1|Hoch|Als Spieler möchte ich, dass mein Geld über eine Session bleibt, aber nicht gespeichert wird nach dem beenden der Applikation.|

## Scrum Board

| Backlog | To Do | In Progress | Testing | Done |
| ------- | ----- | ----------- | ------- | ---- |
|         |       |3.1          |         |1.1|
|         |       |1.2          |         |1.3|
|         |       |             |         |1.4|
|         |       |             |         |2.1|
|         |       |             |         |4.1|
|         |       |             |         |1.5|

## Aufteilungs Planung

| US-ID | Bis | Wer |
| ----- | ----- | --- |
| 1.1   |29.04.2024|Timo Goedertier|
| 1.2   |29.04.2024|Julius Burlet|
| 1.3   |29.04.2024|Timo Goedertier|
| 1.4   |29.04.2024|Julius Burlet|
| 1.5   |29.04.2024|Timo Goedertier|
| 2.1   |29.04.2024|Timo Goedertier|
| 3.1   |29.04.2024|Julius Burlet|
| 4.1   |29.04.2024|Timo Goedertier|

Da J. Burlet ein Problem mit Visual Studio 2022 hatte, wegen der Lizenz der BBB konnte er nicht zur gleichen Zeit wie T. Goedertier anfangen.

## Realisation

| US-ID | Datum | Von |
| ----- | ----- | --- |
| 1.1   |27.04.2024|Timo Goedertier|
| 1.2   |29.04.2024|Timo Goedertier|
| 1.3   |27.04.2024|Timo Goedertier|
| 1.4   |27.04.2024|Timo Goedertier|
| 1.5   |27.04.2024|Timo Goedertier|
| 2.1   |28.04.2024|Timo Goedertier|
| 3.1   |29.04.2024|Julius Burlet|
| 4.1   |28.04.2024|Timo Goedertier|

## Test Driven Development (TDD)

### Timo

Ich konnte gut mit TDD arbeiten und es hat teils auch sehr geholfen es so zu machen. Das einzige Problem, welches ich habe, ist, dass meine Unit Tests versuchen Konsole-Interaktionen zu testen, wobei dies bei Unit Tests nicht möglich ist.

Erklärung von ChatGPT: https://chat.openai.com/share/421616bc-0a81-445e-bd0f-fc5078af3193

### Julius



## Observer-Pattern

Das Observer-Pattern wird in diesem Code durch die Klassen `IChipsObserver`, `ChipsObservable` und `CasinoMenu` implementiert.

1. `IChipsObserver` ist das Interface, das die Beobachter (Observers) implementieren müssen. Es definiert die Methode `ChipsUpdated(int newChips)`, die aufgerufen wird, wenn sich die beobachtete Eigenschaft (in diesem Fall die Anzahl der Chips) ändert.

2. `ChipsObservable` ist die Subjekt-Klasse, die die beobachtete Eigenschaft (`Chips`) enthält. Sie hat eine Liste von `IChipsObserver`-Objekten, die über Änderungen der `Chips`-Eigenschaft informiert werden sollen. Wenn sich der Wert von `Chips` ändert, wird die Methode `NotifyObservers()` aufgerufen, die wiederum die `ChipsUpdated`-Methode für alle registrierten Beobachter aufruft.

3. `CasinoMenu`, `SlotMachine` und `Roulette` sind die Beobachter (Observer). Es implementiert das `IChipsObserver`-Interface und registriert sich selbst als Beobachter in der `ChipsObservable`-Instanz im Konstruktor. Wenn die `ChipsUpdated`-Methode aufgerufen wird, gibt `CasinoMenu` eine Meldung auf der Konsole aus.

Durch diese Entkopplung können beliebig viele Beobachter an der `ChipsObservable` registriert werden, ohne dass die Implementierung der Subjekt-Klasse geändert werden muss. Wenn sich die Anzahl der Chips ändert, werden alle Beobachter über die Änderung informiert und können entsprechend reagieren.

## Command-Pattern

1

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

