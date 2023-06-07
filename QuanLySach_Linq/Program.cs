using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySach_Linq
{
    class Book
    {
        public string BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public string Publisher { get; set; }
        public int Date { get; set; }

        public void xuat()
        {
            Console.WriteLine(BookId.PadLeft(5) + "|" + BookName.PadRight(25) + "|" + Author.PadLeft(4) + "|" + Price.ToString().PadLeft(6) + "|" + Publisher.PadLeft(5) + "|" + Date);
        }
    }
    class Program
    {
        //Định nghĩa phương thức Generic hiển thị dữ liệu
        static void Show<T>(IEnumerable<T> data, string message)
        {
            Console.WriteLine(message);
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            List<Book> ListBook = new List<Book>()
            {
            new Book{BookId="F01",BookName="Điệp viên 007",        Author="TG01",Price=120000,Publisher="NXB01",Date=2011},
            new Book{BookId="F02",BookName="Tam quốc diễn nghĩa",  Author="TG02",Price=130000,Publisher="NXB02",Date=2012},
            new Book{BookId="F03",BookName="Thiếu lâm truyền kỳ",  Author="TG03",Price=016000, Publisher="NXBGD", Date=2015},
            new Book{BookId="F04",BookName="Người nhện 2",         Author="TG04",Price=100000,Publisher="NXB04",Date=2014},
            new Book{BookId="F05",BookName="Ngân hàng tình yêu",   Author="TG05",Price=340000,Publisher="NXBGD",Date=2015},
            new Book{BookId="F06",BookName="Người đẹp và quái thú",Author="TG06",Price=230000,Publisher="NXB06",Date=2015},
            new Book{BookId="F07",BookName="Biệt động Sài Gòn",    Author="TG07",Price=190000,Publisher="NXBGD",Date=2017},
            };

            // Hiển thị tất cả các quyển sách
            IEnumerable<Book> ListBooks = from book in ListBook select book;
            //    Show<Book>(ListBooks, "Hiển thị tất cả các quyển sách");

            Console.WriteLine();
            Console.WriteLine("Hiển thị tất cả các quyển sách");
            foreach (var item in ListBook)
            {
                item.xuat();
            }


            // Hiển thị những quyển sách có giá từ 100000 đến 200000
            IEnumerable<Book> result1 = ListBook.Where(b => (b.Price >= 100000 && b.Price <= 200000));
            //    Show<Book>(result1, "Hiển thị những quyển sách có giá từ 100000 đến 200000");
            
            Console.WriteLine();
            Console.WriteLine("Hiển thị những quyển sách có giá từ 100000 đến 200000");
            foreach (var item in result1)
            {
                item.xuat();
            }

            // Hiển thị những quyển sách xuất bản năm 2015
            IEnumerable<Book> result2 = ListBook.Where(b => b.Date == 2015);
            //    Show<Book>(result2, "Hiển thị những quyển sách xuất bản năm 2015");

            Console.WriteLine();
            Console.WriteLine("Hiển thị những quyển sách xuất bản năm 2015");
            foreach (var item in result2)
            {
                item.xuat();
            }

            // Hiển thị những quyển sách có tên Lập trình
            IEnumerable<Book> result3 = ListBook.Where(b => b.BookName.Contains("lap trinh"));


            // Đếm các quyển sách của NXB GD
            int count = (ListBook.Where(b => b.Publisher == "NXBGD").Count());
            Console.WriteLine("\nSố lượng sách của nhà xuất bản giáo dục là: " + count);
        }
    }
}
