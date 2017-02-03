module.exports = {
  context: __dirname,

  entry: {
    app: './src/app.js'
  },

  output: {
    path: './public',
    filename: 'app.bundle.js'
  }

}
