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
    componentDidMount:function () {
        var canvas = document.getElementById("workSpace");
        var ctx = canvas.getContext("2d");
        let x = 20,
            y = 30;


        function draw(){
            ctx.clearRect(0,0,800,600)
            ctx.fillRect(x,y,150,100);
        }

        setInterval(draw,10);

        canvas.onmousedown = function(e){
            console.log('mouse down');
            x = e.pageX - canvas.offsetLeft;
            y = e.pageY - canvas.offsetTop;
        }
        canvas.onmouseup = function(e){
            console.log('mouse up');
        }

        canvas.onmousemove = function(e){
        
        }
    },

    render: function() {
        return(
            <div className='app'>

                Testing! Maybe Kill Patrick??<br/><br/>

                <canvas id={"workSpace"} width={"800"} height={"600"} style={{"border":"3px solid #000000"}}>
                </canvas>


            </div>
        )
    }
});

ReactDOM.render(
  <App/>,
  document.getElementById('root')
);
