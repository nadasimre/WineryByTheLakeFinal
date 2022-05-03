let suppliers = [];
let connection = null;
getdata();
setupSignalR();

supplierIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:44340/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("SupplierCreated", (user, message) => {
        getdata();
    });

    connection.on("SupplierDeleted", (user, message) => {
        getdata();
    });

    connection.on("SupplierUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:44340/supplier')
        .then(x => x.json())
        .then(y => {
            suppliers = y;
            console.log(suppliers);
            display();
        });
}

function display() {
    document.getElementById('table').innerHTML = "";
    suppliers.forEach(t => {
        document.getElementById('table').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:44340/supplier/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdate(id) {
    document.getElementById('suppliertoupdate').value = suppliers.find(t => t['id'] == id)['name'];
    document.getElementById("update").style.display = 'flex';
    supplierIdToUpdate = id;
}

function update() {
    document.getElementById("update").style.display = 'none';
    let updateName = document.getElementById('suppliertoupdate').value;
    fetch('http://localhost:44340/supplier', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: updateName, Id: supplierIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('suppliername').value;
    fetch('http://localhost:44340/supplier', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}