import React from 'react';
// import { FaFacebook, FaInstagram } from 'react-icons/fa';

function Footer() {
  return (
    <footer className="bg-bright-green p-4 mt-auto">
      <div className="container mt-auto flex flex-col md:flex-row justify-between items-center">
        <div className="text-soft-white text-sm">
          &copy; {new Date().getFullYear()} PlantPal. All rights reserved.
        </div>
        {/* <div className="flex space-x-4 mt-2 md:mt-0">
          <a href="#" className="text-soft-white hover:text-light-gray">
            <FaFacebook />
          </a>
          <a href="#" className="text-soft-white hover:text-light-gray">
            <FaInstagram />
          </a>
        </div> */}
      </div>
    </footer>
  );
}

export default Footer;
