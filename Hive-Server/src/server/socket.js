const { Server } = require('socket.io')

function setupSocket(httpServer) {
  const io = new Server(httpServer, {
    cors: { origin: '*' }
  })

  io.on('connection', socket => {
    console.log(`🟢 Cliente conectado: ${socket.id}`)

    socket.on('disconnect', () => {
      console.log(`🔴 Cliente desconectado: ${socket.id}`)
    })
  })
}

module.exports = { setupSocket }
