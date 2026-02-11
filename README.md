# Система подбора водителей

## Описание
Реализация трёх алгоритмов поиска ближайших водителей:
1. Linear Search
2. Priority Queue
3. Grid-Based Search

![Скриншот README](benchmark.png)
## Результаты бенчмарков (BenchmarkDotNet)

| Алгоритм             | 100 водителей | 1000 водителей |
|----------------------|---------------|----------------|
| Linear Search        | 8.991 μs      | 132.422 μs     |
| Priority Queue       | 6.867 μs      | 61.022 μs      |
| Grid-Based           | 9.143 μs      | 129.108 μs     |

> Вывод: Priority Queue показал лучшее время при обоих размерах данных.

## Архитектура
- `DriverMatching.Core` — модели и интерфейсы
- `DriverMatching.Algorithms` — реализация алгоритмов
- `DriverMatching.Tests` — модульные тесты
- `DriverMatching.Benchmarks` — сравнение производительности
