/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        'bright-green': '#4CAF50',
        'soft-white': '#FFFFFF',
        'light-gray': '#F5F5F5',
        'dark-gray': '#333333',
        'pale-green': '#A5D6A7',
      },
    },
  },
  plugins: [],
}
