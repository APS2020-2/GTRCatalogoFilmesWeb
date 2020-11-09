Class Filme{
  private $id;
  private $titulo;
  private $poster;
  private $descricao;
  private $idiomaOriginal;
  private $dataLancamento;
  private $ano;
  private $duracao;
  private $generoId;
  private $diretorId;

  public function __construct ($id = '',$titulo = '',$poster = '',$descricao = '',$idiomaOriginal = '',$dataLancamento = '',$ano = '',
  $duracao = '',$generoId = '',$diretorId = ''){
    $this->id = $id;
    $this->titulo = $titulo;
    $this->poster = $poster;
    $this->descricao = $descricao;
    $this->idiomaOriginal = $idiomaOriginal;
    $this->dataLancamento = $dataLancamento;
    $this->ano = $ano;
    $this->duracao = $duracao;
    $this->generoId = $generoId;
    $this->diretorId = $diretorId;
  }
//setters

  public function setId($id){
    $this->id = $id;
  }

  public function setTitulo($titulo){
    $this->titulo = $titulo;
  }
  public function setPoster($poster){
    $this->poster = $poster;
  }
  public function setDescricao($descricao){
    $this->descricao = $descricao;
  }
  public function setIdiomaOriginal($idiomaOriginal){
    $this->idiomaOriginal = $idiomaOriginal;
  }
  public function setDataLancamento($dataLancamento){
    $this->dataLancamento = $dataLancamento;
  }
  public function setAno($ano){
    $this->ano = $ano;
  }
  public function setDuracao($duracao){
    $this->duracao = $duracao;
  }
  public function setGeneroId($generoId){
    $this->generoId = $generoId;
  }
  public function setDiretorId($diretorId){
    $this->diretorId = $diretorId;
  }

  //Getters

  public function getId(){
    return $this->id;
  }

  public function getTitulo(){
    return $this->titulo;
  }
  public function getPoster($poster){
    return $this->$poster;
  }
  public function getDescricao(){
    return $this->descricao;
  }
  public function getIdiomaOriginal(){
    return $this->idiomaOriginal;
  }
  public function getDataLancamento(){
    return $this->dataLancamento;
  }
  public function getAno(){
    return $this->ano;
  }
  public function getDuracao(){
    return $this->duracao;
  }
  public function getGeneroId(){
    return $this->generoId);
  }
  public function getDiretorId(){
    return $this->diretorId;
  }

}
