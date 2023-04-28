# dotnet-partition-labels-testing
Проект по разработке различных (unit, api, ui) тестов для проверки решения задачи разбиения строки на подстроки с максимальным количеством уникальных символов. 
Тесты написаны с использованием библиотек NUnit и Selenium.

## Структура:
- PartitionLabels - проект с решением задачи
- PartitionLabels.Console - проект с консольным приложением для проверки решения
- PartitionLabels.UnitTests - проект с модульными тестами
- PartitionLabels.WebAPI - проект с WebAPI для проверки решения
- PartitionLabels.APITests - проект с API тестами
- PartitionLabels.WebUI - проект с WebUI для проверки решения
- PartitionLabels.UITests - проект с UI тестами

## Запуск тестов:
### Запуск модульных тестов:
- Выполнить команду: `dotnet test PartitionLabels.UnitTests`
### Запуск API тестов:
- Запустить проект PartitionLabels.WebAPI: `dotnet run --project PartitionLabels.WebAPI`
- Выполнить команду: `dotnet test PartitionLabels.APITests`
### Запуск UI тестов:
- Запустить проект PartitionLabels.WebUI: `dotnet run --project PartitionLabels.WebUI`
- Выполнить команду: `dotnet test PartitionLabels.UITests`
