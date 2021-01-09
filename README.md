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
