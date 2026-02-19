# Tag Helper, Html Helper
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

## Một số phương thức Html Helper
### Raw(string)
Giữ nguyên thẻ HTML (không thực hiện encoding), vì mặc định khi xuất một giá trị (**@value**) thì nó sẽ encoding rồi xuất

### Value(expression, format)
Xuất giá trị tên **expression** (tên liên quan tới model) với chuỗi định dạng [format](https://docs.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting?redirectedfrom=MSDN)

### Encode(value)
Thực hiện Encode chuỗi value.

### ActionLink
Tạo thẻ `<a>` cho các action của controller.

### AntiForgeryToken
Tạo phần tử ẩn, nếu trong Form - khi form submit thì nó được kiểm tra, để đảm bảo form được gửi đến từ mã Html do ứng dụng phát sinh

### BeginForm
Dựng HTML Form trong MVC
```cs
@using (Html.BeginForm(FormMethod.Post))
{
    // Các phần tử
}
```

### BeginRouteForm
Dựng HTML Form trong MVC, action theo Route

### CheckBox, CheckBoxFor
`CheckBox(expression, isChecked, htmlAttributes)`, Tạo phần tử Html `<input>` kiểu checkbox, expression chuỗi biểu thức phần tử Model

### Display(expression), DislayFor
Dựng HTML cho phần tử Model expression

### DisplayName(expression), DisplayNameFor
Lấy tên expression, tên thiết lập bằng `[Display]`

### DropDownList, DropDownListFor
`DropDownList(expression, selectList, optionLabel, htmlAttributes)` tạo phần tử Select
```cs
@Html.DropDownList("thanhpho",
    new SelectList(new string[] {"Hà Nội", "Sài Gòn"}));
```

### Editor(expression), EditorFor
Tạo control (phần tử input) cho expression (kiểu quy định type của input)

### Hidden(expression), HiddenFor
Tạo input có kiểu hidden

### Label(expression), LabelFor
Tạo phần tử `<label>`

### ListBox, ListBoxFor
Tạo html select - dùng giống DropDownList

### PartialAsync
Dựng Html từ Partial

### RenderPartialAsync
Dựng Html từ Partial

### Password, PasswordFor
Tạo `<input>` nhập password

### RadioButton(expression, value), RadioButtonFor
Tạo `<input>` kiểu radiobutton

### TextArea, TextAreaFor
`TextArea(expression, value, rows, columns, htmlAttributes)` Tạo `<textarea>`

### TextBox, TextBoxFor
`TextBox(expression, value, format, htmlAttributes)` Tạo `<input>` kiểu text

### ValidationMessage
`ValidationMessage (expression, message, htmlAttributes, tag)` Trả về HTML thông báo lỗi kiểm tra Model

### ValidationSummary
Trả về HTML phần tử ul, các thông báo lỗi kiểm tra Model