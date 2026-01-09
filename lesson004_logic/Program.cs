// bool kq;
// == >= <= > < !=
// int a = 3, b = 6;
// kq = a == b;
// Console.WriteLine($"a == b ==> {kq}"); // false
// Console.WriteLine($"a >= b ==> {a >= b}"); // false
// Console.WriteLine($"a <= b ==> {a <= b}"); // true
// Console.WriteLine($"a > b ==> {a > b}"); // false
// Console.WriteLine($"a < b ==> {a < b}"); // true
// Console.WriteLine($"a != b ==> {a != b}"); // true
//==========================================

bool kq;
// && || !
/*
AND chỉ đúng khi cả 2 đều true
OR chỉ sai khi cả 2 đều false
NOT phủ định lại
*/
bool a = false;
bool b = true;
kq = a && b;
Console.WriteLine($"a && b ==> {kq}"); // false
Console.WriteLine($"a || b ==> {a || b}"); // true
Console.WriteLine($"!a ==> {!a}"); // true