using System;
using System.Collections.Generic;

namespace TaskManager
{
    class Program
    {
        static void Main()
        {
            Task1();
            Task2();
        }
        static void Task1()
        {

           
            List<Person> teamMembers = new List<Person>
            {
                new Person("Исаак"),
                new Person("Иуда"),
                new Person("Иисус"),
                new Person("Исайя"),
                new Person("Ишак"),
                new Person("Иерусалисимус"),
                new Person("Иаков"),
                new Person("Ибрагим"),
                new Person("Имран"),
                new Person("Икар")
            };
            Console.WriteLine("Домашнее Задание. Написать программу Task Manager.\n");
            
            Project project = new Project("Разработка нового сайта", DateTime.Now.AddMonths(2), teamMembers[0], teamMembers[1]);

            
            for (int i = 0; i < 5; i++) // создаем задачи и добавляем их в проект
            {
                Task task = new Task($"Задача {i + 1}", DateTime.Now.AddDays(10), teamMembers[0]);
                project.AddTask(task);
                // назначаем задачи исполнителям
                task.Assignee = teamMembers[i + 2]; // назначаем каждому члену команды по задаче
            }

            project.StartProject();

            project.Tasks[0].StartTask(project.Tasks[0].Assignee); // исполнитель берет задачу в работу

            project.Tasks[0].CreateReport("Задача успешно завершена.", DateTime.Now);

            if (project.IsCompleted())
            {
                project.CloseProject();
            }

            Console.WriteLine($"Проект: {project.Description}, Состояние: {project.Status}");
            foreach (var task in project.Tasks)
            {
                Console.WriteLine($"Задача: {task.Description}, : {task.Status}, Исполнитель: {task.Assignee?.Name}");
                if (task.TaskReport != null)
                {
                    Console.WriteLine($"Отчет: {task.TaskReport.Text}, Выполнено: {task.TaskReport.Executor.Name}");
                }
            }
        }
        static void Task2()
        {
          Song mySong = new Song();

            List<Song> songs = new List<Song>();
            Console.WriteLine("\n\nДомашнее задание 9.1 В класс Song (из домашнего задания 8.2) добавить следующие\r\nконструкторы:\r\n1) параметры конструктора – название и автор песни, указатель на предыдущую песню\r\nинициализировать null.\r\n2) параметры конструктора – название, автор песни, предыдущая песня. В методе Main\r\nсоздать объект mySong. Возникнет ли ошибка при инициализации объекта mySong\r\nследующим образом: Song mySong = new Song(); ?\n");
 
            for (int i = 0; i < 4; i++)
            {
                Song song = new Song();
                Console.WriteLine($"Введите название песни {i + 1}:");
                song.SetName(Console.ReadLine());

                Console.WriteLine($"Введите автора песни {i + 1}:");
                song.SetAuthor(Console.ReadLine());

                songs.Add(song);
            }

            Console.WriteLine("\nСписок песен:");
            foreach (var song in songs)
            {
                Console.WriteLine(song.Title());
            }

            if (songs.Count >= 2)
            {
                bool areEqual = songs[0].Equals(songs[1]);
                if (areEqual)
                {
                    Console.WriteLine("\nПервая и вторая песни одинаковые.");
                }
                else
                {
                    Console.WriteLine("\nПервая и вторая песни разные.");
                }
            }
            else
            {
                Console.WriteLine("\nНедостаточно песен для сравнения.");
            }

            Console.ReadLine(); 
        }
    }
}
