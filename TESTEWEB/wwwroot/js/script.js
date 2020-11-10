var i = 0;
var j = 0;
var pagina = 6;
$(document).ready(function () {
    readFilme();
    readDiretor();
    document.getElementById("btnpaginaanterior").disabled = true;
});

$("#btnNew").click(function () {
    openModalCreate(true);

});
$("#btnproximapagina").click(function (){
    proxPagina();

});
$("#btnpaginaanterior").click(function () {
    paginaAnt();

});

$("#btnAtt1").click(function () {
    var id = "lblID0";
    var numeroFilme = document.getElementById(id).innerHTML;
    $('#modalAttFilme').modal('show');

    buscarInfoFilme(numeroFilme);
    
});
function buscarInfoFilme(id) {
    var url = "http://localhost:5000/CatalogoFilmesAPI/filme/" + id;

    $.ajax({
        url: url,
        type: "GET",
        data: {},
        dataType: "JSON",
        success: function (data) {
            openModalAtt(data,true);
        },

        error: function (error) {
            console.log(error);
        }
    });
}

function openModalAtt(data, reset) {
    
        var filme = "txtTitle1";
        var genero = "txtGenre1";
        var duracao = "txtDuracao1";
        var dataLancamento = "txtReleaseDate1";
        var idioma = "txtLanguage1";
        var diretor = "txtDirector1";
        var descricao = "textDescription1";
        var ID = "txtId1";

        document.getElementById(filme).value = data.titulo;
        document.getElementById(genero).value = data.genero.nome;
        document.getElementById(duracao).value = data.duracao;
        document.getElementById(dataLancamento).value = data.dataLancamento;
        document.getElementById(idioma).value = data.idiomaOriginal;
        document.getElementById(diretor).value = data.diretor.nome;
        document.getElementById(descricao).value = data.descricao;
        document.getElementById(ID).value = data.id;
}
function settarvalor(data) {


   

}
function openModalCreate(reset = true) {
    $('#modalNewFilm').modal('show');

    if (reset) {
        resetForm();
    }
}


$("#frmFilme").submit(function (e) {
    sendForm();



    e.preventDefault();
});


$("#frmFilmeAtt").submit(function (e) {
    sendFormAtt();
    e.preventDefault();
});

function openModalViewFilm(id) {
    $('#modalViewFilm').modal('show');

}


//SEND
function sendForm() {
    console.log(obj);
    create();

}
function sendFormAtt() {
    var obj = {
        id: $("#txtId1").val(),
        titulo: $("#txtTitle1").val(),
        descricao: $("#textDescription1").val(),
        idiomaOriginal: $("#txtLanguage1").val(),
        dataLancamento: $("#txtReleaseDate1").val(),
        duracao: parseInt($("#txtDuracao1").val()),
        genero: { nome: $("#txtGenre1").val() },
        diretor: { nome: $("#txtDirector1").val() },

    };


    att();


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
    var m = 0;
    if (data.length < 1) {
        alert("Não há nenhum filme no catálogo");
    } else {
        while (i < pagina) {
            if (data.length < i) {
                var moldura = "#moldura" + m;

                document.getElementById(moldura).style.display = "block";
            } else {

                var filme = "nomeFilme" + m;
                var genero = "genero" + m;
                var duracao = "duracao" + m;
                var dataLancamento = "data" + m;
                var idioma = "idioma" + m;
                var diretor = "diretor" + m;
                var descricao = "descricao" + m;
                var ID = "lblID" + m;
                document.getElementById(filme).innerHTML = data[i].titulo;
                document.getElementById(genero).innerHTML = data[i].genero.nome;
                document.getElementById(duracao).innerHTML = data[i].duracao;
                document.getElementById(dataLancamento).innerHTML = data[i].dataLancamento;
                document.getElementById(idioma).innerHTML = data[i].idiomaOriginal;
                document.getElementById(diretor).innerHTML = data[i].diretor.nome;
                document.getElementById(descricao).innerHTML = data[i].descricao;
                document.getElementById(ID).innerHTML = data[i].id;
            }
            i++;
            m++;
        }
    }
}
function attDiretor(diretor) {
    var m = 0;
    if (diretor.length < 1) {
        alert("Não há nenhum diretor Cadastrado");
    } else {
        while (diretor.length > j) {
            var nomediretor = "nomeDiretor" + m;
            var dataNasc = "dataNasc" + m;
            var bio = "bio" + m;
            var id = "idDiretor" + m;
            document.getElementById(nomediretor).innerHTML = diretor[j].nome;
            if (diretor[j].dataNasc == null) {
                document.getElementById(dataNasc).innerHTML = "Não informado.";
            } else {
                document.getElementById(dataNasc).innerHTML = diretor[j].dataNasc;
            }

            if (diretor[j].bio == null) {
                document.getElementById(bio).innerHTML = "Não informado.";
            } else {
                var str = diretor[j].bio;
                var res = str.substring(0, 350);
                document.getElementById(bio).innerHTML = res;
            }
            document.getElementById(id).innerHTML = diretor[j].id;
            j++;
            m++;
        }
    }
}

function limitMe(e) {
    if (e.keyCode == 8) { return true; }
    return this.value.length < $(this).attr("maxLength");
}
//AJAX
function create() {

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
                alert("Adicionado com Sucesso.");
                resetForm();
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
};  

function att() {

    data = {
        id: $("#txtId1").val(),
        titulo: $("#txtTitle1").val(),
        descricao: $("#textDescription1").val(),
        idiomaOriginal: $("#txtLanguage1").val(),
        dataLancamento: $("#txtReleaseDate1").val(),
        duracao: parseInt($("#txtDuracao1").val()),
        genero: $("#txtGenre1").val() ,
        diretor: $("#txtDirector1").val() 
    }
    $.ajax({
        type: "PUT",
        url: "/Home/AjaxPutCall",
        data: data,
        cache: false,
        success: function (response) {
            alert("Atualizado com sucesso.");
            resetForm();
            location.reload();
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
};  

function proxPagina(data) {
    $.ajax({
        url: "http://localhost:5000/CatalogoFilmesAPI/filme",
        type: "GET",
        data: {},
        dataType: "JSON",
        success: function (data) {

            atualizarProxPag(data);
        },

        error: function (error) {
            console.log(error);
        }
    });

 

}

function paginaAnt(data) {
    $.ajax({
        url: "http://localhost:5000/CatalogoFilmesAPI/filme",
        type: "GET",
        data: {},
        dataType: "JSON",
        success: function (data) {

            voltarPag(data);
        },

        error: function (error) {
            console.log(error);
        }
    });



}
function atualizarProxPag(data) {
    pagina = pagina + 6;

    document.getElementById("btnpaginaanterior").disabled = false;
    var m = 0;
    if (data.length < 1) {
        alert("Não há nenhum filme no catálogo");
    } else {
        while (i < pagina) {
            if (data.length <= i) {
                var moldura = "#moldura" + m;
                $(moldura).hide();
                document.getElementById("btnproximapagina").disabled = true;
            } else {
                var filme = "nomeFilme" + m;
                var genero = "genero" + m;
                var duracao = "duracao" + m;
                var dataLancamento = "data" + m;
                var idioma = "idioma" + m;
                var diretor = "diretor" + m;
                var descricao = "descricao" + m;
                var ID = "lblID" + m;
                document.getElementById(filme).innerHTML = data[i].titulo;
                document.getElementById(genero).innerHTML = data[i].genero.nome;
                document.getElementById(duracao).innerHTML = data[i].duracao;
                document.getElementById(dataLancamento).innerHTML = data[i].dataLancamento;
                document.getElementById(idioma).innerHTML = data[i].idiomaOriginal;
                document.getElementById(diretor).innerHTML = data[i].diretor.nome;
                document.getElementById(descricao).innerHTML = data[i].descricao;
                document.getElementById(ID).innerHTML = data[i].id;
            }
            i++;
            m++;
        }
    }
}


function voltarPag(data) {
    pagina = pagina - 6;
    i = i - 12;
    if (pagina == 6) {

        document.getElementById("btnpaginaanterior").disabled = true;
    }

    document.getElementById("btnproximapagina").disabled = false;
    var m = 0;
    if (data.length < 1) {
        alert("Não há nenhum filme no catálogo");
    } else {
        while (i < pagina) {
            if (data.length <= i) {
                var moldura = "#moldura" + m;
                $(moldura).hide();
                document.getElementById("btnproximapagina").disabled = true;
            } else {

                var moldura = "#moldura" + m;
                $(moldura).show();
                var filme = "nomeFilme" + m;
                var genero = "genero" + m;
                var duracao = "duracao" + m;
                var dataLancamento = "data" + m;
                var idioma = "idioma" + m;
                var diretor = "diretor" + m;
                var descricao = "descricao" + m;
                var ID = "lblID" + m;
                document.getElementById(filme).innerHTML = data[i].titulo;
                document.getElementById(genero).innerHTML = data[i].genero.nome;
                document.getElementById(duracao).innerHTML = data[i].duracao;
                document.getElementById(dataLancamento).innerHTML = data[i].dataLancamento;
                document.getElementById(idioma).innerHTML = data[i].idiomaOriginal;
                document.getElementById(diretor).innerHTML = data[i].diretor.nome;
                document.getElementById(descricao).innerHTML = data[i].descricao;
                document.getElementById(ID).innerHTML = data[i].id;
            }
            i++;
            m++;
        }
    }
}
function readFilme() {
    $.ajax({
        url: "http://localhost:5000/CatalogoFilmesAPI/filme",
        type: "GET",
        data: {},
        dataType: "JSON",
        success: function (data) {
            createTable(data);
        },

        error: function (error) {
            console.log(error);
        }
    });
}


function readDiretor() {
    $.ajax({
        url: "http://localhost:5000/CatalogoFilmesAPI/diretor/",
        type: "GET",
        data: {},
        dataType: "JSON",
        success: function (diretor) {
            attDiretor(diretor);
        },

        error: function (error) {
            console.log(error);
        }
    });
}


