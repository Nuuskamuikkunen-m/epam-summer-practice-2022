using EPAM.FileSharing.Common.Entities;
using EPAM.FileSharing.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FileSharing.PL.ConsolePL
{
    public class Action
    {
       

        public static void MainMenu()
        {
            Action console = new Action();

            while (true)
            {
                Console.Write("\n" + @"Выберите действие:
                    0. Войти ?
                    1. Вывести информацию о профиле по id. +

                    //////
                    
                    2. Удалить файл по id. 
                    3. Добавить файл.  
                    4. Вывод всех файлов, название которых начинается с заданного набора символов.
                    5. Изменить имя файла по id. 
                    6. Реактировать профиль ?
                    7. Выйти"
                );

                int action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:

                        ShowInfoById();
                        break;

                    case 2:

                        DeleteFile();
                        break;

                    case 3:

                        AddFile();
                        break;

                    case 4:
                        EditNameFile();
                        break;

                    default:
                        Console.WriteLine("\nВыберите нужное действие");
                        break;
                }

            }

        }

        public static void AddFile()
        {

            Console.WriteLine("Название файла: ");
            var name = Console.ReadLine();
            Console.WriteLine("Расширение файла: ");
            var ext = Console.ReadLine();
            ShFile shfile = new ShFile(name, ext);


            var bll = DependencyResolver.Instance.ShareLogic;
            bll.AddFile(shfile);

            //throw new NotImplementedException();
        }

        private static void EditNameFile()
        {
            var bll = DependencyResolver.Instance.ShareLogic;
            foreach (var item in bll.GetShFiles())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Файла для редактирования имени: ");

            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Новое имя:");

            string newname = Console.ReadLine();

            bll.EditFile(id, newname);

            // throw new NotImplementedException();
        }

        public static void DeleteFile()
        {
            var bll = DependencyResolver.Instance.ShareLogic;

            foreach (var item in bll.GetShFiles())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("id файла для удаления");

            int id = int.Parse(Console.ReadLine());

            bll.RemoveFile(id);


            //throw new NotImplementedException();
        }

        public static void ShowInfoById()
        {

            var bll = DependencyResolver.Instance.ShareLogic;

            Console.WriteLine("id профиля: ");

            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("информация профиля: ");
            Console.WriteLine(bll.GetProfileById(id));
            Console.WriteLine();

            Console.WriteLine("Все файлы этого профиля: ");

            foreach (var item in bll.GetAllUserShFilesById(id))
            {
                Console.WriteLine(item);
            }
        }
    }
}
