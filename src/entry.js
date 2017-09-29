//Modules
import React from 'react';
import ReactDOM from 'react-dom';

//CSS
import './main.scss'

//Components
import Layout from './components/layout/layout'
import Svg from './components/svg/svg'

//IMAGES
import image from '../images/CHAT2.gif'
import svg from '../images/logout.svg'

var App = React.createClass({

  render: function() {
    return(
      <div className='app'>

        Testing! Maybe Kill Patrick??

        <canvas id={"myCanvas"} width={"200"} height={"100"} style={{"border":"1px solid #000000"}}>
        </canvas>

      </div>
    )
  }
});

ReactDOM.render(
  <App/>,
  document.getElementById('root')
);
