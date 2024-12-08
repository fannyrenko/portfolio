const express = require('express');
const mongoose = require('mongoose');
const cors = require('cors');
const PlantCard = require('./models/PlantCard');
const UserPlant = require('./models/UserPlant');
const userPlantsRoutes = require('./routes/userPlants'); 
require('dotenv').config();

const app = express();
app.use(cors());
app.use(express.json());

// Connect to MongoDB Atlas
mongoose.connect(process.env.MONGODB_URI, {
  useNewUrlParser: true,
  useUnifiedTopology: true,
})
.then(() => console.log('Connected to MongoDB'))
.catch((error) => console.error('MongoDB connection failed:', error));

// Use the userPlants routes
app.use('/api/userPlants', userPlantsRoutes);

// Create route for fetching all plants
app.get('/api/plants', async (req, res) => {
  try {
    const plants = await PlantCard.find();
    res.json(plants);
  } catch (error) {
    res.status(500).json({ message: 'Failed to fetch plants' });
  }
});


const PORT = process.env.PORT || 5000;
app.listen(PORT, () => console.log(`Server running on port ${PORT}`));