var mymap;

window.initialyzemap = () => {
    mymap = L.map('mapid').setView([19.0, - 70.666664], 7);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors>',
        maxZoom: 18,
    }).addTo(mymap);
}

window.setPopupsOnMap = (title, lat, long, description) => {
    var marker = L.marker([lat, long])
        .bindPopup(`<b>${title}<b><br>${description}`)
        .addTo(mymap);

}

