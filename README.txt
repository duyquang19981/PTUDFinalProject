-- Xem xe theo id chu xe
-- Xem bang lai theo id chu xe
/api/Chuxe/1

<<<<<<< Updated upstream
[{"$id":"1","ChuxeId":1,"CMND":123456789,"HoTen":"Quang Huy","DiaChi":"Bien Hoa","GioiTinh":"Nam","NamSinh":1999,"Xes":[{"$id":"2","XeId":2,"BienSoXe":"12345","Hang":"Honda","Loai":"Vison","MauSac":"Den","Nam":2020,"TrangThai":"Hoan tat","ChuxeId":1,"Chuxe":{"$ref":"1"}},{"$id":"3","XeId":3,"BienSoXe":"23451","Hang":"Yamaha","Loai":"Exciter","MauSac":"Den","Nam":2020,"TrangThai":"Hoan tat","ChuxeId":1,"Chuxe":{"$ref":"1"}}],"ChuxevaBanglais":[{"$id":"4","ChuxeId":1,"Chuxe":{"$ref":"1"},"BanglaiId":1,"Banglai":null},{"$id":"5","ChuxeId":1,"Chuxe":{"$ref":"1"},"BanglaiId":2,"Banglai":null},{"$id":"6","ChuxeId":1,"Chuxe":{"$ref":"1"},"BanglaiId":3,"Banglai":null}]}]
=======
[{"$id":"1","ChuxeId":1,"CMND":123456789,"HoTen":"Quang Huy","DiaChi":"Bien Hoa","GioiTinh":"Nam","NamSinh":1999,"Xes":[{"$id":"2","XeId":2,"BienSoXe":"12345","Hang":"Honda","Loai":"Vison","MauSac":"Den","Nam":2020,"TrangThai":"Hoan tat","ChuxeId":1,"Chuxe":{"$ref":"1"}},{"$id":"3","XeId":3,"BienSoXe":"23451","Hang":"Yamaha","Loai":"Exciter","MauSac":"Den","Nam":2020,"TrangThai":"Hoan tat","ChuxeId":1,"Chuxe":{"$ref":"1"}}],"ChuxevaBanglais":[{"$id":"4","ChuxeId":1,"Chuxe":{"$ref":"1"},"BanglaiId":1,"Banglai":null},{"$id":"5","ChuxeId":1,"Chuxe":{"$ref":"1"},"BanglaiId":2,"Banglai":null},{"$id":"6","ChuxeId":1,"Chuxe":{"$ref":"1"},"BanglaiId":3,"Banglai":null}]}]


-- Xem bang lai theo id
/api/Banglai/2

[{"$id":"1","BanglaiId":2,"LoaiBang":"A2","ThongTin":"Cho xe may","ChuxevaBanglais":null}]

-- Xem xe theo id
/api/Xe/2
[{"$id":"1","XeId":2,"BienSoXe":"12345","Hang":"Honda","Loai":"Vison","MauSac":"Den","Nam":2020,"TrangThai":"Hoan tat","ChuxeId":1,"Chuxe":{"$id":"2","ChuxeId":1,"CMND":123456789,"HoTen":"Quang Huy","DiaChi":"Bien Hoa","GioiTinh":"Nam","NamSinh":1999,"Xes":[{"$ref":"1"}],"ChuxevaBanglais":null}}]
>>>>>>> Stashed changes
