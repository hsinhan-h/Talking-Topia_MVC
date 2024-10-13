"use strict";

let connection;

document.getElementById("connectBtn").addEventListener("click", async () => {
    const userId = document.getElementById("userInput").value;

    if (!userId) {
        alert("請輸入使用者 ID！");
        return;
    }

    connection = new signalR.HubConnectionBuilder()
        .withUrl(`https://localhost:7263/chatHub?userId=${userId}`)
        .withAutomaticReconnect([0, 2000, 10000, 30000])
        .build();

    connection.onreconnecting(error => {
        console.warn(`連線中斷，正在重新連接：${error}`);
    });

    connection.onreconnected(connectionId => {
        console.log(`重新連接成功：${connectionId}`);
    });

    connection.on("ReceiveMessage", (user, message) => {
        const li = document.createElement("li");
        li.textContent = `${user} 對您說：${message}`;
        document.getElementById("messagesList").appendChild(li);
    });

    try {
        await connection.start();
        console.log("SignalR 連線成功");
        document.getElementById("chat").style.display = "block";

        const targetUserId = document.getElementById("targetUserId").value;

        // 呼叫 loadChatHistory 並處理歷史訊息
        await loadChatHistory(userId, targetUserId);

    } catch (err) {
        console.error("SignalR 連線失敗：", err.toString());
    }
});

async function loadChatHistory(userId, targetUserId) {
    try {
        const response = await fetch(`/api/chat/history?user1=${userId}&user2=${targetUserId}`);
        const messages = await response.json();

        messages.forEach(msg => {
            const li = document.createElement("li");
            li.textContent = `${msg.senderId} 對您說：${msg.content}`;
            document.getElementById("messagesList").appendChild(li);
        });
    } catch (err) {
        console.error("載入歷史訊息失敗：", err.toString());
    }
}

document.getElementById("sendButton").addEventListener("click", async (event) => {
    event.preventDefault();

    const targetUserId = document.getElementById("targetUserId").value;
    const message = document.getElementById("messageInput").value;
    const userId = document.getElementById("userInput").value;

    console.log("Target User ID:", targetUserId);
    console.log("Message:", message);
    console.log("User ID:", userId);

    if (!targetUserId || !message) {
        alert("請輸入目標使用者 ID 和訊息內容！");
        return;
    }

    try {
        await connection.invoke("SendPrivateMessage", targetUserId, message);
        document.getElementById("messageInput").value = "";
    } catch (err) {
        console.error("發送訊息失敗：", err.toString());

        const errorLi = document.createElement("li");
        errorLi.textContent = "無法發送訊息，請稍後再試。";
        document.getElementById("messagesList").appendChild(errorLi);
    }
});


