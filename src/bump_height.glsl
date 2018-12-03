// Create a bumpy surface by using procedural noise to generate a height (
// displacement in normal direction).
//
// Inputs:
//   is_moon  whether we're looking at the moon or centre planet
//   s  3D position of seed for noise generation
// Returns elevation adjust along normal (values between -0.1 and 0.1 are
//   reasonable.
float bump_height(bool is_earth, bool is_venus, bool is_sun, bool is_mercury, vec3 s)
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  float scale = 0.2;
  if(is_earth){
     scale = scale * 0.5;
  }
  else if(is_venus){
	 scale = scale * 0.45;
  }
  else if(is_mercury){
	 scale = scale * 0.3;
  }
  return (perlin_noise(s)*scale);
  /////////////////////////////////////////////////////////////////////////////
}
