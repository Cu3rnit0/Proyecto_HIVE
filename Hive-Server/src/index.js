import express from "express";
import http from "http";
import { WebSocketServer } from "ws";
import dotenv from "dotenv";

dotenv.config();
const app = express();
const server = http.createServer(app);
const wss = new WebSocketServer({ server });

wss.on("connection", (ws, req) => {
  const ip = req.socket.remoteAddress;
  console.log(`Client connected from ${ip}`);

  ws.on("message", (message) => {
    console.log("Message received:", message.toString());
    // Respond to handshake
    ws.send(JSON.stringify({ type: "ack", payload: "HANDSHAKE_OK" }));
  });

  ws.on("close", () => {
    console.log(`Client disconnected from ${ip}`);
  });
});

const PORT = process.env.PORT || 3000;
server.listen(PORT, () => {
  console.log(`🚀 HIVE Server running on port ${PORT}`);
});
