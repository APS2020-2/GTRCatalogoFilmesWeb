"use strict"

$(document).ready(function(){
    console.clear();
    readAll();

})

$("#btnNew").click(function(){
  openModalCreate(true);

});

$("#frmFilme").submit(function(e){
  sendForm();


  e.preventDefault();
});



function openModalCreate(reset = true){
  $('#modalNewFilm').modal('show');

  if(reset){
    resetForm();
  }

}

function openModalViewFilm(id){
  $('#modalViewFilm').modal('show');

}

function deleteFilm(id){
  if(!confirm("Deseja realmente remover?"))
  return;

}



//SEND
function sendForm(){
  var obj = {

    titulo : $("#txtTitle").val(),
    idiomaOriginal : $("#txtLanguage").val(),
    dataLancamento : $("#txtReleaseDate").val(),
    generoId : parseInt($("#txtGenre").val()),
    diretorId : parseInt($("#txtDirector").val()),
    poster : $("#txtPoster").val(),
    descricao : $("#textDescription").val(),
    duracao : parseInt($("#txtDuracao").val())
  };

  console.log(obj);

  create(obj);


}





function resetForm(){

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

function createTable(data){
  if(data.length <1)
    return;

  var section = document.getElementById("section");
  section.innerHTML = "";

  for(var i = 0; i<data.length;i++){
    var col =   "<div class='col-md-3 mt-3'>"+
      "<div class='card-header-primary'>"+
          "<div class='card-header'>"+data[i].titulo+"</div>"+

          "<div class='card-body'>"+
              "<div >"+
                  "<img = '"+data[i].poster+"'>"+
              "</div>"+
        "  </div>"+

        "  <div class='card-footer'>"+
              "<div class='row'>"+
                "<div class='col-md-4'>"+
                    "<button type='button' name='button' class='mb-2 w-100 btn btn-outline-warning'>Edit</button>"+
                "</div>"+

                "<div class='col-md-4'>"+
                    "<button type='button' name='button' class='mb-2 w-100 btn btn-outline-success' onclick='openModalViewFilm(21)'>View</button>"+
              "  </div>"+

              "  <div class='col-md-4'>"+
                "  <button type='button' name='button' class='mb-2 w-100 btn btn-outline-danger' onClick='deleteFilm(78)'>Del</button>"+
              "  </div>"+
              "</div>"+
          "</div>"+

      "</div>"+
    "</div>"+

    "</div>"

  }
}



//AJAX
function create(obj){
  $.ajax({

    url : "http://localhost/CatalogoFilmesAPI/filme",
    type : "POST",
    data: JSON.stringify(obj),
    dataType:"JSON",
    beforeSend: function(){
      //chama antes de enviar
      $("#btnSubmit").attr("disabled" , true);
    },

    success: function(data){
      //Tudo estiver ok
      console.log(data);
    },

    erro:function(error){
      //Quando houver um erro
      console.log(error);
    },
    complete:function(){
      //Quando finaliza
      $("#btnSubmit").attr("disabled" , false);
    }
  });
  console.log("Enviou");
}



function readAll(){
  $.ajax({
    url: "http://localhost:5000/CatalogoFilmesAPI/filme",
    type: "GET",
    data: {},
    dataType:"JSON",
    success: function(data){
      console.table(data);
      createTable(data);
    },

    error : function(error){
      console.log(error);
    }


  });
}
