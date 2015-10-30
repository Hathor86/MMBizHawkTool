sampler2D implicitInput : register(s0);
float Hue : register(c0);
float Brightness : register(c1);
float Saturation : register(c2);
float Contrast : register(c3);

float3x3 QuaternionToMatrix(float4 quat)
{
    float3 cross = quat.yzx * quat.zxy;
    float3 square= quat.xyz * quat.xyz;
    float3 wimag = quat.w * quat.xyz;

    square = square.xyz + square.yzx;

    float3 diag = 0.5 - square;
    float3 a = (cross + wimag);
    float3 b = (cross - wimag);

    return float3x3(
    2.0 * float3(diag.x, b.z, a.y),
    2.0 * float3(a.z, diag.y, b.x),
    2.0 * float3(b.y, a.x, diag.z));
}

const float3 lumCoeff = float3(0.2125, 0.7154, 0.0721);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 outputColor = tex2D(implicitInput, uv);
    float3 hsv; 
    float3 intensity;           
        float3 root3 = float3(0.57735, 0.57735, 0.57735);
        float half_angle = 0.5 * radians(Hue); // Hue is radians of 0 tp 360 degree
        float4 rot_quat = float4( (root3 * sin(half_angle)), cos(half_angle));
        float3x3 rot_Matrix = QuaternionToMatrix(rot_quat);     
        outputColor.rgb = mul(rot_Matrix, outputColor.rgb);
        outputColor.rgb = (outputColor.rgb - 0.5) *(Contrast + 1.0) + 0.5;  
        outputColor.rgb = outputColor.rgb + Brightness;         
        intensity = float(dot(outputColor.rgb, lumCoeff));
        outputColor.rgb = lerp(intensity, outputColor.rgb, Saturation );            

    return outputColor;
}