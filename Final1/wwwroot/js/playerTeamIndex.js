"use strict";
(function _playerTeamIndex() {
    const url = "/api/playerteamapi/playerrankreport";
    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error('There was a network error!');
            }
            return response.json();
        })
        .then(result => {
            populateTable(result);
        })
        .catch(error => {
            console.error('Error:', error);
        });
})();

function populateTable(result) {
    const tableBody = document.getElementById("tableBody");
    result.forEach((item) => {
        const tr = document.createElement("tr");
        for (let key in item) {
            const td = document.createElement("td");
            let text = item[key];
            if (text === '' && key === 'playerRank') {
                text = "No rank";
            }
            let textNode = document.createTextNode(text);
            td.appendChild(textNode);
            tr.appendChild(td);
        }
        tableBody.appendChild(tr);
    });
}