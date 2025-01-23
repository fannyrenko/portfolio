const mongoose = require('mongoose');

const userPlantSchema = new mongoose.Schema({
    plantId: { type: mongoose.Schema.Types.ObjectId, ref: 'Plant', required: true },
    userId: { type: String, required: true },
    name: { type: String, required: true }, 
    latin_name: { type: String },
    water_frequency: { type: String },
    sunlight: { type: String },
    humidity: { type: String },
    fertilizing: { type: String },
    pet_friendly: { type: Boolean },
    care_level: { type: String },
    imageUrl: { type: String },
}, { timestamps: true });

const UserPlant = mongoose.model('UserPlant', userPlantSchema);
module.exports = UserPlant;
