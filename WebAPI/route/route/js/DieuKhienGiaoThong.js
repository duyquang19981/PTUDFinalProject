const port = 44399;
const url_DenGiaoThong = `https://localhost:${port}/api/DenGiaoThong`;
const url_KhuVuc = `https://localhost:${port}/api/KhuVuc`;
var urlParams;
var page = prevPage = nextPage = totalPage = greatestID =  1;

// var madoitac
var khuVuc_Id;
const pageSize = 15;
var selectTag_KhuVuc = '';
var CE = 0; // Count_Edit_Button_onClick
//get URL query

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
$(document).ready( async function(){
    
    var data_DenGiaoThong =[];
    var data_KhuVuc =[];

    // get all data  
    await axios.get(url_DenGiaoThong).then(function(res){
        data_DenGiaoThong = RestoreJsonNetReferences(res.data);

    });

    

    //get khuVuc_Id 
    khuVuc_Id = Number(urlParams.khuVuc_Id) || 1;
    
    // get data in page
    // if khuVuc_Id = 0 : get all
    // else : query khuVuc_Id
    var data_KhuVuc_showing;
        await axios.get(url_KhuVuc + `/${khuVuc_Id}`).then(function(res){
            const temp = RestoreJsonNetReferences(res.data)
            data_DenGiaoThong = temp.DenGiaoThongs;
            console.log('den gt trong khu vuc :>> ', data_DenGiaoThong);
            data_KhuVuc_showing = temp;
        });
    
    await axios.get(url_KhuVuc).then(function(res){
        data_KhuVuc = RestoreJsonNetReferences(res.data);
    });
    
        // create select tag
    selectTag_KhuVuc  = '<select class="form-control input " >';
    for( i of data_KhuVuc){
        selectTag_KhuVuc += `<option value = '${i.Id}'>${i.TenKhuVuc}</option>`;
    }
    selectTag_KhuVuc += '</select>';
    
    $('.search-block').append(selectTag_KhuVuc);
    $('.search-block').find("select:first-child").addClass('search-key-select');
    // $('.search-key-select').prepend('<option value = "0">--Tất cả--</option>');   //add Tatca option
    $('.search-key-select').find(`option:nth-child(${Number(khuVuc_Id)})`).prop('selected','selected');    // option selected

    //render data
    var mapwrap = $('.map-wrap');
    for(i in data_DenGiaoThong){  
      var randx = Math.floor(Math.random() * 10) ;
      var randy =  Math.floor(Math.random() * 5);
      var id_Den = data_DenGiaoThong[i].Id;
      console.log('id_Den :>> ', id_Den);
      var TenDuong = data_DenGiaoThong[i].TenDuong;
      console.log('TenDuong :>> ', TenDuong);
      var traffic_img = `<a href="theodoiden.html?id_Den=${id_Den}" data-toggle="tooltip" data-placement="top" title="${TenDuong}">
                            <img id="traffic-light-${i}" 
                              class = "trafic-light"
                              src = "img/den.png"
                              style="left:${randx*100 + randy*10 + 30}px; top:${randy*70 + randx*15 + 15}px; ">
                          </a>`
      mapwrap.append(traffic_img);
    }
    $('[data-toggle="tooltip"]').tooltip(); 
    
    var TenKhuVuc =  data_KhuVuc_showing.TenKhuVuc;
    console.log('TenKhuVuc :>> ', TenKhuVuc);
    $('.map-wrap').css('background-image', `url('./img/${TenKhuVuc}.png')`);
    
    //
    $(document).on("click", "#search", function(){
        var search_key =  $('.search-key-select').val();
        console.log('search_key :>> ', search_key);
        window.location.replace(`dieukhiengiaothong.html?khuVuc_Id=${search_key}`);
        
    });
});