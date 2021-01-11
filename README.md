# PTUDFinalProject

API chức năng xem

QUANG: [{
  link: 'https://localhost:44399/api/DenGiaoThong/2',
  data: {
    "$id": "1",
    "KhuVuc": {
      "$id": "2",
      "DenGiaoThongs": [
        {
          "$ref": "1"
        },
        {
          "$id": "3",
          "KhuVuc": {
            "$ref": "2"
          },
          "Id": 3,
          "Do": 12,
          "Vang": 23,
          "Xanh": 30,
          "TrangThai": 1
        },
        {
          "$id": "4",
          "KhuVuc": {
            "$ref": "2"
          },
          "Id": 4,
          "Do": 30,
          "Vang": 3,
          "Xanh": 30,
          "TrangThai": 1
        }
      ],
      "Id": 1,
      "TenKhuVuc": "Lam dong"
    },
    "Id": 2,
    "Do": 12,
    "Vang": 23,
    "Xanh": 42,
    "TrangThai": 1
  }
},{
  "link": 'https://localhost:44399/api/KhuVuc/2',
  "data" :{
    "$id": "1",
    "DenGiaoThongs": [
      {
        "$id": "2",
        "KhuVuc": {
          "$ref": "1"
        },
        "Id": 6,
        "Do": 30,
        "Vang": 30,
        "Xanh": 30,
        "TrangThai": 0
      }
    ],
    "Id": 2,
    "TenKhuVuc": "ha noi"
  }
}]

KHANG: 
API CHỨC NĂNG XEM TÂT CẢ BÁO CÁO
{
  link:https://localhost:44399/api/BaoCao
  data:
  {
"$id": "1",
"Id": 1,
"NguoiViPham": 123456789,
"DiaDiemPhat": "Nguyen Van Cu",
"ThoiGianLap": "10/1/2021",
"TienPhat": 100,
"TinhTrangNopPhat": "Chua",
"ViPhamLuatGTs": [
{
"$id": "2",
"Id": 1,
"Id_BaoCao": 1,
"BaoCao": {
"$ref": "1"
},
"Id_LuatGiaoThong": 2,
"LuatGiaoThong": null
},
{
"$id": "3",
"Id": 2,
"Id_BaoCao": 1,
"BaoCao": {
"$ref": "1"
},
"Id_LuatGiaoThong": 3,
"LuatGiaoThong": null
}
]
},
{
"$id": "4",
"Id": 2,
"NguoiViPham": 28159753,
"DiaDiemPhat": "Linh Trung",
"ThoiGianLap": "9/1/2021",
"TienPhat": 100,
"TinhTrangNopPhat": "Chua",
"ViPhamLuatGTs": [
{
"$id": "5",
"Id": 3,
"Id_BaoCao": 2,
"BaoCao": {
"$ref": "4"
},
"Id_LuatGiaoThong": 5,
"LuatGiaoThong": null
}
]
},
{
"$id": "6",
"Id": 3,
"NguoiViPham": 147258369,
"DiaDiemPhat": "Thu Duc",
"ThoiGianLap": "8/1/2021",
"TienPhat": 100,
"TinhTrangNopPhat": "Roi",
"ViPhamLuatGTs": [
{
"$id": "7",
"Id": 4,
"Id_BaoCao": 3,
"BaoCao": {
"$ref": "6"
},
"Id_LuatGiaoThong": 7,
"LuatGiaoThong": null
}
]
}
}

CHỨC NĂNG XEM BÁO CÁO CỦA 1 NGƯỜI THEO CMND (123456789)
KHANG

{
link:https://localhost:44399/api/BaoCao/123456789
data:
{
"$id": "1",
"Id": 1,
"NguoiViPham": 123456789,
"DiaDiemPhat": "Nguyen Van Cu",
"ThoiGianLap": "10/1/2021",
"TienPhat": 100,
"TinhTrangNopPhat": "Chua",
"ViPhamLuatGTs": [
{
"$id": "2",
"Id": 1,
"Id_BaoCao": 1,
"BaoCao": {
"$ref": "1"
},
"Id_LuatGiaoThong": 2,
"LuatGiaoThong": null
},
{
"$id": "3",
"Id": 2,
"Id_BaoCao": 1,
"BaoCao": {
"$ref": "1"
},
"Id_LuatGiaoThong": 3,
"LuatGiaoThong": null
}
]
}
}
=======
YEN: {
  link: 'http://localhost:64714/api/Xe/1',
  data: {
    [{"$id":"1","Chuxe":{"$id":"2","Xes":[{"$ref":"1"}],"Id":1,"CMND":2000,"HoTen":"Vu Thi Hai Yen","DiaChi":"235B Nguyen Van Cu, quan 1","GioiTinh":"Nu","NamSinh":1999},"Id":1,"BienSoXe":"51B-70000","Hang":"Vision","Loai":"Tay ga","MauSac":"Do","Nam":2020,"TrangThai":"Khong"}]}
