void FallofMap_float(float4 uvab, out float result) 
{
    float x = uvab.x * 2 - 1;
    float y = uvab.y * 2 - 1;
    float value = max(abs(x), abs(y));

    // const float a = 3;
    // const float b = 2.2;
    float a = uvab.z;
    float b = uvab.w;
    result = pow(value, a) / (pow(value, a) + pow(b - b * value, a));
}



