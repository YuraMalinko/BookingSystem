using BookingSystem;

User administrator = new User();


Console.WriteLine("Главное меню :");
Console.WriteLine("1) Столы");
Console.WriteLine("2) Брони");
Console.Write($"Выберете нужный пункт меню (чтобы завершить работу программы введите  0 ) : ");
int EnterHomeMenu = Convert.ToInt32(Console.ReadLine());

while (EnterHomeMenu != 0)
{
    if (EnterHomeMenu == 1)
    {
        Console.WriteLine("\nСтолы :");
        Console.WriteLine("1) Добавить стол ");
        Console.WriteLine("2) Удалить стол ");
        Console.WriteLine("3) Показать все столы");
        Console.Write($"Выберете нужный пункт меню столов ( чтобы вернуться в предыдущее меню, введите 0 ) : ");
        int EnterTableMenu = Convert.ToInt32(Console.ReadLine());

        while (EnterTableMenu != 0)
        {
            if (EnterTableMenu == 1)
            {
                Console.Write("Введите номер нового стола : ");
                int numberTable = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите вместимость стола : ");
                int numberSeats = Convert.ToInt32(Console.ReadLine());
                administrator.AddNewTable(new Table(numberTable, numberSeats));
            }
            else if (EnterTableMenu == 2)
            {
                Console.WriteLine("");

                foreach(Table table in administrator.DataFile.Tables)
                {
                    Console.WriteLine(table);
                }

                Console.Write("Введите номер стола для удаления (для отмены введите 0) : ");
                int numberTable = Convert.ToInt32(Console.ReadLine());

                if (numberTable != 0)
                {
                    administrator.RemoveTable(numberTable);
                }
            }
            else if (EnterTableMenu == 3)
            {
                Console.WriteLine("");

                foreach (Table table in administrator.DataFile.Tables)
                {
                    Console.WriteLine(table);
                }

                Console.Write("Введите номер стола ,чтобы показать  все его брони ");
                int numberTable = Convert.ToInt32(Console.ReadLine());

                foreach (Reservation reservation in administrator.ReturnReservationsForSpecificTable(numberTable))
                {
                    reservation.ToString();
                }
            }
            else
            {
                Console.WriteLine("Пункта меню с таким номером нет, попробуйте ещё раз");
            }

            Console.WriteLine("\nСтолы :");
            Console.WriteLine("1) Добавить стол ");
            Console.WriteLine("2) Удалить стол ");
            Console.WriteLine("3) Показать все столы");
            Console.Write($"Выберете нужный пункт меню столов ( чтобы вернуться в предыдущее меню, введите 0 ) : ");
            EnterTableMenu = Convert.ToInt32(Console.ReadLine());
        }
    }
    else if (EnterHomeMenu == 2)
    {
        Console.WriteLine("\nБрони :");
        Console.WriteLine("1) Добавить бронь");
        Console.WriteLine("2) Удалить бронь");
        Console.WriteLine("3) Показать все брони");
        Console.WriteLine("4) Показать брони на определённый день ");
        Console.WriteLine("5) Показань брони по столику ");
        Console.WriteLine("6) Показань брони по дате и количеству гостей ");
        Console.Write($"Выберете нужный пункт меню столов ( чтобы вернуться в предыдущее меню, введите 0 ) : ");
        int EnterReservationMenu = Convert.ToInt32(Console.ReadLine());

        while (EnterReservationMenu != 0)
        {
            if (EnterReservationMenu == 1)
            {
                int numberReservation = administrator.GeneratesNumberReservation();
                Console.Write("Введите количество гостей : ");
                int numberOfGuest = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nВведите интересующую Вас дату (в формате дд.ММ.гггг) : ");
                DateTime dataTime = Convert.ToDateTime(Console.ReadLine());

                foreach (Table table in administrator.ReturnCorrectTable(dataTime, numberOfGuest))
                {
                    Console.WriteLine(table);
                }

                Console.Write("Введите номер стола : ");
                int numberTable = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите имя гостя : ");
                string nameGuest = Convert.ToString(Console.ReadLine());
                Console.Write("Введите контактный номер гостя : ");
                string telephoneNumberGuest = Convert.ToString(Console.ReadLine());
                administrator.AddNewReservation(new Reservation(numberTable, numberReservation, nameGuest, telephoneNumberGuest, dataTime, numberOfGuest));
            }
            else if (EnterReservationMenu == 2)
            {
                Console.WriteLine("");
                administrator.ShowAllReservations();

                Console.Write("Введите номер брони для удаления (для отмены введите 0) : ");
                int numberReservation = Convert.ToInt32(Console.ReadLine());

                if (numberReservation != 0)
                {
                    administrator.RemoveReservation(numberReservation);
                }
            }
            else if (EnterReservationMenu == 3)
            {
                Console.WriteLine("");
                administrator.ShowAllReservations();
            }
            else if (EnterReservationMenu == 4)
            {
                Console.Write("\nВведите интересующую Вас дату (в формате дд.ММ.гггг) : ");
                DateTime dataTime = Convert.ToDateTime(Console.ReadLine());

                foreach (Reservation reservation in administrator.ReturnReservationsForSpecificDay(dataTime))
                {
                    reservation.ToString();
                }
            }
            else if (EnterReservationMenu == 5)
            {
                Console.WriteLine("");
                administrator.ShowAllTables();
                Console.Write("Введите номер стола ,чтобы показать  все его брони ");
                int numberTable = Convert.ToInt32(Console.ReadLine());

                foreach (Reservation reservation in administrator.ReturnReservationsForSpecificTable(numberTable))
                {
                    reservation.ToString();
                }
            }
            else if (EnterReservationMenu == 6)
            {
                Console.Write("\nВведите интересующую Вас дату (в формате дд.ММ.гггг) : ");
                DateTime dataTime = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Введите число гостей : ");
                int numberSeats = Convert.ToInt32(Console.ReadLine());
                foreach (Reservation reservation in administrator.ReturnReservationsForSpecificDayAndSeatz(dataTime, numberSeats))
                {
                    reservation.ToString();
                }
            }
            else
            {
                Console.WriteLine("Пункта меню с таким номером нет, попробуйте ещё раз");
            }

            Console.WriteLine("\nБрони :");
            Console.WriteLine("1) Добавить бронь");
            Console.WriteLine("2) Удалить бронь");
            Console.WriteLine("3) Показать все брони");
            Console.WriteLine("4) Показать брони на определённый день ");
            Console.WriteLine("5) Показань брони по столику ");
            Console.Write($"Выберете нужный пункт меню столов ( чтобы вернуться в предыдущее меню, введите 0 ) : ");
            EnterReservationMenu = Convert.ToInt32(Console.ReadLine());
        }
    }
    else
    {
        Console.WriteLine("Пункта меню с таким номером нет, попробуйте ещё раз");
    }

    Console.WriteLine("\nГлавное меню :");
    Console.WriteLine("1) Столы");
    Console.WriteLine("2) Брони");
    Console.Write($"Выберете нужный пункт меню (чтобы завершить работу программы введите  0 ) : ");
    EnterHomeMenu = Convert.ToInt32(Console.ReadLine());
}
