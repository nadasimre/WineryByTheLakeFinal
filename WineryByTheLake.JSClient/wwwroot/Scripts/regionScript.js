let regions = [];
let connection = null;
getdata();
setupSignalR();

let regionIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:44340/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("RegionCreated", (user, message) => {
        getdata();
    });

    connection.on("RegionDeleted", (user, message) => {
        getdata();
    });

    connection.on("RegionUpdated", (user, message) => {
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
    await fetch('http://localhost:44340/region')
        .then(x => x.json())
        .then(y => {
            regions = y;
            console.log(regions);
            display();
        });
}

function display() {
    document.getElementById('table').innerHTML = "";
    regions.forEach(t => {
        document.getElementById('table').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:44340/region/' + id, {
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
    document.getElementById('regiontoupdate').value = regions.find(t => t['id'] == id)['name'];
    document.getElementById("update").style.display = 'flex';
    regionIdToUpdate = id;
}

function update() {
    document.getElementById("update").style.display = 'none';
    let updateName = document.getElementById('regiontoupdate').value;
    fetch('http://localhost:44340/region', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: updateName, Id: regionIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let createName = document.getElementById('regionname').value;
    fetch('http://localhost:44340/region', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: createName })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}