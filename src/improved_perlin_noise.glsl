// Given a 3d position as a seed, compute an even smoother procedural noise
// value. "Improving Noise" [Perlin 2002].
//
// Inputs:
//   st  3D seed
// Values between  -½ and ½ ?
//
// expects: random_direction, improved_smooth_step
float improved_perlin_noise( vec3 st) 
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code

float x = floor(st.x);
  float y = floor(st.y);
  float z = floor(st.z);

  vec3 fbl = vec3(x, y, z); // front bottom left
  vec3 fbr = vec3(x+1, y, z);
  vec3 ftl = vec3(x, y+1, z); 
  vec3 ftr = vec3(x+1, y+1, z);
  vec3 btr = vec3(x+1, y+1, z-1); //back top right; z-1 since we are looking in the -ve z direction
  vec3 btl = vec3(x, y+1, z-1); 
  vec3 bbr = vec3(x+1, y, z-1);
  vec3 bbl = vec3(x, y, z-1);

  vec3 dist_fbl = st - fbl; 
  vec3 dist_fbr = st - fbr;
  vec3 dist_ftl = st - ftl; 
  vec3 dist_ftr = st - ftr;
  vec3 dist_btr = st - btr; 
  vec3 dist_btl = st - btl; 
  vec3 dist_bbr = st - bbr;
  vec3 dist_bbl = st - bbl;

  vec3 grad_fbl = random_direction(fbl); 
  vec3 grad_fbr = random_direction(fbr);
  vec3 grad_ftl = random_direction(ftl); 
  vec3 grad_ftr = random_direction(ftr);
  vec3 grad_btr = random_direction(btr); 
  vec3 grad_btl = random_direction(btl); 
  vec3 grad_bbr = random_direction(bbr);
  vec3 grad_bbl = random_direction(bbl);

  float dot_fbl = dot(dist_fbl, grad_fbl); 
  float dot_fbr = dot(dist_fbr, grad_fbr);
  float dot_ftl = dot(dist_ftl, grad_ftl); 
  float dot_ftr = dot(dist_ftr, grad_ftr);
  float dot_btr = dot(dist_btr, grad_btr); 
  float dot_btl = dot(dist_btl, grad_btl); 
  float dot_bbr = dot(dist_bbr, grad_bbr); 
  float dot_bbl = dot(dist_bbl, grad_bbl); 

  float wx = fract(st.x);
  float wy = fract(st.y);
  float wz = fract(st.z);

  float ix0 = dot_fbl + improved_smooth_step(wx)*(dot_fbr - dot_fbl);
  float ix1 = dot_ftl + improved_smooth_step(wx)*(dot_ftr - dot_ftl);
  float iy0 = ix0 + improved_smooth_step(wy)*(ix1 - ix0);
  float ix2 = dot_bbl + improved_smooth_step(wx)*(dot_bbr - dot_bbl);
  float ix3 = dot_btl + improved_smooth_step(wx)*(dot_btr - dot_btl);
  float iy1 = ix2 + improved_smooth_step(wy)*(ix3 - ix2);
  float iz0 = iy0 + improved_smooth_step(wz)*(iy1 - iy0);

  return iz0;
  /////////////////////////////////////////////////////////////////////////////
}

