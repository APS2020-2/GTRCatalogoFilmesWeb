<?php
namespace App\Controller;
use App\Entity\Filme;

class FilmeController{
    //POST - Cria um novo filme
    function create($data = null)
    {
      return json_encode(["name" => "create"]);
    }
    //PUT- Altera um filme
    function update($id = 0,$data = null)
    {
      return json_encode(["name" => "update"]);
    }
    //DELETE - Remove um filme
    function delete($id = 0)
    {
      return json_encode(["name" => "delete"]);
    }
    //GET - Retorna um filme pelo o ID
    function readById($id = 0)
    {
      return json_encode(["name" => "readById"]);
    }
    //GET - Retorna todos os filmes
    function readAll()
    {
      return json_encode(["name" => "readAll"]);
    }
}
?>
