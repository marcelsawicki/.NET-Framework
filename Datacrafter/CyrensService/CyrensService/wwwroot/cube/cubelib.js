function przeliczX(xa, ya, za)
{
	var fi=fia;
	var teta=45;
	var wsp_x=100;
	var wsp_y=100;
	var skala=500;
	var dist=100;
	
	var xn=-Math.sin(fi*Math.PI/180)*xa+Math.cos(fi*Math.PI/180)*ya;
	var yn=-Math.cos(fi*Math.PI/180)*xa-Math.sin(fi*Math.PI/180)*Math.cos(teta*Math.PI/180)*ya+Math.sin(teta*Math.PI/180)*za;
	var zn=-Math.cos(fi*Math.PI/180)*Math.sin(teta*Math.PI/180)*ya-Math.cos(teta*Math.PI/180)*za+dist;
	 var x=skala*xn/(zn+dist)+wsp_x;
	 var y=skala*yn/(zn+dist)+wsp_y;
	return x;
}

function przeliczY(xa, ya, za)
{
	var fi=45;
	var teta=45;
	var wsp_x=100;
	var wsp_y=100;
	var skala=500;
	var dist=100;
	
	var xn=-Math.sin(fi*Math.PI/180)*xa+Math.cos(fi*Math.PI/180)*ya;
	var yn=-Math.cos(fi*Math.PI/180)*xa-Math.sin(fi*Math.PI/180)*Math.cos(teta*Math.PI/180)*ya+Math.sin(teta*Math.PI/180)*za;
	var zn=-Math.cos(fi*Math.PI/180)*Math.sin(teta*Math.PI/180)*ya-Math.cos(teta*Math.PI/180)*za+dist;
	 var x=skala*xn/(zn+dist)+wsp_x;
	 var y=skala*yn/(zn+dist)+wsp_y;
	return y;
}

function draw(fia)
{
	window.fia = fia;
		var canvas = document.getElementById('kanwa');
	var context = canvas.getContext('2d');
	context.clearRect(0, 0, 320, 240);	
	    // clear path
    context.beginPath();
	context.fillStyle = "blue";

	context.fillRect(0, 0, canvas.width, canvas.height);
	
	  
	  context.moveTo(przeliczX(10,10,0), przeliczY(10,10,0));
      context.lineTo(przeliczX(10,20,0), przeliczY(10,20,0));
      context.stroke();
	  
	  context.moveTo(przeliczX(20,10,0), przeliczY(20,10,0));
      context.lineTo(przeliczX(20,20,0), przeliczY(20,20,0));
      context.stroke();
	  
	  context.moveTo(przeliczX(20,20,0), przeliczY(20,20,0));
      context.lineTo(przeliczX(10,20,0), przeliczY(10,20,0));
      context.stroke();
	  
	  context.moveTo(przeliczX(20,10,0), przeliczY(20,10,0));
      context.lineTo(przeliczX(10,10,0), przeliczY(10,10,0));
	  context.strokeStyle = 'white';
      context.stroke();

	  //
	  
	  context.moveTo(przeliczX(20,20,0), przeliczY(20,20,0));
      context.lineTo(przeliczX(20,20,10), przeliczY(20,20,10));
      context.stroke();
	  
	  context.moveTo(przeliczX(20,20,10), przeliczY(20,20,10));
      context.lineTo(przeliczX(20,10,10), przeliczY(20,10,10));
      context.stroke();
	  
	  context.moveTo(przeliczX(20,10,10), przeliczY(20,10,10));
      context.lineTo(przeliczX(20,10,0), przeliczY(20,10,0));
      context.stroke();
	  
	  //
	  
	  context.moveTo(przeliczX(20,10,10), przeliczY(20,10,10));
      context.lineTo(przeliczX(10,10,10), przeliczY(10,10,10));
      context.stroke();
	  
	  context.moveTo(przeliczX(10,10,10), przeliczY(10,10,10));
      context.lineTo(przeliczX(10,10,0), przeliczY(10,10,0));
      context.stroke();
	  
	  context.moveTo(przeliczX(10,10,10), przeliczY(10,10,10));
      context.lineTo(przeliczX(10,20,10), przeliczY(10,20,10));
      context.stroke();
	  
	  //
	  
	  context.moveTo(przeliczX(10,20,10), przeliczY(10,20,10));
      context.lineTo(przeliczX(10,20,0), przeliczY(10,20,0));
      context.stroke();
	  
	  context.moveTo(przeliczX(10,20,10), przeliczY(10,20,10));
      context.lineTo(przeliczX(20,20,10), przeliczY(20,20,10));
      context.stroke();	
}