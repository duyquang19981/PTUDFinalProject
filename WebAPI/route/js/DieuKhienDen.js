const port = 44399;
const url_DenGiaoThong = `https://localhost:${port}/api/DenGiaoThong`;
const url_KhuVuc = `https://localhost:${port}/api/KhuVuc`;
var urlParams;
var page = prevPage = nextPage = totalPage = greatestID =  1;

// var madoitac

(window.onpopstate = function () {
    var match,
        pl     = /\+/g,  // Regex for replacing addition symbol with a space
        search = /([^&=]+)=?([^&]*)/g,
        decode = function (s) { return decodeURIComponent(s.replace(pl, " ")); },
        query  = window.location.search.substring(1);
    urlParams = {};
    while (match = search.exec(query))
    urlParams[decode(match[1])] = decode(match[2]);
})();


function startTimer(duration1 ,duration2, duration3, state, display1, display2 ) {
  var timer = duration1;
  var state = state;
  setInterval(function () {
      display1.textContent = timer;
      display2.textContent = timer;
      if (--timer < 0) {
        switch (state) {
          case 'd':
            timer = duration2;
            state = 'v';
            $('#red1').addClass('light-off');
            $('#green2').addClass('light-off');
            $('#yellow1').removeClass('light-off');
            $('#yellow2').removeClass('light-off');
          break;
          case 'v':
            timer = duration3;
            state = 'x';
            $('#yellow1').addClass('light-off');
            $('#yellow2').addClass('light-off');
            $('#green1').removeClass('light-off');
            $('#red2').removeClass('light-off');
          break;
          case 'x':
            timer = duration1;
            state = 'd';
            $('#green1').addClass('light-off');
            $('#red1').removeClass('light-off');
            $('#red2').addClass('light-off');
            $('#green2').removeClass('light-off');
          break;
          default:
            break;
        }
      }
  }, 1000);
}



$(document).ready( async function(){
    
    var data_DenGiaoThong =[];
    var data_KhuVuc =[];
  //get khuVuc_Id 
    var id_Den = Number(urlParams.id_Den) || 1;
    
    // get  data  
    await axios.get(url_DenGiaoThong+`/${id_Den}`).then(function(res){
        data_DenGiaoThong = RestoreJsonNetReferences(res.data);
        
    });
    console.log('data_DenGiaoThong :>> ', data_DenGiaoThong);
    var Id_Den = data_DenGiaoThong.Id;
    console.log('Id_Den :>> ', Id_Den);
    var Do = data_DenGiaoThong.Do;
    var Vang = data_DenGiaoThong.Vang;
    var Xanh = data_DenGiaoThong.Xanh;
    var khuVuc_Id = data_DenGiaoThong.KhuVuc.Id;
    var TenDuong = data_DenGiaoThong.TenDuong;
    $('.DiaDiem')[0].append(TenDuong);
    display1 = document.getElementsByClassName('clock1')[0];
    display2 = document.getElementsByClassName('clock2')[0];
    var state = 'd';
    startTimer(Do ,Vang, Xanh, state, display1, display2);
        
    $(document).on("click", "#btn_thaydoi", function(){
      
      const Do = $('#red')[0].value;
      console.log('object :>> ', $('#red'));
      console.log('object :>> ', Do);
      const Vang = $('#yellow')[0].value;
      console.log('Vang :>> ', Vang);
      const Xanh = $('#green')[0].value;
      console.log('Xanh :>> ', Xanh);
      if(!Do || !Vang || !Xanh){
        alert('Nhập dữ liệu thời gian');
        return;
      }
      axios({
          method: 'PUT',
          url: url_DenGiaoThong + `/${Id_Den}`,
          data:({
              //KhuVuc_Id: khuVuc_Id,
              Do: Do,
              Vang :Vang,
              Xanh : Xanh,
              TenDuong : TenDuong,
              TrangThai : 1,
          }),
          
      }) .then(function (response) {
          if (response.status === 200) {
            console.log("Update Success");
            return window.location.reload();
            
          }
      })
      .catch(function (response) {
          console.log(response);
        
      });
    });
});


 