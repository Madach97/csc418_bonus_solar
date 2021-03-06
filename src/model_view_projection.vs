// Determine the perspective projection (do not conduct division) in homogenous
// coordinates. If is_moon is true, then shrink the model by 30%, shift away
// from the origin by 2 units and rotate around the origin at a frequency of 1
// revolution per 4 seconds.
//
// Uniforms:
//                  4x4 view transformation matrix: transforms "world
//                  coordinates" into camera coordinates.
uniform mat4 view;
//                  4x4 perspective projection matrix: transforms
uniform mat4 proj;
//                                number of seconds animation has been running
uniform float animation_seconds;
//                     whether we're rendering the moon or the other object
uniform bool is_earth;
uniform bool is_venus;
uniform bool is_sun;
uniform bool is_mercury;

// Inputs:
//                  3D position of mesh vertex
in vec3 pos_vs_in; 
// Ouputs:
//                   transformed and projected position in homogeneous
//                   coordinates
out vec4 pos_cs_in; 
// expects: PI, model
void main()
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
    vec4 in_vec = vec4(pos_vs_in,1.0);
    if(is_earth){
      mat4 scaling = uniform_scale(0.5);
	  in_vec = scaling*in_vec;
    }
	else if(is_venus){
	  mat4 scaling = uniform_scale(0.45);
	  in_vec = scaling*in_vec;
	}

	else if(is_mercury){
	  mat4 scaling = uniform_scale(0.3);
	  in_vec = scaling*in_vec;
	}
    mat4 m = model(is_sun, is_mercury, is_venus, is_earth, animation_seconds);
    pos_cs_in = proj*view*m*in_vec;
  /////////////////////////////////////////////////////////////////////////////
}
