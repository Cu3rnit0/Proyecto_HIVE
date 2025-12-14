const { createHttpServer } = require('./http')
const { setupSocket } = require('./socket')
const { PORT } = require('../config')

function startServer() {
  const httpServer = createHttpServer()
  setupSocket(httpServer)

  httpServer.listen(PORT, () => {
    console.log(`🚀 HIVE Server iniciado en puerto ${PORT}`)
  })
}

module.exports = { startServer }
