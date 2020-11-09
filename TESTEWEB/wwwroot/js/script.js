//"use strict"
$(document).ready(function () {
    console.clear();
    readAll();
});

$("#btnNew").click(function () {
    openModalCreate(true);

});

$("#frmFilme").submit(function (e) {
    sendForm();


    e.preventDefault();
});
function openModalCreate(reset = true) {
    $('#modalNewFilm').modal('show');

    if (reset) {
        resetForm();
    }
}

function openModalViewFilm(id) {
    $('#modalViewFilm').modal('show');

}

function deleteFilm(id) {
    if (!confirm("Deseja realmente remover?"))
        return;

}



//SEND
function sendForm() {
    var obj = {

        titulo: $("#txtTitle").val(),
        descricao: $("#textDescription").val(),
        idiomaOriginal: $("#txtLanguage").val(),
        dataLancamento: $("#txtReleaseDate").val(),
        duracao: parseInt($("#txtDuracao").val()),
        genero: { nome: $("#txtGenre").val() },
        diretor: { nome: $("#txtDirector").val() },
        poster: $("#txtPoster").val(),
    };

    console.log(obj);

    create();


}
function resetForm() {

    $("#txtId").val("0");
    $("#txtTitle").val("");
    $("#txtLanguage").val("");
    $("#txtReleaseDate").val("");
    $("#txtYear").val("");
    $("#txtGenre").val("");
    $("#txtDirector").val("");
    $("#txtPoster").val("");
    $("#textDescription").val("");
    $("#txtDuracao").val("");



}

function createTable(data) {
    if (data.length < 1)
        return;

    document.getElementById("#section").innerHTML = col;
    for (var i = 0; i < data.length; i++) {
        var col = "<div class='col-md-3 mt-3'>" +
            "<div class='card-header-primary'>" +
            "<div class='card-header'>" + data[i].titulo + "</div>" +

            "<div class='card-body'>" +
            "<div >" +
            "<img scr = '" + data[i].poster + "'/>" +
            "</div>" +
            "  </div>" +

            "  <div class='card-footer'>" +
            "<div class='row'>" +
            "<div class='col-md-4'>" +
            "<button type='button' name='button' class='mb-2 w-100 btn btn-outline-warning'>Edit</button>" +
            "</div>" +

            "<div class='col-md-4'>" +
            "<button type='button' name='button' class='mb-2 w-100 btn btn-outline-success' onclick='openModalViewFilm(21)'>View</button>" +
            "  </div>" +

            "  <div class='col-md-4'>" +
            "  <button type='button' name='button' class='mb-2 w-100 btn btn-outline-danger' onClick='deleteFilm(78)'>Del</button>" +
            "  </div>" +
            "</div>" +
            "</div>" +

            "</div>" +
            "</div>" 

    }
}





//AJAX
function create() {

    //var employeeData = new Object();
    //employeeData.titulo = $("#txtTitle").val(),
    //    employeeData.descricao = $("#textDescription").val(),
    //    employeeData.idiomaOriginal = $("#txtLanguage").val(),
    //    employeeData.dataLancamento = $("#txtReleaseDate").val(),
    //    employeeData.duracao = parseInt($("#txtDuracao").val()),
    //    employeeData.genero = $("#txtGenre").val(),
    //    employeeData.diretor = $("#txtDirector").val()

    data = {
        titulo: $("#txtTitle").val(),
        descricao: $("#textDescription").val(),
        idiomaOriginal: $("#txtLanguage").val(),
        dataLancamento: $("#txtReleaseDate").val(),
        duracao: $("#txtDuracao").val(),
        genero: $("#txtGenre").val(),
        diretor: $("#txtDirector").val()
    }
        $.ajax({
            type: "POST",
            url: "/Home/AjaxPostCall",
            data: data,
            cache: false,
            success: function (response) {
                alert("Sucesso");
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
};  
function readAll() {
    $.ajax({
        url: "http://localhost:5000/CatalogoFilmesAPI/filme",
        type: "GET",
        data: {},
        dataType: "JSON",
        success: function (data) {
            console.log(data);
            console.table(data);
            createTable(data);
        },

        error: function (error) {
            console.log(error);
        }


    });
}
