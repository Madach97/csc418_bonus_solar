// Set the pixel color to an interesting procedural color generated by mixing
// and filtering Perlin noise of different frequencies.
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

// expects: blinn_phong, perlin_noise
void main()
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  vec4 light = vec4(0, 0, 100, 1);
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
  float p = 1000;
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
  float x = sphere_fs_in.x;
  float y = sphere_fs_in.y;
  float z = sphere_fs_in.z;
  color = rgb;
 if(is_sun){
	float noise =  perlin_noise(sphere_fs_in) + 0.5*perlin_noise(2*sphere_fs_in) + 0.25*perlin_noise(4*sphere_fs_in);
	float val = noise;
    if(val > cos(mod(animation_seconds, 10)) + 1.5){
	   	color = vec3(1, 1, 0)*cos(noise);
	}
	else{
	  	color = vec3(1, 0, 0)*sin(noise + 0.2*sin(animation_seconds))*2;
	}
 }

 if(is_earth){
 	 color = rgb;
	 float plain = perlin_noise(sphere_fs_in);
	 float noise = perlin_noise((0.2+sin(animation_seconds))*sphere_fs_in);
	 if(plain > 0.3){
	 	 color = vec3(9/255.0, 140/255.0, 68/255.0)*plain;
		 color * rgb;
	 }
 }
 if(!is_earth && !is_venus && !is_mercury && !is_sun){
 	 color = vec3(1, 1, 1);
 }

}
