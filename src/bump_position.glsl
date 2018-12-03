// Create a bumpy surface by using procedural noise to generate a new 3D position
// via displacement in normal direction.
// 
// Inputs:
//   is_moon  whether we're looking at the moon or centre planet
//   s  3D position of seed for noise generation, also assumed to be surface
//     point on the unit sphere (and thus also equal to its normal)
// Returns 3D position of p adjusted along n by bump amount
//
// Hint: for a unit sphere object, you might use s=p=n
//
// expects: bump_height
vec3 bump_position(bool is_earth, bool is_venus, bool is_sun, bool is_mercury, vec3 s)
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  float h = bump_height(is_earth, is_venus, is_sun, is_mercury, s);
  return s + (h*s);
  /////////////////////////////////////////////////////////////////////////////
}
