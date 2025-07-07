# TodoApp

Проект создан в целях демонстрации запуска приложения через Docker.  
Функционал базовый: создание задачи, удаление, отметка как выполненной.  
Добавлен таймер помодоро.  
Реализовано на Razor Pages.  
Используется база данных SQLite.

## Запуск через Docker

1. Клонируйте репозиторий:
```bash
https://github.com/ArturMirzaiev/ToDoMiniApp.git
cd todoapp

2. Соберите Docker-образ:
docker build -t todoapp .

3. Запустите контейнер:
docker run -d -p 8080:8080 todoapp

4. Откройте в браузере: 
http://localhost:8080:
