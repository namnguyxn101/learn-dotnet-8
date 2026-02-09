# Tag Helper
## Một số Tag Helper
### Anchor
**Anchor Tag Helper** cải tiến thẻ `<a>`, bằng cách thêm vào các thuộc tính, các thuộc tính này bắt đầu bằng tiền tố **asp-**. Từ các thuộc tính **asp-**, nó sinh ra giá trị cho thuộc tính **href**, một số thuộc tính đó là:

`asp-controller` Controller (MVC) để phát sinh href của thẻ <hr>
`asp-action` Action của controller <hr>
`asp-route-{value}` tham số của Route, ví dụ asp-route-id ...<hr>
`asp-route` Route để phát sinh href <hr>
`asp-all-route-data` thuộc tính gán giá trị bằng đối tượng kiểu `Dictionary<string, string>` để phát sinh phần query của url <hr>
`asp-fragment` phần fragment của URL <hr>
`asp-area` tên Area <hr>
`asp-page` tên trang Razor <hr>
`asp-page-handler` thiết lập handler của trang Razor

```html
<a asp-page="ViewProduct" asp-route-id="2">Sản phẩm khác</a>
<!-- Kết quả: <a href="/ViewProduct/2/" >Sản phẩm khác</a> -->
```
### Form
Cải tiến thẻ `<form>` với các thuộc tính thêm vào để phát sinh giá trị cho thuộc tính action

`asp-controller`	Tên của controller <hr>
`asp-action`	Actionn trong controller <hr>
`asp-area`	Tên Area <hr>
`asp-page`	Tên trang Razor <hr>
`asp-page`-handler	Tên handler của Razor (OnGet, OnPost ..) <hr>
`asp-route`	Tên route <hr>
`asp-route-{value}`	Giá trị thành phần route <hr>
`asp-all-route-data` Giá trị xây dựng query action <hr>
`asp-fragment`	fragment của action form

Có thể sử dụng Input, Button để tạo ActionForm với các thuộc tính trên.

### Image
Làm việc trên thẻ `<img>` với thuộc tính `asp-append-version="true"` để thêm query `v=xxxx` vào địa chỉ ảnh.

Chú ý thuộc tính src phải trỏ đến một file tĩnh, ví dụ `src="~/images/1.png"`, nếu vậy nếu `asp-append-version="true"` thì mỗi phiên bản hình ảnh sẽ cache địa chỉ (phát sinh query v=xxx)

### Input
Làm việc trên thẻ `<input>` với thuộc tính `asp-for="@data"`

**@data** là biểu thức, chỉ ra tên dữ liệu.

qua đó nó sinh ra phần tử HTML input với các thuộc tính sinh ra là

* **type** phần tử sinh ra phụ thuộc vào kiểu data, ví dụ như data là bool thì input có thuộc tính type="checkbox". Ngoài ra kiểu cũng xác định bởi các thuộc tính bổ sung như: [EmailAddress], [DataType(DataType.Time)] ...
* Phát sinh id dựa vào biểu thức asp-for

### Label
Làm việc trên thẻ `<label>` với thuộc tính `asp-for="@data"`

### Link
Làm việc trên thẻ `<link>`

### Select
Làm việc trên thẻ `<select>`, ví dụ:
```html
<select asp-for="Country" asp-items="Model.Countries"></select>
```

### Textarea
Làm việc trên thẻ `<textarea>` với thuộc tính asp-for="s"