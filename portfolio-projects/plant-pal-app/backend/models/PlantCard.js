const mongoose = require('mongoose');

const plantSchema = new mongoose.Schema({
  name: { type: String, required: true },
  scientific_name: { type: String },
  water_frequency: { type: String },
  sunlight: { type: String },
  humidity: { type: String },
  fertilizing: { type: String },
  pet_friendly: { type: Boolean },
  care_level: { type: String },
  imageUrl: { type: String }, 
});

module.exports = mongoose.model('Plant', plantSchema);


