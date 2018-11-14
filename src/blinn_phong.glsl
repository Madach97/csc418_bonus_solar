// Compute Blinn-Phong Shading given a material specification, a point on a
// surface and a light direction. Assume the light is white and has a low
// ambient intensity.
//
// Inputs:
//   ka  rgb ambient color
//   kd  rgb diffuse color
//   ks  rgb specular color
//   p  specular exponent (shininess)
//   n  unit surface normal direction
//   v  unit view direction
//   l  unit light direction
// Returns rgb color
vec3 blinn_phong(
  vec3 ka,
  vec3 kd,
  vec3 ks,
  float p,
  vec3 n,
  vec3 v,
  vec3 l)
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  vec3 I = vec3(1, 1, 1);
  float n_dot_l = max(dot(n, l), 0.0);
  vec3 h = normalize(v + l);
  float n_dot_h = pow(max(dot(n,h), 0.0), p);
  vec3 diffuse = kd * (n_dot_l*I);
  vec3 specular = ks * (n_dot_h*I);
  vec3 rgb = ka * I + specular + diffuse;
  return rgb;
  /////////////////////////////////////////////////////////////////////////////
}


