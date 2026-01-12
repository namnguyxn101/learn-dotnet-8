//=========================
// Lớp DriveInfo
//=========================
// var drives = DriveInfo.GetDrives();

// foreach (var drive in drives)
// {
//     Console.WriteLine($"Drive: {drive.Name}");
//     Console.WriteLine($"Drive Type: {drive.DriveType}");
//     Console.WriteLine($"Label: {drive.VolumeLabel}");
//     Console.WriteLine($"Format: {drive.DriveFormat}");
//     Console.WriteLine($"Size: {drive.TotalSize / (1024*1024*1024)}");
//     Console.WriteLine($"Free: {drive.TotalFreeSpace / (1024*1024*1024)}");
//     Console.WriteLine("--------------------------------");
// }
//===========================================

//=========================
// Lớp Directory
//=========================
// string path = "Abc";

// Directory.CreateDirectory(path);

// Directory.Delete(path);
// if (Directory.Exists(path))
// {
//     Console.WriteLine($"{path} - ton tai");
// }
// else Console.WriteLine($"{path} - khong ton tai");
//------------

// class Program
// {
//     public static void ListFileDirectory(string path)
//     {
//         var files = Directory.GetFiles(path);
//         var directories = Directory.GetDirectories(path);

//         foreach (var f in files)
//         {
//             Console.WriteLine(f);
//         }

//         Console.WriteLine("------------");

//         foreach (var d in directories)
//         {
//             Console.WriteLine(d);
//             ListFileDirectory(d); // Đệ quy
//         }
//     }

//     static void Main()
//     {
//         string path = "obj";
//         ListFileDirectory(path);
//     }
// }
//===========================================

//=========================
// Lớp Path
//=========================
// Console.WriteLine(Path.DirectorySeparatorChar);

// // Kết hợp các chuỗi thành đường dẫn
// var path = Path.Combine("dir1", "dir2", "tenfile.txt");
// Console.WriteLine(path);

// var path = "dir1/dir2/tenfile.txt";
// Console.WriteLine(path);
// Đổi phần mở rộng file
// path = Path.ChangeExtension(path, "md");
// Console.WriteLine(path);

// Trả về đường dẫn thư mục chứa file
// Console.WriteLine(Path.GetDirectoryName(path));

// Trả về phần mở rộng
// Console.WriteLine(Path.GetExtension(path));

// Trả về tên file kèm phần mở rộng
// Console.WriteLine(Path.GetFileName(path));

// Trả về chỉ tên file
// Console.WriteLine(Path.GetFileNameWithoutExtension(path));

// Trả về đường dẫn tuyệt đối
// Nếu đường dẫn viết ở dạng tương đối (dir1/dir2/tenfile.txt)
// --> trả về đường dẫn của thư mục hiện tại kết hợp với đường dẫn tương đối đó.
// Nếu đường dẫn tuyệt đối --> chỉ trả về đường dẫn tuyệt đối.
// Console.WriteLine(Path.GetFullPath(path));

// Trả về một tên file ngẫu nhiên, ko trùng với bất kỳ file nào có sẵn trong đĩa
// path = Path.GetRandomFileName();
// Console.WriteLine(path);

// Trả về tên một file tạm
// path = Path.GetTempFileName();
// Console.WriteLine(path);
//===========================================

//=========================
// Lớp File
//=========================
// string filename = "abc.txt";
// string content = "Xin chao cac ban";
// Khi dùng phương thức WriteAllText nó sẽ thay toàn bộ nội dung trong file
// File.WriteAllText(filename, content);

// Khi dùng phương thức AppendAllText nó sẽ giữ nội dung cũ và thêm nội dung mới vào file
// File.AppendAllText(filename, "2024");

// Di chuyển file
// File.Move("abc.txt", "demo/abc.txt");

// Copy file
// File.Copy("abc.txt", "abc-copy.txt");

// Xóa file
// File.Delete("demo/abc.txt");