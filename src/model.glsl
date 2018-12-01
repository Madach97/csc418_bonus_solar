// Construct the model transformation matrix. The moon should orbit around the
// origin. The other object should stay still.
//
// Inputs:
//   is_moon  whether we're considering the moon
//   time  seconds on animation clock
// Returns affine model transformation as 4x4 matrix
//
// expects: identity, rotate_about_y, translate, PI
mat4 model(bool is_sun, bool is_mercury, bool is_venus, bool is_earth, float time)
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  if(is_mercury){
     float angle = -time*M_PI/4;
     return rotate_about_y(angle)*translate(vec3(2,0,0));
  }
  if(is_venus){
     float angle = -time*M_PI/2;
     return rotate_about_y(angle)*translate(vec3(3,0,0));
  } 
  if(is_earth){
     float angle = -time*M_PI*3/4;
     return rotate_about_y(angle)*translate(vec3(4,0,0));
  } 
  
  return identity();
  /////////////////////////////////////////////////////////////////////////////
}
