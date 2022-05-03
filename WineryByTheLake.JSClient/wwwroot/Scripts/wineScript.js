let wines = [];
let connection = null;
getdata();
setupSignalR();

let wineIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:44340/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("WineCreated", (user, message) => {
        getdata();
    });

    connection.on("WineDeleted", (user, message) => {
        getdata();
    });

    connection.on("WineUpdated", (user, message) => {
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
    await fetch('http://localhost:44340/wine')
        .then(x => x.json())
        .then(y => {
            wines = y;
            //console.log(wines);
            display();
        });
}

function display() {
    document.getElementById('table').innerHTML = "";
    wines.forEach(t => {
        document.getElementById('table').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>"
            + t.price + "</td><td>"
            + t.sweetness + "</td><td>"
            + t.color + "</td><td>"
            + t.supplierID + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:44340/wine/' + id, {
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
    document.getElementById('winenametoupdate').value = wines.find(t => t['id'] == id)['name'];
    document.getElementById('winepricetoupdate').value = wines.find(t => t['id'] == id)['price'];
    document.getElementById('sweetnesstoupdate').value = wines.find(t => t['id'] == id)['sweetness'];
    document.getElementById('colortoupdate').value = wines.find(t => t['id'] == id)['color'];
    document.getElementById('supplieridtoupdate').value = wines.find(t => t['id'] == id)['supplierID'];
    document.getElementById("update").style.display = 'flex';
    wineIdToUpdate = id;
}

function update() {
    document.getElementById("update").style.display = 'none';
    let updateName = document.getElementById('winenametoupdate').value;
    let updatePrice = parseInt(document.getElementById('winepricetoupdate').value);
    let updateSweetness = document.getElementById('sweetnesstoupdate').value;
    let updateColor = parseInt(document.getElementById('colortoupdate').value);
    let updateSupplierid = parseInt(document.getElementById('supplieridtoupdate').value);
    fetch('http://localhost:44340/wine', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: updateName, Color: updateColor, Sweetness: updateSweetness, Price: updatePrice, SupplierID: updateSupplierid, Id: wineIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let newName = document.getElementById('winename').value;
    let newPrice = parseInt(document.getElementById('wineprice').value);
    let newSweetness = document.getElementById('sweetness').value;
    let newColor = parseInt(document.getElementById('color').value);
    let newSupplierid = parseInt(document.getElementById('supplierid').value);
    fetch('http://localhost:44340/wine', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: newName, Color: newColor, Sweetness: newSweetness, Price: newPrice, SupplierID: newSupplierid })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}