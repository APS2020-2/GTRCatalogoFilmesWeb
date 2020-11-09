using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogoFilmesAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diretores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    DataNasc = table.Column<string>(nullable: true),
                    Imagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    IdiomaOriginal = table.Column<string>(nullable: true),
                    DataLancamento = table.Column<string>(nullable: true),
                    Duracao = table.Column<int>(nullable: false),
                    GeneroId = table.Column<int>(nullable: false),
                    DiretorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmes_Diretores_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filmes_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Diretores",
                columns: new[] { "Id", "Bio", "DataNasc", "Imagem", "Nome" },
                values: new object[] { 1, "David Fincher nasceu em 1962 em Denver, Colorado, e foi criado no condado de Marin, Califórnia. Quando tinha 18 anos, foi trabalhar para John Korty na Korty Films em Mill Valley. Posteriormente, trabalhou na ILM (Industrial Light and Magic) de 1981-1983. Fincher deixou a ILM para dirigir comerciais de TV e videoclipes após assinar com N. Lee Lacy em Hollywood. Ele fundou a Propaganda em 1987 com seus colegas diretores Dominic Sena , Greg Gold e Nigel Dick . Fincher dirigiu comerciais de TV para clientes que incluem Nike, Coca-Cola, Budweiser, Heineken, Pepsi, Levi's, Converse, AT&T e Chanel. Ele dirigiu videoclipes para Madonna , Sting ,The Rolling Stones , Michael Jackson , Aerosmith , George Michael , Iggy Pop , The Wallflowers , Billy Idol , Steve Winwood , The Motels e, mais recentemente, A Perfect Circle .", "28/08/1962", "", "David Fincher" });

            migrationBuilder.InsertData(
                table: "Diretores",
                columns: new[] { "Id", "Bio", "DataNasc", "Imagem", "Nome" },
                values: new object[] { 2, "Taika Waititi, também conhecido como Taika Cohen, é natural da região de Raukokore, na costa leste da Nova Zelândia, e é filho de Robin (Cohen), um professor, e de Taika Waiti, um artista e fazendeiro. Seu pai é Maori (Te-Whanau-a-Apanui), e sua mãe é de ascendência judia Ashkenazi, irlandesa, escocesa e inglesa. Taika está envolvido na indústria do cinema há vários anos, inicialmente como ator, e agora se concentra em escrever e dirigir. Two Cars, One Night é o primeiro esforço cinematográfico profissional de Taika e, desde sua conclusão em 2003, ele terminou outro curta Tama Tu sobre um grupo de soldados Maori na Itália durante a 2ª Guerra Mundial. Como artista e comediante, Taika tem sido envolvido em algumas das produções originais mais inovadoras e bem-sucedidas vistas na Nova Zelândia. Ele regularmente faz shows de stand-up em todo o país e em 2004 lançou sua produção solo, Taika's Incredible Show. Em 2005, ele encenou a sequência, Taika's Incrediblerer Show. Como ator, Taika foi aclamado pela crítica por suas habilidades cômicas e dramáticas. Em 2000, ele foi indicado para Melhor Ator no Nokia Film Awards por seu papel no filme Scarfies dos irmãos Sarkies.", "16/08/1975", "", "Taika Waititi" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Drama" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Comédia" });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "DataLancamento", "Descricao", "DiretorId", "Duracao", "GeneroId", "IdiomaOriginal", "Poster", "Titulo" },
                values: new object[] { 1, "29/10/1999", "Um trabalhador de escritório e um fabricante de sabonetes que cuidam do diabo formam um clube de luta clandestino que evolui para algo muito maior.", 1, 139, 1, "EN", "", "Clube da Luta" });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "DataLancamento", "Descricao", "DiretorId", "Duracao", "GeneroId", "IdiomaOriginal", "Poster", "Titulo" },
                values: new object[] { 2, "06/02/2019", "Um jovem parte do exército nazi, descobre que sua mãe esconde uma jovem judia na sua casa.", 2, 108, 2, "EN", "", "Jojo Rabbit" });

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_DiretorId",
                table: "Filmes",
                column: "DiretorId");

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_GeneroId",
                table: "Filmes",
                column: "GeneroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Diretores");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
