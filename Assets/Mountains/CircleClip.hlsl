void CircleClip_float(float2 uv, out float res)
{
    uv = uv - 0.5;
    clip(0.25 - (pow(uv.x, 2) + pow(uv.y, 2)));
    res = 0;
}