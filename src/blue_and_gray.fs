// Set the pixel color to blue or gray depending on is_moon.
//
// Uniforms:
uniform bool is_earth;
uniform bool is_venus;
uniform bool is_sun;
uniform bool is_mercury;

// Outputs:
out vec3 color;
void main()
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code:
  if(is_earth){
       color = vec3(25.0/255.0,22.0/255.0,224.0/255.0);
  }
  else if(is_venus){
  	  color = vec3(173.0/255.0, 138.0/255.0, 12.0/255.0);
  }
  else if(is_mercury){
  	   color = vec3(229.0/255.0, 41.0/255.0, 27.0/255.0);
  }
  else if(is_sun){
  	  color = vec3(224.0/255.0, 180.0/255.0, 22.0/255.0);
  }
  else{
  	  color = vec3(0, 0, 0);
  }

  /////////////////////////////////////////////////////////////////////////////
}
