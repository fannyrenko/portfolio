import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import PlantCard from './PlantCard'; 
import '../styles/PlantCollection.css'; 

const PlantCollection = () => {
  const [plants, setPlants] = useState([]);        // All plants
  const [myPlants, setMyPlants] = useState([]);    // User's plants
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [view, setView] = useState('all');          // Tracks the current view
  const [searchTerm, setSearchTerm] = useState(''); // State for search input

  // Fetch all plants when the component mounts
  useEffect(() => {
    const fetchPlants = async () => {
      try {
        const response = await axios.get('http://localhost:5000/api/plants');
        setPlants(response.data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    fetchPlants();
  }, []);

  // Fetch user's plants
  const fetchMyPlants = async () => {
    const userId = '1'; // Replace this with actual user ID, possibly from auth context
    try {
      const response = await axios.get(`http://localhost:5000/api/userPlants?userId=${userId}`);
      setMyPlants(response.data);
    } catch (err) {
      setError(err.message);
    }
  };

  // Handle view change
  const handleViewChange = (viewType) => {
    setView(viewType);
    if (viewType === 'my') {
      fetchMyPlants(); // Fetch user's plants when switching to "My Plants"
    }
  };

  // Handle search term change
  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  // Handle adding a plant to the user's collection
  const handleAddPlant = async (plant) => {
    const userId = '1'; // userId='1' for testing the app
    try {
      const response = await axios.post('http://localhost:5000/api/userPlants', {
        plantId: plant._id,
        userId,
        name: plant.name,  
        latin_name: plant.latin_name,
        water_frequency: plant.water_frequency,
        sunlight: plant.sunlight,
        humidity: plant.humidity,
        fertilizing: plant.fertilizing,
        pet_friendly: plant.pet_friendly,
        care_level: plant.care_level,
        imageUrl: plant.imageUrl,
      });
  
      if (response.status === 201) {
        toast.success(`${plant.name} has been added to your collection!`);
        fetchMyPlants(); // Refresh the user's plants
      }
    } catch (error) {
      toast.error('Failed to add the plant!');
      console.error('Add error:', error.response ? error.response.data : error); // Log the error response
    }
  };
  

  const handleDeletePlant = async (plantId) => {
    const userId = '1'; // Ensure this matches the user whose plants you are trying to delete
    try {
        const response = await axios.delete(`http://localhost:5000/api/userPlants/${userId}/${plantId}`);
        if (response.status === 200) {
            toast.success('Plant has been removed from your collection!');
            fetchMyPlants(); // Refresh the user's plants
        }
    } catch (error) {
      toast.error('Failed to delete the plant!');
      console.error('Delete error:', error.response ? error.response.data : error); // Log the error response
    }
  };

  // Display loading or error message
  if (loading) {
    return <div className="text-center text-lg">Loading plants...</div>;
  }

  if (error) {
    return <div className="text-center text-lg text-red-600">Error: {error}</div>;
  }

  // Determine which plants to display based on the current view
  const currentPlants = view === 'my' ? myPlants : plants;

  // Filter plants based on the search term
  const displayedPlants = currentPlants.filter((plant) =>
    plant.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  // Show a message if there are no user plants
  if (view === 'my' && myPlants.length === 0) {
    return (
      <div className="text-center">
        <p className="mb-4">No plants found in your collection. Please add some from the All Plants view.</p>
        <button onClick={() => handleViewChange('all')} className="bg-bright-green text-white py-2 px-4 rounded shadow hover:bg-green-600 transition">
          View All Plants
        </button>
      </div>
    );
  }

  return (
    <div className="container mx-auto p-6">
      <ToastContainer />

      {/* Search Bar */}
      <div className="flex justify-center mb-6">
        <input
          type="text"
          placeholder="Search plants..."
          value={searchTerm}
          onChange={handleSearchChange}
          className="w-full max-w-md p-2 border border-gray-300 rounded shadow focus:outline-none focus:ring focus:border-blue-300"
        />
      </div>

      {/* Buttons to switch views */}
      <div className="flex justify-center space-x-4 mb-6">
        <button 
          onClick={() => handleViewChange('all')}
          className={`btn ${view === 'all' ? 'bg-bright-green text-white' : 'bg-gray-200 text-gray-700'} py-2 px-4 rounded shadow transition`}
        >
          All Plants
        </button>
        <button 
          onClick={() => handleViewChange('my')}
          className={`btn ${view === 'my' ? 'bg-bright-green text-white' : 'bg-gray-200 text-gray-700'} py-2 px-4 rounded shadow transition`}
        >
          My Plants
        </button>
      </div>

      {/* Plants Grid */}
      <div className="plant-list grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
        {displayedPlants.map((plant) => (
          <PlantCard
            key={plant._id}
            plant={plant}
            onAdd={handleAddPlant}
            onDelete={handleDeletePlant} // Pass delete handler
            view={view} // Pass the current view to PlantCard
          />
        ))}
      </div>
    </div>
  );
};

export default PlantCollection;
