using Project.DataAccess.Models;
using System;
using System.IO;
using System.Linq;

namespace Project.Console
{
    public static class Program
    {
        private static int _entTab;
        private static int _st;
        private static int _x;
        private static int _enterMenu;
        private static int _enterChange;
        private static int _enterDelete;
        private static void ShowTable()
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
            _st = Convert.ToInt32(System.Console.ReadLine());
            if (_st == 0)
            {
                WorkBd();
            }
        }

        private static void EnterTable()
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
            _entTab = Convert.ToInt32(System.Console.ReadLine());
            switch (_entTab)
            {
                case 1:
                    _x = 1;
                    break;
                case 2:
                    _x = 2;
                    break;
                case 3:
                    _x = 3;
                    break;
                case 4:
                    _x = 4;
                    break;
                case 5:
                    _x = 5;
                    break;
                case 6:
                    _x = 6;
                    break;
                case 7:
                    _x = 7;
                    break;
                case 8:
                    _x = 8;
                    break;
                case 0:
                    WorkBd();
                    break;
            }
        }

        private static void WorkBd()
        {
            System.Console.WriteLine("Добро пожаловать в аудиторный фонд!\n");
            System.Console.WriteLine("Для дальнейшей работы выберите:\n");
            System.Console.WriteLine("1 - Просмотр списка таблиц\n");
            System.Console.WriteLine("2 - Просмотр таблицы\n");
            System.Console.WriteLine("3 - Добавить данные в таблицу\n");
            System.Console.WriteLine("4 - Изменить данные в таблице\n");
            System.Console.WriteLine("5 - Удалить данные из таблицы\n");
            System.Console.WriteLine("0 - Выход\n");
            _enterMenu = Convert.ToInt32(System.Console.ReadLine());

            switch (_enterMenu)
            {
                case 1:
                    System.Console.WriteLine("Список таблиц\n");
                    ShowTable();
                    break;
                case 2:
                    System.Console.WriteLine("Просмотр таблицы\n");
                    EnterTable();
                    break;
                case 3:
                    System.Console.WriteLine("Добавить данные в таблицу\n");
                    EnterTable();
                    break;
                case 4:
                    System.Console.WriteLine("Изменить данные в таблице\n");
                    EnterTable();
                    break;
                case 5:
                    System.Console.WriteLine("Удалить данные из таблицы\n");
                    EnterTable();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void Add_Document()
        {
            System.Console.WriteLine("Введите название инвентаря");
            var IN = System.Console.ReadLine();
            System.Console.WriteLine("Введиите срок экспулуатации");
            var DU = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите дату ввода");
            var DF = DateTime.Now;
            System.Console.WriteLine("Введиите причину");
            var R = System.Console.ReadLine();

            var context = new ProjectDataBaseContext();
            var toAdd = new Document
            {
                InventoryName = IN,
                DurationOfUse = DU,
                DateUsedFrom = DF,
                Reason = R
            };
            context.Documents.Add(toAdd);
            context.SaveChanges();
        }

        public static void Add_Auditories()
        {
            System.Console.WriteLine("Введиите id ответственного");
            var RI = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите тип аудитории");
            var AT = System.Console.ReadLine();
            
            var context = new ProjectDataBaseContext();
            var toAdd = new Auditory
            {
                ResponsibleId = RI,
                AuditoryType = AT
            };
            context.Auditories.Add(toAdd);
            context.SaveChanges();
        }

        public static void Add_Inventar()
        {
            System.Console.WriteLine("Введите id аудитории");
            var AI = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите id документа");
            var DI = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введите состояние");
            var CS = System.Console.ReadLine();
            System.Console.WriteLine("Введиите наличие");
            var Av = Convert.ToByte(System.Console.ReadLine());

            var context = new ProjectDataBaseContext();
            var toAdd = new Inventory
            {
                AuditoriumId = AI,
                DocumentId=DI,
                CurrentState=CS,
                Availability=Av
            };
            context.Inventories.Add(toAdd);
            context.SaveChanges();
        }

        public static void Add_Inventarization()
        {
            System.Console.WriteLine("Введите дату");
            var DI = DateTime.Now;
            System.Console.WriteLine("Введиите id проверяющего");
            var VI = Convert.ToInt32(System.Console.ReadLine());
            

            var context = new ProjectDataBaseContext();
            var toAdd = new Inventarization
            {
                InventarizationDate = DI,
                VerifierId = VI
            };
            context.Inventarizations.Add(toAdd);
            context.SaveChanges();
        }

        public static void Add_List()
        {
            System.Console.WriteLine("Введите id аудитории");
            var AI = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите id инвентаризации");
            var II = Convert.ToInt32(System.Console.ReadLine());
 
            var context = new ProjectDataBaseContext();
            var toAdd = new List
            {
                AuditoriumId = AI,
                InventarizationId = II
            };
            context.Lists.Add(toAdd);
            context.SaveChanges();
        }

        public static void Add_Otvet()
        {
            System.Console.WriteLine("Введите имя ответственного");
            var RN = System.Console.ReadLine();
            System.Console.WriteLine("Введиите пароль");
            var Pass = System.Console.ReadLine();

            var context = new ProjectDataBaseContext();
            var toAdd = new Responsible
            {
                ResponsibleName = RN,
                Password = Pass
            };
            context.Responsibles.Add(toAdd);
            context.SaveChanges();
        }

        public static void Add_Remont()
        {
            System.Console.WriteLine("Введите id аудитории");
            var II = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите id документа");
            var DI = DateTime.Now;
            System.Console.WriteLine("Введиите описание");
            var De = System.Console.ReadLine();

            var context = new ProjectDataBaseContext();
            var toAdd = new Repair
            {
                InventoryId = II,
                DateStart = DI,
                Description = De
            };
            context.Repairs.Add(toAdd);
            context.SaveChanges();
        }

        public static void Add_Prover()
        {
            System.Console.WriteLine("Введите имя проверяющего");
            var VN = System.Console.ReadLine();
            System.Console.WriteLine("Введиите пароль");
            var Pass = System.Console.ReadLine();

            var context = new ProjectDataBaseContext();
            var toAdd = new Verifier
            {
                VefifierName = VN,
                Password = Pass
            };
            context.Verifiers.Add(toAdd);
            context.SaveChanges();
        }

        public static void changeDocument() {
           /* System.Console.WriteLine("Введите название инвентаря");
            var IN = System.Console.ReadLine();
            System.Console.WriteLine("Введиите срок экспулуатации");
            var DU = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите дату ввода");
            var DF = DateTime.Now;
            System.Console.WriteLine("Введиите причину");
            var R = System.Console.ReadLine();
            var context = new ProjectDataBaseContext();
            var toChange = context.Documents.First(x => x.DocumentId == _enterChange)
             {
                InventoryName = IN,
                DurationOfUse = DU,
                DateUsedFrom = DateTime.Now,
                Reason = R
            };

            context.SaveChanges();*/
        }
        public static void deleteDocument() {
            var context = new ProjectDataBaseContext();
            var toDelete = context.Documents.First(x => x.DocumentId == _enterDelete);
            context.Documents.Remove(toDelete);
            context.SaveChanges();
        }
        public static void deleteAuditoriya()
        {
            var context = new ProjectDataBaseContext();
            var toDelete = context.Auditories.First(x => x.AuditoriumId == _enterDelete);
            context.Auditories.Remove(toDelete);
            context.SaveChanges();
        }
        public static void deleteInventarization()
        {
            var context = new ProjectDataBaseContext();
            var toDelete = context.Inventarizations.First(x => x.InventarizationId == _enterDelete);
            context.Inventarizations.Remove(toDelete);
            context.SaveChanges();
        }
        public static void deleteInventory()
        {
            var context = new ProjectDataBaseContext();
            var toDelete = context.Inventories.First(x => x.InventoryId == _enterDelete);
            context.Inventories.Remove(toDelete);
            context.SaveChanges();
        }
        public static void deleteList()
        {
            var context = new ProjectDataBaseContext();
            var toDelete = context.Lists.First(x => x.ListId == _enterDelete);
            context.Lists.Remove(toDelete);
            context.SaveChanges();
        }
        public static void deleteRepair()
        {
            var context = new ProjectDataBaseContext();
            var toDelete = context.Repairs.First(x => x.RepairId == _enterDelete);
            context.Repairs.Remove(toDelete);
            context.SaveChanges();
        }
        public static void deleteResponsible()
        {
            var context = new ProjectDataBaseContext();
            var toDelete = context.Responsibles.First(x => x.ResponsibleId == _enterDelete);
            context.Responsibles.Remove(toDelete);
            context.SaveChanges();
        }
        public static void deleteVerifier()
        {
            var context = new ProjectDataBaseContext();
            var toDelete = context.Verifiers.First(x => x.VerifierId == _enterDelete);
            context.Verifiers.Remove(toDelete);
            context.SaveChanges();
        }
        private static void Main()
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
            while (true)
            {
                WorkBd();
                if (_enterMenu == 2)
                {
                               
                    //просмотр таблиц
                    switch (_x)
                    {
                        case 1:
                            System.Console.WriteLine("Таблица Аудитория\n");
                            context.Auditories.ToList().ForEach(System.Console.WriteLine);
                            break;
                        case 2:
                            System.Console.WriteLine("Таблица Сопроводительные документы\n");
                            context.Documents.ToList().ForEach(System.Console.WriteLine);
                            break;
                        case 3:
                            System.Console.WriteLine("Таблица Инвентарь\n");
                            context.Inventories.ToList().ForEach(System.Console.WriteLine);
                            break;
                        case 4:
                            System.Console.WriteLine("Таблица Ремонт\n");
                            context.Repairs.ToList().ForEach(System.Console.WriteLine);
                            break;
                        case 5:
                            System.Console.WriteLine("Таблица Ответственный\n");
                            context.Responsibles.ToList().ForEach(System.Console.WriteLine);
                            break;
                        case 6:
                            System.Console.WriteLine("Таблица Проверяющий\n");
                            context.Verifiers.ToList().ForEach(System.Console.WriteLine);
                            break;
                        case 7:
                            System.Console.WriteLine("Таблица Инвентаризация\n");
                            context.Inventarizations.ToList().ForEach(System.Console.WriteLine);
                            break;
                        case 8:
                            System.Console.WriteLine("Таблица Список\n");
                            context.Lists.ToList().ForEach(System.Console.WriteLine);
                            break;
                        default:
                            System.Console.WriteLine("Введено неверное значение");
                            break;
                    }
                }
                else if (_enterMenu == 3)
                {
                    //Добавить данные в таблицу
                    switch (_x)
                    {
                        case 1:
                            Add_Auditories();
                            break;
                        case 2:
                            Add_Document();
                            break;
                        case 3:
                            Add_Inventar();
                            break;
                        case 4:
                            Add_Remont();
                            break;
                        case 5:
                            Add_Otvet();
                            break;
                        case 6:
                            Add_Prover();
                            break;
                        case 7:
                            Add_Inventarization();
                            break;
                        case 8:
                            Add_List();
                            break;
                        default:
                            System.Console.WriteLine("Введено неверное значение");
                            break;
                    }
                }
                else if (_enterMenu == 4)
                {

                    //Изменить данные в таблице
                    switch (_x)
                    {
                        case 1:
                            break;
                        case 2:
                            System.Console.WriteLine("Введите id документа для изменения");
                            _enterChange = Convert.ToInt32(System.Console.ReadLine());
                            changeDocument();
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
                else if (_enterMenu == 5)
                {
                    
                    System.Console.WriteLine("5 - Ответственные\n");
                    System.Console.WriteLine("6 - Проверяющие\n");
                    System.Console.WriteLine("7 - Инвентаризация\n");
                    System.Console.WriteLine("8 - Список инвентаризации\n");
                    System.Console.WriteLine("0 - Главное меню\n");
                    //Удалить данные из таблицы
                    switch (_x)
                    {
                        case 1:
                            System.Console.WriteLine("Введите id аудитории для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteAuditoriya();
                            break;
                        case 2:
                            System.Console.WriteLine("Введите id документа для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteDocument();
                            break;
                        case 3:
                            System.Console.WriteLine("Введите id инвентаря для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteDocument();
                            break;
                        case 4:
                            System.Console.WriteLine("Введите id ремонта для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteDocument();
                            break;
                        case 5:
                            System.Console.WriteLine("Введите id ответственного для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteDocument();
                            break;
                        case 6:
                            System.Console.WriteLine("Введите id проверяющего для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteDocument();
                            break;
                        case 7:
                            System.Console.WriteLine("Введите id инвентаризации для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteDocument();
                            break;
                        case 8:
                            System.Console.WriteLine("Введите id списка для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteDocument();
                            break;
                        default:
                            System.Console.WriteLine("Введено неверное значение");
                            break;
                    }
                }
            }
        }
    }
}