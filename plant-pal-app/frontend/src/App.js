// src/App.js
import React, { useState } from 'react';
import PlantCollection from './components/PlantCollection';
import Header from './components/Header';
import Footer from './components/Footer';

function App() {
  const [view, setView] = useState('all'); // State to track the current view

  const handleViewChange = (viewType) => {
    setView(viewType);
  };

  return (
    <div className="flex flex-col min-h-screen">
      <Header handleViewChange={handleViewChange} view={view} />
      <div className="container mx-auto p-4">
        <PlantCollection view={view} />
      </div>
      <Footer />
    </div>
  );
}

export default App;
