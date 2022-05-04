"use strict";
(function _playerTeamCreate() {
    const formCreatePlayerTeam =
        document.querySelector("#formCreatePlayerTeam");
    formCreatePlayerTeam.addEventListener('submit', e => {
        e.preventDefault();
        const url = "/api/playerteamapi/create";
        const method = "post";
        const formData = new FormData(formCreatePlayerTeam);
        console.log(`${url} ${method}`);

        fetch(url, {
            method: method,
            body: formData
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('There was a network error!');
                }
                return response.json();
            })
            .then(result => {
                console.log('Success: the player team record was created');
                window.location.replace(`/player/details/${result.playerNumber}`); // redirect
            })
            .catch(error => {
                console.error('Error:', error);
            });
    });

})();