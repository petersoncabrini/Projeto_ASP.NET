

//Retorna à página anterior
$("#Btn_Voltar").click(function () {
    window.history.back();
});

//Exibe alerta ao cadastrar
function exibirAlert() {
    alert('Cadastro realizado com sucesso!')
}

//Apaga os inputs fo formulário com id = form
function resetForm() {
    $(':input', '#form')
        .not(':button, :submit, :reset, :hidden')
        .val('')
}

//Remove registro da tabela
$(".table").on("click", "#btnExcluir", function (id) {
    var tr = $(this).closest('tr');
    tr.fadeOut(200, function () {
        tr.remove();
    });
    return false;
});

function excluir(id) {
    //Chamada do Ajax para trazer os detalhes da ordem
    $.ajax({
        url: controller + '/Excluir/' + id, //selecionando o endereço que iremos acessar no backend
        type: 'POST', //selecionando o tipo de requesição, PUT,GET,POST,DELETE
        success: function () {

        },
        error: function (err) {
            //Em caso de erro
            console.log(err);
        }
    });
}