"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
$("#chatButton").prop("disabled", true);

let StartConnection = (userName) => {
    connection.start().then(() => {
        connection.invoke("SaveUserName", userName).catch((err) => {
            return console.error(err.toString());
        });
        $("#chatButton").prop("disabled", false);
    }).catch((err) => {
        return console.error(err.toString());
    });
}

