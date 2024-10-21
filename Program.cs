using System.Text.RegularExpressions;

class LibraryManagement
{   
    static List<LibraryItem> books = new List<LibraryItem>();
    static List<F> followers = new List<F>();
    static List<Olingan> olingan = new List<Olingan>();
    static void Main(string[] args)
    {
        int son = 0;

        while(son != 6)
        {
            Console.WriteLine("+---------------------------------------------------------------------------------------------+");
            Console.WriteLine("|1.Kitoblarni qo'shish.Yangilash.Kitoblarni o'chirish                                         |");
            Console.WriteLine("|2.Foydalanuvchilarni ro'yhatga qo'shish.Yangilash.Foydalanuvchilarni ro'yhatdan olib tashlash|");
            Console.WriteLine("|3.Kitob Bron va Kitob Qaytarish                                                              |");
            Console.WriteLine("|4.Mavjud Kitoblar. Olingan kitoblar va Kechiktirilgan kitoblar ro'yhati                      |");
            Console.WriteLine("|5.Kitoblarni sarlavha, muallifi yoki ISBN bo'yicha qidirish                                  |");
            Console.WriteLine("|6.Exit                                                                                       |");
            Console.WriteLine("+---------------------------------------------------------------------------------------------+");
            son = Convert.ToInt32(Console.ReadLine());

            if(son == 1)
            {
                Console.WriteLine("+-----------------+");
                Console.WriteLine("|1.Kitob qo'shish |");
                Console.WriteLine("|2.Yangilash      |");
                Console.WriteLine("|3.Kitob o'chirish|");
                Console.WriteLine("|4.Exit           |");
                Console.WriteLine("+-----------------+");
                int son1 = Convert.ToInt32(Console.ReadLine());

                switch(son1)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        BookView();
                        break;
                    case 3:
                        BookDelete();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Noto'g'ri buyruq");
                        break;
                }
            }
            else if(son == 2)
            {
                Console.WriteLine("+-------------------------+");
                Console.WriteLine("|1.Foydalanuvchi qo'shish |");
                Console.WriteLine("|2.Yangilash              |");
                Console.WriteLine("|3.Foydalanuvchi o'chirish|");
                Console.WriteLine("|4.Exit                   |");
                Console.WriteLine("+-------------------------+");
                int son2 = Convert.ToInt32(Console.ReadLine());

                switch(son2)
                {
                    case 1:
                        AddF();
                        break;
                    case 2:
                        ViewF();
                        break;
                    case 3:
                        FDelete();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Noto'g'ri buyruq");
                        break;
                }
            }
            else if(son == 3)
            {
                Console.WriteLine("+-----------------+");
                Console.WriteLine("|1.Kitob bron     |");
                Console.WriteLine("|2.Kitob qaytarish|");
                Console.WriteLine("|3.Exit           |");
                Console.WriteLine("+-----------------+");
                int son3 = Convert.ToInt32(Console.ReadLine());

                switch(son3)
                {
                    case 1:
                        BookBron();
                        break;
                    case 2:
                        BookQaytarish();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Noto'g'ri buyruq");
                        break;
                }
            }
            else if(son == 4)
            {
                Console.WriteLine("+----------------------------------+");
                Console.WriteLine("|1.Mavjud kitoblar                 |");
                Console.WriteLine("|2.Olingan Kitoblar                |");
                Console.WriteLine("|3.Kechiktirilgan kitoblar ro'yhati|");
                Console.WriteLine("|4.Exit                            |");
                Console.WriteLine("+----------------------------------+");
                int son4 = Convert.ToInt32(Console.ReadLine());

                switch(son4)
                {
                    case 1:
                        BookView();
                        break;
                    // case 2:
                        
                    //     break;
                    // case 3:
                        
                    //     break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Noto'g'ri buyruq");
                        break;
                }
            }
            else if(son == 5)
            {
                Console.WriteLine("+----------------------------------------+");
                Console.WriteLine("|1.Kitoblarni sarlavha bo'yicha qidirish |");
                Console.WriteLine("|2.Muallif bo'yicha qidirish             |");
                Console.WriteLine("|3.ISBN bo'yicha qidirish                |");
                Console.WriteLine("|4.Exit                                  |");
                Console.WriteLine("+----------------------------------------+");
                int son5 = Convert.ToInt32(Console.ReadLine());

                switch(son5)
                {
                    case 1:
                        BookNameP();
                        break;
                    case 2:
                        BookMP();
                        break;
                    case 3:
                        BookISBN();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Noto'g'ri buyruq");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Noto'g'ri buyruq");
            }

            static void AddBook()
            {
                Console.Write("Kitobni nomini kiritng: ");
                string title = Console.ReadLine()!;
                Console.Write("Kitobni muallifi: ");
                string author = Console.ReadLine()!;
                Console.Write("Kitob ishlab chiqalirgan yil: ");
                string publicationYear = Console.ReadLine()!;
                Console.Write("ISBN ni kiriting formati(Format: X-XXX-XXXX): ");
                string isbn = Console.ReadLine()!;
        

                if(title.Trim().Length > 0 && author.Trim().Length > 0)
                {
                    books.Add(new LibraryItem(title,author,publicationYear,isbn));
                    Console.WriteLine("Kitob qo'shildi.");
                }
                else
                {
                    System.Console.WriteLine("Kitob qo'shishda muammo yuzaga keldi.");
                }
            }

            static void BookView()
            {
                Console.WriteLine("Kitoblar ro'yxati: ");
                for(int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine($"{i+1}.Kitobning nomi: {books[i].Title}, Kitobning Muallifi: {books[i].Author}, Kitobning yili: {books[i].PublicationYear}, ISBN: {books[i].ISBN}");
                }
            }

            static void BookBron()
            {
                BookView();
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

            static void BookQaytarish()
            {
                Console.Write("Kitob nomini kiriting: ");
                string title = Console.ReadLine()!;
                Console.Write("Kitob muallifini kiriting: ");
                string author = Console.ReadLine()!;
                Console.Write("Kitob yilini kiriting: ");
                string publicationYear = Console.ReadLine()!;
                Console.Write("ISBN ni kiriting: ");
                string isbn = Console.ReadLine()!;

                if(title.Trim().Length > 0 && author.Trim().Length > 0 && publicationYear.Trim().Length > 0)
                {
                    books.Add(new LibraryItem(title,author,publicationYear,isbn));
                    Console.WriteLine("Kitob qaytarildi.");
                }
                else
                {
                    System.Console.WriteLine("Kitob qaytarishda muammo yuzaga keldi.");
                }
            }

            static void BookDelete()
            {
                BookView();
                Console.Write("Kitob o'chirish uchun kitob raqamini kiriting: ");
                int bookNumber1 = Convert.ToInt32(Console.ReadLine());
                if(bookNumber1 > 0 && bookNumber1 <= books.Count)
                {
                    books.RemoveAt(bookNumber1-1);
                    Console.WriteLine("Kitob o'chirildi");
                }
                else
                {
                    Console.WriteLine("Noto'g'ri raqam.");
                }
            }

            static void AddF()
            {
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
                Console.WriteLine("Foydalanuvchilar ro'yxati: ");
                for(int i = 0; i < followers.Count; i++)
                {
                    Console.WriteLine($"{i+1}.Foydalanuvchi ismi: {followers[i].FName}, Foydalanuvchining yoshi: {followers[i].FYear}");
                }
            }

            static void FDelete()
            {
                ViewF();
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

            static void BookISBN()
            {
                Console.Write("Qidirilayotgan Kitob ISBN formati(Format: X-XXX-XXXX): ");
                string bronnomer = Console.ReadLine()!;
                Regex regex = new Regex(@"/d{1}-/d{3}-/d{4}");
                for(int i = 0; i < books.Count; i++)
                {
                    if(regex.IsMatch(bronnomer) == regex.IsMatch(books[i].ISBN))
                    {
                        Console.WriteLine($"{i}.Kitob: {books[i].Title}, Mualifi: {books[i].Author}, Yili: {books[i].PublicationYear}, ISBN: {books[i].ISBN}");
                    }
                    else
                    {
                        Console.WriteLine("Kitob ISBN formati noto'g'ri. Iltimos boshqattan kiriting: ");
                    }
                }

            }

            static void BookNameP()
            {
                Console.Write("Kitobni ismini kiriting: ");
                string name = Console.ReadLine()!;
                for(int i = 0; i < books.Count; i++)
                {
                    if(name == books[i].Title)
                    {
                        Console.WriteLine($"{i}.Kitob Nomi: {books[i].Title}, Kitob Muallifi: {books[i].Author}, Yili: {books[i].PublicationYear}, ISBN: {books[i].ISBN}");
                    }
                    else
                    {
                        Console.WriteLine("Unday kitob mavjud emas");
                    }
                }

            }

            static void BookMP()
            {
                Console.Write("Kitobni mualifini kiriting: ");
                string ism = Console.ReadLine()!;
                for(int i = 0; i < books.Count; i++)
                {
                    if(ism == books[i].Author)
                    {
                        Console.WriteLine($"{i+1}.Kitob Nomi: {books[i].Title}, Muallifi: {books[i].Author}, Yili: {books[i].PublicationYear}, ISBN: {books[i].ISBN}");
                    }
                    else
                    {
                        Console.WriteLine("Unday muallifli kitob mavjud emas");
                    }
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

        public LibraryItem(string title, string author, string publicationYear, string isbn)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            ISBN = isbn;
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
    class Olingan
    {
        public string OBook {get; set;}
        public Olingan(string oBook)
        {
            OBook = oBook;
        }
    }

}