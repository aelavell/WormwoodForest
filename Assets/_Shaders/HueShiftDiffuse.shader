Shader "Color/Diffuse Hue Shift" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _HueShift ("Hue Shift", range(-3.14159265359,3.14159265359)) = 0
      _HSL_Shift ("HSL Shift", range(-1,1)) = 0
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      #pragma target 3.0
      #include "Color.cginc"

      struct Input {
          float2 uv_MainTex;
      };
      sampler2D _MainTex;
      float _HueShift;

      void surf (Input IN, inout SurfaceOutput o) {
          float4 col = tex2D (_MainTex, IN.uv_MainTex);
		  float3 c = col.xyz;
          c = HueShiftRGB(c, _HueShift*2);

          o.Albedo = c;
		  o.Alpha = col.w;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }