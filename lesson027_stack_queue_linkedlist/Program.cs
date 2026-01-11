// Queue<string> cachoso = new Queue<string>();

// // Thêm vào cuối
// cachoso.Enqueue("Ho so 1");
// cachoso.Enqueue("Ho so 2");
// cachoso.Enqueue("Ho so 3");

// // Đọc và loại bỏ phần tử đầu tiên
// var hoso1 = cachoso.Dequeue();
// Console.WriteLine($"Xu ly ho so: {hoso1} - con lai: {cachoso.Count}");

// // Đọc phần tử đầu tiên
// var hoso2 = cachoso.Peek();
// Console.WriteLine($"Xem ho so: {hoso2} - con lai: {cachoso.Count}");
//=============================================

// Stack<string> hanghoa = new Stack<string>();

// hanghoa.Push("Mat hang 1");
// hanghoa.Push("Mat hang 2");
// hanghoa.Push("Mat hang 3");

// // Đọc và loại bỏ phần tử trên cùng
// var mathang3 = hanghoa.Pop();
// Console.WriteLine($"Lay ra: {mathang3} - con lai: {hanghoa.Count}");

// // Đọc phần tử trên cùng
// var mathang2 = hanghoa.Peek();
// Console.WriteLine($"Xem: {mathang2} - con lai: {hanghoa.Count}");

// // Kiểm tra phần tử có tồn tại không
// if (!hanghoa.Contains("Mat hang 4"))
// {
//     Console.WriteLine("Khong co mat hang nay!");
// }
//=============================================

LinkedList<string> cacbaihoc = new LinkedList<string>();

cacbaihoc.AddFirst("Bai hoc 1"); // Thêm vào đầu
cacbaihoc.AddLast("Bai hoc 2"); // Thêm vào cuối
cacbaihoc.AddLast("Bai hoc 3");
cacbaihoc.AddLast("Bai hoc 4");

// Lấy node đầu tiên
LinkedListNode<string> FirstNode = cacbaihoc.First ?? new LinkedListNode<string>("");
// Tạo node muốn thêm vào danh sách
LinkedListNode<string> NewNode1 = new LinkedListNode<string>("Bai hoc moi 1");
// Thêm node mới vào trước node chỉ định
cacbaihoc.AddBefore(FirstNode, NewNode1);

LinkedListNode<string> LastNode = cacbaihoc.Last ?? new LinkedListNode<string>("");
// Thêm node mới vào sau node chỉ định
cacbaihoc.AddAfter(LastNode, "Bai hoc moi 2");

// Xóa toàn bộ danh sách
// cacbaihoc.Clear();

// Đếm số node
// Console.WriteLine(cacbaihoc.Count);

// Kiểm tra nút có tồn tại với giá trị tương ứng
// if (cacbaihoc.Contains("Bai hoc 1"))
//     Console.WriteLine("Bai hoc ton tai");
// else
//     Console.WriteLine("Bai hoc khong ton tai");

// Xóa nút có giá trị tương ứng
// cacbaihoc.Remove("Bai hoc 3");

// Xóa nút đầu tiên
// cacbaihoc.RemoveFirst();

// Xóa nút cuối cùng
// cacbaihoc.RemoveLast();

foreach (var bh in cacbaihoc)
{
    Console.WriteLine(bh);
}

// Tìm nút đầu tiên mà khớp với giá trị truyền vào 
// var bh1 = cacbaihoc.Find("Bai hoc 1");
// Console.WriteLine(bh1?.Value);

LinkedListNode<string> bh1 = cacbaihoc?.First?.Next ?? new LinkedListNode<string>(" ");
Console.WriteLine(bh1.Value);

LinkedListNode<string> bh4 = cacbaihoc?.Last?.Previous ?? new LinkedListNode<string>("");
Console.WriteLine(bh4.Value);