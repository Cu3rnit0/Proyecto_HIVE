import express from "express";
import http from "http";
import { WebSocketServer } from "ws";
import dotenv from "dotenv";

console.log("🔥 Iniciando HIVE Server...");

dotenv.config();

const app = express();
const server = http.createServer(app);
const wss = new WebSocketServer({ server });

wss.on("connection", (ws, req) => {
  const ip = req.socket.remoteAddress;
  console.log(`Cliente conectado desde ${ip}`);

  ws.on("message", (message) => {
    console.log("Mensaje recibido:", message.toString());
    ws.send("ACK_FROM_SERVER");
  });

  ws.on("close", () => {
    console.log(`Cliente ${ip} desconectado`);
  });
});

const PORT = process.env.PORT || 3000;

server.listen(PORT, () => {
  console.log(`🚀 HIVE Server iniciado en puerto ${PORT}`);
});
