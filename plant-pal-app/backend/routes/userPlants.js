const express = require('express');
const router = express.Router();
const UserPlant = require('../models/UserPlant');
const mongoose = require('mongoose');

// Fetch user's plants
router.get('/', async (req, res) => {
  const userId = req.query.userId; // Fetch user ID from query parameters
  try {
    const userPlants = await UserPlant.find({ userId });
    console.log("Fetched user plants:", userPlants); // Log the retrieved plants
    res.json(userPlants);
  } catch (error) {
    res.status(500).json({ message: error.message });
  }
});


// Add a user plant
router.post('/', async (req, res) => {
  const {
    plantId,
    userId,
    name,
    latin_name,
    water_frequency,
    sunlight,
    humidity,
    fertilizing,
    pet_friendly,
    care_level,
    imageUrl,
  } = req.body;

  // Ensure all necessary fields are provided
  if (!plantId || !userId || !name) {
    return res.status(400).json({ message: 'plantId, userId, and name are required.' });
  }

  const newUserPlant = new UserPlant({
    plantId,
    userId,
    name,
    latin_name,
    water_frequency,
    sunlight,
    humidity,
    fertilizing,
    pet_friendly,
    care_level,
    imageUrl,
  });

  try {
    const savedPlant = await newUserPlant.save();
    res.status(201).json(savedPlant);
    console.log('Plant added to My Plants.');
  } catch (error) {
    console.error('Error saving user plant:', error);
    res.status(400).json({ message: error.message });
  }
});

// Delete user plant route
router.delete('/:userId/:plantId', async (req, res) => {
  const { userId, plantId } = req.params;

  try {
    console.log('Attempting to delete:', { userId, plantId });

    // Directly use plantId without conversion if it's a string in the database
    const result = await UserPlant.deleteOne({
      userId,
      plantId, // No conversion unless plantId is stored as ObjectId
    });

    console.log('Delete result:', result);

    if (result.deletedCount === 0) {
      return res.status(404).json({ message: 'No plant found to delete' });
    }

    res.status(200).json({ message: 'Plant deleted successfully' });
  } catch (error) {
    console.error('Error during deletion:', error);
    res.status(500).json({ message: 'Failed to delete plant', error: error.message });
  }
});

module.exports = router;
