const {
  createRoom,
  getAllRooms,
  getRoomById
} = require('../models/roomModel');

exports.getRooms = async (req, res) => {
  try {
    const rooms = await getAllRooms();
    res.json(rooms);
  } catch (err) {
    console.error(err);
    res.status(500).json({ message: "Server error" });
  }
};

exports.getRoom = async (req, res) => {
  try {
    const room = await getRoomById(req.params.id);
    res.json(room);
  } catch (err) {
    console.error(err);
    res.status(500).json({ message: "Server error" });
  }
};

exports.postRoom = async (req, res) => {
  try {
    const { name, description } = req.body;
    const created_by = req.userId;
    const room = await createRoom({ name, description, created_by });
    res.status(201).json(room);
  } catch (err) {
    console.error(err);
    res.status(500).json({ message: "Server error" });
  }
};
