const pool = require('../config/db');

async function createRoom({ name, description, created_by }) {
  const res = await pool.query(
    'INSERT INTO rooms (name, description, created_by) VALUES ($1,$2,$3) RETURNING *',
    [name, description, created_by]
  );
  return res.rows[0];
}

async function getAllRooms() {
  const res = await pool.query('SELECT * FROM rooms');
  return res.rows;
}

async function getRoomById(id) {
  const res = await pool.query('SELECT * FROM rooms WHERE id = $1', [id]);
  return res.rows[0];
}

module.exports = {
  createRoom,
  getAllRooms,
  getRoomById
};
