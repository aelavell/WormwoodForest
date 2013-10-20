#ifndef COLOR_CGINC
#define COLOR_CGINC

float3 XYZ_RGB(float3 c) {
	float3 rt = float3(3.2406, -1.5372, -0.4986);
	float3 gt = float3(-0.9689, 1.8758, 0.0415);
	float3 bt = float3(0.0557, -0.2040, 1.0570);

	return float3(dot(c,rt), dot(c,gt), dot(c,bt));
}

float3 RGB_XYZ(float3 c) {
	float3 xt = float3(0.4124, 0.3576, 0.1805);
	float3 yt = float3(0.2126, 0.7152, 0.0722);
	float3 zt = float3(0.0193, 0.1192, 0.9505);

	return float3(dot(c,xt), dot(c, yt), dot(c, zt));
}


float3 XYZ_Yuv(float3 c) {
	float u = 4 * c.x / dot(c, float3(1, 15, 3));
	float v = 9 * c.y / dot(c, float3(1, 15, 3));
	return float3(c.y, u, v);
}

float3 Yuv_XYZ(float3 c) {
	float X = c.x * (9*c.y)/(4*c.z);
	float Z = c.x * (12-3*c.y-20*c.z) / (4*c.z);
	return float3(X, c.x, Z);
}


float3 Yuv_LUV(float3 c) {
	float3 w = XYZ_Yuv(RGB_XYZ(1));
	float yyn = c.x/w.x;
	float L = yyn <= pow(6.0/29.0, 3) ? 
		pow(29.0/3.0,3) * yyn :
		116 * pow(yyn, 1/3.0) - 16;

	float U = 13 * L * (c.y - w.y);
	float V = 13 * L * (c.z - w.z);
	return float3(L,U,V)*0.01;
}

float3 LUV_Yuv(float3 c) {
	c *= 100.0;
	float3 w = XYZ_Yuv(RGB_XYZ(1));
	float u = c.y / (13 * c.x) + w.y;
	float v = c.z / (13 * c.x) + w.z;

	float Y = c.x <= 8.0 ?
		w.x * c.x * pow(3/29.0, 3) :
		w.x * pow((c.x+16)/116, 3);

	return float3(Y,u,v);
}

float3 LUV_HCL(float3 c) {
	float C = sqrt(dot(c.yz, c.yz));
	float H = atan2(c.z, c.y);
	return float3(H,C,c.x);
}

float3 HCL_LUV(float3 c) {
	float u = c.y * cos(c.x);
	float v = c.y * sin(c.x);
	return float3(c.z, u, v);
}

float3 RGB_HSL(float3 c) {
	float R = c.x;
	float G = c.y;
	float B = c.z;

	float M = max(max(R, G), B);
	float m = min(min(R, G), B);

	float C = M-m;
    float L = 0.5 * (M+m);

	float H = 
		R>=G && R>=B ? (G - B)/C + 6:
		G>=R && G>=B ? (B - R)/C + 2 :
		         	   (R - G)/C + 4;

    float S = 0;
    if(C < 0.001) H = 0;
    else {
    	H = H / 6;
    	S = C / (1-abs(2*L-1));
    }
    return float3(H,S,L);
}

float3 HSL_RGB(float3 c) {
	float H = c.x;
	float S = c.y;
	float L = c.z;
	H =H- floor(H);
	float C = (1 - abs(2*L-1)) * S;
	float X = C * (1-abs(fmod(H*6,2) - 1));
	float3 RGB =
		H*6 < 1 ? float3(C,X,0) :
		H*6 < 2 ? float3(X,C,0) :
		H*6 < 3 ? float3(0,C,X) :
		H*6 < 4 ? float3(0,X,C) :
		H*6 < 5 ? float3(X,0,C) :
		          float3(C,0,X);

	float m = L - 0.5 * C;
	return RGB+m;
}

float3 RGB_HSV(float3 c) {
	float R = c.x;
	float G = c.y;
	float B = c.z;

	float M = max(max(R, G), B);
	float m = min(min(R, G), B);

	float C = M-m;
    float V = M;

	float H = 
		R>=G && R>=B ? (G - B)/C + 6:
		G>=R && G>=B ? (B - R)/C + 2 :
		         	   (R - G)/C + 4;

    float S = 0;
    if(C < 0.001) H = 0;
    else {
    	H = H / 6;
    	S = C / V;
    }
    return float3(H,C,V);
}

float3 HSV_RGB(float3 c) {
	float H = c.x;
	float S = c.y;
	float V = c.z;
	H =H- floor(H);
	float C = V * S;
	float X = C * (1-abs(fmod(H*6,2) - 1));
	float3 RGB =
		H*6 < 1 ? float3(C,X,0) :
		H*6 < 2 ? float3(X,C,0) :
		H*6 < 3 ? float3(0,C,X) :
		H*6 < 4 ? float3(0,X,C) :
		H*6 < 5 ? float3(X,0,C) :
		          float3(C,0,X);

	float m = V-C;
	return RGB+m;
}

float maxChroma(float2 hl) {
	float3 m[3] = { 
		float3(3.2406, -1.5372, -0.4986),
		float3(-0.9689, 1.8758,  0.0415),
		float3(0.0557, -0.2040,  1.0570) 
	};

	float h = hl.x;
	float l = hl.y;
	float sh = sin(h);
	float ch = cos(h);
	float s1 = pow(l+16, 3) / 1560896.0;
	float s2 = s1 > 0.008856 ? s1 : l / 903.3;

	float3 tt = float3(0.99915, 1.05122, 1.14460) * s2;
	float3 rbt = float3(0, 0.17266, 0.86330);
	float3 lbt = float3(0.38848, 0, 0.12949);
	float2 bt = float2(sh, ch) * s2;

	float result = 5000;
	for(int i = 0; i < 3; ++i) {
		float3 r = m[i];
		float top = dot(tt,r);
		float bb = float2(
			dot(rbt, r), dot(lbt, r));
		float bot = dot(bb, bt);
		for(float j = 0; j <= 1; ++j) {
			float c = (l * (top-1.05122 * j) / (bot+0.17266 * sh * j));
			if(c > 0.0 && c < result) {
				result = c;
			}
		}
	}
	return result;
}

float3 RGB_Yuv(float3 c) {
	return XYZ_Yuv(RGB_XYZ(c));
}

float3 Yuv_RGB(float3 c) {
	return XYZ_RGB(Yuv_XYZ(c));
}

float3 RGB_LUV(float3 c) {
	return Yuv_LUV(RGB_Yuv(c));
}

float3 LUV_RGB(float3 c) {
	return Yuv_RGB(LUV_Yuv(c));
}

float3 RGB_HCL(float3 c) {
	return LUV_HCL(RGB_LUV(c));
}
float3 HCL_RGB(float3 c) {
	return LUV_RGB(HCL_LUV(c));
}

float3 HueShiftRGB(float3 c, float shift) {
	c = RGB_HCL(c);
	c.x += shift;
	c.y = min(c.y, maxChroma(c.xz));
	return HCL_RGB(c);
}

#endif
