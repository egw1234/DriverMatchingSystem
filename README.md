# DriverMatching.Algorithms

Реализация трёх алгоритмов поиска ближайших водителей:
1. Linear Search
2. Priority Queue  
3. Grid-Based Search

## Результаты бенчмарков

![Бенчмарк](benchmark.png)

| Алгоритм         | Время выполнения |
|------------------|-----------------|
| Linear Search    | 12,21 мс        |
| Priority Queue   | 6,60 мс         |
| Grid-Based       | 0,37 мс         |

> Вывод: Grid-Based алгоритм самый быстрый при малом количестве водителей (10).

## Архитектура
- `DriverMatching.Core` — модели и интерфейсы
- `DriverMatching.Algorithms` — реализация алгоритмов
- `DriverMatching.Tests` — модульные тесты
- `DriverMatching.Benchmarks` — сравнение производительности

## Тестирование
- Все алгоритмы прошли модульные тесты
- Проверена корректность результата (ID водителей и расстояния)