// Set the pixel color using Blinn-Phong shading (e.g., with constant blue and
// gray material color) with a bumpy texture.
// 
// Uniforms:
uniform mat4 view;
uniform mat4 proj;
uniform float animation_seconds;
uniform bool is_moon;
// Inputs:
//                     linearly interpolated from tessellation evaluation shader
//                     output
in vec3 sphere_fs_in;
in vec3 normal_fs_in;
in vec4 pos_fs_in; 
in vec4 view_pos_fs_in; 
// Outputs:
//               rgb color of this pixel
out vec3 color;
// expects: model, blinn_phong, bump_height, bump_position,
// improved_perlin_noise, tangent
void main()
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  vec3 p = bump_position(is_moon, sphere_fs_in);
  vec3 T;
  vec3 B;
  tangent(normal_fs_in, T, B);
  //calculate the new normal
  vec3 n = cross(1000*((p*(sphere_fs_in + (0.0001*T))) - (p*sphere_fs_in)), 1000*((p*(sphere_fs_in + (0.0001*B))) - (p*sphere_fs_in))); 
  n = normalize(n);
  vec4 light = vec4(100, 1, 100, 1);
  mat4 rotate =  mat4(
  cos(animation_seconds*M_PI/2), 0, sin(animation_seconds*M_PI/2),0,
    0,        1,    0,      0,
  -sin(animation_seconds*M_PI/2),0, cos(animation_seconds*M_PI/2),0,
    0,        0,    0,      1);
  mat4 translate = mat4(
  1,0,0,0,
  0,1,0,0,
  0,0,1,0,
  0,0,4,1);
  mat4 model = rotate*translate;
  vec3 l = normalize((view*model*light).xyz);
  vec3 v = normalize((-1*view_pos_fs_in).xyz);
  float shiny = 500;
  vec3 ka = vec3(0, 0, 0);
  vec3 kd = vec3(0, 0, 1);
  if(is_moon){
    kd = vec3(0.5,0.5,0.5);
  }
  vec3 ks = vec3(1, 1 ,1);
  vec3 rgb = blinn_phong(ka, kd, ks, shiny, n, v, l);

  color = rgb;
  /////////////////////////////////////////////////////////////////////////////
}
