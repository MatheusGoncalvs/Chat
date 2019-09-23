var connection = new signalR.HubConnectionBuilder()
    .withUrl('/Home/Index')
    .build();

connection.on('receiveMessage', addMessageToChat);

connection.start()
    .catch(err => {
        console.error(err.message);
    });

function sendMessageToHub(message) {
    connection.invoke('sendMessage', message);
}