## README
Please run it with ```data/test-06.json```.

The github source is at https://github.com/Madach97/csc418_bonus_solar 

### Radiosity Implementation

* Originally, I set out to implement radiosity by extending theray tracer from assignment 3. While interesting, this turned out to be more ambitious than expected and hence I resorted to the solar system delineated below. Regardless, I did quite a bit of research on radiosity and based on it, the implementation route I would have taken would be:
  Suppose I were to incorporate radiosity in a scene with a couple spheres, one red and one green then:
    * First, split the spheres into smaller patches. I would do this by creating a mesh.
    *  Iterate through each patch of the red (or the green) sphere and compute the view factor of it with respect to each of the green (or red if green sphere was chosen first) patches. The formula is as in the image below (also in the github repo as form_factor.jpg).
    ![](form_factor.jpg)
    * The visibility on the above equation is 1 for the surfaces that the ray tracer hots first and 0 for shadows (and obviously surfaces it does not touch)
    * calculate the usual blinn phong shading of the objects.
    * Bounce off the light ray form the sphere to the other sphere and set the proportion of the light reaching the other sphere based on the view factors.
    * Repeat it for 3 bounces
    * Calculate the colour based on the factor form values computed.
    * Finally use catmull clark to smooth the meshes to a sphere.

    I refered to the following sources extensively
        *  https://www.cl.cam.ac.uk/teaching/1718/AdvGraph/02_Global_Illumination.pdf
        * http://groups.csail.mit.edu/graphics/classes/6.837/F01/Lecture20/lecture20_4up.pdf
        http://web.mit.edu/4.455/software/lightscape/Docs/Lightscape%20User%20Guide.pdf


### Implementing the solar system

I implemented everything under the "basic" section and under the "Extended" section is a list of features I would have liked to implement.

#### Basic
* Add Mercury, Venus, Sun and Earth to orbit
    * Add more spheres
    * Set a colour for them
    * Update their rotation to match their relative rotation speeds
* Update their blinn phong shading 
    * Make sure to have different diffuse colours based on the planet
* Add perlin noise to the sun to create a fireball effect


#### Extended
* Update the light to originate at the sun
    * This was one I spent a considerable time on, but couldn't yet perfect. I wanted to try to make sure that the face of any given planet that is facing the sun should be lit up and anything else should be in (partial) darkness.
    * to implement this, I place a point on the radius of the sun and set it to    the direction of the planet by rotation and translating the point light.
* Add  bump maps to the sun 
    * Add a bump map to the sun's surface using perlin noise value as the height. 
* Add bump map to Earth
    * similar thing, but for the earth.
* Create the shades for a Christmas decoration
    * Change the theme of the video every, say, 20 secs so that it becomes Christmas laterns at that point in time. To do this:
        * Check the animation seconds and mod the result by 40. Once the animation_seconds mod 40 becomes 20, we know that we can switch scenes.
        * When the value is > 20 we are in the Christmas scene, so use the blinn phong shading to change the colour of the planets to the colour of a latern by manipulating the kd value.
        * When it is <= 20, then it is in the solar mode and so they will be coloured as they are now.

##### Notes: My perlin noise implementation from the assignment was a bit buggy so I used the code from the another source https://gist.github.com/patriciogonzalezvivo/670c22f3966e662d2f83 . It is also mentioned in the source code. I was inspired by the ways of interpolating perlin noise from https://www.redblobgames.com/maps/terrain-from-noise/#ridged . The source code mentions this. 

