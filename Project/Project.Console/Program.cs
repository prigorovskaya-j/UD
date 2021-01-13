using Project.DataAccess.Models;
using System;
using System.IO;
using System.Linq;

namespace Project.Console
{
    public static class Program
    {
        private static bool dostup=true;
        private static int _entTab;
        private static int _st;
        private static int _x;
        private static int _enterMenu;
        private static int _enterChange;
        private static int _enterDelete;
        private static int adminId = 0987654321;
        private static string adminPassword = "masterkey";

        private static int _po;
        private static int _id;
        private static string _ps;
        private static bool _admin = false, _prover = false, _otvet = false;
        private static bool _adminP = false, _proverP = false, _otvetP = false;

        private static bool vhodAdmin = false, vhodProver = false, vhodOtvet = false;

        private static bool vhod = false;

        private static int enterLogin = -1;
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
            try {
            _entTab = Convert.ToInt32(System.Console.ReadLine());
            }
            catch (Exception ex) { 
                System.Console.WriteLine("Введен неверный формат данных! Введите число!\n");
                EnterTable();
            }
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
        private static void EnterTableOtvet()
        {
            System.Console.WriteLine("Выберите таблицу:\n");
            System.Console.WriteLine("1 - Аудитория\n");
            System.Console.WriteLine("2 - Сопроводительный документ\n");
            System.Console.WriteLine("3 - Инвентарь\n");
            System.Console.WriteLine("4 - Ремонт\n");
            System.Console.WriteLine("0 - Главное меню\n");
            try { 
            _entTab = Convert.ToInt32(System.Console.ReadLine());
            }
            catch (Exception ex) { 
                System.Console.WriteLine("Введен неверный формат данных! Введите число!\n");
                EnterTableOtvet();
            }
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
                    System.Console.WriteLine("У вас нет доступа!\n");
                    dostup = false;
                    break;
                case 6:
                    System.Console.WriteLine("У вас нет доступа!\n");
                    dostup = false;
                    break;
                case 7:
                    System.Console.WriteLine("У вас нет доступа!\n");
                    dostup = false;
                    break;
                case 8:
                    System.Console.WriteLine("У вас нет доступа!\n");
                    dostup = false;
                    break;
                case 0:
                    WorkBd();
                    break;
            }
        }
        private static void EnterTableProver()
        {
            System.Console.WriteLine("Выберите таблицу:\n");
            System.Console.WriteLine("1 - Аудитория\n");
            System.Console.WriteLine("2 - Сопроводительный документ\n");
            System.Console.WriteLine("3 - Инвентарь\n");
            System.Console.WriteLine("7 - Инвентаризация\n");
            System.Console.WriteLine("8 - Список инвентаризации\n");
            System.Console.WriteLine("0 - Главное меню\n");
            try { 
            _entTab = Convert.ToInt32(System.Console.ReadLine());
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных! Введите число!\n");
                EnterTableProver();
            }
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
                    System.Console.WriteLine("У вас нет доступа!\n");
                    dostup = false;
                    break;
                case 5:
                    System.Console.WriteLine("У вас нет доступа!\n");
                    dostup = false;
                    break;
                case 6:
                    System.Console.WriteLine("У вас нет доступа!\n"); 
                    dostup = false;
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
            System.Console.WriteLine("5 - Сохранить данные из таблицы в файл\n");
            System.Console.WriteLine("6 - Удалить данные из таблицы\n");
            System.Console.WriteLine("0 - Выход\n");
            try { 
            _enterMenu = Convert.ToInt32(System.Console.ReadLine());
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных! Введите число!\n");
                WorkBd();
            }

            switch (_enterMenu)
            {
                case 1:
                    System.Console.WriteLine("Список таблиц\n");
                    ShowTable();
                    break;
                case 2:
                    System.Console.WriteLine("Просмотр таблицы\n");
                    if (_admin == true) { EnterTable(); }
                    else if (_prover == true) { EnterTableProver(); }
                    else if (_otvet==true) { EnterTableOtvet(); };                   
                    break;
                case 3:
                    System.Console.WriteLine("Добавить данные в таблицу\n");
                    if (_admin == true) { EnterTable(); }
                    else if (_prover == true) { EnterTableProver(); }
                    else if (_otvet == true) { EnterTableOtvet(); };
                    break;
                case 4:
                    System.Console.WriteLine("Изменить данные в таблице\n");
                    if (_admin == true) { EnterTable(); }
                    else if (_prover == true) { EnterTableProver(); }
                    else if (_otvet == true) { EnterTableOtvet(); };
                    break;
                case 5:
                    System.Console.WriteLine("Удалить данные из таблицы\n");
                    if (_admin == true) { EnterTable(); }
                    else if (_prover == true) { EnterTableProver(); }
                    else if (_otvet == true) { EnterTableOtvet(); };
                    break;
                case 6:
                    System.Console.WriteLine("Сохранить данные из таблицы в файл\n");
                    if (_admin == true) { EnterTable(); }
                    else if (_prover == true) { EnterTableProver(); }
                    else if (_otvet == true) { EnterTableOtvet(); };
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void Add_Document()
        {
            var context = new ProjectDataBaseContext();
            try { 
            System.Console.WriteLine("Введите название инвентаря");
            var IN = System.Console.ReadLine();
            System.Console.WriteLine("Введиите срок экспулуатации");
            var DU = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите дату ввода");
            var DF = DateTime.Now;
            System.Console.WriteLine("Введиите причину");
            var R = System.Console.ReadLine();
                       
            var toAdd = new Document
            {
                InventoryName = IN,
                DurationOfUse = DU,
                DateUsedFrom = DF,
                Reason = R
            };

            context.Documents.Add(toAdd);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных!\n");
                WorkBd();
            }
            context.SaveChanges();
        }

        public static void Add_Auditories()
        {
            var context = new ProjectDataBaseContext();
            try { 
            System.Console.WriteLine("Введиите id ответственного");
            var RI = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите тип аудитории");
            var AT = System.Console.ReadLine();
                        
            var toAdd = new Auditory
            {
                ResponsibleId = RI,
                AuditoryType = AT
            };
            context.Auditories.Add(toAdd);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных!\n");
                WorkBd();
            }
            context.SaveChanges();
        }

        public static void Add_Inventar()
        {
            var context = new ProjectDataBaseContext();
            try { 
            System.Console.WriteLine("Введите id аудитории");
            var AI = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите id документа");
            var DI = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введите состояние");
            var CS = System.Console.ReadLine();
            System.Console.WriteLine("Введиите наличие");
            var Av = Convert.ToByte(System.Console.ReadLine());
                       
            var toAdd = new Inventory
            {
                AuditoriumId = AI,
                DocumentId=DI,
                CurrentState=CS,
                Availability=Av
            };
            context.Inventories.Add(toAdd);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных!\n");
                WorkBd();
            }
            context.SaveChanges();
        }

        public static void Add_Inventarization()
        {
            var context = new ProjectDataBaseContext();
            try { 
            System.Console.WriteLine("Введите дату");
            var DI = DateTime.Now;
            System.Console.WriteLine("Введиите id проверяющего");
            var VI = Convert.ToInt32(System.Console.ReadLine());
                        
            var toAdd = new Inventarization
            {
                InventarizationDate = DI,
                VerifierId = VI
            };
            context.Inventarizations.Add(toAdd);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных!\n");
                WorkBd();
            }
            context.SaveChanges();
        }

        public static void Add_List()
        {
            var context = new ProjectDataBaseContext();
            try { 
            System.Console.WriteLine("Введите id аудитории");
            var AI = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите id инвентаризации");
            var II = Convert.ToInt32(System.Console.ReadLine());
             
            var toAdd = new List
            {
                AuditoriumId = AI,
                InventarizationId = II
            };
            context.Lists.Add(toAdd);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных!\n");
                WorkBd();
            }
            context.SaveChanges();
        }

        public static void Add_Otvet()
        {
            var context = new ProjectDataBaseContext();
            try { 
            System.Console.WriteLine("Введите имя ответственного");
            var RN = System.Console.ReadLine();
            System.Console.WriteLine("Введиите пароль");
            var Pass = System.Console.ReadLine();
                        
            var toAdd = new Responsible
            {
                ResponsibleName = RN,
                Password = Pass
            };
            context.Responsibles.Add(toAdd);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных!\n");
                WorkBd();
            }
            context.SaveChanges();
        }

        public static void Add_Remont()
        {
            var context = new ProjectDataBaseContext();
            try { 
            System.Console.WriteLine("Введите id аудитории");
            var II = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите id документа");
            var DI = DateTime.Now;
            System.Console.WriteLine("Введиите описание");
            var De = System.Console.ReadLine();
                        
            var toAdd = new Repair
            {
                InventoryId = II,
                DateStart = DI,
                Description = De
            };
            context.Repairs.Add(toAdd);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных!\n");
                WorkBd();
            }
            context.SaveChanges();
        }

        public static void Add_Prover()
        {
            var context = new ProjectDataBaseContext();
            try { 
            System.Console.WriteLine("Введите имя проверяющего");
            var VN = System.Console.ReadLine();
            System.Console.WriteLine("Введиите пароль");
            var Pass = System.Console.ReadLine();

            var toAdd = new Verifier
            {
                VefifierName = VN,
                Password = Pass
            };
            context.Verifiers.Add(toAdd);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных!\n");
                WorkBd();
            }
            context.SaveChanges();
        }

        public static void changeDocument() {
            var context = new ProjectDataBaseContext();
            try
            {
             System.Console.WriteLine("Введите название инвентаря");
            var IN = System.Console.ReadLine();
            System.Console.WriteLine("Введиите срок экспулуатации");
            var DU = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите дату ввода");
            var DF = DateTime.Now;
            System.Console.WriteLine("Введиите причину");
            var R = System.Console.ReadLine();
            
                var document = context.Documents.Where(x => x.DocumentId == _enterChange).FirstOrDefault();

                document.InventoryName = IN;
                document.DurationOfUse = DU;
                document.DateUsedFrom = DateTime.Now;
                document.Reason = R;
            }
            catch (Exception ex) { 
                System.Console.WriteLine("Введен неверный формат данных или id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void changeAuditory()
        {
            var context = new ProjectDataBaseContext();
            try
            {
            System.Console.WriteLine("Введите id ответственного");
            var RI = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите тип аудитории");
            var AT = System.Console.ReadLine();
                      
                var auditory = context.Auditories.Where(x => x.AuditoriumId == _enterChange).FirstOrDefault();

                auditory.ResponsibleId = RI;
                auditory.AuditoryType = AT;
            }
            catch (Exception ex) {
                System.Console.WriteLine("Введен неверный формат данных или id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void changeInventory()
        {
            var context = new ProjectDataBaseContext();

            try
            {
            System.Console.WriteLine("Введите id аудитории");
            var AI = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите id документа");
            var DI = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите состояние");
            var CS = System.Console.ReadLine();
            System.Console.WriteLine("Введиите наличие");
            var Av = Convert.ToByte(System.Console.ReadLine());

            var inventory = context.Inventories.Where(x => x.InventoryId == _enterChange).FirstOrDefault();

            inventory.AuditoriumId = AI;
            inventory.DocumentId = DI;
            inventory.CurrentState = CS;
            inventory.Availability = Av;
            }
            catch (Exception ex) {
                System.Console.WriteLine("Введен неверный формат данных или id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void changeInventarization()
        {
            var context = new ProjectDataBaseContext();
            try { 
            System.Console.WriteLine("Введиите дату");
            var ID = DateTime.Now;
            System.Console.WriteLine("Введиите причину");
            var VI = Convert.ToInt32(System.Console.ReadLine());
                       
            var inventarization = context.Inventarizations.Where(x => x.InventarizationId == _enterChange).FirstOrDefault();

            inventarization.InventarizationDate = ID;
            inventarization.VerifierId = VI;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных или id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void changeList()
        {
            var context = new ProjectDataBaseContext();
            try { 
            System.Console.WriteLine("Введите id аудитории");
            var AI = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите id инвентаризации");
            var II = Convert.ToInt32(System.Console.ReadLine());
           
            var list = context.Lists.Where(x => x.ListId == _enterChange).FirstOrDefault();

            list.AuditoriumId = AI;
            list.InventarizationId = II;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных или id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void changeRemont()
        {
            var context = new ProjectDataBaseContext();
            try
            {
            System.Console.WriteLine("Введите id инвентаря");
            var II = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите дату ремонта");
            var DS = DateTime.Now;
            System.Console.WriteLine("Введиите описание");
            var De = System.Console.ReadLine();
                    
                var remont = context.Repairs.Where(x => x.RepairId == _enterChange).FirstOrDefault();
                remont.InventoryId = II;
                remont.DateStart = DS;
                remont.Description = De;
            }
            catch (Exception ex) {
                System.Console.WriteLine("Введен неверный формат данных или id не найден\n");
                WorkBd();
            }                     
            context.SaveChanges();
        }
        public static void changeOtvet()
        {
            var context = new ProjectDataBaseContext();

            try
            {
            System.Console.WriteLine("Введите имя ответственного");
            var RN = System.Console.ReadLine();
            System.Console.WriteLine("Введиите пароль");
            var Pass = System.Console.ReadLine();

            var otvet = context.Responsibles.Where(x => x.ResponsibleId == _enterChange).FirstOrDefault();

            otvet.ResponsibleName = RN;
            otvet.Password = Pass;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Введен неверный формат данных или id не найден\n");
                WorkBd();
            }

            context.SaveChanges();
        }
        public static void changeProver()
        {
            var context = new ProjectDataBaseContext();
            try
            {
            System.Console.WriteLine("Введите название инвентаря");
            var IN = System.Console.ReadLine();
            System.Console.WriteLine("Введиите срок экспулуатации");
            var DU = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Введиите дату ввода");
            var DF = DateTime.Now;
            System.Console.WriteLine("Введиите причину");
            var R = System.Console.ReadLine();

            var document = context.Documents.Where(x => x.DocumentId == _enterChange).FirstOrDefault();

            document.InventoryName = IN;
            document.DurationOfUse = DU;
            document.DateUsedFrom = DateTime.Now;
            document.Reason = R;
            }
            catch (Exception ex) {
                System.Console.WriteLine("Введен неверный формат данных или id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void deleteDocument() {
            var context = new ProjectDataBaseContext();
            try
            {
                var toDelete = context.Documents.First(x => x.DocumentId == _enterDelete);
                context.Documents.Remove(toDelete);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void deleteAuditoriya()
        {
            var context = new ProjectDataBaseContext();
            try { 
            var toDelete = context.Auditories.First(x => x.AuditoriumId == _enterDelete);
            context.Auditories.Remove(toDelete);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void deleteInventarization()
        {
            var context = new ProjectDataBaseContext();
            try { 
            var toDelete = context.Inventarizations.First(x => x.InventarizationId == _enterDelete);
            context.Inventarizations.Remove(toDelete);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void deleteInventory()
        {
            var context = new ProjectDataBaseContext();
            try { 
            var toDelete = context.Inventories.First(x => x.InventoryId == _enterDelete);
            context.Inventories.Remove(toDelete);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void deleteList()
        {
            var context = new ProjectDataBaseContext();
            try { 
            var toDelete = context.Lists.First(x => x.ListId == _enterDelete);
            context.Lists.Remove(toDelete);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void deleteRepair()
        {
            var context = new ProjectDataBaseContext();
            try { 
            var toDelete = context.Repairs.First(x => x.RepairId == _enterDelete);
            context.Repairs.Remove(toDelete);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void deleteResponsible()
        {
            var context = new ProjectDataBaseContext();
            try { 
            var toDelete = context.Responsibles.First(x => x.ResponsibleId == _enterDelete);
            context.Responsibles.Remove(toDelete);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void deleteVerifier()
        {
            var context = new ProjectDataBaseContext();
            try { 
            var toDelete = context.Verifiers.First(x => x.VerifierId == _enterDelete);
            context.Verifiers.Remove(toDelete);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("id не найден\n");
                WorkBd();
            }
            context.SaveChanges();
        }
        public static void saveDocument() {
            string writePath = @"C:\Users\prigo\Downloads\document.txt";
            var context = new ProjectDataBaseContext();
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    context.Documents.ToList().ForEach(sw.WriteLine);
                }

                System.Console.WriteLine("Запись выполнена\n");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public static void saveAuditoriya()
        {
            string writePath = @"C:\Users\prigo\Downloads\auditoriya.txt";
            var context = new ProjectDataBaseContext();
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    context.Auditories.ToList().ForEach(sw.WriteLine);
                }

                System.Console.WriteLine("Запись выполнена\n");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public static void saveList()
        {
            string writePath = @"C:\Users\prigo\Downloads\list.txt";
            var context = new ProjectDataBaseContext();
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    context.Lists.ToList().ForEach(sw.WriteLine);
                }

                System.Console.WriteLine("Запись выполнена\n");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public static void saveProver()
        {
            string writePath = @"C:\Users\prigo\Downloads\verifiers.txt";
            var context = new ProjectDataBaseContext();
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    context.Verifiers.ToList().ForEach(sw.WriteLine);
                }

                System.Console.WriteLine("Запись выполнена\n");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public static void saveOtvet()
        {
            string writePath = @"C:\Users\prigo\Downloads\responsible.txt";
            var context = new ProjectDataBaseContext();
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    context.Responsibles.ToList().ForEach(sw.WriteLine);
                }

                System.Console.WriteLine("Запись выполнена\n");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public static void saveRemont()
        {
            string writePath = @"C:\Users\prigo\Downloads\remont.txt";
            var context = new ProjectDataBaseContext();
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    context.Repairs.ToList().ForEach(sw.WriteLine);
                }

                System.Console.WriteLine("Запись выполнена\n");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public static void saveInventarization()
        {
            string writePath = @"C:\Users\prigo\Downloads\inventarization.txt";
            var context = new ProjectDataBaseContext();
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    context.Inventarizations.ToList().ForEach(sw.WriteLine);
                }

                System.Console.WriteLine("Запись выполнена\n");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public static void saveInventory()
        {
            string writePath = @"C:\Users\prigo\Downloads\inventory.txt";
            var context = new ProjectDataBaseContext();
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    context.Inventories.ToList().ForEach(sw.WriteLine);
                }

                System.Console.WriteLine("Запись выполнена\n");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
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

            

            while (vhod==false)
            {
                System.Console.WriteLine("Для входа выберите. Вы:\n");
                System.Console.WriteLine("1 - Администратор\n");
                System.Console.WriteLine("2 - Ответственный\n");
                System.Console.WriteLine("3 - Проверяющий\n");
                try { 
                _po = Convert.ToInt32(System.Console.ReadLine());
                

                if (_po == 1)
                {
                    System.Console.WriteLine("Администратор, введите свой id:\n");
                    _id = Convert.ToInt32(System.Console.ReadLine());
                    if (adminId == _id) { 
                        _admin = true; 
                        enterLogin = _id; 
                    }
                    else System.Console.WriteLine("Вы ввели неверный id!\n");

                }
                else if (_po == 2)
                {
                    System.Console.WriteLine("Ответственный, введите свой id\n");
                    _id = Convert.ToInt32(System.Console.ReadLine());
                    try
                    {
                        var login = context.Responsibles.Where(x => x.ResponsibleId == _id).FirstOrDefault();
                        _otvet = true;
                        enterLogin = _id;
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Вы ввели неверный id!\n");
                    }

                }
                else if (_po == 3)
                {
                    System.Console.WriteLine("Проверяющий, введите свой id\n");
                    _id = Convert.ToInt32(System.Console.ReadLine());
                    try
                    {
                        var login = context.Verifiers.Where(x => x.VerifierId == _id).FirstOrDefault();
                        _prover = true;
                        enterLogin = _id;
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Вы ввели неверный id!\n");
                    }
                }
                else System.Console.WriteLine("Введено некорректное значение\n");

                if (_admin == true) {
                    System.Console.WriteLine("Администратор, введите свой пароль\n");
                    _ps= System.Console.ReadLine();
                    if (adminPassword == _ps) { 
                        System.Console.WriteLine("Добро пожаловать, Администратор!\n");
                        vhod = true;
                        vhodAdmin = true;
                    }
                    else System.Console.WriteLine("Неверный пароль!\n");
                }
                else if (_otvet == true) {
                    System.Console.WriteLine("Ответственный, введите свой пароль\n");
                    _ps = System.Console.ReadLine();
                    try
                    {
                        var login = context.Responsibles.Where(x => x.Password == _ps && x.ResponsibleId == enterLogin).FirstOrDefault();
                        System.Console.WriteLine("Добро пожаловать, Ответственный!\n");
                        vhod = true;
                        vhodOtvet = true;
                    }
                    catch (Exception ex) {
                        System.Console.WriteLine("Неверный пароль!\n");
                    }
                }
                else if (_prover == true) {
                    System.Console.WriteLine("Проверяющий, введите свой пароль\n");
                    _ps = System.Console.ReadLine();
                    try
                    {
                        var login = context.Verifiers.Where(x => x.Password == _ps && x.VerifierId == enterLogin).FirstOrDefault();
                        System.Console.WriteLine("Добро пожаловать, Проверяющий!\n");
                        vhod = true;
                        vhodProver = true;
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Неверный пароль!\n");
                    }
                }
                else System.Console.WriteLine("Повторите попытку входа!\n");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Неверный формат данных!\n");
                    WorkBd();
                }
            }
            while (true)
            {
                WorkBd();
                try { 
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
                {   //Изменить данные в таблице
                    switch (_x)
                    {
                        case 1:
                            System.Console.WriteLine("Введите id аудитории для изменения");
                            _enterChange = Convert.ToInt32(System.Console.ReadLine());
                            changeAuditory();
                            break;
                        case 2:
                            System.Console.WriteLine("Введите id документа для изменения");
                            _enterChange = Convert.ToInt32(System.Console.ReadLine());
                            changeDocument();
                            break;
                        case 3:
                            System.Console.WriteLine("Введите id инвентаря для изменения");
                            _enterChange = Convert.ToInt32(System.Console.ReadLine());
                            changeInventory();
                            break;
                        case 4:
                            System.Console.WriteLine("Введите id ремонта для изменения");
                            _enterChange = Convert.ToInt32(System.Console.ReadLine());
                            changeRemont();
                            break;
                        case 5:
                            System.Console.WriteLine("Введите id ответственного для изменения");
                            _enterChange = Convert.ToInt32(System.Console.ReadLine());
                            changeOtvet();
                            break;
                        case 6:
                            System.Console.WriteLine("Введите id проверяющего для изменения");
                            _enterChange = Convert.ToInt32(System.Console.ReadLine());
                            changeProver();
                            break;
                        case 7:
                            System.Console.WriteLine("Введите id инвентаризации для изменения");
                            _enterChange = Convert.ToInt32(System.Console.ReadLine());
                            changeInventarization();
                            break;
                        case 8:
                            System.Console.WriteLine("Введите id списка для изменения");
                            _enterChange = Convert.ToInt32(System.Console.ReadLine());
                            changeList();
                            break;
                        default:
                            System.Console.WriteLine("Введено неверное значение");
                            break;
                    }
                }
                else if (_enterMenu == 5)
                {
                    //Сохранить данные из таблицы
                    switch (_x)
                    {
                        case 1:
                            System.Console.WriteLine("Сохранить таблицу Аудитории");
                            saveAuditoriya();
                            break;
                        case 2:
                            System.Console.WriteLine("Сохранить таблицу Документы");                            
                            saveDocument();
                            
                            break;
                        case 3:
                            System.Console.WriteLine("Сохранит таблицу Инвентарь");
                            saveInventory();
                            break;
                        case 4:
                            System.Console.WriteLine("Сохранить таблицу Ремонт");
                            saveRemont();
                            break;
                        case 5:
                            System.Console.WriteLine("Сохранить таблицу Ответственные");
                            saveOtvet();
                            break;
                        case 6:
                            System.Console.WriteLine("Сохранить таблицу Проверяющие");
                            saveProver();
                            break;
                        case 7:
                            System.Console.WriteLine("Сохранить таблицу Инвентаризация");
                            saveInventarization();
                            break;
                        case 8:
                            System.Console.WriteLine("Сохранить таблицу Списки");
                            saveList();
                            break;
                        default:
                            System.Console.WriteLine("Введено неверное значение");
                            break;
                    }
                }
                else if (_enterMenu == 6) {
                    switch (_x)
                    {
                        //Удалить данные из табицы
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
                            deleteInventory();
                            break;
                        case 4:
                            System.Console.WriteLine("Введите id ремонта для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteRepair();
                            break;
                        case 5:
                            System.Console.WriteLine("Введите id ответственного для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteResponsible();
                            break;
                        case 6:
                            System.Console.WriteLine("Введите id проверяющего для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteVerifier();
                            break;
                        case 7:
                            System.Console.WriteLine("Введите id инвентаризации для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteInventarization();
                            break;
                        case 8:
                            System.Console.WriteLine("Введите id списка для удаления");
                            _enterDelete = Convert.ToInt32(System.Console.ReadLine());
                            deleteList();
                            break;
                        default:
                            System.Console.WriteLine("Введено неверное значение");
                            break;
                    }
                }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Неверный формат данных!\n");
                    WorkBd();
                }
            }
        }
    }
}