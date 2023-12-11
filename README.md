# BaiTapLon_HeThongPhanTan
Đề Bài:
Tạo 5 bản sao cho CSDL SQL (Có 1 table gồm 5 trường dữ liệu với các kiểu dữ liệu khác nhau )trên hệ thống mạng nội bộ nhóm. 
Viết ứng dụng lan truyền cập nhật từ CSDL đến Bản sao 1, bản sao 1 đến bản sao 2 và bản sao 3, 4 và 5.

* Sử dụng SQL server 2022

- Tạo 5 server: mỗi người trong nhóm tạo một server.

- Tạo database: gồm hai bảng 1 bảng là yêu cầu đề bài, bảng còn lại
lưu lại thời gian và nội dung cập nhật khi người dùng thêm sửa xóa.

- Phân tán: kết nối với các server lại với nhau và phân tán.

- Tạo trigger khi người dùng thực hiện thao tác cập nhật trên bảng.

- Tạo sp để thêm, xóa, sửa cho table ở "bản sao 1".

- Tạo giao tác phân tán để lan truyền cập nhật cho các site còn lại.

*Sử dung C# và IDE visual studio

- Tạo một form:
	+ Form tự động kết nối với tất cả các site.

	+ From sẽ có 5 tab phần mỗi tab sẽ hiển thị các table ở các site.

	+ Người dùng có thể thao tác trực tiếp trên table trên form

	+ khi người dùng thêm, xóa, sửa trên một bảng bất kỳ và nhấn lưu lại
	 thì ứng dụng sẽ gọi thực hiện sp và gọi giao tác phân tán.

* Công việc:
- Công việc cho một cá nhân:
	+ Tạo sp update
	+ Tạo sp delete
	+ Tạo sp add
	+ Tạo Transaction và job
	+ Tạo trigger
	+ Tạo Form C# kết nối tất cả các site(mình đã chuẩn bị sẵn code để kết nối các site)
	mỗi site sẽ co 2 table: 1 là table của đề bài, 2 là table lưu lại thời gian, nội dung cập nhật.
- Công việc nhóm: 
	+ Chọn thời gian địa điểm làm nhóm để phân tán và test ứng dụng.
	+ Tạo server
	+ Cài đặt visual studio
	+ Học lý thuyết

![image](https://github.com/QuachNamLuong/BaiTapLon_HeThongPhanTan/assets/82036270/cc793b17-0380-4511-83e9-64ebcd2843f3)
- Chọn server trước rồi mới nhấn nút "Làm mới", các server khác cũng có chức năng thêm, xoá, sửa như server 1. Copy file employee.sql (có mấy lệnh sp thêm, xoá, sửa mới demo được chức năng crud). Muốn demo server nào thì tạo thêm server trên SSMS rổi paste file sql dô rồi chạy



