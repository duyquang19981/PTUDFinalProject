    
    const port = 44399;
    const url_DenGT_ThayDoi = `https://localhost:${port}/api/DenGT_ThayDoi`;
    const url_KhuVuc = `https://localhost:${port}/api/DenGiaoThong`;
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
        var data_DenGT_ThayDoi =[];
        var data_KhuVuc =[];

        // get all data  
        await axios.get(url_DenGT_ThayDoi).then(function(res){
          data_DenGT_ThayDoi = RestoreJsonNetReferences(res.data);
        });


        for(i in data_DenGT_ThayDoi){
      
            
            let row =   '<tr> '+ `
                            <td>${data_DenGT_ThayDoi[i].Id}</td>
                            <td>${data_DenGT_ThayDoi[i].ThoiDiemThayDoi}</td>
                            <td>${data_DenGT_ThayDoi[i].ThoiGianDoi}</td>
                            <td>${data_DenGT_ThayDoi[i].Do_TD}</td>
                            <td>${data_DenGT_ThayDoi[i].Vang_TD}</td>
                            <td>${data_DenGT_ThayDoi[i].Xanh_TD}</td>
                            <td>${data_DenGT_ThayDoi[i].TuDong}</td>
                            <td>${data_DenGT_ThayDoi[i].ThoiGianThucHien}</td>
                            <td>${data_DenGT_ThayDoi[i].DenGiaoThong_Id}</td>
                            <td>${data_DenGT_ThayDoi[i].NguoiQuanLyGT_Id}</td>
                            
                        </tr>`;
            $("tbody").append(row);
        }
     
      
    });