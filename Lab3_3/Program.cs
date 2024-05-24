using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Tạo thư mục "data"
        string dataDirectory = "data";
        Directory.CreateDirectory(dataDirectory);

        // Tạo file "data.txt" trong thư mục "data" và ghi dữ liệu vào file
        string dataFilePath = Path.Combine(dataDirectory, "data.txt");
        using (StreamWriter writer = new StreamWriter(dataFilePath))
        {
            writer.WriteLine("MSSV");
            writer.WriteLine("họ và tên");
        }

        // Tạo thư mục "data2"
        string data2Directory = "data2";
        Directory.CreateDirectory(data2Directory);

        // Copy file từ thư mục "data" sang thư mục "data2"
        CopyFiles(dataDirectory, data2Directory);

        Console.WriteLine("Hoàn thành!");
    }

    static void CopyFiles(string sourceDir, string destinationDir)
    {
        DirectoryInfo dir = new DirectoryInfo(sourceDir);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException($"Thư mục nguồn không tồn tại hoặc không thể tìm thấy: {sourceDir}");
        }

        // Lấy tất cả các file trong thư mục nguồn
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string tempPath = Path.Combine(destinationDir, file.Name);
            // Kiểm tra xem file đã tồn tại chưa trước khi copy
            if (!File.Exists(tempPath))
            {
                file.CopyTo(tempPath, false);
            }
        }

        // Lấy tất cả các thư mục con trong thư mục nguồn
        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo subdir in dirs)
        {
            string tempPath = Path.Combine(destinationDir, subdir.Name);
            // Tạo thư mục con nếu nó chưa tồn tại
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }
            CopyFiles(subdir.FullName, tempPath);
        }
    }
}
