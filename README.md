Thầy vào chấm điểm muốn chạy thử thì nhớ cài theo sau nha :
Vào Tools -> NuGet Package Manager -> Pakage Manager Console
Chạy lệnh: 
dotnet nuget locals all --clear


Cài các extension:
Microsoft.AspNetCore.Identity.EntityFrameworkCore v8.0.7
Microsoft.AspNetCore.Identity.UI v8.0.7
Microsoft.EntityFrameworkCore v8.0.7
Microsoft.EntityFrameworkCore.Design v8.0.7
Microsoft.EntityFrameworkCore.SqlServer v8.0.7
Microsoft.EntityFrameworkCore.Tools v8.0.7
Microsoft.VisualStudio.Web.CodeGeneration.Design v8.0.7


Sửa trong appsetting.json:
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=DESKTOP-EV9H5TN\\SQLEXPRESS;Database=Webbanhang;Trusted_Connection=True;TrustServerCertificate=True"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*"
}

Thay DESKTOP-EV9H5TN\\SQLEXPRESS thành tên của Servername trong SQL Server (nếu tên có 1 dấu \ thay thành \\)

Chạy lệnh(Pakage Manager Console):
Add-Migration ExtendIdentityUser
Drop-Database(Nếu trong Sql server đã có sẵn database "Webbanhang" để tránh bị trùng tên)
Update-Database

Vào Sql Server-> Database->Webbanhang->Bảng Categories-> Thêm dữ liệu vào Name như "Laptop" "Phone"...

Khởi động chương trình:
Đăng ký (Register) với vai trò customer
- Khi thêm vào /product/add sau tên miền localhost thì sẽ bị cấm không xem được do đang ở dưới quyền khách hàng (customer)
//Khách hàng không thể add, edit, delete chỉ được xem và display product

Đăng ký (Register) với vai trò admin
- Có thể sử dụng mọi chức năng
- vui lòng vào db.caterogy tạo thủ công sẵn 2 tới 5 loại sản phẩm rồi hả thêm sãn phẩm
- sau đó vào thêm sản phẩm với giá trị sãn phẩm được tính bằng đô nên không thể quá cao được giới hạn 
