import React, { useState, useEffect } from 'react';
import defaultImage from '../assets/images/default-plant.jpg';
import WaterDropIcon from '@mui/icons-material/WaterDrop';
import LocalDrinkIcon from '@mui/icons-material/LocalDrink';
import Tooltip from '@mui/material/Tooltip';

const ONE_HOUR_MS = 3500; // For testing

const PlantCard = ({ plant, onAdd, onDelete, view }) => {
  let plantImage;
  try {
    plantImage = require(`../assets/images/${plant.name.replace(/\s+/g, '-').toLowerCase()}.jpg`);
  } catch (err) {
    plantImage = defaultImage;
  }

  const [lastWatered, setLastWatered] = useState(null);
  const [wateringProgress, setWateringProgress] = useState(0);
  const [wateringBarColor, setWateringBarColor] = useState("#28a745");
  const [lastFertilized, setLastFertilized] = useState(null);
  const [fertilizingProgress, setFertilizingProgress] = useState(0);
  const [fertilizingBarColor, setFertilizingBarColor] = useState("#28a745");

  const getIntervalMs = (frequency) => {
    const [value, unit] = frequency.split(' ');
    switch (unit) {
      case 'hours':
        return value * ONE_HOUR_MS;
      case 'days':
        return value * ONE_HOUR_MS * 24;
      default:
        return ONE_HOUR_MS * 24;
    }
  };

  const wateringInterval = getIntervalMs(plant.water_frequency);
  const fertilizingInterval = getIntervalMs(plant.fertilizing_frequency || '30 days');

  const handleWatering = () => {
    const currentTime = Date.now();
    setLastWatered(currentTime);
    setWateringProgress(100);
    setWateringBarColor("#28a745");
    localStorage.setItem(`lastWatered_${plant.plantId}`, currentTime);
  };

  const handleFertilizing = () => {
    const currentTime = Date.now();
    setLastFertilized(currentTime);
    setFertilizingProgress(100);
    setFertilizingBarColor("#28a745");
    localStorage.setItem(`lastFertilized_${plant.plantId}`, currentTime);
  };

  useEffect(() => {
    const savedLastWatered = localStorage.getItem(`lastWatered_${plant.plantId}`);
    const savedLastFertilized = localStorage.getItem(`lastFertilized_${plant.plantId}`);
    if (savedLastWatered) setLastWatered(Number(savedLastWatered));
    if (savedLastFertilized) setLastFertilized(Number(savedLastFertilized));

    const intervalId = setInterval(() => {
      if (lastWatered) {
        const timeElapsed = Date.now() - lastWatered;
        const newWateringProgress = Math.max(0, 100 - (timeElapsed / wateringInterval) * 100);
        setWateringProgress(newWateringProgress);
        setWateringBarColor(newWateringProgress > 50 ? "#28a745" : newWateringProgress > 20 ? "#ffc107" : "#dc3545");
      }

      if (lastFertilized) {
        const timeElapsed = Date.now() - lastFertilized;
        const newFertilizingProgress = Math.max(0, 100 - (timeElapsed / fertilizingInterval) * 100);
        setFertilizingProgress(newFertilizingProgress);
        setFertilizingBarColor(newFertilizingProgress > 50 ? "#28a745" : newFertilizingProgress > 20 ? "#ffc107" : "#dc3545");
      }
    }, 1000);

    return () => clearInterval(intervalId);
  }, [lastWatered, lastFertilized, wateringInterval, fertilizingInterval, plant.plantId]);

  return (
    <div className="plant-card">
      <img src={plantImage} alt={plant.name} className="plant-image" />
      <div className="plant-details">
        <h3 className="plant-name">{plant.name}</h3>
        <p className="plant-info">Type: {plant.latin_name}</p>
        <p className="plant-info">Water Frequency: {plant.water_frequency}</p>
        <p className="plant-info">Sunlight: {plant.sunlight}</p>
        <p className="plant-info">Humidity: {plant.humidity}</p>
        <p className="plant-info">Fertilizing: {plant.fertilizing}</p>
        <p className="plant-info">Pet Friendly: {plant.pet_friendly ? 'Yes' : 'No'}</p>
        <p className="plant-info">Care Level: {plant.care_level}</p>
      </div>

      <div className="action-buttons">
        {view === 'my' ? (
          <>
            <Tooltip title="Water your plant" arrow>
              <button onClick={handleWatering} className="icon-button">
                <WaterDropIcon style={{ color: wateringBarColor, fontSize: '2rem' }} />
              </button>
            </Tooltip>
            <div className="progress-bar-container">
              <div
                className="progress-bar"
                style={{ backgroundColor: wateringBarColor, width: `${wateringProgress}%` }}
              />
            </div>

            <Tooltip title="Fertilize your plant" arrow>
              <button onClick={handleFertilizing} className="icon-button">
                <LocalDrinkIcon style={{ color: fertilizingBarColor, fontSize: '2rem' }} />
              </button>
            </Tooltip>
            <div className="progress-bar-container">
              <div
                className="progress-bar"
                style={{ backgroundColor: fertilizingBarColor, width: `${fertilizingProgress}%` }}
              />
            </div>

            <button className="delete-button" onClick={() => onDelete(plant.plantId)}>Delete</button>
          </>
        ) : (
          <button className="add-button" onClick={() => onAdd(plant)}>Add to My Plants</button>
        )}
      </div>
    </div>
  );
};

export default PlantCard;
