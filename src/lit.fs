// Add (hard code) an orbiting (point or directional) light to the scene. Light
// the scene using the Blinn-Phong Lighting Model.
//
// Uniforms:
uniform mat4 view;
uniform mat4 proj;
uniform float animation_seconds;
uniform bool is_moon;
// Inputs:
in vec3 sphere_fs_in;
in vec3 normal_fs_in;
in vec4 pos_fs_in; 
in vec4 view_pos_fs_in; 
// Outputs:
out vec3 color;
// expects: PI, blinn_phong
void main()
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
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
  vec3 n = normalize(normal_fs_in);
  float p = 500;
  vec3 ka = vec3(0, 0, 0);
  vec3 kd = vec3(0, 0, 1);
  if(is_moon){
    kd = vec3(0.5,0.5,0.5);
  }
  vec3 ks = vec3(1, 1 ,1);
  vec3 rgb = blinn_phong(ka, kd, ks, p, n, v, l);
  color = rgb;
  /////////////////////////////////////////////////////////////////////////////
}
