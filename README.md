# 🛒 E-Commerce Web Application (MVC)

Dự án Website Thương mại Điện tử được xây dựng trên nền tảng **ASP.NET Core MVC**, tập trung vào kiến trúc phân lớp (N-Tier Architecture) và triển khai các kỹ thuật lập trình backend hiện đại.

## Công nghệ sử dụng (Tech Stack)

* **Framework:** ASP.NET Core 7.0/8.0 (MVC Pattern)
* **Database:** MS SQL Server & Entity Framework Core
* **Authentication:** ASP.NET Core Identity (Identity Framework)
* **Patterns:** Repository Pattern, Unit of Work, Dependency Injection
* **Frontend:** Razor Pages, Bootstrap 5, JavaScript, SweetAlert2
* **Payment:** Tích hợp Stripe API (Xử lý thanh toán trực tuyến)

## Tính năng cốt lõi (Core Features)

### Khu vực người dùng (Customer Side)
- **Product Gallery:** Hiển thị danh sách sản phẩm theo danh mục và tìm kiếm.
- **Shopping Cart:** Hệ thống giỏ hàng (Add/Update/Remove) lưu trữ thông tin sản phẩm tạm thời.
- **Checkout Process:** Quy trình đặt hàng, nhập thông tin giao hàng và xác nhận đơn hàng.
- **Order History:** Xem lại danh sách các đơn hàng đã thực hiện và trạng thái hiện tại.

### Khu vực quản trị (Admin Side)
- **Category Management:** Quản lý danh mục sản phẩm (CRUD).
- **Product Management:** Quản lý thông tin chi tiết, giá cả và hình ảnh sản phẩm.
- **Company Management:** Quản lý thông tin các công ty đối tác (B2B).
- **Order Management:** Quản lý luồng đơn hàng (Duyệt đơn, Đang giao, Hoàn thành, Hủy đơn).

## Cấu trúc Solution (Project Structure)

Dự án được chia thành các Layer để đảm bảo tính đóng gói và dễ bảo trì:

1.  **Bulky.Models:** Chứa các POCO classes (Entities), ViewModels và Data Annotations.
2.  **Bulky.DataAccess:** Chứa `ApplicationDbContext`, Migrations và triển khai `Repository Pattern`.
3.  **Bulky.Utility:** Các hằng số (Static Details), cấu hình Email, Stripe và các Helper Classes.
4.  **BulkyWeb:** Dự án chính (Presentation Layer) chứa Controllers, Views và các tài nguyên tĩnh (`wwwroot`).

## Hướng dẫn cài đặt

1.  **Clone Repository:**
    ```bash
    git clone [https://github.com/Niyaa1786/E-Commerce.git](https://github.com/Niyaa1786/E-Commerce.git)
    ```
2.  **Cấu hình Connection String:**
    Cập nhật thông tin Server SQL trong file `appsettings.json` tại dự án Web:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER;Database=Bulky;Trusted_Connection=True;TrustServerCertificate=True"
    }
    ```
3.  **Migration Database:**
    Mở *Package Manager Console* và chọn Default Project là `Bulky.DataAccess`:
    ```powershell
    Update-Database
    ```
4.  **Chạy dự án:** Chọn `BulkyWeb` làm Startup Project và nhấn `F5`.

---
*Dự án được thực hiện nhằm mục đích học tập và xây dựng Portfolio.*
