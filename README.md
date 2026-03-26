# Assembly Shop

Ứng dụng thương mại điện tử xây dựng bằng ASP.NET Core với Razor Pages, cung cấp các chức năng quản lý sản phẩm, danh mục, đơn hàng, giỏ hàng và xác thực người dùng.

---

## Công Nghệ Sử Dụng

### Ngôn Ngữ & Nền Tảng
- **Ngôn Ngữ:** C# 14.0
- **Framework:** ASP.NET Core 10.0 (.NET 10)
- **Kiến Trúc:** Razor Pages / MVC
- **Cơ Sở Dữ Liệu:** SQL Server

### Thư Viện & Công Cụ Chính
- **Entity Framework Core 10.0.5** - ORM cho truy vấn cơ sở dữ liệu
- **ASP.NET Core Identity** - Xác thực và phân quyền người dùng
- **ASP.NET Core Identity EntityFrameworkCore** - Tích hợp Identity với EF Core
- **Tailwind CSS** - Styling UI (thông qua input.css)
- **FontAwesome** - Icon library

---

## Cấu Trúc Thư Mục

```
E-Commerce/
│
├── Controllers/               # Xử lý logic request-response
│   ├── AdminHomeController.cs # Quản lý dashboard admin
│   ├── OrderController.cs     # Quản lý đơn hàng
│   ├── CartController.cs      # Quản lý giỏ hàng
│   ├── ProductController.cs   # Quản lý sản phẩm
│   ├── CategoryController.cs  # Quản lý danh mục
│   ├── AuthController.cs      # Xác thực người dùng
│   └── HomeController.cs      # Trang chủ
│
├── Models/                    # Định nghĩa data models
│   ├── Orders/
│   │   ├── Order.cs          # Model đơn hàng
│   │   └── OrderItem.cs      # Chi tiết sản phẩm trong đơn hàng
│   ├── Products/
│   │   ├── Product.cs        # Model sản phẩm
│   │   └── ProductVarient.cs # Biến thể sản phẩm
│   ├── Categories/
│   │   └── Category.cs       # Model danh mục
│   ├── Carts/
│   │   ├── Cart.cs           # Model giỏ hàng
│   │   └── CartItem.cs       # Mục trong giỏ hàng
│   ├── Users/
│   │   └── User.cs           # Model người dùng
│   ├── Enums/
│   │   └── OrderStatus.cs    # Enum trạng thái đơn hàng
│   ├── BaseEntity.cs         # Lớp cơ sở cho tất cả entities
│   └── AuditableEntity.cs    # Lớp audit tự động
│
├── Services/                  # Business logic layer
│   ├── Interfaces/           # Định nghĩa interfaces
│   │   ├── IProductServices.cs
│   │   ├── IOrderServices.cs
│   │   ├── ICategoryServices.cs
│   │   ├── IAuthServices.cs
│   │   └── ICartServices.cs
│   └── Implementations/      # Triển khai services
│       ├── ProductServices.cs
│       ├── OrderServices.cs
│       ├── CategoryServices.cs
│       ├── AuthServices.cs
│       └── CartServices.cs
│
├── DTOs/                      # Data Transfer Objects
│   ├── ProductDTO/           # DTO cho sản phẩm
│   │   ├── CreateProductRequest.cs
│   │   ├── UpdateProductRequest.cs
│   │   └── ProductVariantRequest.cs
│   ├── CategoryDTO/          # DTO cho danh mục
│   │   ├── CategoryRequest.cs
│   │   └── CategoryResponse.cs
│   └── AuthDTO/              # DTO cho xác thực
│       ├── LoginRequest.cs
│       └── RegisterRequest.cs
│
├── Views/                     # Razor Pages templates
│   ├── AdminHome/
│   │   └── Index.cshtml      # Dashboard quản lý đơn hàng
│   ├── Order/
│   │   ├── Checkout.cshtml   # Trang thanh toán
│   │   ├── GetAllProducts.cshtml
│   │   └── GetOrderDetail.cshtml
│   ├── Cart/
│   │   └── Index.cshtml      # Trang giỏ hàng
│   ├── Product/
│   │   ├── Index.cshtml      # Danh sách sản phẩm
│   │   ├── Details.cshtml    # Chi tiết sản phẩm
│   │   └── Create.cshtml     # Tạo sản phẩm
│   ├── Category/
│   │   ├── Index.cshtml      # Danh sách danh mục
│   │   ├── Create.cshtml     # Tạo danh mục
│   │   └── Edit.cshtml       # Chỉnh sửa danh mục
│   ├── Auth/
│   │   ├── Login.cshtml      # Trang đăng nhập
│   │   └── Register.cshtml   # Trang đăng ký
│   ├── Home/
│   │   ├── Index.cshtml      # Trang chủ
│   │   └── InProgress.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml    # Layout chính
│   │   └── _AdminLayout.cshtml # Layout admin
│   ├── _ViewStart.cshtml
│   └── _ViewImports.cshtml
│
├── Data/                      # Database context
│   └── AppDbContext.cs       # Entity Framework DbContext
│
├── Migrations/                # Entity Framework migrations
│   └── [các file migration]
│
├── wwwroot/                   # Thư mục static assets
│   └── css/
│       └── input.css         # Tailwind CSS configuration
│
├── Program.cs                 # Cấu hình ứng dụng
├── appsettings.json          # Cơ sở dữ liệu & logging
└── E-Commerce.csproj         # Project file
```

---

## Hướng Dẫn Cài Đặt

### Yêu Cầu Hệ Thống
- **.NET 10 SDK** - [Tải từ đây](https://dotnet.microsoft.com/en-us/download)
- **SQL Server 2019+** - [Tải từ đây](https://www.microsoft.com/en-us/sql-server/sql-server-2022)
- **Visual Studio 2022+** hoặc **Visual Studio Code**
- **Git** (tuỳ chọn)

### Các Bước Cài Đặt

#### 1. Clone Repository
```bash
git clone https://github.com/Niyaa1786/E-Commerce.git
cd E-Commerce
```

#### 2. Cấu Hình Chuỗi Kết Nối
Mở file `appsettings.json` và chỉnh sửa `DefaultConnection`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME\\SQLEXPRESS;Database=E-Commerce(MVC);Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

**Lưu ý:**
- Thay `YOUR_SERVER_NAME` bằng tên SQL Server của bạn
- Hoặc nếu dùng SQL Server trực tiếp: `Server=.;Database=E-Commerce(MVC);Trusted_Connection=True;`

#### 3. Restore Dependencies
```bash
dotnet restore
```

#### 4. Tạo Cơ Sở Dữ Liệu
```bash
dotnet ef database update
```

Hoặc từ **Package Manager Console** trong Visual Studio:
```powershell
Update-Database
```

#### 5. Chạy Ứng Dụng
```bash
dotnet run
```

Ứng dụng sẽ chạy tại: `https://localhost:5001` (hoặc cổng được chỉ định)

---

## ✨ Các Tính Năng Chính

### Tính Năng Người Dùng
- **Xác Thực & Phân Quyền**
  - Đăng ký tài khoản mới
  - Đăng nhập/Đăng xuất
  - Phân quyền dựa trên vai trò (Admin, User)

- **Quản Lý Sản Phẩm**
  - Xem danh sách sản phẩm
  - Xem chi tiết sản phẩm
  - Lọc theo danh mục
  - Hỗ trợ biến thể sản phẩm (kích thước, màu sắc, v.v.)

- **Quản Lý Giỏ Hàng**
  - Thêm/xoá sản phẩm khỏi giỏ hàng
  - Cập nhật số lượng
  - Tính toán tổng tiền tự động

- **Xử Lý Đơn Hàng**
  - Đặt đơn hàng
  - Trang thanh toán

### Tính Năng Admin
- **Dashboard Quản Lý**
  - Xem tổng doanh thu
  - Thống kê tổng đơn hàng
  - Hiển thị đơn hàng chờ duyệt
  - Lịch sử giao dịch

- **Quản Lý Sản Phẩm**
  - Tạo sản phẩm mới
  - Chỉnh sửa/Xoá sản phẩm
  - Quản lý danh mục sản phẩm

- **Quản Lý Danh Mục**
  - Tạo danh mục mới
  - Chỉnh sửa danh mục
  - Xoá danh mục

---

## Cách Sử Dụng

### Quy Trình Mua Hàng Thông Thường

#### 1. **Đăng Ký/Đăng Nhập**
- Truy cập `/Auth/Register` để tạo tài khoản
- Hoặc `/Auth/Login` để đăng nhập

#### 2. **Duyệt Sản Phẩm**
- Vào trang `/Product/Index` để xem tất cả sản phẩm
- Click vào sản phẩm để xem chi tiết tại `/Product/Details/{id}`

#### 3. **Thêm vào Giỏ Hàng**
- Trên trang chi tiết sản phẩm, nhấn nút "Thêm vào giỏ"
- Xem giỏ hàng tại `/Cart/Index`

#### 4. **Thanh Toán**
- Từ giỏ hàng, nhấn "Tiến tới thanh toán"
- Điền thông tin giao hàng trên `/Order/Checkout`
- Xác nhận đơn hàng

#### 5. **Theo Dõi Đơn Hàng**
- Xem lịch sử đơn hàng trong tài khoản
- Kiểm tra trạng thái đơn hàng

### Quy Trình Quản Lý Admin

#### 1. **Truy Cập Dashboard**
- Đăng nhập với tài khoản Admin
- Vào `/AdminHome/Index` để xem dashboard

#### 2. **Quản Lý Sản Phẩm**
- `/Product/Index` - Danh sách sản phẩm
- `/Product/Create` - Tạo sản phẩm mới

#### 3. **Quản Lý Danh Mục**
- `/Category/Index` - Danh sách danh mục
- `/Category/Create` - Tạo danh mục mới

#### 4. **Xem Đơn Hàng**
- Dashboard hiển thị thống kê đơn hàng
- Bảng "Lịch sử giao dịch" liệt kê tất cả đơn hàng

---

## Cấu Trúc Dữ Liệu Chính

### Order (Đơn Hàng)
```csharp
- Id: int
- UserId: int
- TotalAmount: decimal
- Status: string (Pending, Confirmed, Shipped, Delivered)
- ShippingAddress: string
- CreatedAt: DateTime
- OrderItems: List<OrderItem>
```

### OrderItem (Chi Tiết Đơn Hàng)
```csharp
- Id: int
- OrderId: int
- ProductId: int
- Quantity: int
- UnitPrice: decimal
```

### Product (Sản Phẩm)
```csharp
- Id: int
- Name: string
- Description: string
- Price: decimal
- CategoryId: int
- StockQuantity: int
- ProductVariants: List<ProductVarient>
```

### Category (Danh Mục)
```csharp
- Id: int
- Name: string
- Description: string
- Products: List<Product>
```

---

## Công Cụ Hỗ Trợ Phát Triển

### Tạo Migration Mới
```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

---

## Tài khoản

| Vai trò       | Tài khoản            | Mật khẩu      | 
| ------------- |:--------------------:|:-------------:|
| Admin         | admin@assembly.com   |admin@123      |
| Customer      | customer@assembly.com|customer@123   |
