using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Spectre.Console;

class LibraryManagement
{   
    static List<LibraryItem> books = new List<LibraryItem>();
    static List<F> followers = new List<F>();
    static void Main()
    {
        int son = 0;
        
        while(son != 1)
        {
            Console.Clear();
            AnsiConsole.Write(
            new FigletText("WELCOME     TO     LIBRARY     MENU")
            .Centered()
            .Color(Color.White));
            var fruit = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[blue]Enter youe choose:[/]?")
                .PageSize(13)
                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                .AddChoices(new[] {
                    "1.Kitob qo'shish",
                    "2.Kitoblarni Yangilash",
                    "3.Kitob O'chirish",
                    "4.Foydalanuvchi qo'shish",
                    "5.Foydalanuvchilarni Yangilash",
                    "6.Foydalanuvchi O'chirish",
                    "7.Kitob olish",
                    "8.Kitob Qaytarish",
                    "9.Mavjud Kitoblar",
                    "10.Sarlavha bo'yicha qidirish",
                    "11.Muallif bo'yicha qidirish",
                    "12.ISBN bo'yicha qidirish",
                    "13.Exit"
                }));


                switch(fruit)
                {
                    case "1.Kitob qo'shish":
                        AddBook();
                        break;
                    case "2.Kitoblarni Yangilash":
                        ViewB();
                        break;
                    case "3.Kitob O'chirish":
                        BDelete();
                        break;
                    case "4.Foydalanuvchi qo'shish":
                        AddF();
                        break;
                    case "5.Foydalanuvchilarni Yangilash":
                        ViewF();
                        break;
                    case "6.Foydalanuvchi O'chirish":
                        FDelete();
                        break;
                    case "7.Kitob olish":
                        BookBron();
                        break;
                    case "8.Kitob Qaytarish":
                        BQaytarish();
                        break;
                    case "9.Mavjud Kitoblar":
                        ViewB();
                        break;
                    case "10.Sarlavha bo'yicha qidirish":
                        BTitleP();
                        break;
                    case "11.Muallif bo'yicha qidirish":
                        BMP();
                        break;
                    case "12.ISBN bo'yicha qidirish":
                        IsbnP();
                        break;
                    case "13.Exit":
                        son++;
                        break;
                }
        }
            
        static void AddBook()
        {
            AnsiConsole.Write(
            new FigletText("ADD     BOOK")
            .Centered()
            .Color(Color.Green));

            Console.Write("Kitobni nomini kiritng: ");
            string title = Console.ReadLine()!;
            Console.Write("Kitobni muallifi: ");
            string author = Console.ReadLine()!;
            Console.Write("Kitob nima haqida yoki kimlar uchun?");
            string theme = Console.ReadLine()!;
            Console.Write("Kitob ishlab chiqalirgan yil: ");
            string publicationYear = Console.ReadLine()!;
            Console.Write("ISBN ni kiriting formati(Format: X-XXX-XXXX): ");
            Regex regex = new Regex(@"\d{1}-\d{3}-\d{4}");
            string isbn = Console.ReadLine()!;

            if(title.Trim().Length > 0 && author.Trim().Length > 0)
            {
                if(regex.IsMatch(isbn))
                {
                    books.Add(new LibraryItem(title,author,publicationYear,isbn,theme));
                    Console.WriteLine("Kitob qo'shildi.");
                }
                else
                {
                Console.WriteLine("Kitob qo'shishda muammo yuzaga keldi.");
                }
            }
            else
            {
                Console.WriteLine("Kitob qo'shishda muammo yuzaga keldi.");
            }
        }

        static void ViewB()
        {
            AnsiConsole.Write(
            new FigletText("VIEW     BOOK")
            .Centered()
            .Color(Color.Red));
            Console.WriteLine("Kitoblar ro'yxati: ");
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i+1}.Kitobning nomi: {books[i].Title}, Kitobning Muallifi: {books[i].Author}, Kitobning Mavzusi: {books[i].Theme}, Kitobning yili: {books[i].PublicationYear}, ISBN: {books[i].ISBN}");
            }
        }

        static void BDelete()
        {
            AnsiConsole.Write(
            new FigletText("BOOK     DELETE")
            .Centered()
            .Color(Color.Blue));
            Console.WriteLine("Kitoblar ro'yxati: ");
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i+1}.Kitobning nomi: {books[i].Title}, Kitobning Muallifi: {books[i].Author}, Kitobning Mavzusi: {books[i].Theme}, Kitobning yili: {books[i].PublicationYear}, ISBN: {books[i].ISBN}");
            }
            Console.Write("O'chirish uchun kitob raqamini kiriting: ");
            int bookNumber = Convert.ToInt32(Console.ReadLine());
            if(bookNumber > 0 && bookNumber <= books.Count)
            {
                books.RemoveAt(bookNumber-1);
                Console.WriteLine("Kitob o'chirildi.");
            }
            else
            {
                Console.WriteLine("Noto'g'ri raqam.");
            }
        }

        static void AddF()
        {
            AnsiConsole.Write(
            new FigletText("ADD     FOLLOWER")
            .Centered()
            .Color(Color.Yellow));
            Console.Write("Foydalanuvchi ismini kiriting: ");
            string FName = Console.ReadLine()!;
            Console.Write("Foydalanuvchi yoshi ");
            int FYear = Convert.ToInt32(Console.ReadLine())!;
    
            if(FName.Trim().Length > 0)
            {
                followers.Add(new F(FName,FYear));
                Console.WriteLine("Foydalanuvchi qo'shildi.");
            }
            else
            {
                System.Console.WriteLine("Foydalanuvchi qo'shishda muammo yuzaga keldi.");
            }
        }

        static void ViewF()
        {
            AnsiConsole.Write(
            new FigletText("VIEW     FOLLOWER")
            .Centered()
            .Color(Color.Red));
            Console.WriteLine("Foydalanuvchilar ro'yxati: ");
            for(int i = 0; i < followers.Count; i++)
            {
                Console.WriteLine($"{i+1}.Foydalanuvchi ismi: {followers[i].FName}, Foydalanuvchining yoshi: {followers[i].FYear}");
            }
        }

        static void FDelete()
        {
            AnsiConsole.Write(
            new FigletText("DELETE     FOLLOWER")
            .Centered()
            .Color(Color.Blue));
            Console.WriteLine("Foydalanuvchilar ro'yxati: ");
            for(int i = 0; i < followers.Count; i++)
            {
                Console.WriteLine($"{i+1}.Foydalanuvchi ismi: {followers[i].FName}, Foydalanuvchining yoshi: {followers[i].FYear}");
            }
            Console.WriteLine("Foydalanuvchini o'chirish uchun raqamini kiriting");
            int fNumber1 = Convert.ToInt32(Console.ReadLine());
            if(fNumber1 > 0 && fNumber1 <= followers.Count)
            {
                followers.RemoveAt(fNumber1-1);
                Console.WriteLine("Foydalanuvchi o'chirildi");
            }
            else
            {
                Console.WriteLine("Noto'g'ri raqam.");
            }
        }

        static void BookBron()
        {
            AnsiConsole.Write(
            new FigletText("BOOK     BRON")
            .Centered()
            .Color(Color.White));
            Console.WriteLine("Kitoblar ro'yxati: ");
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i+1}.Kitobning nomi: {books[i].Title}, Kitobning Muallifi: {books[i].Author}, Kitobning Mavzusi: {books[i].Theme}, Kitobning yili: {books[i].PublicationYear}, ISBN: {books[i].ISBN}");
            }
            Console.Write("Bron qlish uchun kitob raqamini kiriting: ");
            int bookNumber = Convert.ToInt32(Console.ReadLine());
            if(bookNumber > 0 && bookNumber <= books.Count)
            {
                books.RemoveAt(bookNumber-1);
                Console.WriteLine("Kitob bron qlindi.");
            }
            else
            {
                Console.WriteLine("Noto'g'ri raqam.");
            }
        }

        static void BQaytarish()
        {
            AnsiConsole.Write(
            new FigletText("BOOK     QAYTARISH")
            .Centered()
            .Color(Color.Green));
            Console.Write("Kitob nomini kiriting: ");
            string title = Console.ReadLine()!;
            Console.Write("Kitob muallifini kiriting: ");
            string author = Console.ReadLine()!;
            Console.WriteLine("Kitob nima haqida yoki kimlar uchun?");
            string theme = Console.ReadLine()!;
            Console.Write("Kitob yilini kiriting: ");
            string publicationYear = Console.ReadLine()!;
            Console.Write("ISBN ni kiriting formati(Format: X-XXX-XXXX): ");
            Regex regex = new Regex(@"\d{1}-\d{3}-\d{4}");
            string isbn = Console.ReadLine()!;

            if(title.Trim().Length > 0 && author.Trim().Length > 0 && publicationYear.Trim().Length > 0)
            {
                books.Add(new LibraryItem(title,author,publicationYear,isbn,theme));
                Console.WriteLine("Kitob qaytarildi.");
            }
            else
            {
                Console.WriteLine("Kitob qaytarishda muammo yuzaga keldi.");
            }
        }

        static void BTitleP()
        {
            AnsiConsole.Write(
            new FigletText("SEARCH     BOOK")
            .Centered()
            .Color(Color.Blue));
            Console.Write("Kitobni ismini kiriting: ");
            string name = Console.ReadLine()!;
            for(int i = 0; i < books.Count; i++)
            {
                if(name == books[i].Title)
                {
                    Console.WriteLine($"{i}.Kitob Nomi: {books[i].Title}, Kitob Muallifi: {books[i].Author}, Kitobning Mavzusi: {books[i].Theme}, Yili: {books[i].PublicationYear}, ISBN: {books[i].ISBN}");
                }
                else
                {
                    Console.WriteLine("Unday kitob mavjud emas");
                }
            }
        }

        static void BMP()
        {
            AnsiConsole.Write(
            new FigletText("SEARCH     bOOK")
            .Centered()
            .Color(Color.Blue));
            Console.Write("Kitobni mualifini kiriting: ");
            string ism = Console.ReadLine()!;
            for(int i = 0; i < books.Count; i++)
            {
                if(ism == books[i].Author)
                {
                    Console.WriteLine($"{i+1}.Kitob Nomi: {books[i].Title}, Muallifi: {books[i].Author}, Kitobning Mavzusi: {books[i].Theme}, Yili: {books[i].PublicationYear}, ISBN: {books[i].ISBN}");
                }
                else
                {
                    Console.WriteLine("Unday muallifli kitob mavjud emas");
                }
            }
        }

        static void IsbnP()
        {
            AnsiConsole.Write(
            new FigletText("SEARCH     BOOK")
            .Centered()
            .Color(Color.Black));
            Console.Write("Qidirilayotgan Kitob ISBN formati(Format: X-XXX-XXXX): ");
            string bronnomer = Console.ReadLine()!;
            Regex regex = new Regex(@"\d{1}-\d{3}-\d{4}");
            for(int i = 0; i < books.Count; i++)
            {
                if(regex.IsMatch(bronnomer) == regex.IsMatch(books[i].ISBN))
                {
                    Console.WriteLine($"{i}.Kitob: {books[i].Title}, Mualifi: {books[i].Author}, Kitobning Mavzusi: {books[i].Theme}, Yili: {books[i].PublicationYear}, ISBN: {books[i].ISBN}");
                }
                else
                {
                    Console.WriteLine("Kitob ISBN formati noto'g'ri. Iltimos boshqattan kiriting: ");
                }
            }
        }
    }

    struct LibraryItem  
    {
        public string Title {get; set;}
        public string Author {get; set;}
        public string PublicationYear {get; set;}
        public string ISBN {get; set;}
        public string Theme {get; set;}

        public LibraryItem(string title, string author, string publicationYear, string isbn, string theme)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            ISBN = isbn;
            Theme = theme;
        }
    }
    class F
    {
        public string FName {get; set;}
        public int FYear {get; set;}

        public F(string fName, int fYear)
        {
            FName = fName;
            FYear = fYear;
        }
    }
}

// Random rnd = new Random();
// int kun = rnd.Next(01,31);
// int oy = rnd.Next(01,12);
// int yil = rnd.Next(2000,2024);

// Console.Write($"{kun}.{oy}.{yil}");`1