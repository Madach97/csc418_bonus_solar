// Generate a pseudorandom unit 3D vector
// 
// Inputs:
//   seed  3D seed
// Returns psuedorandom, unit 3D vector drawn from uniform distribution over
// the unit sphere (assuming random2 is uniform over [0,1]²).
//
// expects: random2.glsl, PI.glsl
vec3 random_direction( vec3 seed)
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  vec2 vector = random2(seed);
  return normalize(vec3(sin(seed.x)*cos(seed.y), sin(seed.x)*sin(seed.y), cos(seed.x)));
  /////////////////////////////////////////////////////////////////////////////
}
