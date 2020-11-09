Class Genero{
    private $id;
    private $nome;
    private $bio;
    private $dataDeNascimento;

    public function __construct($id = '',$nome = '',$bio = '',$dataDeNascimento = ''){
      $this->id = $id;
      $this->nome = $nome;
      $this->bio = $bio;
      $this->dataDeNascimento = $dataDeNascimento;
    }

    public function setId($id){
      $this->id = $id;
    }
    public function setNome($nome){
      $this->nome = $nome;
    }
    public function setBio($bio){
      $this->bio = $bio;
    }
    public function setDataDeNascimento($dataDeNascimento){
      $this->dataDeNascimento = $dataDeNascimento;
    }

    public function getId(){
      return $this->id;
    }

    public function getNome(){
      return $this->nome;
    }
    public function getBio(){
      return $this->bio;
    }
    public function getDataDeNascimento(){
      return $this->dataDeNascimento;
    }
}
