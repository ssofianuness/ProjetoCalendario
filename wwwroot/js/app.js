let categories = [];
let events = [];

async function loadCategories() {
    const res = await fetch("/api/categories");
    categories = await res.json();

    renderCategories();
}

async function addCategory() {
    const name = document.getElementById("catName").value;

    await fetch("/api/categories", {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify({ name })
    });

    loadCategories();
}

function renderCategories() {
    const list = document.getElementById("categoryList");
    const select = document.getElementById("category");

    list.innerHTML = "";
    select.innerHTML = "";

    categories.forEach(c => {
        list.innerHTML += `<li>${c.name}</li>`;
        select.innerHTML += `<option>${c.name}</option>`;
    });
}

async function loadEvents() {
    const res = await fetch("/api/events");
    events = await res.json();

    renderEvents();
}

function renderEvents() {
    const table = document.getElementById("eventTable");
    table.innerHTML = "";

    events.forEach(e => {
        table.innerHTML += `
            <tr>
                <td>${e.title}</td>
                <td>${e.start}</td>
                <td>${e.end}</td>
                <td>${e.category}</td>
                <td>${e.priority}</td>
                <td>
                    <button onclick="deleteEvent(${e.id})">❌</button>
                </td>
            </tr>
        `;
    });
}

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
        body: JSON.stringify(ev)
    });

    loadEvents();
}

async function deleteEvent(id) {
    await fetch(`/api/events/${id}`, { method: "DELETE" });
    loadEvents();
}

loadCategories();
loadEvents();
