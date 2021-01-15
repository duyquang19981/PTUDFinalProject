const port = 44399;
    const url_NguoiQuanLyGT = `https://localhost:${port}/api/NguoiQuanLyGT`;

$(document).ready( async function(){
  var nguoiquanly ;
  console.log('get adta');
  await axios.get(url_NguoiQuanLyGT).then(function(res){
    nguoiquanly = RestoreJsonNetReferences(res.data)[0];
    console.log('nguoiquanly :>> ', nguoiquanly);
  });

  $('#login-btn').on('click',function(){
    const username = $('#username')[0].value;
    const password = $('#password')[0].value;
    
    if(username===nguoiquanly.Username && password===nguoiquanly.Password){
      confirm("Đăng nhập thành công!123");
      window.location.replace(`/site/home.html`);
    }
    else{
      alert('Tài khoản hoặc mật khẩu không đúng!');
    }
  })

  
});