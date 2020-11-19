"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("messageInput").disabled = true;
var sala = document.getElementById("salaID").value;

connection
    .on("sala", function (user, message) {

        if (message !== '') {
            var mensagem = message
                .replace(/&/g, "&amp;")
                .replace(/</g, "&lt;")
                .replace(/>/g, "&gt;");

            var useraa = document.getElementById("userInput").value;

            var encodedMsg = user + ": " + mensagem

            var messageHTML = document.createElement("div");
            if (useraa === user) {
                messageHTML.className = "mensagem__content mensagem__content--others"
            } else {
                messageHTML.className = "mensagem__content mensagem__content--sender"
            }


            var li = document.createElement("li");
            li.textContent = encodedMsg;
            messageHTML.textContent = encodedMsg
            document.getElementById("mensagens").appendChild(messageHTML);
        }
    });

connection
    .start()
    .then(function () {
        document.getElementById("messageInput").disabled = false;
    })
    .catch(function (err) {
        return console.error(err.toString());
    });

document
    .getElementById("messageInput")
    .addEventListener("keyup", function (event) {
        if (event.keyCode === 13) {

            var user = document.getElementById("userInput").value;
            var message = document.getElementById("messageInput").value;
            var sala = document.getElementById("salaID").value;
  
            connection
                .invoke("SendMessage", sala, user, message)
                .catch(function (err) {
                    return console.error(err.toString());
                });

            document.getElementById("messageInput").value = ""

            event.preventDefault();
        }
    });

