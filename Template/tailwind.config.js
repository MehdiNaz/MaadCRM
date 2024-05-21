module.exports = {
  content: [
    "./app/**/*.{js,ts,jsx,tsx}", // Note the addition of the `app` directory.
    "./pages/**/*.{js,ts,jsx,tsx}",
    "./components/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: "#2141A8",
        second: '#F1F5F8',
        third: '#2E51BB',
        borderColor: '#707070'
      },
      fontFamily: {
        IRANSansX: ["IRANSansX"]
      },
      fontSize: {
        '11p': "11px",
        '12p': "12px"
      }
    }
  }
}