## Lớp Uri
**System.Uri** là lớp biểu diễn về địa chỉ URI (URL) [(xem thêm URI, URL)](https://xuanthulab.net/dia-chi-url-uri-urn-duong-dan-url-trang-web-va-file.html), nó giúp cho nhanh chóng lấy thông tin các thành phần của URL như host, path, query ... Đối tượng Uri còn sử dụng trong tham số để thực hiện các truy vấn HTTP Request ở các phần sau.

## Lớp tĩnh Dns và lớp IPHostEntry
**Lớp Dns (System.Net.Dns)** cung cấp các phương thức tính để lấy thông tin về host (địa chỉ website, server cung cấp các dịch vụ mạng) từ hệ thống phân giải tên miền (Dns). Các thông tin truy vấn được nó trả về một đối tượng giao diện **IPHostEntry**

> DNS (Domain Name System) là hệ thống phân giải tên miền, giúp cho các trình client (như các trình duyệt) truy vấn để chuyển đổi một tên miền (như xuanthulab.net) sang địa chỉ IP vật lý tương ứng của tên miên đó. Sau đó địa chỉ IP này được dùng để kết nối client/server. Dữ liệu DNS được lưu trữ và phục vụ truy vấn từ các Server DNS được vận hành bởi các nhà cung cấp dịch vụ và các tổ chức

### Một số phương thức của lớp Dns

 | Phương thức                                         | Ý nghĩa                                                                                                               |
 | :-------------------------------------------------- | :-------------------------------------------------------------------------------------------------------------------- |
 | `GetHostName()`                                     | Lấy hostname của máy local.                                                                                           |
 | `GetHostEntry(String)`<br>`GetHostEntry(IPAddress)` | Phân giải host hoặc IP thành đối tượng **IPHostEntry**. Đối tượng kiểu IPHostEntry nó chứa thông tin địa chỉ về host. |

### IPHostEntry có các thuộc tính để lấy thông tin về host như
| Phương thức   | Ý nghĩa                                             |
| :------------ | :-------------------------------------------------- |
| `HostName`    | Chuỗi chứa hostname của Server                      |
| `AddressList` | Mảng các phần tử kiểu **IPAddress** chứa các địa chỉ IP |

## Lớp Ping
**Lớp Ping (System.Net.NetworkInformation.Ping)**, lớp này cho phép ứng dụng xác định một máy từ xa (như server, máy trong mạng ...) có phản hồi không.