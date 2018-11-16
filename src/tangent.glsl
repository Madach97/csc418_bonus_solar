// Input:
//   N  3D unit normal vector
// Outputs:
//   T  3D unit tangent vector
//   B  3D unit bitangent vector
void tangent(in vec3 N, out vec3 T, out vec3 B)
{
  /////////////////////////////////////////////////////////////////////////////
  // Replace with your code 
  // tangent_plane = 2*N.x*(x - N.x) + 2*N.y*(y - N.y) + 2*N.z*(z - N.z)
  float theta = acos(N.z);
  float phi;
  if(N.x == 0){
     phi = atan(N.y/N.x);
   }
   else{
     phi = M_PI/2;
   }
   //derivative of the sphere with respect to theta and then phi
   vec3 d1 = normalize(vec3(cos(theta)*cos(phi), cos(theta)*sin(phi), -sin(theta)));
   vec3 d2 = normalize(vec3(-sin(theta)*cos(phi), sin(theta)*sin(phi), 0));

   T = cross(N, d1);
   B = cross(N, d2);


  /////////////////////////////////////////////////////////////////////////////
}
