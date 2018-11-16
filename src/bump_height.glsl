// Create a bumpy surface by using procedural noise to generate a height (
// displacement in normal direction).
//
// Inputs:
//   is_moon  whether we're looking at the moon or centre planet
//   s  3D position of seed for noise generation
// Returns elevation adjust along normal (values between -0.1 and 0.1 are
//   reasonable.
float bump_height( bool is_moon, vec3 s)
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  float scale = 0.2;
  if(is_moon){
     scale = scale * 0.3;
  }
  return (improved_perlin_noise(s)*scale) - 0.1; //since it is in the range 0 to 1 originally
  /////////////////////////////////////////////////////////////////////////////
}
