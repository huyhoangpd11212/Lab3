using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        // Tạo chuỗi để lưu thông tin tài khoản
        string accountInfo;

        // Sử dụng StringWriter để ghi thông tin tài khoản
        using (StringWriter sw = new StringWriter())
        {
            // Thông tin tài khoản
            string username = "user112";
            string password = "pass115";
            DateTime saveTime = DateTime.Now;

            // Ghi thông tin vào StringWriter
            sw.WriteLine($"Username: {username}");
            sw.WriteLine($"Password: {password}");
            sw.WriteLine($"Saved at: {saveTime}");

            // Lưu chuỗi đã ghi vào accountInfo
            accountInfo = sw.ToString();
        }

        // Hiển thị chuỗi đã lưu
        Console.WriteLine("Thông tin tài khoản đã lưu:");
        Console.WriteLine(accountInfo);

        // Sử dụng StringReader để đọc thông tin từ chuỗi
        using (StringReader reader = new StringReader(accountInfo))
        {
            string line;
            Console.WriteLine("Đọc thông tin tài khoản từ StringReader:");
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
