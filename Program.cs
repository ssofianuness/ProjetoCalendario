//Cria o construtor da aplicação web.
//Este objeto configura o servidor, rotas, serviços, etc.
var builder = WebApplication.CreateBuilder(args);

//Regista o serviço de controladores na aplicação.
//Isto permite usar controladores API (por exemplo: UsersController, EventsController).
builder.Services.AddControllers();
//Regista o sistema de documentação automática de endpoints.
//Não é obrigatório.
builder.Services.AddEndpointsApiExplorer();  // opcional

//Constrói a aplicação com as configurações definidas.
var app = builder.Build();

//Permite servir ficheiros estáticos a partir da pasta wwwroot.
//Isto inclui: HTML, CSS, JavaScript, imagens, etc.
app.UseStaticFiles(); 

//Mapeia oautomaticamente todos os controladores API.
//Exemplo: UsersController, EventsController, etc.
app.MapControllers();

//Inicia a aplicação e começa a ouvir pedidos HTTP.
app.Run();

