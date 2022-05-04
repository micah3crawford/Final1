"use strict";
(function _playerTeamRemove() {
    const formRemove =
        document.querySelector("#formRemove");
    formRemove.addEventListener('submit', e => {
        e.preventDefault();
        const url = "/api/playerteamapi/remove";
        const method = "delete";
        const formData = new FormData(formRemove);
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
                console.log("Success: the player rank record was removed");
                window.location.replace(`/player/details/${Number}`); // redirect
            })
            .catch(error => {
                console.error('Error:', error);
            });
    });

})();