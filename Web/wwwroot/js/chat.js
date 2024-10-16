"use strict";

async function startChat() {
    const senderId = window.senderId;
    const sender = window.senderName;
    const receiverId = window.receiverId;
    const receiver = window.receiverName;

    let connection = new signalR.HubConnectionBuilder()
        .withUrl(`/chatHub?senderId=${senderId}&receiverId=${receiverId}`)
        .withAutomaticReconnect([0, 2000, 10000, 30000])
        .build();

    connection.onreconnecting(error => {
        console.warn(`連線中斷，正在重新連接：${error}`);
    });

    connection.onreconnected(connectionId => {
        console.log(`重新連接成功：${connectionId}`);
    });

    connection.on("ReceiveMessage", (user, message) => {
        console.log(`收到來自 ${user} 的訊息：${message}`);
        const li = document.createElement("li");
        li.textContent = `${user} 對您說：${message}`;
        document.getElementById("messagesList").appendChild(li);
    });

    try {
        await connection.start();
        console.log("SignalR 連線成功");
    }
    catch (err) {
        console.error("SignalR 連線失敗：", err.toString());
    }


    document.getElementById("chat").style.display = "block";
    await loadChatHistory(senderId, receiverId);


    async function loadChatHistory(senderId, receiverId) {
        try {
            const response = await fetch(`/api/chat/history?user1=${senderId}&user2=${receiverId}`);
            const messages = await response.json();

            messages.forEach(msg => {
                const li = document.createElement("li");
                li.textContent = `${msg.senderName} 對您說：${msg.content}`;
                document.getElementById("messagesList").appendChild(li);
            });
        } catch (err) {
            console.error("載入歷史訊息失敗：", err.toString());
        }
    }

    document.getElementById("sendButton").addEventListener("click", async (event) => {
        event.preventDefault();

        const message = document.getElementById("messageInput").value;

        console.log("Message:", message);

        if (!receiverId || !message) {
            alert("請輸入目標使用者 ID 和訊息內容！");
            return;
        }

        try {
            await connection.invoke("SendPrivateMessage", receiverId, message);
            document.getElementById("messageInput").value = "";

            // 測試：直接新增訊息到畫面
            const li = document.createElement("li");
            li.textContent = `您：${message}`;
            document.getElementById("messagesList").appendChild(li);
        } catch (err) {
            console.error("發送訊息失敗：", err.toString());

            const errorLi = document.createElement("li");
            errorLi.textContent = "無法發送訊息，請稍後再試。";
            document.getElementById("messagesList").appendChild(errorLi);
        }
    });
}

window.addEventListener("DOMContentLoaded", startChat);