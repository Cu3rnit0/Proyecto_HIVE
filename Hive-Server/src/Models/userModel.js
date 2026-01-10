const pool = require('../Config/db');

async function createUser({ email, display_name, password_hash }) {
  const res = await pool.query(
    'INSERT INTO users (email, display_name, password_hash) VALUES ($1,$2,$3) RETURNING *',
    [email, display_name, password_hash]
  );
  return res.rows[0];
}

async function getUserByEmail(email) {
  const res = await pool.query(
    'SELECT * FROM users WHERE email = $1',
    [email]
  );
  return res.rows[0];
}

module.exports = {
  createUser,
  getUserByEmail
};
