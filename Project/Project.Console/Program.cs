using Project.DataAccess.Models;
using System;
using System.IO;
using System.Linq;

namespace Project.Console
{
    class Program
    {
        static int entTab;
        static int st;
        static int x;
        static int enterMenu;
        static void showTable()
        {
            System.Console.WriteLine("В базе данных присутствует 8 таблиц: \n");
            System.Console.WriteLine("1 - Аудитория\n");
            System.Console.WriteLine("2 - Сопроводительный документ\n");
            System.Console.WriteLine("3 - Инвентарь\n");
            System.Console.WriteLine("4 - Ремонт\n");
            System.Console.WriteLine("5 - Ответственные\n");
            System.Console.WriteLine("6 - Проверяющие\n");
            System.Console.WriteLine("7 - Инвентаризация\n");
            System.Console.WriteLine("8 - Список инвентаризации\n");
            System.Console.WriteLine("Введите 0, чтобы вернуться\n");
            st = Convert.ToInt32(System.Console.ReadLine());
            if (st == 0) { workBD(); }
        }
        static void enterTable()
        {
            System.Console.WriteLine("Выберите таблицу:\n");
            System.Console.WriteLine("1 - Аудитория\n");
            System.Console.WriteLine("2 - Сопроводительный документ\n");
            System.Console.WriteLine("3 - Инвентарь\n");
            System.Console.WriteLine("4 - Ремонт\n");
            System.Console.WriteLine("5 - Ответственные\n");
            System.Console.WriteLine("6 - Проверяющие\n");
            System.Console.WriteLine("7 - Инвентаризация\n");
            System.Console.WriteLine("8 - Список инвентаризации\n");
            System.Console.WriteLine("0 - Главное меню\n");
            entTab = Convert.ToInt32(System.Console.ReadLine());
            switch (entTab)
            {
                case 1:
                    x = 1;
                    break;
                case 2:
                    x = 2;
                    break;
                case 3:
                    x = 3;
                    break;
                case 4:
                    x = 4;
                    break;
                case 5:
                    x = 5;
                    break;
                case 6:
                    x = 6;
                    break;
                case 7:
                    x = 7;
                    break;
                case 8:
                    x = 8;
                    break;
                case 0:
                    workBD();
                    break;
            }
        }
        static void workBD()
        {

            System.Console.WriteLine("Добро пожаловать в аудиторный фонд!\n");
            System.Console.WriteLine("Для дальнейшей работы выберите:\n");
            System.Console.WriteLine("1 - Просмотр списка таблиц\n");
            System.Console.WriteLine("2 - Просмотр таблицы\n");
            System.Console.WriteLine("3 - Добавить данные в таблицу\n");
            System.Console.WriteLine("4 - Изменить данные в таблице\n");
            System.Console.WriteLine("5 - Удалить данные из таблицы\n");
            System.Console.WriteLine("0 - Выход\n");
            enterMenu = Convert.ToInt32(System.Console.ReadLine());

            switch (enterMenu)
            {
                case 1:
                    System.Console.WriteLine("Список таблиц\n");
                    showTable();
                    break;
                case 2:
                    System.Console.WriteLine("Просмотр таблицы\n");
                    enterTable();
                    break;
                case 3:
                    System.Console.WriteLine("Добавить данные в таблицу\n");
                    enterTable();
                    break;
                case 4:
                    System.Console.WriteLine("Изменить данные в таблице\n");
                    enterTable();
                    break;
                case 5:
                    System.Console.WriteLine("Удалить данные из таблицы\n");
                    enterTable();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }
        }
        public void Add_Document()
        {
            string IN;
            int DU;
            DateTime DF;
            DateTime DT;
            string R;
            System.Console.WriteLine("Введите название инвентаря");
            IN = System.Console.ReadLine();
            System.Console.WriteLine("Введиите срок экспулуатации");
            DU = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите дату ввода");
            DF = DateTime.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Введиите дату вывода");
            DT = DateTime.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Введиите причину");
            R = System.Console.ReadLine();

            var context = new ProjectDataBaseContext();
            var toAdd = new Document
            {
                InventoryName = IN,
                DurationOfUse = DU,
                DateUsedFrom = DF,
                DateUsedTo=DT,
                Reason = R
            };
            context.Documents.Add(toAdd);
            context.SaveChanges();
        }
        public void Add_Auditories()
        {
            var context = new ProjectDataBaseContext();
            var toAdd = new Document
            {
                InventoryName = "Stol",
                DurationOfUse = 2,
                DateUsedFrom = DateTime.Now,
                Reason = "I want it"
            };
            context.Documents.Add(toAdd);
            context.SaveChanges();
        }
        public void Add_Inventar()
        {
            var context = new ProjectDataBaseContext();
            var toAdd = new Document
            {
                InventoryName = "Stol",
                DurationOfUse = 2,
                DateUsedFrom = DateTime.Now,
                Reason = "I want it"
            };
            context.Documents.Add(toAdd);
            context.SaveChanges();
        }
        public void Add_Inventarization()
        {
            var context = new ProjectDataBaseContext();
            var toAdd = new Document
            {
                InventoryName = "Stol",
                DurationOfUse = 2,
                DateUsedFrom = DateTime.Now,
                Reason = "I want it"
            };
            context.Documents.Add(toAdd);
            context.SaveChanges();
        }
        public void Add_List()
        {
            var context = new ProjectDataBaseContext();
            var toAdd = new Document
            {
                InventoryName = "Stol",
                DurationOfUse = 2,
                DateUsedFrom = DateTime.Now,
                Reason = "I want it"
            };
            context.Documents.Add(toAdd);
            context.SaveChanges();
        }
        public void Add_Otvet()
        {
            var context = new ProjectDataBaseContext();
            var toAdd = new Document
            {
                InventoryName = "Stol",
                DurationOfUse = 2,
                DateUsedFrom = DateTime.Now,
                Reason = "I want it"
            };
            context.Documents.Add(toAdd);
            context.SaveChanges();
        }
        public void Add_Remont()
        {
            var context = new ProjectDataBaseContext();
            var toAdd = new Document
            {
                InventoryName = "Stol",
                DurationOfUse = 2,
                DateUsedFrom = DateTime.Now,
                Reason = "I want it"
            };
            context.Documents.Add(toAdd);
            context.SaveChanges();
        }
        public void Add_Prover()
        {
            var context = new ProjectDataBaseContext();
            var toAdd = new Document
            {
                InventoryName = "Stol",
                DurationOfUse = 2,
                DateUsedFrom = DateTime.Now,
                Reason = "I want it"
            };
            context.Documents.Add(toAdd);
            context.SaveChanges();
        }
        static void Main(string[] args)
        {
            var context = new ProjectDataBaseContext();
            var document = context.Documents.FirstOrDefault();
            var auditoriya = context.Auditories.FirstOrDefault();
            var inventar = context.Inventories.FirstOrDefault();
            var inventarisation = context.Inventarizations.FirstOrDefault();
            var list = context.Lists.FirstOrDefault();
            var remont = context.Repairs.FirstOrDefault();
            var otvet = context.Responsibles.FirstOrDefault();
            var prover = context.Verifiers.FirstOrDefault();

            workBD();
            if (enterMenu == 2)
            {   //просмотр таблиц
                switch (x)
                {
                    case 1:
                        System.Console.WriteLine("Таблица Аудитории: ");
                        System.Console.WriteLine("№ аудитории|id ответственного|тип аудитории\n");
                        System.Console.WriteLine(auditoriya.AuditoriumId + "     |" + auditoriya.ResponsibleId + "           |" + auditoriya.AuditoryType + "\n");
                        break;
                    case 2:
                        System.Console.WriteLine("Таблица Сопроводительный документ: ");
                        System.Console.WriteLine("№ документа|название|срок эксплуатации|дата ввода|дата вывода|причина\n");
                        System.Console.WriteLine(document.DocumentId + "     |" + document.InventoryName + "|" + document.DurationOfUse + "|" + document.DateUsedFrom + "|" + document.DateUsedTo + "|" + document.Reason + "\n");
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    default:
                        System.Console.WriteLine("Введено неверное значение");
                        break;

                }
            }
            else if (enterMenu == 3)
            {
                //Добавить данные в таблицу
                switch (x)
                {
                    case 1:
                        break;
                    case 2:
                        Add_Document();
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    default:
                        System.Console.WriteLine("Введено неверное значение");
                        break;

                }
            }
            else if (enterMenu == 4)
            {
                //Изменить данные в таблице
                switch (x)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    default:
                        System.Console.WriteLine("Введено неверное значение");
                        break;

                }
            }
            else if (enterMenu == 5)
            {
                //Удалить данные из таблицы
                switch (x)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    default:
                        System.Console.WriteLine("Введено неверное значение");
                        break;

                }
            }
        }
    }
}
