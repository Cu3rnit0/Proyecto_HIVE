const express = require('express');
const { getRooms, getRoom, postRoom } = require('../controllers/roomsController');
const auth = require('../middlewares/authMiddleware');
const router = express.Router();

router.get('/', getRooms);
router.get('/:id', getRoom);
router.post('/', auth, postRoom);

module.exports = router;
