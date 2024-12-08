import React from 'react';
import { FaLeaf } from 'react-icons/fa';

function Header() {
  return (
    <header className="bg-bright-green p-4">
      <div className="container mx-auto flex flex-col md:flex-row justify-between items-center">
        <div className="flex items-center mb-2 md:mb-0">
          <FaLeaf className="text-soft-white h-8 w-8 mr-2 waving-leaf" />
          <div>
            <h1 className="text-soft-white text-2xl font-bold">
              PlantPal
            </h1>
            <h2 className="text-soft-white text-sm">
              Care for your green friends!
            </h2>
          </div>
        </div>

      </div>
    </header>
  );
}

export default Header;
