 - Abrir o arquivo ModeloMaisTransporte.mwb que está dentro da pasta AnaliseProjeto.
 - Dentro do MySql Workbench clique em: Database -> Synchronize model -> Prosseguir até o final.
 - Abrir o arquivo MaisTransporte.sln que está dentro da pasta Codigo.
 - Dentro do Visual Studio clique em: Tools -> NuGet Package Manager -> Package Manager Console.
 - No terminal, digite os comandos abaixo:
 
Instalação dos pacotes:
 ```CMD
dotnet restore
 ```
Instalação do dotnet tool (Basta executar esse comando uma vez por máquina):
 ```CMD
dotnet tool install --global dotnet-ef 
 ```
Atualização das entidades do código (Execute esse comando a cada atualização na modelagem do banco):
 ```CMD
dotnet ef dbcontext scaffold "server=localhost;port=3306;user=root;password=123456;database=ModeloMaisTransporte" MySql.EntityFrameworkCore -p Core -c MaisTransporteContext -f -v
 ```
Altere o comando acima de acordo com as configurações da sua instância do mysql.