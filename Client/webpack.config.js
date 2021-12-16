const path = require('path');

module.exports = {
    entry: './src/scripts/main.js',

    module: {
        rules: [{
            test: /\.js$/,
            exclude: /node_modules/,
            use: {
                loader: 'babel-loader',
                options: {
                    presets: [
                        ["@babel/preset-env", { "targets": "defaults" }]
                    ]
                }
            }
        }]
    },

    plugins: [],

    optimization: {
        minimize: false,
    },

    output: {
        path: path.resolve(__dirname, 'public/js'),
        filename: 'bundle.js',
    },
}