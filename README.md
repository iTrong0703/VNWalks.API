# VNWalks.API

## Kiến trúc và tổ chức

Dự án được tổ chức theo kiến trúc tách biệt (Clean Architecture) với các layer rõ ràng:

-   **Controllers:** Chứa các endpoint API, xử lý logic giao tiếp.
-   **Repositories:** Quản lý truy vấn và giao tiếp với cơ sở dữ liệu.
-   **Models:**
    -   **Domain Models:** Đại diện cho thực thể thực tế trong nghiệp vụ.
    -   **DTO Models:** Chỉ chứa dữ liệu cần thiết để giao tiếp giữa client và server.

## Công nghệ sử dụng

-   **Backend:** ASP.NET Core 8
-   **Database:** SQL Server
-   **Authentication:** ASP.NET Core Identity, JWT Token
-   **Mappings:** AutoMapper
-   **Testing:** Serilog, Swagger, Postman

## Về project

1. **Phát triển RESTful API:**

-   Sử dụng ASP.NET Core Web API.
-   Áp dụng các nguyên tắc RESTful để thiết kế các endpoint rõ ràng, dễ sử dụng.

2. **Entity Framework Core (EF Core):**

-   Sử dụng Code-First để tạo cơ sở dữ liệu và thực hiện các thao tác CRUD.
-   Seed dữ liệu mẫu cho một vài bảng trong cơ sở dữ liệu.

3. **Dependency Injection (DI)**

-   Sử dụng Dependency Injection (DI) để quản lý các dependency trong ứng dụng.

4. **Repository Pattern:**

-   Sử dụng Repository Pattern để quản lý riêng logic truy cập dữ liệu ở cơ sở dữ liệu, giúp mã nguồn dễ bảo trì và tái sử dụng.

5. **Xác thực và phân quyền:**

-   Sử dụng ASP.NET Core Identity để quản lý xác thực người dùng.
-   Sử dụng JSON Web Tokens (JWT) để xác thực, bảo mật.
-   Áp dụng phân quyền dựa trên vai trò (Role-based Authorization) cho các endpoint.

6. **Chức năng:**

-   Tích hợp các chức năng lọc, sắp xếp và phân trang để tối ưu hóa hiệu năng và nâng cao trải nghiệm người dùng.

7. **Tích hợp AutoMapper:**

-   Sử dụng AutoMapper để chuyển đổi giữa Domain Models và Data Transfer Objects (DTO), giảm thiểu việc viết mã lặp lại, ẩn đi các dữ liệu không cần thiết.

8. **Kiểm thử API:**

-   Dùng Swagger để tạo tài liệu API tự động và kiểm tra các endpoint.
-   Sử dụng thêm Postman.
-   Sử dụng Serilog để debug.
