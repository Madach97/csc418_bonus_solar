// Add (hard code) an orbiting (point or directional) light to the scene. Light
// the scene using the Blinn-Phong Lighting Model.
//
// Uniforms:
uniform mat4 view;
uniform mat4 proj;
uniform float animation_seconds;
uniform bool is_earth;
uniform bool is_venus;
uniform bool is_sun;
uniform bool is_mercury;
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
  vec4 light = vec4(0, 0, 1, 0);
  
  mat4 rotate_y =  mat4(
	  cos(M_PI), sin(M_PI), 0, 0,
	  -sin(M_PI), cos(M_PI), 0, 0,
		0,        0,    1,      0,
		0,        0,    0,      1   );
  mat4 model = mat4(
	  1,0,0,0,
	  0,1,0,0,
	  0,0,1,0,
	  0,0,0,1);;
  if(is_mercury){
     light =  vec4(sphere_fs_in, 1);
     float angle = animation_seconds*M_PI/4;
	  mat4 rotate =  mat4(
	  cos(angle), 0, sin(angle),0,
		0,        1,    0,      0,
	  -sin(angle),0, cos(angle),0,
		0,        0,    0,      1);
	  mat4 translate = mat4(
	  1,0,0,0,
	  0,1,0,0,
	  0,0,1,0,
	  0,0,0,1);
	  model = rotate*translate;
  }
  if(is_venus){
     float angle = animation_seconds*M_PI/2;
	  mat4 rotate =  mat4(
	  cos(angle), 0, sin(angle),0,
		0,        1,    0,      0,
	  -sin(angle),0, cos(angle),0,
		0,        0,    0,      1);
	  
	  mat4 translate = mat4(
	  1,0,0,0,
	  0,1,0,0,
	  0,0,1,1,
	  0,0,0,1);
	  model = rotate*translate;
  }


  if(is_earth){
     float angle = -1*animation_seconds*M_PI/4;
	  mat4 rotate =  mat4(
	  cos(angle), 0, sin(angle),0,
		0,        1,    0,      0,
	  -sin(angle),0, cos(angle),0,
		0,        0,    0,      1);
	  mat4 translate = mat4(
	  1,0,0,0,
	  0,1,0,0,
	  0,0,1,0,
	  0,0,0,1);
	  model = translate*rotate*rotate_y;
  }
  
  vec3 l = normalize((model*view*light).xyz);
  vec3 v = normalize((-1*view_pos_fs_in).xyz);
  vec3 n = normalize(normal_fs_in);
  float p = 500;
  vec3 ka = vec3(0, 0, 0);
  vec3 kd = vec3(0, 0, 1);
  if(is_earth){
       kd = vec3(25.0/255.0,22.0/255.0,224.0/255.0);
  }
  else if(is_venus){
  	  kd = vec3(173.0/255.0, 138.0/255.0, 12.0/255.0);
  }
  else if(is_mercury){
  	   kd = vec3(229.0/255.0, 41.0/255.0, 27.0/255.0);
  }
  else if(is_sun){
  	  kd = vec3(224.0/255.0, 180.0/255.0, 22.0/255.0);
  }
  vec3 ks = vec3(1, 1 ,1);
  vec3 rgb = blinn_phong(ka, kd, ks, p, n, v, l);
  color = rgb;
  /////////////////////////////////////////////////////////////////////////////
}
