Jak zalozyc projekt Webpack + TypeScript?
------------------------------------------  

npm init  
npm install -g typescript  
tsc init  
npm install webpack webpack-cli webpack-dev-server --save-dev  
npm install typescript ts-loader --save-dev  




skopiować do pliku webpack.config.js
-------------------------------------

const path = require('path');

const ROOT = path.resolve( __dirname, 'src' );
const DEST = path.resolve( __dirname, 'dist' );

module.exports = {

    entry: path.join(ROOT, '/app.ts'),
    output: {
        filename: 'app.js',
        path: DEST
        //path: __dirname
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                loader: 'ts-loader',
                exclude: /node_modules/,
            },
        ]
    },
    resolve: {
        extensions: [".tsx", ".ts", ".js"]
    },
};

---------------------------------------------

dodac do package.json  

  "scripts": {
    "test": "echo \"Error: no test specified\" && exit 1",
    "start": "webpack-dev-server --mode development",
    "build": "webpack --mode development"
  },
  
  
  linki:
  https://appdividend.com/2018/03/18/how-to-setup-typescript-with-webpack-4/#Step_4_Install_webpack_and_ts_dependencies