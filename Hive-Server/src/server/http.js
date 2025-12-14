const express = require('express')
const http = require('http')

function createHttpServer() {
  const app = express()
  return http.createServer(app)
}

module.exports = { createHttpServer }
