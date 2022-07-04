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
                    
                    2. Удалить файл по id. (+)
                    3. Добавить файл.  (+)
                    4.. Изменить имя файла по id. (+)
                    5. Вывод всех файлов, название которых начинается с заданного набора символов. ?
                    6. Реактировать профиль +
                    7. Выйти ??? " + "\n"
                ) ;

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

                    case 6:
                        //edit profile
                        EditProfile();
                        break;

                    default:
                        Console.WriteLine("\nВыберите нужное действие");
                        break;
                }

            }

        }

        public static void EditProfile()
        {
            Console.WriteLine("Введите айди профиля, который нужно отредактировать: ");

            int id = int.Parse(Console.ReadLine());

            Console.WriteLine(@"Выберите, что нужно отредактировать: 
                                1. Имя
                                2. Email
                                3. Дату рождения
                                4. Логин
                                5. Пароль
                                6. Отмена" + "\n");

            int action = int.Parse(Console.ReadLine());

            switch (action)
            {
                case 1:
                    EditNameProfile(id);
                    break;
                case 2:
                    EditEmailProfile(id);
                    break;
                case 3:
                    EditDateProfile(id);
                    break;
                case 4:
                    EditLoginProfile(id);
                    break;
                case 5:
                    EditPasswordProfile(id);
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }


                    //throw new NotImplementedException();
            }

        public static void EditPasswordProfile(int id)
        {
            Console.WriteLine("Введите новый пароль: ");

            string newpass = Console.ReadLine();
            var bll = DependencyResolver.Instance.ShareLogic;
            bll.EditPasswordProfileById(id, newpass);
            //throw new NotImplementedException();
        }

        public static void EditLoginProfile(int id)
        {
            Console.WriteLine("Введите новый логин: ");

            string newlog = Console.ReadLine();
            var bll = DependencyResolver.Instance.ShareLogic;
            bll.EditLoginProfileById(id, newlog);
            //throw new NotImplementedException();
        }

        public static void EditDateProfile(int id)
        {
            Console.WriteLine("Введите новую дату рождения: ");

            DateTime newdate = DateTime.Parse(Console.ReadLine());
            var bll = DependencyResolver.Instance.ShareLogic;
            bll.EditDateProfileById(id, newdate);
            //throw new NotImplementedException();
        }

        public static void EditEmailProfile(int id)
        {
            Console.WriteLine("Введите новый email: ");

            string newemail = Console.ReadLine();
            var bll = DependencyResolver.Instance.ShareLogic;
            bll.EditEmailProfileById(id, newemail);
            //throw new NotImplementedException();
        }

        public static void EditNameProfile(int id)
        {
            Console.WriteLine("Введите новое имя: ");

            string newname = Console.ReadLine();
            var bll = DependencyResolver.Instance.ShareLogic;
            bll.EditNameProfileById(id, newname);

            //throw new NotImplementedException();
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
