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
        khuVuc_Id = Number(urlParams.khuVuc_Id) || 0;
        
        // get data in page
        // if khuVuc_Id = 0 : get all
        // else : query khuVuc_Id
        if(khuVuc_Id==0){
            await axios.get(url_DenGiaoThong).then(function(res){
                data_DenGiaoThong = RestoreJsonNetReferences(res.data);
            });
        }
        else{
            await axios.get(url_KhuVuc + `/${khuVuc_Id}`).then(function(res){
                const temp = RestoreJsonNetReferences(res.data)
                data_DenGiaoThong = temp.DenGiaoThongs;
                console.log('object :>> ', data_DenGiaoThong);
            });
        }
        
        
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
        $('.search-key-select').prepend('<option value = "0">--Tất cả--</option>');   //add Tatca option

        $('.search-key-select').find(`option:nth-child(${Number(khuVuc_Id)+1})`).prop('selected','selected');    // option selected
    
        //render data
        var tableNV = document.getElementById('table-body');
        for(i in data_DenGiaoThong){
            // lay ten doi tac
            let TenKhuVuc = '';
            for(j in data_KhuVuc){
                if(data_KhuVuc[j].Id == data_DenGiaoThong[i].KhuVuc_Id){
                    TenKhuVuc = data_KhuVuc[j].TenKhuVuc ;
                    break;
                }
                else{ 
                    TenKhuVuc = "Unknown";
                }
            }
            
            let row =   '<tr> '+ `
                            <td>${data_DenGiaoThong[i].Id}</td>
                            <td>${TenKhuVuc}</td>
                            <td>${data_DenGiaoThong[i].Do}</td>
                            <td>${data_DenGiaoThong[i].Vang}</td>
                            <td>${data_DenGiaoThong[i].Xanh}</td>
                            <td>${data_DenGiaoThong[i].TrangThai}</td>
                            <td>${data_DenGiaoThong[i].TenDuong}</td>
                            <td>
                                <a class="add" title="Add" data-toggle="tooltip"><i class="material-icons">&#xE03B;</i></a>
                                <a class="edit" title="Edit" data-toggle="tooltip"><i class="material-icons">&#xE254;</i></a>
                                <a class="delete" title="Delete" data-toggle="tooltip"><i class="material-icons">&#xE872;</i></a>
                            </td>
                        </tr>`;
            $("tbody").append(row);
        }
        
        //
        $('[data-toggle="tooltip"]').tooltip();
        var actions = $("table td:last-child").html();
        // Append table with add row form on add new button click
        
        $(".add-new").click( async function(){
            $(this).attr("disabled", "disabled");
            
            var index = $("table tbody tr:last-child").index();
            
            var row = '<tr>' +
                '<td><input  type="text" class="form-control input" readonly="readonly"></td>' +
                //'<td><input  type="text" class="form-control input" name="TenDoiTac" id="TenDoiTac" placeholder = "Input ID: 1,2 or 3" ></td>' +
                '<td>'+selectTag_KhuVuc+'</td>' +
                '<td><input type="number"  min="0" class="form-control input" name="Do" id="datepicker_add1"  value="" ></td>' +
                '<td><input type="number"  min="0" class="form-control input" name="Vang" id="ViTriDang"></td>' +
                '<td><input type="number"  min="0" class="form-control input" name="Xanh" id="datepicker_add2" value=""  ></td>' +
                '<td><input type="number" max="1" min="0" class="form-control input" name="TrangThai" id="GiaTri"></td>' +
                '<td><input type="text" class="form-control input" name="TenDuong" id="GiaTri"></td>' +
                '<td>' + actions + '</td>' +
            '</tr>';
            
            $("table").append(row);		
            $('.delete').hide();
            $("table tbody tr").eq(index + 1).find(".add, .edit").toggle();
            $('[data-toggle="tooltip"]').tooltip();
        });
        // Add row on add button click
        $(document).on("click", ".add", function(){
            var empty = false;
           // var input = $(this).parents("tr").find('input[type="text"]');
            var input = $(this).parents("tr").find('.input');
            //return;
            let i = 0;
            input.each(function(){
                if(!$(this).val() && i!=0 ){        //~
                    $(this).addClass("error");
                    empty = true;
                } else{
                    $(this).removeClass("error");
                }
                i++;
            });
            // if(!(+input[2].value) || !(+input[3].value) ||!(+input[4].value)||!(+input[5].value)){
            //     alert('Something wrong with data type!');
            //     return;
            // }
            $(this).parents("tr").find(".error").first().focus();
            if(!empty){
                let i = 0 ;
                input.each(function(){                  
                    if(i==0 ){
                        if( !input[0].value){
                            $(this).parent("td").html(greatestID+1);
                        }
                        else{
                            $(this).parent("td").html($(this).val());                           
                        }
                    }
                
                    $(this).closest("td").html($(this).val());
                    i++;
                });			    
                $(this).parents("tr").find(".add, .edit").toggle();
                $(".add-new").removeAttr("disabled");

                //check: add or edit        
                $('.delete').show();
                const khuVuc_Id = +input[1].value;
                const Do = +input[2].value;
                const Vang = +input[3].value;
                const Xanh = +input[4].value;
                const TrangThai = +input[5].value;
                const TenDuong= input[6].value;
                console.log('khu :>> ', khuVuc_Id);
                if(!input[0].value){
                    console.log('add');
                    // ADD
                    axios({
                        method: 'POST',
                        url: url_DenGiaoThong,
                        data: {
                            KhuVuc_Id: khuVuc_Id,
                            Do: Do,
                            Vang :Vang,
                            Xanh : Xanh,
                            TrangThai:TrangThai,
                            TenDuong : TenDuong
                        }
                    });
                    
                }
                else{
                 
                    axios({
                        method: 'PUT',
                        url: url_DenGiaoThong + `/${input[0].value}`,
                        data:({
                            //KhuVuc_Id: khuVuc_Id,
                            Do: Do,
                            Vang :Vang,
                            Xanh : Xanh,
                            TenDuong : TenDuong,
                            TrangThai : TrangThai,
                        }),
                        
                    }) .then(function (response) {
                        if (response.status === 200) {
                        console.log("Update Success");
                        }
                    })
                    .catch(function (response) {
                        console.log(response);
                      
                    });
                }
            
            }		
        });
        // Edit row on edit button click
        $(document).on("click", ".edit", function(){	
	
            $(this).parents("tr").find("td:first-child").each(function(){
                $(this).html('<input type="text" class="form-control input" value="' + $(this).text() + '" readonly="readonly">');
            });	
            $(this).parents("tr").find("td:nth-child(2)").each(function(){
                $(this).html('<input type="text" class="form-control input" value="' + $(this).text() + '" readonly="readonly">');

            });	
            $(this).parents("tr").find("td:nth-child(3)").each(function(){
                // $(this).html('<input type="text" class="form-control input" value="' + $(this).text() + '" readonly="readonly">');
                $(this).html('<input type="number" min = "0" class="form-control input"  value="'+ $(this).text() +'" >');
            });	
            $(this).parents("tr").find("td:nth-child(4)").each(function(){
              // $(this).html('<input type="text" class="form-control input" value="' + $(this).text() + '" readonly="readonly">');
              $(this).html('<input type="number" min = "0" class="form-control input"  value="'+ $(this).text() +'" >');
          });
          $(this).parents("tr").find("td:nth-child(5)").each(function(){
                // $(this).html('<input type="text" class="form-control input" value="' + $(this).text() + '" readonly="readonly">');
                $(this).html('<input type="number" min = "0" class="form-control input"  value="'+ $(this).text() +'" >');
            });
            $(this).parents("tr").find("td:nth-child(6)").each(function(){
              // $(this).html('<input type="text" class="form-control input" value="' + $(this).text() + '" readonly="readonly">');
                $(this).html('<input type="number" min = "0" max = "1" class="form-control input"  value="'+ $(this).text() +'" >');
            });
            $(this).parents("tr").find("td:nth-child(7)").each(function(){
                // $(this).html('<input type="text" class="form-control input" value="' + $(this).text() + '" readonly="readonly">');
                $(this).html('<input type="text" class="form-control input"  value="'+ $(this).text() +'" >');
            });	
            // $(this).parents("tr").find("td:not(:last-child):not(:first-child):not(:nth-child(2)):not(:nth-child(7))").each(function(){
            //     $(this).html('<input type="number" class="form-control input" value="' + $(this).text() + '">');
            // });		

            $(this).parents("tr").find(".add, .edit").toggle();
            $(".add-new").attr("disabled", "disabled");

            //$('.delete').hide();
        });
        // Delete row on delete button click
        $(document).on("click", ".delete", function(){
            var id_ele =  $(this).parents("tr").find("td:first-child");
            var id = id_ele[0].innerText;
            if(!id){
                id_ele =  $(this).parents("tr").children(':first-child').children(':first-child');
                id = id_ele.val();
            }
            
            if(window.confirm(`Delete this record? (ID=${id})`)){
                //DELETE
                axios({
                        method: 'DELETE',
                        url: url_DenGiaoThong + `/${id}`,
                }).then(()=>{
                    $(this).parents("tr").remove();
                    $(".add-new").removeAttr("disabled");
                    alert(`The record has been deleted! (ID=${id})`);
                }).catch((error)=>{
                    alert("Failed! " + error);
                });
            }
            
        });
        $(document).on("click", "#search", function(){
            var search_key =  $('.search-key-select').val();
            console.log('search_key :>> ', search_key);
            window.location.replace(`quanlydengiaothong.html?khuVuc_Id=${search_key}`);
            
        });
    });