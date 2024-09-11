import React, { useState, useEffect } from 'react';
import portfolioPic from './img/pic.png';
import skillcollectorPic from './img/skillcollector_screenshot.png';
import snakegamePic from './img/snakegame.png';
import portfoliopagePic from './img/portfoliopage.png';
import arkadicsPic from './img/arkadics.png'
import ergobrassPic from './img/ergobrass.png'
import './App.css';

export default function App() {
  const [navBackground, setNavBackground] = useState(false);

  const handleScroll = () => {
    const show = window.scrollY > 780;
    setNavBackground(show);
  };

  useEffect(() => {
    window.addEventListener('scroll', handleScroll);
    return () => {
      window.removeEventListener('scroll', handleScroll);
    };
  }, []);

  const navClass = navBackground
    ? 'backdrop-blur-sm bg-white/30'
    : 'bg-transparent';

  const projects = [
    { id: 1, 
      title: 'Skill Collector', 
      category: 'UX Design', 
      description: 'UX Design for a Skill Collector App', 
      image: skillcollectorPic , 
      link: 'https://github.com/fannyrenko/portfolio/tree/main/projects/python-projects/RL-snake-game' 
    },
    { id: 2, 
      title: 'Portfolio 2024', 
      category: 'Frontend', 
      description: 'Portfolio page made using React and Tailwind CSS', 
      image: portfoliopagePic,
      link: 'https://github.com/fannyrenko/portfolio/tree/main/workfolio',
    },
/*     { id: 3, 
      title: 'Portfolio 2023', 
      category: 'Frontend', 
      description: 'Portfolio page made using React and Tailwind CSS', 
      image: portfoliopagePic,
      link: '',
    }, */
    { id: 4, 
      title: 'Arkadics Website', 
      category: 'Frontend', 
      description: 'Wordpress Website for Arkadics Oy', 
      image: arkadicsPic,
      link: 'https://www.arkadics.com/',

    },
    { id: 5, 
      title: 'Plant It', 
      category: 'Application Development', 
      description: 'Application for tracking watering and fertilizing of house plants', 
      image: 'https://via.placeholder.com/300' 
    },
    { id: 6, 
      title: 'Snake Game', 
      category: 'Reinforced learning', 
      description: 'Snake Game', 
      image: snakegamePic,
      link: 'https://github.com/fannyrenko/portfolio/tree/main/projects/python-projects/RL-snake-game' 
    
    },
    { id: 7, 
      title: 'ErgoBrass Website', 
      category: 'Frontend', 
      description: 'Wordpress Website for ErgoBrass Oy', 
      image: ergobrassPic,
      link: 'https://www.ergobrass.com/' 
    
    },
  ];

  const [selectedCategory, setSelectedCategory] = useState('');

  const handleCategoryClick = (category) => {
    setSelectedCategory(selectedCategory === category ? '' : category);
  };

  return (
    <main className="min-h-screen w-full">
      <header className={`fixed top-0 w-full text-white p-4 z-50 transition-all duration-300 ${navClass}`}>
        <nav className="container mx-auto flex justify-around items-center h-16">
          <a href="#about" className="hover:text-pink-500 text-xl hover:text-2xl transition-all duration-300">About Me</a>
          <a href="#skills" className="hover:text-orange-300 text-xl hover:text-2xl transition-all duration-300">Skill Stack</a>
          <a href="#projects" className="hover:text-indigo-400 text-xl hover:text-2xl transition-all duration-300">Projects</a>
          <a href="#contact" className="hover:text-purple-700 text-xl hover:text-2xl transition-all duration-300">Contact</a>
        </nav>
      </header>

      <div className="container mx-auto flex items-center justify-center h-screen p-5">
        <div>
          <h1 className='text-white'>Hello, I'm Fanny Renko</h1>
          <p className='text-lg'>ICT engineer and designer</p>
        </div>
      </div >
      
      {/* About Section */}
      <section  id="about" className=" w-full py-12 backdrop-blur-sm bg-white/30 pt-20 pb-10 mt-20"  >
        <h1 className="text-4xl font-extrabold text-center text-white mb-24">About</h1>
        <div className="container mx-auto px-8 flex flex-col md:flex-row items-center justify-center">
          <div className="flex-1 flex flex-col justify-center md:pr-8 mb-8 md:mb-0 pb-5">
            <p className="leading-relaxed text-white">
              As a fourth-year ICT Engineering student with a Bachelor's degree in Design, I am deeply passionate about the intersection of technology and human experience. My focus is on developing innovative programs and applications that are intuitive, user-friendly, and designed to improve people's lives. I have a strong interest in emerging technologies, particularly in artificial intelligence and reinforcement learning, and I am eager to explore their potential to create meaningful, positive change.
            </p>
          </div>
          <div className="flex-1 flex items-center justify-center">
            <img src={portfolioPic} alt="portfolio pic" className="w-full h-auto max-w-sm pb-5" />
          </div>
        </div>
      </section>

      {/* Skills */}
      <section id="skills" className="h-screen px-8 py-12 pt-20 pb-20 mt-20">
        <h1 className="text-4xl font-extrabold text-center text-white mb-40">Skill Stack</h1>
        <div className="grid grid-cols-3 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-6 gap-8">
          <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/python/python-original-wordmark.svg" alt="Python" className="w-24 h-24 mx-auto" />
          <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/react/react-original-wordmark.svg" alt="React" className="w-24 h-24 mx-auto" />
          <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/tailwindcss/tailwindcss-original.svg" alt="Tailwind CSS" className="w-24 h-24 mx-auto" />
          <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/csharp/csharp-original.svg" alt="C#" className="w-24 h-24 mx-auto" />
          <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/figma/figma-original.svg" alt="Figma" className="w-24 h-24 mx-auto" />
          <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/nodejs/nodejs-original-wordmark.svg" alt="Node.js" className="w-24 h-24 mx-auto" />
          <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/blender/blender-original.svg" alt="Blender" className="w-24 h-24 mx-auto" />
          <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/android/android-original.svg" alt="Android" className="w-24 h-24 mx-auto" />
          <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/vite/vite-original.svg" alt="Vite" className="w-24 h-24 mx-auto" />
          <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/wordpress/wordpress-plain.svg" alt="Wordpress" className="w-24 h-24 mx-auto" />
          <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/html5/html5-plain.svg" alt="HTML" className="w-24 h-24 mx-auto" />
          <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/cplusplus/cplusplus-plain.svg" alt="C++" className="w-24 h-24 mx-auto" />

        </div>
      </section>
      
      {/* Projects */}
      <section id="projects" className="w-full px-8 py-12 pt-20 pb-20">
        <h1 className="text-4xl font-extrabold text-center text-white mb-12">Projects</h1>
        <div className="mb-8 text-center">
          <button onClick={() => handleCategoryClick('Frontend')} className="bg-[#fc7445] text-white px-4 py-2 rounded-lg m-2 hover:bg-[#fc734589]">Frontend</button>
          <button onClick={() => handleCategoryClick('Application Development')} className="bg-[#8d40c8] text-white px-4 py-2 rounded-lg mx-2 hover:bg-[#9d5dce65]">Application Development</button>
          <button onClick={() => handleCategoryClick('UX Design')} className="bg-[#e64e9c] text-white px-4 py-2 rounded-lg mx-2 hover:bg-[#e64e9d8e]">UX Design</button>
          <button onClick={() => handleCategoryClick('Reinforced learning')} className="bg-[#e5961b] text-white px-4 py-2 rounded-lg mx-2 hover:bg-[#e5981b9e]">Reinforced learning</button>
          <button onClick={() => handleCategoryClick('')} className="bg-[#25257e] text-white px-4 py-2 rounded-lg mx-2 hover:bg-[#3131e485]">All</button>
        </div>
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-8">
          {projects
            .filter(project => selectedCategory === '' || project.category === selectedCategory)
            .map(project => (
              <div key={project.id} className="bg-white/30 shadow-lg rounded-lg overflow-hidden">
                <img src={project.image} alt={project.title} className="w-full h-48 object-cover" />
                <div className="p-6">
                  <h2 className="text-2xl font-bold mb-4">{project.title}</h2>
                  <p className="text-white mb-4">{project.description}</p>
                  <div className="flex space-x-4">
                    <a href={project.link} target='_blank' rel='noreferrer' className="bg-gray-800 text-white px-4 py-2 rounded-lg text-center hover:bg-gray-700">Project Page</a>
                  </div>
                </div>
              </div>
            ))}
        </div>
      </section>


      {/* Contact */}
      <section id="contact" className="w-full bg-white/30 backdrop-blur-sm pt-20 pb-10 mb-20 relative text-white">
        <div className="absolute inset-0 bg-gradient-to-br from-blue-500 via-purple-500 to-pink-500 opacity-50"></div>
        <div className="container mx-auto px-8 py-12 relative z-10">
          <h1 className="text-4xl font-extrabold text-center  mb-12">Contact</h1>
          <p className="text-2xl font-semibold mb-6 text-center">Get in Touch!</p>
          <div className="w-full max-w-lg mx-auto p-8">
            
          <div className="grid grid-cols-2 sm:grid-cols-3 gap-4 mt-8 text-center">
            <a href="https:/www.linkedin.com/in/fanny-renko" target="_blank" rel="noopener noreferrer" className="hover-link">
              <i className="devicon-linkedin-plain"></i>
            </a>
            <a href="mailto:fannyrenko@gmail.com" className="hover-link">
              <span className="material-symbols-outlined">mail</span>
            </a>
            <a href="https://github.com/fannyrenko/portfolio" target="_blank" rel="noopener noreferrer" className="hover-link">
              <i className="devicon-github-original"></i>
            </a>
            {/* Add more icons if needed */}
          </div>
          </div>
        </div>
      </section>
    </main>
  );
}
