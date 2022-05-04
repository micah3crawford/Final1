"use strict";
(function _playerTeamAssignRank() {
    const formAssignRank =
        document.querySelector("#formAssignrank");
    formAssignRank.addEventListener('submit', e => {
        e.preventDefault();
        const url = "/api/playerteamapi/assignrank";
        const method = "put";
        const formData = new FormData(formAssignRank);
        console.log(`${url} ${method}`);
        const eNumber = formData.get("Number");

        fetch(url, {
            method: method,
            body: formData
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('There was a network error!');
                }
                return response.status;
            })
            .then(result => {
                console.log(result);
                console.log("Success: the player's rank was changed");
                window.location.replace(`/player/details/${Number}`); // redirect
            })
            .catch(error => {
                console.error('Error:', error);
            });
    });

})();
