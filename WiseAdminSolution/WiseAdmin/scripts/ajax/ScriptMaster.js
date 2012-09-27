function logar(usuario,senha) {
    $.ajax({
        type: "POST",
        url: "Default.aspx/logar", // url da pagina/nome do metodo 
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: "{ usuario:'"+usuario+"',psw:'"+senha+"'}", //parametros da função 

        success: function (json) {
            alert(json.d);

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.responseText);
        }
    });
}
function validaLogon() {
    var usuario = $('#ContentPlaceHolder1_txtLogin').val();
    usuario = usuario + "";
    var senha = $('#ContentPlaceHolder1_txtSenha').val();
    senha = senha + "";
    if (usuario == "" || senha == "") { 
        AbreModal_Valor("#dialog-message","Preencher usuário e senha para efetuar logon!!");
        return false;
    }
    else{
        return true;
       
    }


}
function AbreModal(id) {

    $(id).dialog("open");
    return false;
}

function AbreModal_Valor(id,valor) {

    document.getElementById('textoMsg').innerHTML = valor;
    
    $(id).dialog("open");

    return false;
}