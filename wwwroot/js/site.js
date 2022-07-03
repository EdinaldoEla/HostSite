// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.()

function Cadastrar()
{
    let parametros = {
        Nome: $("#nome").val(),
        Email: $("#email").val(),
        Mensagem: $("#mensagem").val(),
    }
    $.post("/Home/Cadastrar", parametros)

    .done(
        //Tratamento
        function(retorno)
        {
            if(retorno.status=="OK"){
                $("#areaContato").after("<h3>Cadastro realizado com suceso !</h3>");
                $("#areaContato").hide();
            }else{
                $("#areaContato").after("<h3>"+retorno.mensagem+"</h3>");
            }
            
        }



    )

    .fail(
        function(){
            alert("Ocorreu um erro!");
        }
    )
}

$(document).ready(function(){

    $("#frmCadastro").submit(
        function(e){
            e.preventDefault();
            Cadastrar();
        }
    );

});
