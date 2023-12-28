shader_type canvas_item;

uniform float distortion_strengh: hint_range(0, 5000) = 1000;
uniform float snap_strengh: hint_range(0, 10) = 1.0;

float rand(vec2 co)
{
    return fract(sin(dot(co.xy ,vec2(12.9898,78.233))) * 43758.5453);
}

float snap (float x, float snap)
{
    return snap * round(x / snap);
}

void vertex() 
{
	float time = snap(TIME, snap_strengh);
	float noise = rand(VERTEX.xy + time) * distortion_strengh;
	VERTEX.xy += noise - (distortion_strengh * 0.5f);
}
