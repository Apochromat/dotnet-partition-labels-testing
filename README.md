# dotnet-partition-labels-testing
Проект по разработке различных тестов для проверки решения задачи разбиения строки на подстроки с максимальным количеством уникальных символов. 
Решение задачи и тесты написаны на C#, тесты написаны с использованием библиотеки NUnit.
## Структура:
- PartitionLabels - проект с решением задачи
- PartitionLabels.Console - проект с консольным приложением для проверки решения
- PartitionLabels.UnitTests - проект с модульными тестами
- PartitionLabels.WebAPI - проект с WebAPI для проверки решения
- PartitionLabels.APITests - проект с API тестами

## Запуск тестов:
### Запуск модульных тестов:
- Выполнить команду: `dotnet test PartitionLabels.UnitTests`
### Запуск API тестов:
- Запустить проект PartitionLabels.WebAPI: `dotnet run --project PartitionLabels.WebAPI`
- Выполнить команду: `dotnet test PartitionLabels.APITests`