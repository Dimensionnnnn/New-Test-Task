# New-Test-Task

Реализована база данных с двумя таблицами: сотрудники и подразделение.
Написаны 4 запроса для этой базы данных:
 1. Вывод сотрудника с максимальной заработной платой.
 
 ![image](https://user-images.githubusercontent.com/84111957/190895060-e590b040-5020-4097-bfae-3b1c4b955240.png)
 
 2. Отдел, с самой высокой заработной платой между сотрудниками.
 
 ![image](https://user-images.githubusercontent.com/84111957/190895082-6239c494-e500-4e58-8753-767473f3834f.png)
 
 3. Отдел, с максимальной суммарной зарплатой сотрудников.
 
 ![image](https://user-images.githubusercontent.com/84111957/190895092-fb748dd2-826a-4bb1-b9e6-ceb00bb1d591.png)
 
 4. Сотрудника, чье имя начинается на "Р" и заканчивается на "н".
 
 ![image](https://user-images.githubusercontent.com/84111957/190895107-6a27ef56-63fd-4e8c-ae45-a90ae94ef931.png)

Реализовано консольное приложение на C#, которое на вход принимает большой текстовый файл ("Война и Мир") (файлы на вход/выход лежат в bin/debug)
На выходе создает текстовый файл с перечислением всех уникальных слов, встречающихся в тексте, и количеством их употреблений,
отсортированных в порядке убывания количества употреблений.
