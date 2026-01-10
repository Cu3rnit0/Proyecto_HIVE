const bcrypt = require('bcryptjs');
const jwt = require('jsonwebtoken');
const { createUser, getUserByEmail } = require('../models/userModel');

exports.register = async (req, res) => {
  try {
    const { email, display_name, password } = req.body;
    const existing = await getUserByEmail(email);
    if (existing) return res.status(400).json({ message: "User already exists" });

    const password_hash = await bcrypt.hash(password, 10);
    const user = await createUser({ email, display_name, password_hash });

    res.status(201).json({ user });
  } catch (err) {
    console.error(err);
    res.status(500).json({ message: "Server error" });
  }
};

exports.login = async (req, res) => {
  try {
    const { email, password } = req.body;
    const user = await getUserByEmail(email);
    if (!user) return res.status(400).json({ message: "Invalid credentials" });

    const valid = await bcrypt.compare(password, user.password_hash);
    if (!valid) return res.status(400).json({ message: "Invalid credentials" });

    const token = jwt.sign({ id: user.user_id }, process.env.JWT_SECRET);
    res.json({ token, user });
  } catch (err) {
    console.error(err);
    res.status(500).json({ message: "Server error" });
  }
};
