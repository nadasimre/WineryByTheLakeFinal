let reds = [];
let whites = [];
let roses = [];
getdata();

async function getdata() {
    await fetch('http://localhost:44340/product/red')
        .then(x => x.json())
        .then(y => {
            reds = y;
            console.log(reds);
            display();
        });
    await fetch('http://localhost:44340/product/white')
        .then(x => x.json())
        .then(y => {
            whites = y;
            console.log(whites);
            display();
        });
    await fetch('http://localhost:44340/product/rose')
        .then(x => x.json())
        .then(y => {
            roses = y;
            console.log(roses);
            display();
        });
}

function display() {
    document.getElementById('white').innerHTML = "";
    whites.forEach(t => {
        document.getElementById('white').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>"
            + t.price + "</td><td>"
            + t.sweetness + "</td><td>"
            + t.color + "</td><td>"
            + t.supplierID + "</td></tr>";
    });

    document.getElementById('red').innerHTML = "";
    reds.forEach(t => {
        document.getElementById('red').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>"
            + t.price + "</td><td>"
            + t.sweetness + "</td><td>"
            + t.color + "</td><td>"
            + t.supplierID + "</td></tr>";
    });

    document.getElementById('rose').innerHTML = "";
    roses.forEach(t => {
        document.getElementById('rose').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>"
            + t.price + "</td><td>"
            + t.sweetness + "</td><td>"
            + t.color + "</td><td>"
            + t.supplierID + "</td></tr>";
    });
}