class Message {
    constructor(username, text, when) {
        this.userName = username;
        this.text = text;
        this.when = when;
    }
}

// userName is declared in razor page.
const username = userName;
const textInput = document.getElementById('messageText');
const whenInput = document.getElementById('when');
const chat = document.getElementById('chat');
const messagesQueue = [];

document.getElementById('submitButton').addEventListener('click', () => {
    var currentdate = new Date();
    when.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
});

function clearInputField() {
    messagesQueue.push(textInput.value);
    textInput.value = "";
}

function sendMessage() {
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;

    let when = new Date();
    let message = new Message(username, text);
    sendMessageToHub(message);
}

function addMessageToChat(message) {

    let msgs_chat = document.createElement('div');
    msgs_chat.className = "msgs-chat";

    let img_perfil = document.createElement('div');
    img_perfil.className = "img-perfil";

    let content_msg = document.createElement('div');
    content_msg.className = "content-msg-chat";

    let content_head = document.createElement('div');
    content_head.className = "head";

    let userMessage = document.createElement('h2');
    userMessage.className = "user";
    userMessage.innerHTML = message.userName;

    let when = document.createElement('h3');
    when.className = "horario";
    var currentdate = new Date();
    when.innerHTML =
        currentdate.getDate() + "/"
        + (currentdate.getMonth() + 1) + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })

    let content_body = document.createElement('div');
    content_body.className = "body";

    let MessageText = document.createElement('h2');
    MessageText.innerHTML = message.text;

    msgs_chat.appendChild(img_perfil);
    msgs_chat.appendChild(content_msg);

    content_msg.appendChild(content_head);

    content_head.appendChild(userMessage);
    content_head.appendChild(when);

    content_msg.appendChild(content_body);
    content_body.appendChild(MessageText);

    chat.appendChild(msgs_chat);
}