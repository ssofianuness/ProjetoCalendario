//Arrays que vão guardar as categorias e eventos carregados da API.
let categories = [];
let events = [];

/* ---------------------------------------------------
   CARREGAR CATEGORIAS
   --------------------------------------------------- */

/**
 * Carrega as categorias da API e renderiza na interface.
 * Depois de carregar as categorias, chama a função que as desenha no ecrã.
 */
async function loadCategories() {
    const res = await fetch("/api/categories"); //Faz uma requisição para a API para obter as categorias.
    categories = await res.json();              //Converte a resposta em JSON e armazena na variável categories.

    renderCategories();                         //Atualiza a interface.
}

/**
 * Adiciona uma nova categoria enviando um POST para a API.
 */
async function addCategory() {
    const name = document.getElementById("catName").value;  //Lê o nome da categoria.

    await fetch("/api/categories", {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify({ name })  //Envia apenas o nome.
    });

    loadCategories();   //Recarrega a lista após adicionar.
}

/**
 * Atualiza a lista de categorias no HTML (lista + dropdown)
 */
function renderCategories() {
    const list = document.getElementById("categoryList");   //Elemento UL para a lista de categorias.
    const select = document.getElementById("category");     //Elemento SELECT para o dropdown de categorias.

    list.innerHTML = "";    //Limpa lista
    select.innerHTML = "";  //Limpa dropdown

    //Adiciona cada categoria à lista e ao dropdown.
    categories.forEach(c => {
        list.innerHTML += `<li>${c.name}</li>`;
        select.innerHTML += `<option>${c.name}</option>`;
    });
}

/* ---------------------------------------------------
   CARREGAR EVENTOS
   --------------------------------------------------- */

/**
 * Carrega os eventos da API e renderiza na interface.
 */
async function loadEvents() {
    const res = await fetch("/api/events"); //Faz uma requisição para a API para obter os eventos.
    events = await res.json();              //Converte a resposta em JSON e armazena na variável events.

    renderEvents();                         //Atualiza a interface.
}

/**
 * Desenha a tabela de eventos no HTML.
 */
function renderEvents() {
    const table = document.getElementById("eventTable");
    table.innerHTML = "";   //Limpa a tabela

    //Cria uma linha por evento.
    events.forEach(e => {
        table.innerHTML += `
            <tr>
                <td>${e.title}</td>
                <td>${e.start}</td>
                <td>${e.end}</td>
                <td>${e.category}</td>
                <td>${e.priority}</td>
                <td>
                    <button onclick="deleteEvent(${e.id})">Apaga</button>
                </td>
            </tr>
        `;
    });
}

/* ---------------------------------------------------
   ADICIONAR EVENTO
   --------------------------------------------------- */

/**
 * Lê os valores do formulário e envia um POST para a API para adicionar um novo evento.
 */
async function addEvent() {
    const ev = {
        title: title.value,
        description: desc.value,
        start: start.value,
        end: end.value,
        category: category.value,
        priority: priority.value
    };

    await fetch("/api/events", {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(ev)    //Envia o evento completo.
    });

    loadEvents();   //Atualiza a tabela.
}

/* ---------------------------------------------------
   ELIMINAR EVENTO
   --------------------------------------------------- */

/**
 * Elimina um evento pelo ID enviando um pedido de DELETE.
 */
async function deleteEvent(id) {
    await fetch(`/api/events/${id}`, { method: "DELETE" });
    loadEvents();   //Atualiza tabela após eliminar.
}

/* ---------------------------------------------------
   INICIALIZAÇÃO
   --------------------------------------------------- */

//Carrega categorias e eventos ao iniciar a página.
loadCategories();
loadEvents();
